using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace JACKBLACK
{
    public partial class Form_Conectare : Form
    {
        public Socket socket;//socket-ul folosit pentru comunicarea cu serverul(public pt trimiterea spre form2
        public Form_Conectare()
        {
            InitializeComponent();
        }

        private void butonConectare_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(ConectareLaServer);//porneste un fir nou pentru conectare pentru a nu bloca UI
            t.IsBackground = true;
            t.Start();
        }
        void ConectareLaServer() //conectare la server;foloseste invoke pt acutualizarea UI-ului din alt fir+deschiderea form-ului joc
        {
            ///try catch pentru a prinde erorile de conectare(ip gresit,server oprit,conexiune refuzata)
            try
            {
                IPAddress ip = IPAddress.Parse(textBoxIP.Text);//preia IP-ul introdus de utilizator
                IPEndPoint ep = new IPEndPoint(ip, 5000);//seteaza endpoint-ul cu portul 5000
                socket = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);//creaza socket-ul client;stream=conexiune stabila

                socket.Connect(ep);//conectare efectiva la server;nu exista server;exceptie

                // Așteptăm ID-ul (Ex: "ID:1" sau "SERVER_PLIN")
                byte[] buffer = new byte[256];//buffer pentru primirea datelor de la server(id/ server plin)
                int bytes = socket.Receive(buffer);//primim datele de la server

                if (bytes == 0) throw new Exception("Serverul a închis conexiunea.");//daca serverul inchide conexiunea

                string mesaj = Encoding.ASCII.GetString(buffer, 0, bytes).Trim();//convertim datele primite in string

                if (mesaj == "SERVER_PLIN")//serverul are 2 jucatori
                {//Folosim invoke pentru a actualiza UI-ul din firul principal(suntem pe fi secundar)
                    this.Invoke((MethodInvoker)delegate {
                        //MESAJ SERVER PLIN PENTRU UTILIZATOR
                        labelConectare.Text = "Serverul este plin!";
                        labelConectare.ForeColor = Color.Red;
                        butonConectare.Enabled = true;
                    });
                    socket.Close();//inchidere conexiune
                    return;
                }

                if (mesaj.StartsWith("ID:"))//primim un ID valid(serverul a acceptat clientul)
                {
                    int jucatorID = int.Parse(mesaj.Substring(3));//extragem ID-ul din mesaj
                    //din nou accesam ui din fir secundar=>invoke
                    this.Invoke((MethodInvoker)delegate
                    {
                        labelConectare.Text = "Conectat!";//feedback vizual pentru utilizator
                        labelConectare.ForeColor = Color.Green;

                        // Pasăm socket-ul și ID-ul către Form2
                        f2 = new Form2(socket, jucatorID);
                        f2.Show();
                        this.Hide();
                    });
                }
            }
            catch (Exception ex)
            {
                this.Invoke((MethodInvoker)delegate {
                    labelConectare.Text = "Eroare: " + ex.Message;
                    labelConectare.ForeColor = Color.Red;
                    butonConectare.Enabled = true;
                });
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
