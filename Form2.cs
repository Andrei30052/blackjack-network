using System;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Net;
using System.Threading;
namespace JACKBLACK
{
    public partial class Form2 : Form
    {
        int jucatorID = 0;//identificator jucator primit de la server
        int randCurent = 1;//cine e la rand
        bool rundaTerminata = false;//daca runda s-a terminat-blocheaza butoanele
        Socket socket;//socket de comunicare cu serverul
        Thread listenThread;//thread de legatura cu serverul-nu extista=>blocaj
        bool dealerArata = false;//daca dealerul si-a aratat cartea ascunsa
        bool asteapta = false;//daca jocul e oprit asteapta pana la restart
        public Form2(Socket s,int id)
        {
            InitializeComponent();
            socket = s;//atribui socket-ul creat in form conectare
            jucatorID = id;//atribui id-ul primit in form conectare
            label_rezultat.Text = "Sunteți jucătorul " + jucatorID;//afisez id-ul jucatorului
        }
        string stare_buffer = "";//buffer pentru starea primita de la server
        void AscultaServer()//asculta mesajele de la server; ruleaza intr-un thread separat
        {
            try
            {
                while (true)// bucla infinita pentru ascultare
                {
                    byte[] buf = new byte[2048]; //buffer mai mare pentru a primi mesaje mai mari
                    int bytes = socket.Receive(buf);//citeste pachetel de biti venite prin retea

                    if (bytes == 0) break; // serverul a închis conexiunea

                    string mesaj = Encoding.ASCII.GetString(buf, 0, bytes);
                    if(mesaj.Contains("Server oprit"))
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            MessageBox.Show("Serverul a fost oprit!", "Conexiune pierdută", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Application.Exit();
                        });
                        return;
                    }
                    //stare_buffer += Encoding.ASCII.GetString(buf, 0, bytes);//concatenez datele primite in buffer-ul de stare
                    stare_buffer += mesaj;
                    while (stare_buffer.Contains("\nEND\n"))//mesaj complet primit
                    {
                        int idx = stare_buffer.IndexOf("\nEND\n");
                        // extragem mesajul complet
                        string mesajComplet = stare_buffer.Substring(0, idx);
                        stare_buffer = stare_buffer.Substring(idx + 5); // 5 = "\nEND\n"

                        this.Invoke((MethodInvoker)delegate//muta executia pe firul principal al interfete grafice
                        {                                  //pt a purea desena cartile fara erori de acces
                            ProceseazaPachet(mesajComplet);//trimite mesaj catre interfata garfica pentru procesare
                        });// doar firul UI poate modifica controalele grafice(sa deseneze)
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Conexiune pierdută: " + ex.Message);
            }
        }

        PictureBox[] pbJucator1 = new PictureBox[12];
        PictureBox[] pbJucator2= new PictureBox[12];
        PictureBox[] pbDealer = new PictureBox[12];
        Image spate=Properties.Resources.SpateCarte;
        private void Form2_Load(object sender, EventArgs e)
        {
            //Porneste Ascultarea
            listenThread = new Thread(AscultaServer);
            listenThread.IsBackground = true;
            listenThread.Start();
            //Creare dinamica PictureBox-uri pentru carti
            for (int j = 0; j <pbJucator1.Length; j++)
            {
                int coloana_j = j % 5;
                int rand_j = j / 5;

                pbJucator1[j] = new PictureBox
                {
                    Width = 65,
                    Height = 95,
                    Left=100+j*50,
                    Top = 390,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Visible = false
                };
                this.Controls.Add(pbJucator1[j]);
                pbJucator2[j] = new PictureBox
                {
                    Width = 65,
                    Height = 95,
                    Left=700+j*50,
                    Top = 390,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Visible = false
                };
                this.Controls.Add(pbJucator2[j]);
                pbDealer[j] = new PictureBox
                {
                    Width = 65,
                    Height = 95,
                    Left = 200 + j * 40,
                    Top = 100,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                   
                    Visible = false
                };
                this.Controls.Add(pbDealer[j]);
            }
        }
        Image GetImagine(string numeCarte)
        {
            Image img = Properties.Resources.ResourceManager.GetObject(numeCarte) as Image;
            return img;
        }

