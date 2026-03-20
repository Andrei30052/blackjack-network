using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JACKBLACK
{
    internal class Jucator:Participant
    {
        public override int CalculeazaScor()
        {
            int scor = 0;
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
        
    }
}
