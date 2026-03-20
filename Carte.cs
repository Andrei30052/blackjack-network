using System;
using System.Drawing;
using System.Windows.Forms;
namespace JACKBLACK
{
    internal class Carte
    {
        private string Culoare;
        private String Valoare;
        private Image Imagine;
        private int Punctaj;
        public string getCuloare
        {
            get { return Culoare; }
            set { Culoare = value; }
        }
        public string getValoare
        {
            get { return Valoare; }
            set { Valoare = value; }
        }
        public Image getImagine
        {
            get { return Imagine; }
            set { Imagine = value; }
        }
        public int getPunctaj
        {
            get { return Punctaj; }
            set { Punctaj = value; }
        }
        public Carte(string culoare, string valoare, int punctaj,Image Imagine)
        {
            Culoare = culoare;
            Valoare = valoare;
            Punctaj = Valoare_Punctaj(valoare);
            this.Imagine = Imagine;
        }
        private int Valoare_Punctaj(string valoare)
        {
            switch (valoare)
            {
                case "Valet":
                    return 10;
                case "Dama":
                    return 10;
                case "Rege":
                    return 10;
                case "As":
                    return 11;
                default:
                    return int.Parse(valoare);
            }
        }
    }
}
