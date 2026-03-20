using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace JACKBLACK
{
    public partial class Form_Server : Form //creare joc+primire comenzi+validare comenzi+decizii+trimitere stare
    {
        Socket client1 = null;//socket jucator
        Socket client2 = null;//socket jucator
        bool stareModificata = false;//daca se schimba starea jocului(HIT/STAND/RESET JOC)
        int jucatorCurent = 1;//cine are voie sa joace acum/al cui e randul
        bool jucator1_Stand = false;//daca jucatorul 1 a dat stand
        bool jucator2_Stand = false;//daca jucatorul 2 a dat stand
        Thread serverThread;//firul de executie pentru server
        Socket listener;//socket de ascultare conexiuni noi
        bool jocTerminat = false;//daca runda curenta s-a terminat devine true
        public Form_Server()
        {
            InitializeComponent();
            serverThread = new Thread(PornesteServer);//creare thread pentru server
            serverThread.IsBackground = true;//setare thread ca background(daca se inchide aplicatia se inchide si firul)
            serverThread.Start();//pornire thread-imediat dupa deschiderea form-ului
        }
        private void Form_Server_Load(object sender, EventArgs e)
        {

        }
            void ProcesareComanda(string cmd, Joc joc)//primeste comanda(HIT,STAND,RESET) si o proceseaza
            {
            if(client1==null || client2==null)//daca nu sunt 2 jucatori conectati, nu proceseaza comanda
            {
                if(cmd!="EXIT")
                {
                    Log("Comanda ignorata- nu sunt 2 jucatori conectati.\n");
                    return;
                }
            }    
                if (cmd == "RESET")//reset al jocului
                {
                    joc.jucator1.resetareMana();
                    joc.jucator2.resetareMana();
                    joc.dealer.resetareMana();
                    joc.StartJoc();//reinițializare joc;amestec pachet și împărțire cărți
                    jocTerminat = false;
                    jucator1_Stand = false;
                    jucator2_Stand = false;
                    if(joc.Jucator1Blackjack())
                    {
                        jucator1_Stand = true;
                    }
                    if(joc.Jucator2Blackjack())
                    {
                        jucator2_Stand = true;
                    }
                    if(jucator1_Stand && jucator2_Stand)
                    {
                        joc.DealerJoaca();
                        jocTerminat = true;
                        jucatorCurent = 0;
                    }
                    else if(jucator1_Stand)
                    {
                        jucatorCurent = 2;
                    }
                    else
                    {
                        jucatorCurent = 1;
                    }
                    stareModificata = true;//trimitere stare noua
                    return;//oprire procesare
                }

                // -------- HIT --------
                if (cmd.StartsWith("HIT:"))//tragere carte
                {
                    int id = int.Parse(cmd.Split(':')[1]);//extrage id jucator
                    if (id != jucatorCurent) return;//daca nu e randul lui, ignoram comanda

                    if (id == 1 && !jucator1_Stand)//daca jucatorul 1 nu a dat stand
                    {
                        joc.Jucator1TrageCarte();//trage carte
                        int scorJ1 = joc.CalculeazaScorJucator1();//calculeaza scor
                        if (scorJ1>21)//daca a depasit 21
                        {
                            jucator1_Stand = true; // bust = terminat
                            jucatorCurent = 2;
                        }
                        else if(scorJ1 == 21)
                        {
                            jucator1_Stand = true; // 21 = terminat
                            jucatorCurent = 2;
                        }
                        
                    }
                    else if (id == 2 && !jucator2_Stand)//daca jucatorul 2 nu a dat stand
                    {
                        joc.Jucator2TrageCarte();//trage carte
                        int scorJ2 = joc.CalculeazaScorJucator2();//calculeaza scor
                        if (scorJ2>21)//daca a depasit 21
                        {
                            jucator2_Stand = true; // bust = terminat
                        }
                        else if(scorJ2 == 21)
                        {
                            jucator2_Stand = true; // 21 = terminat
                        }
                    }
                    // dacă amândoi au terminat -> dealer
                    if (jucator1_Stand && jucator2_Stand && !jocTerminat)
                    {
                        // dealer joacă doar dacă există măcar un jucător ne-depășit
                        if (!joc.Jucator1Depasit() || !joc.Jucator2Depasit())
                            joc.DealerJoaca();

                        jocTerminat = true;
                        jucatorCurent = 0;
                    }

                    stareModificata = true;//trimitere stare noua
                    return;
                }

                // -------- STAND --------
                if (cmd.StartsWith("STAND:"))//daca jucatorulnu mai trage carti
                {
                    int id = int.Parse(cmd.Split(':')[1]);//extrage id jucator
                    if (id != jucatorCurent) return;//daca nu e randul lui, ignoram comanda

                    if (id == 1)//jucator 1 da stand
                    {
                        jucator1_Stand = true;
                        jucatorCurent = 2;
                    }
                    else if (id == 2)//jucator 2 da stand
                    {
                        jucator2_Stand = true;
                    }

                    // dacă celălalt e deja stand/bust -> dealer
                    if (jucator1_Stand && jucator2_Stand && !jocTerminat)
                    {
                        if (!joc.Jucator1Depasit() || !joc.Jucator2Depasit())//dealer joaca doar daca exista macar un jucator ne-depasit
                            joc.DealerJoaca();

                        jocTerminat = true;
                        jucatorCurent = 0;
                    }

                    stareModificata = true;//trimitere stare noua
                    return;
                }
            } 
            void PornesteServer() //Porneste serverul TCP si gestioneaza jocul
            {
                try                   //cauta orice eroare de socket//deconectare client/date invalide
                {
                //SETUP SOCKET SERVER
                IPAddress ip = IPAddress.Any;//asculta pe toate interfetele
                IPEndPoint ep = new IPEndPoint(ip, 5000);//port 5000
                //START ASCULTARE
                listener = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);//creeaza un socket tcp stream=conex. continua
                listener.Bind(ep);// leaga socket ul de Ip si portul def mai sus                                  
                listener.Listen(100);//maxim 100 de clienti pot sta la rand
                listener.Blocking = false;//setare non-blocant(sa nu inghete aplicatia)
                Log("\nServer pornit. Asteptare clienti...\n");
                Joc joc = new Joc();//creare joc
                    //BUFFERE PENTRU COMUNICATII CU CLIENTII
                    byte[] buffer1 = new byte[1024];
                    byte[] buffer2 = new byte[1024];
                 //--------||-------------
                    while (true) //loop principal server-nu se opreste niciodata
                    {
                        if(this.IsDisposed )//daca form-ul e inchis, opreste serverul
                        {
                            return;
                        }
                    //ACCEPTARE CONEXIUNI NOI
                    if (client1 == null || client2 == null || listener.Poll(0, SelectMode.SelectRead))// verifica daca lipsest cineva sau daca sunt conexiuni noi
                    {                                                                                   // poll verifica daca exista conexiuni noi in asteptare fara a bloca executia
                        try
                        {
                            Socket temp = listener.Accept();//accepta conexiune
                            if (client1 == null)
                            {
                                client1 = temp; //seteaza client 1
                                client1.Blocking = true;//setare blocant pentru comunicatii(sa nu interfereze cu acceptarea conexiunilor noi)
                                client1.Send(Encoding.ASCII.GetBytes("ID:1\n"));//trimite ID jucator
                                Log("Client1 conectat.\n");
                            }
                            else if (client2 == null)
                            {
                                client2 = temp;//seteaza client 2
                                client2.Blocking = true;//setare blocant pentru comunicatii
                                client2.Send(Encoding.ASCII.GetBytes("ID:2\n"));//trimite ID jucator
                                Log("Client2 conectat. Joc inceput.\n");
                                joc.StartJoc();//amestecare si impartire carti
                                jucator1_Stand = false;//ambii pot actiona
                                jucator2_Stand = false;//ambii pot actiona
                                if (joc.Jucator1Blackjack())//verificare blackjack initial
                                {
                                    jucator1_Stand = true;//daca are blackjack, nu mai poate juca
                                    Log("Jucatorul 1 are BLACKJACK!\n");
                                }
                                if (joc.Jucator2Blackjack())//verificare blackjack initial
                                {
                                    jucator2_Stand = true;  //daca are blackjack, nu mai poate juca
                                    Log("Jucatorul 2 are BLACKJACK!\n");
                                }
                                if (joc.Jucator1Blackjack() && joc.Jucator2Blackjack())//ambii blackjack=>delaer joaca
                                {
                                    joc.DealerJoaca();//dealer joaca
                                    jocTerminat = true;//runda s-a terminat
                                    jucatorCurent = 0;//nimeni nu mai joaca
                                }
                                else if (jucator1_Stand)//daca jucatorul 1 ramane stand
                                {
                                    jucatorCurent = 2;
                                }
                                else//altfel incepe jucatorul 1
                                {
                                    jucatorCurent = 1;
                                   // jocTerminat = false;
                                }
                                stareModificata = true;//trimite stare initiala
                            }
                            else //respinge clientii in plus
                            {
                                temp.Send(Encoding.ASCII.GetBytes("SERVER_PLIN\n"));
                                temp.Close();
                                Log("Client suplimentar respins.\n");
                            }
                        }
                        catch (SocketException ex)
                        {
                            if (ex.NativeErrorCode != 10035)
                            {
                                Log("Eroare neasteptata:" + ex.Message + "\n");
                            }
                        }
                    }


                    // --- MODIFICARE 3: VERIFICĂRI DE NULL LA CLIENT 1 ---
                    if (client1 != null && client1.Available > 0)//primire comenzi jucator 1
                    {
                        int bytes = client1.Receive(buffer1);//primeste date
                        if (bytes > 0)//daca a primit ceva
                        {
                            string cmd = Encoding.ASCII.GetString(buffer1, 0, bytes).Trim();
                            if (cmd.StartsWith("EXIT"))
                            {
                                Log("Jucatorul 1 a iesit.\n");
                                client1.Close();
                                client1 = null;
                            }
                            else
                            {
                                Log("Comanda J1: " + cmd + "\n");
                                ProcesareComanda(cmd, joc);
                                stareModificata = true;
                            }
                        }
                    }

                    // --- MODIFICARE 4: VERIFICĂRI DE NULL LA CLIENT 2 ---
                    if (client2 != null && client2.Available > 0)
                    {
                        int bytes = client2.Receive(buffer2);
                        if (bytes > 0)
                        {
                            string cmd = Encoding.ASCII.GetString(buffer2, 0, bytes).Trim();
                            if (cmd.StartsWith("EXIT"))
                            {
                                Log("Jucatorul 2 a iesit.\n");
                                client2.Close();
                                client2 = null;
                                jocTerminat = true;
                            }
                            else
                            {
                                Log("Comanda J2: " + cmd + "\n");
                                ProcesareComanda(cmd, joc);
                                stareModificata = true;
                            }
                        }
                    }
                    //TRIMITERE STARE MODIFICATA
                    if (stareModificata)
                        {
                        
                        if (client1 != null && client1.Connected)
                            client1.Send(Encoding.ASCII.GetBytes(ConstruiesteStare(joc, 1) + "\nEND\n"));

                        if (client2 != null && client2.Connected)
                            client2.Send(Encoding.ASCII.GetBytes(ConstruiesteStare(joc, 2) + "\nEND\n"));

                        stareModificata = false;
                        Log("Am trimis stare noua.\n");
                    }

                        Thread.Sleep(30);//pauza pentru a nu suprasolicita CPU
                    }
                }
                catch (Exception ex)
                {
                    Log("Eroare server: " + ex.Message + "\n");
                }
            }
            void Log(string text)
            {
                if (InvokeRequired)
                {
                    Invoke(new Action<string>(Log), text);
                    return;
                }
                textBoxLog.AppendText(text + Environment.NewLine);
            }
            string ConstruiesteStare(Joc joc, int nrJucator)//transforma jocul in text transmis prin TCP;nr jucator=cine primeste mesajul
            {
            if(client1==null|| client2==null)//daca nu sunt 2 jucatori conectati, nu trimite stare
            {
                return "STOP:Asteptam jucatori...";
            }
                string stare = "";//string ce va contine starea jocului(mesaj complet)=tot ce vede clientul
                ///CARTILE JUCATORULUI 1
                stare += "Jucator1:";//eticheta jucator 1
                for (int i = 0; i < joc.jucator1.getNrCarti(); i++)//parcurge cartile jucatorului 1
                {
                    if (nrJucator == 2 && !jucator1_Stand)//nu arata cartile sale celuilalt pana nu a dat stand
                    {
                        stare += "ASCUNS";
                    }
                    else
                    {
                        Carte c = joc.jucator1.getCarte(i);//cartea de pe pozitia i
                        stare += '_' + c.getValoare + "_" + c.getCuloare;//construieste cartea
                    }
                    if (i < joc.jucator1.getNrCarti() - 1)  //      SEPARAREA
                    {                                       //      CARTILOR
                        stare += ",";                       //      DIN MANA
                    }                                       //      CU VIRGULA
                }
                // CARTILE JUCATORULUI 2
                stare += "\nJucator2:";//linie noua
                for (int i = 0; i < joc.jucator2.getNrCarti(); i++)
                {
                    if (nrJucator == 1 && !jucator2_Stand)//idem jucator 1
                    {
                        stare += "ASCUNS";
                    }
                    else
                    {
                        Carte c = joc.jucator2.getCarte(i);
                        stare += '_' + c.getValoare + "_" + c.getCuloare;
                    }
                    if (i < joc.jucator2.getNrCarti() - 1)
                    {
                        stare += ",";
                    }
                }
                stare += "\nDealer:";
                for (int i = 0; i < joc.dealer.getNrCarti(); i++)               //NU se acunde cartea aici, e doar ef vizual
                {
                    Carte c = joc.dealer.getCarte(i);
                    stare += '_' + c.getValoare + "_" + c.getCuloare;
                    if (i < joc.dealer.getNrCarti() - 1)
                    {
                        stare += ",";
                    }
                }
                stare += "\nScorJucator1:" + joc.CalculeazaScorJucator1();  //  Trimitere
                stare += "\nScorJucator2:" + joc.CalculeazaScorJucator2();  //  Scoruri
                if (joc.Jucator1Blackjack())
                {
                    stare += "\nJ1_BLACKJACK";
                }
                if (joc.Jucator2Blackjack())
                {
                    stare += "\nJ2_BLACKJACK";
                }
                if (jucator1_Stand && jucator2_Stand)//daca ambii au dat stand=>dealerul joaca
                {
                    stare += "\nDEALER_ARATA";
                }
            //Caz pentru ambii jucatori depasiti
                if (joc.Jucator1Depasit() && joc.Jucator2Depasit())
                {
                    stare += "\nJ1_PIERDE";
                    stare += "\nJ2_PIERDE";
                    stare += "\nRAND:0";
                    return stare;
                }
                //Caz pentru runda TERMINATA 
                if (jocTerminat)    //devine true daca ambii jucatori au dat STAND=> dealerul joaca
                {
                    int scorDealer = joc.CalculeazaScorDealer();
                    
                    if (joc.Jucator1Depasit())
                    {
                        stare += "\nJ1_PIERDE";
                    }
                    else
                    {
                        int scorJ1 = joc.CalculeazaScorJucator1();
                        if (joc.DealerDepasit())
                        {
                            stare += "\nJ1_CASTIGA";
                        }
                        else if (scorJ1 > scorDealer)
                            stare += "\nJ1_CASTIGA";
                        else if (scorJ1 < scorDealer)
                            stare += "\nJ1_PIERDE";
                        else
                            stare += "\nJ1_REMIZA";
                    }
                    if (joc.Jucator2Depasit())
                    {
                        stare += "\nJ2_PIERDE";
                    }
                    else
                    {
                        int scorJ2 = joc.CalculeazaScorJucator2();
                        if (joc.DealerDepasit())
                        {
                            stare += "\nJ2_CASTIGA";
                        }
                        else if (scorJ2 > scorDealer)
                            stare += "\nJ2_CASTIGA";
                        else if (scorJ2 < scorDealer)
                            stare += "\nJ2_PIERDE";
                        else
                            stare += "\nJ2_REMIZA";
                    }
                    if (joc.DealerDepasit())
                    {
                        stare += "\nDEALER_DEPASIT";
                    }
                    else if (joc.DealerBlackjack())
                    {
                        stare += "\nDEALER_BLACKJACK";
                        stare += "\nDEALER_ARATA";
                    }
                }
                if (!jocTerminat)
                    stare += "\nRAND:" + jucatorCurent;
                else
                    stare += "\nRAND:0";
                return stare;
            }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] mesaj = Encoding.ASCII.GetBytes("Server oprit.\n");
            if (client1 != null)
            {
                try
                {
                    if (client1.Connected)
                    {
                        client1.Send(mesaj);
                    }
                    client1.Close();
                }
                catch { }
            }
                if (client2 != null)
                {
                    try
                    {
                        if (client2.Connected)
                        {
                            client2.Send(mesaj);
                        }
                        client2.Close();
                    }
                    catch { }

                }
                Log("Server oprit de administrator.\n");
                Application.Exit();
        }
        private void Form_Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                string msg="Server oprit.\n";
                byte[] mesaj = Encoding.ASCII.GetBytes(msg);
                if(client1!=null && client1.Connected)
                {
                    client1.Send(mesaj);
                    client1.Shutdown(SocketShutdown.Both);
                    client1.Close();
                }
                if (client2 != null && client2.Connected)
                {
                    client2.Send(mesaj);
                    client2.Shutdown(SocketShutdown.Both);
                    client2.Close();
                }
                if (listener != null)
                {
                    listener.Close();
                }
            }
            catch { }
            Application.Exit();

        }
    }
    }
