using System;
using System.Windows.Forms;
namespace JACKBLACK
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form_Server fs= new Form_Server();
            fs.Show();
            this.Hide();
            butonJoin.Enabled = false;
            buton_Start.Enabled = false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void butonJoin_Click(object sender, EventArgs e)
        {
            Form_Conectare f_conectare = new Form_Conectare();
            f_conectare.Show();
            this.Hide();
        }
    }
}