        void ProceseazaStare(string stare)//construiește tot: masa,jucatori,carti,etc
        {
            //buton_resetare.Enabled = false;
            //RESET VIZUAL
            for (int i = 0; i < pbJucator1.Length; i++)
            {
                pbJucator1[i].Visible = false;
                pbJucator2[i].Visible = false;
                pbDealer[i].Visible = false;
                pbJucator1[i].Image = null;
                pbJucator2[i].Image = null;
                pbDealer[i].Image = null;
            }
            label_rezultat.Text="Sunteți jucătorul "+jucatorID;
            label_rezultat.ForeColor= Color.Black;
            rundaTerminata = false;
            string[] linii = stare.Split('\n');//imparte starea in randuri separate
            dealerArata = false;
            int idxJ1 = 0;
            int idxJ2 = 0;
            int idxD = 0;
            foreach (string linieBruta in linii)// analizeaza fiecare dintre liniile primite pentru a gasi informatii speciale
            {
                string linie = linieBruta.Trim();
                if(linie=="J1_BLACKJACK" && jucatorID==1)//daca jucatorul 1 are blackjack si e jucatorul 1
                {
                    label_rezultat.Text = "BLACKJACK!";
                    label_rezultat.ForeColor = Color.Gold;
                }
                else if(linie=="J2_BLACKJACK" && jucatorID==2)
                {
                    label_rezultat.Text = "BLACKJACK! AI CASTIGAT!";
                    label_rezultat.ForeColor = Color.Gold;
                }
                if (linie == "DEALER_ARATA")
                {
                    dealerArata = true;
                }
            }
            foreach (string linieBruta in linii)
            {
                string linie = linieBruta.Trim();
            if (linie.StartsWith("Jucator1:"))//daca contine cartile jucatorului 1=>extragem numele primite
                {
                    string[] carti = linie.Substring(9).Split(',');//extragem cartile jucatorului 1

                    foreach (string c in carti)//parcurgem cartile jucatorului 1
                    {
                        if(idxJ1>=pbJucator1.Length) break;
                        PictureBox target=pbJucator1[idxJ1];//selecteaza locul unde se va pune cartea
                        target.Image = (c == "ASCUNS") ? spate : GetImagine(c);//daca e ascunsa pune spatele, altfel imaginea corespunzatoare
                        target.Visible = true;
                        target.BringToFront();
                        idxJ1++;
                    }
                }
                else if (linie.StartsWith("Jucator2:"))//parcurgem cartile jucatorului 2
                {
                    string[] carti = linie.Substring(9).Split(',');//extragem cartile jucatorului 2

                    foreach (string c in carti)//parcurgem cartile jucatorului 2
                    {
                        if(idxJ2>=pbJucator2.Length) break;//safety check
                        PictureBox target;//selecteaza locul unde se va pune cartea
                       target = pbJucator2[idxJ2];//
                        target.Image = (c == "ASCUNS") ? spate : GetImagine(c);
                        target.Visible = true;
                        target.BringToFront();
                        idxJ2++;
                    }
                }
               
                else if (linie.StartsWith("Dealer:"))
                {
                    string[] carti = linie.Substring(7).Split(',');

                    for (int i = 0; i < carti.Length && idxD<pbDealer.Length; i++)//parcurgem cartile dealerului
                    {
                        pbDealer[idxD].Visible = true;//face vizibila cartea
                        pbDealer[idxD].BringToFront();//aduce cartea in fata altor controale
                        if (i == 1 && !dealerArata)//daca e a doua carte si dealerul nu a aratat-o inca
                            pbDealer[idxD].Image = spate;
                            
                        else
                            pbDealer[idxD].Image = GetImagine(carti[i]);

                        idxD++;
                    }
                }
                else if(linie.StartsWith("RAND:"))//cine e la rand
                {
                    string randValoare=linie.Substring(5).Trim();//extragem valoarea dupa "RAND:"
                    
                    randCurent= int.Parse(randValoare);
                  
                }
                else if(linie.StartsWith("ScorJucator1:") && jucatorID==1)
                {
                    label_scor.Text = "SCOR: " + linie.Substring(13);
                }
                else if (linie.StartsWith("ScorJucator2:") && jucatorID==2)
                {
                    label_scor.Text = "SCOR: " + linie.Substring(13);
                }
                if (linie == "J1_CASTIGA" && jucatorID == 1)//daca jucatorul 1 castiga si e jucatorul 1
                {
                    if (label_rezultat.Text != "BLACKJACK!")//daca a fost blackjack nu suprascrie mesajul
                    {
                        label_rezultat.Text = "AI CASTIGAT!"; 

                    }//afisare mesaj castig
                    rundaTerminata = true;//seteaza runda ca terminata
                }
                else if (linie == "J1_PIERDE" && jucatorID == 1)
                {
                    label_rezultat.Text = "AI PIERDUT!";
                    rundaTerminata = true;
                }
                else if (linie == "J1_REMIZA" && jucatorID == 1)
                {
                    label_rezultat.Text = "REMIZA!";
                    rundaTerminata = true;
                }
                if (linie == "J2_CASTIGA" && jucatorID == 2)
                {
                    if (label_rezultat.Text != "BLACKJACK!")
                    {
                        label_rezultat.Text = "AI CASTIGAT!";
                    }
                    rundaTerminata = true;
                }
                
                else if (linie == "J2_PIERDE" && jucatorID == 2)
                {
                    label_rezultat.Text = "AI PIERDUT!";
                    rundaTerminata = true;
                }
                else if (linie == "J2_REMIZA" && jucatorID == 2)
                {
                    label_rezultat.Text = "REMIZA!";
                    rundaTerminata = true;
                }

            }
            if(randCurent==0)
            {
                rundaTerminata = true;
            }
            bool esteRandulMeu = (jucatorID == randCurent) && !rundaTerminata;
            buton_hit.Enabled = false;
            buton_stand.Enabled = false;
            buton_hit2.Enabled = false;
            buton_stand2.Enabled = false;

            if (jucatorID == 1)
            {
                buton_hit.Enabled = esteRandulMeu;
                buton_stand.Enabled = esteRandulMeu;
                buton_hit2.Visible = false;
                buton_stand2.Visible = false;
            }
            else if(jucatorID==2)
            {
                buton_hit2.Enabled = esteRandulMeu;
                buton_stand2.Enabled = esteRandulMeu;
                buton_hit.Visible = false;
                buton_stand.Visible = false;
            }
        }
        void Trimite(string mesaj)
        {
            byte[] data=Encoding.ASCII.GetBytes(mesaj);
            socket.Send(data);
        }
        void ProceseazaPachet(string mesaj)//proceseaza mesajul complet primit de la server 
        {
            string[] linii=mesaj.Split('\n');//impartim mesajul in linii
            foreach(string linieBruta in linii)
            {
                string linie=linieBruta.Trim();
                if (linie.Length == 0) continue;
                if(linie.StartsWith("STOP:"))
                {
                    string mesajStop=linie.Substring(5).Trim();
                    buton_hit.Enabled = false;
                    buton_stand.Enabled = false;
                    buton_hit2.Enabled = false;
                    buton_stand2.Enabled = false;
                    if (!asteapta)
                    {
                        asteapta = true;
                        MessageBox.Show(mesajStop, "Joc Oprit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    return;
                }
                if (linie.StartsWith("ID:"))//identificator jucator
                
                { string valoare=linie.Substring(3).Trim();
                   if(int.TryParse(valoare, out int ID))
                    {
                        jucatorID = ID;
                    }
                        if (jucatorID == 1)
                        {
                            buton_hit.Visible = true;
                            buton_stand.Visible = true;
                            buton_hit2.Visible = false;//Ascundem butoanele celuilalt jucator
                            buton_stand2.Visible = false;//
                                                         // buton_hit.Enabled = !stand;
                        }
                        else if (jucatorID == 2)
                        {
                            buton_hit2.Visible = true;
                            buton_stand2.Visible = true;
                            buton_hit.Visible = false;
                            buton_stand.Visible = false;
                            // buton_hit2.Enabled = !stand;
                        }
                    
                    label_rezultat.Text = "Sunteți jucătorul " + jucatorID;
                }
            }
            if (mesaj.Contains("Jucator1:") || mesaj.Contains("Jucator2:")|| mesaj.Contains("Dealer:"))
            {
                asteapta = false;//daca primim o stare noua inseamna ca jocul a fost reluat
                ProceseazaStare(mesaj);
            }
}
        private void button1_Click(object sender, EventArgs e)
        {

            Trimite("HIT:"+jucatorID);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Trimite("STAND:"+jucatorID);
        }
       
        
        private void buton_JocNou_Click(object sender, EventArgs e)
        {
            dealerArata = false;
            Trimite("RESET");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                // cerem starea curenta
                Trimite("EXIT" + jucatorID);
                if (socket != null)
                {
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                }
            }
            catch { }
            Application.Exit();
  
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Trimite("EXIT:" + jucatorID);
                if(socket!=null)
                    socket.Close();

            }
            catch(Exception)
            {
                //ignora
            }
            Application.Exit();
        }
    }
}

