using System;
using System.Drawing;


namespace JACKBLACK
{
    internal class Pachet
    {
        private Carte[] carti;
        Random rand = new Random();
        public Pachet()
        {
            carti = new Carte[52];
            Image Imagine = Properties.Resources._10_Inima_Neagra;
            string[] culori = { "Inima_Rosie", "Inima_Neagra", "Romb", "Trefla" };
            string[] valori = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Valet", "Dama", "Rege", "As" };
            int index = 0;
            for (int i = 0; i < culori.Length; i++)
            {

                for (int j = 0; j < valori.Length; j++)
                {
                    switch (culori[i])
                    {
                        case "Inima_Rosie":
                            {
                                switch (valori[j])
                                {
                                    case "2":
                                        {
                                            Imagine = Properties.Resources._2_Inima_Rosie;
                                            break;
                                        }
                                    case "3":
                                        {
                                            Imagine = Properties.Resources._3_Inima_Rosie;
                                            break;
                                        }
                                    case "4":
                                        {
                                            Imagine = Properties.Resources._4_Inima_Rosie;
                                            break;
                                        }
                                    case "5":
                                        {
                                            Imagine = Properties.Resources._5_Inima_Rosie;
                                            break;
                                        }
                                    case "6":
                                        {
                                            Imagine = Properties.Resources._6_Inima_Rosie;
                                            break;
                                        }
                                    case "7":
                                        {
                                            Imagine = Properties.Resources._7_Inima_Rosie;
                                            break;
                                        }
                                    case "8":
                                        {
                                            Imagine = Properties.Resources._8_Inima_Rosie;
                                            break;
                                        }
                                    case "9":
                                        {
                                            Imagine = Properties.Resources._9_Inima_Rosie;
                                            break;
                                        }
                                    case "10":
                                        {
                                            Imagine = Properties.Resources._10_Inima_Rosie;
                                            break;
                                        }
                                    case "Valet":
                                        {
                                            Imagine = Properties.Resources._Valet_Inima_Rosie;
                                            break;
                                        }
                                    case "Dama":
                                        {
                                            Imagine = Properties.Resources._Dama_Inima_Rosie;
                                            break;
                                        }
                                    case "Rege":
                                        {
                                            Imagine = Properties.Resources._Rege_Inima_Rosie;
                                            break;
                                        }
                                    case "As":
                                        {
                                            Imagine = Properties.Resources._As_Inima_Rosie;
                                            break;
                                        }

                                }
                            }
                            break;
                        case "Inima_Neagra":
                            {
                                switch (valori[j])
                                {
                                    case "2":
                                        {
                                            Imagine = Properties.Resources._2_Inima_Neagra;
                                            break;
                                        }
                                    case "3":
                                        {
                                            Imagine = Properties.Resources._3_Inima_Neagra;
                                            break;
                                        }
                                    case "4":
                                        {
                                            Imagine = Properties.Resources._4_Inima_Neagra;
                                            break;
                                        }
                                    case "5":
                                        {
                                            Imagine = Properties.Resources._5_Inima_Neagra;
                                            break;
                                        }
                                    case "6":
                                        {
                                            Imagine = Properties.Resources._6_Inima_Neagra;
                                            break;
                                        }
                                    case "7":
                                        {
                                            Imagine = Properties.Resources._7_Inima_Neagra;
                                            break;
                                        }
                                    case "8":
                                        {
                                            Imagine = Properties.Resources._8_Inima_Neagra;
                                            break;
                                        }
                                    case "9":
                                        {
                                            Imagine = Properties.Resources._9_Inima_Neagra;
                                            break;
                                        }
                                    case "10":
                                        {
                                            Imagine = Properties.Resources._10_Inima_Neagra;
                                            break;
                                        }
                                    case "Valet":
                                        {
                                            Imagine = Properties.Resources._Valet_Inima_Neagra;
                                            break;
                                        }
                                    case "Dama":
                                        {
                                            Imagine = Properties.Resources._Dama_Inima_Neagra;
                                            break;
                                        }
                                    case "Rege":
                                        {
                                            Imagine = Properties.Resources._Rege_Inima_Neagra;
                                            break;
                                        }
                                    case "As":
                                        {
                                            Imagine = Properties.Resources._As_Inima_Neagra;
                                            break;
                                        }

                                }
                            }
                            break;
                        case "Romb":
                            {
                                switch (valori[j])
                                {
                                    case "2":
                                        {
                                            Imagine = Properties.Resources._2_Romb;
                                            break;
                                        }
                                    case "3":
                                        {
                                            Imagine = Properties.Resources._3_Romb;
                                            break;
                                        }
                                    case "4":
                                        {
                                            Imagine = Properties.Resources._4_Romb;
                                            break;
                                        }
                                    case "5":
                                        {
                                            Imagine = Properties.Resources._5_Romb;
                                            break;
                                        }
                                    case "6":
                                        {
                                            Imagine = Properties.Resources._6_Romb;
                                            break;
                                        }
                                    case "7":
                                        {
                                            Imagine = Properties.Resources._7_Romb;
                                            break;
                                        }
                                    case "8":
                                        {
                                            Imagine = Properties.Resources._8_Romb;
                                            break;
                                        }
                                    case "9":
                                        {
                                            Imagine = Properties.Resources._9_Romb;
                                            break;
                                        }
                                    case "10":
                                        {
                                            Imagine = Properties.Resources._10_Romb;
                                            break;
                                        }
                                    case "Valet":
                                        {
                                            Imagine = Properties.Resources._Valet_Romb;
                                            break;
                                        }
                                    case "Dama":
                                        {
                                            Imagine = Properties.Resources._Dama_Romb;
                                            break;
                                        }
                                    case "Rege":
                                        {
                                            Imagine = Properties.Resources._Rege_Romb;
                                            break;
                                        }
                                    case "As":
                                        {
                                            Imagine = Properties.Resources._As_Romb;
                                            break;
                                        }
                                }
                            }
                            break;
                        case "Trefla":
                            {
                                switch (valori[j])
                                {
                                    case "2":
                                        {
                                            Imagine = Properties.Resources._2_Trefla;
                                            break;
                                        }
                                    case "3":
                                        {
                                            Imagine = Properties.Resources._3_Trefla;
                                            break;
                                        }
                                    case "4":
                                        {
                                            Imagine = Properties.Resources._4_Trefla;
                                            break;
                                        }
                                    case "5":
                                        {
                                            Imagine = Properties.Resources._5_Trefla;
                                            break;
                                        }
                                    case "6":
                                        {
                                            Imagine = Properties.Resources._6_Trefla;
                                            break;
                                        }
                                    case "7":
                                        {
                                            Imagine = Properties.Resources._7_Trefla;
                                            break;
                                        }
                                    case "8":
                                        {
                                            Imagine = Properties.Resources._8_Trefla;
                                            break;
                                        }
                                    case "9":
                                        {
                                            Imagine = Properties.Resources._9_Trefla;
                                            break;
                                        }
                                    case "10":
                                        {
                                            Imagine = Properties.Resources._10_Trefla;
                                            break;
                                        }
                                    case "Valet":
                                        {
                                            Imagine = Properties.Resources._Valet_Trefla;
                                            break;
                                        }
                                    case "Dama":
                                        {
                                            Imagine = Properties.Resources._Dama_Trefla;
                                            break;
                                        }
                                    case "Rege":
                                        {
                                            Imagine = Properties.Resources._Rege_Trefla;
                                            break;
                                        }
                                    case "As":
                                        {
                                            Imagine = Properties.Resources._As_Trefla;
                                            break;
                                        }
                                }
                                break;
                            }
                    }
                    carti[index] = new Carte(culori[i], valori[j],0, Imagine);
                    index++;
                }
            }
        }
        public void Amesteca()
        {
            
            for (int i = 0; i < carti.Length; i++)
            {
                int j = rand.Next(carti.Length);
                Carte temp = carti[i];
                carti[i] = carti[j];
                carti[j] = temp;
            }
        }
        public Carte TrageCarte()
        {
            if(carti.Length == 0)
            {
                return null;
            }
            Carte carte = carti[0];
            Carte[] temp = new Carte[carti.Length - 1];
            for (int i = 1; i < carti.Length;i++)
            {
                temp[i - 1] = carti[i];
            }
            carti = temp;
            return carte;
        }
    }
}
