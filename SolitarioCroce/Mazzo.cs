using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolitarioCroce
{
    public class Mazzo
    {
        private Carta[] _carte;

        public Mazzo()
        {
            _carte = new Carta[40];
            InizializzaMazzo();
           
        }

        private void InizializzaMazzo()
        {
            int i = 0;
            for (int seme = 1; seme <= 4; seme++)
            {
                for (int valore = 1; valore <= 10; valore++)
                {
                    _carte[i] = new Carta(valore, (Seme)seme);
                    i++;
                }
            }
        }
        public void MescolaMazzo()
        {
            Random random = new Random();
            bool[,]presenti = new bool[4,10];
            int i = 0;
            while(i!=39)
            {
                Carta carta = new Carta(random.Next(1, 11), (Seme)random.Next(1, 5));
                if (presenti[(int)carta.SemeCarta - 1, (int)carta.ValoreCarta - 1]) continue;
                presenti[(int)carta.SemeCarta - 1, (int)carta.ValoreCarta - 1] = true;
                i++;
                _carte[i] = carta;
            }
        }


        public Carta EstraiCarta
        {
            get
            {
                Random random = new Random();
                Carta carta=_carte[random.Next(0,40)];
                return carta;
            }
        }

        public override string ToString()
        {
            string res = "";
            for(int i=0; i< _carte.Length; i++) 
            {
                res += _carte[i].ToString();
                res += "\n";
            }
            return res;
        }
    }
}
