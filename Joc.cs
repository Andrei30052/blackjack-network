using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace JACKBLACK
{
    internal class Joc
    {
        public Participant jucator1 { get; private set; }
        public Participant jucator2 { get; private set; }
        public Participant dealer { get; private set; }
        public Pachet pachet { get; private set; }
        public Joc()
        {
            jucator1 = new Jucator();
            jucator2 = new Jucator();
            dealer = new Dealer();
            
        }
        public void StartJoc()
        {
            pachet = new Pachet();
            pachet.Amesteca();
            jucator1.resetareMana();
            jucator2.resetareMana();
            dealer.resetareMana();
            jucator1.AdaugaCarte(pachet.TrageCarte());
            jucator2.AdaugaCarte(pachet.TrageCarte());
            dealer.AdaugaCarte(pachet.TrageCarte());
            jucator1.AdaugaCarte(pachet.TrageCarte());
            jucator2.AdaugaCarte(pachet.TrageCarte());
            dealer.AdaugaCarte(pachet.TrageCarte());
        }
        public void Jucator1TrageCarte()
        {
            Carte c = pachet.TrageCarte();
            if (c != null)
            {
                jucator1.AdaugaCarte(c);
            }
        }
        public void Jucator2TrageCarte()
        {
            Carte c=pachet.TrageCarte();
            if(c!=null)
            {
                jucator2.AdaugaCarte(c);
            }
        }
        public void DealerJoaca()
        {
            dealer.Joaca(pachet);
        }
        public int CalculeazaScorJucator1()
        {
            return jucator1.CalculeazaScor();
        }
        public int CalculeazaScorJucator2()
        {
            return jucator2.CalculeazaScor();
        }
        public int CalculeazaScorDealer()
        {
            return dealer.CalculeazaScor();
        }
        public bool Jucator1Depasit()
        {
            return jucator1.Depasit();
        }
        public bool Jucator2Depasit()
        {
            return jucator2.Depasit();
        }
        public bool Jucator1Blackjack()
        {
            return jucator1.CalculeazaScor() == 21 && jucator1.getNrCarti() == 2;
        }
        public bool Jucator2Blackjack()
        {
            return jucator2.CalculeazaScor() == 21 && jucator2.getNrCarti() == 2;
        }
        public bool DealerDepasit()
        {
            return dealer.CalculeazaScor() > 21;
        }
        public bool DealerBlackjack()
        {
            return dealer.CalculeazaScor() == 21 && dealer.getNrCarti() == 2;
        }
    }
}
