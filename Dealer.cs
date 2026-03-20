using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JACKBLACK
{
    internal class Dealer:Participant
    {
        public override int CalculeazaScor()
        {
            int scor = 0;
            //int nr_asi = 0;
            for (int i = 0; i < nr_carti; i++)
            {
                scor += mana[i].getPunctaj;
                if (scor > 21 && mana[i].getValoare == "As")
                {
                    scor -= 10;
                }   
            }
            return scor;
        }
        public bool TrageCarte()
        {
            return CalculeazaScor() < 17;
        }
        public override void Joaca(Pachet pachet)
        {
            while (TrageCarte())
            {
                Carte c=pachet.TrageCarte();
                if(c==null)
                    break;
                AdaugaCarte(c);
            }
        }

    }
}
