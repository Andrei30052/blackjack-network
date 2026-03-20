using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JACKBLACK
{
    internal abstract class Participant
    {
        protected Carte[] mana;
        protected int nr_carti;
        public Participant()
        {
            mana = new Carte[12];
            nr_carti = 0;
        }
        public virtual void AdaugaCarte(Carte c)
        {
            if(nr_carti < mana.Length)
            {
                mana[nr_carti] = c;
                nr_carti++;
            }
        }
        public void resetareMana()
        {
            nr_carti = 0;
            for(int i=0;i<mana.Length;i++)
            {
                mana[i] = null;
            }
        }
        public Carte getCarte(int index)
        {    if(index < nr_carti)
                     return mana[index];
             else
                     return null;
        }
        public int getNrCarti()
        {
            return nr_carti;
        }
        public abstract int CalculeazaScor();
        public virtual bool Depasit()
        {
            return CalculeazaScor() > 21;

        }
        public virtual void Joaca(Pachet pachet)
        {
            
        }
    }
}
