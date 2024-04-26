using SolitarioCroce;
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
        private int _indexExtraction;
        public Mazzo()
        {
            _carte = new Carta[40];
            InizializzaMazzo();
            _indexExtraction = 0;
            
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
            if (_indexExtraction > 0) throw new ArgumentException("Non puoi mescolare il mazzo se hai già estratto una carta");
            Random random = new Random();
            int pos;
            Carta cartaDaScambiare;
            for (int i = 0; i < _carte.Length; i++)
            {
                pos = random.Next(_carte.Length);
                cartaDaScambiare = _carte[pos];
                _carte[pos] = _carte[i];
                _carte[i] = cartaDaScambiare;
            }
        }

        public Carta VisualizzaPrimaCarta()
        {
            if (_indexExtraction == _carte.Length) throw new ArgumentOutOfRangeException("Non puoi estrarre altre carte");

            return _carte[_indexExtraction];
        }
        public Carta EstraiPrimaCarta
        {
            get
            {
                if (_indexExtraction == _carte.Length) throw new ArgumentOutOfRangeException("Non puoi estrarre altre carte");
                Carta carta = _carte[_indexExtraction];
                _carte[_indexExtraction] = null;
                _indexExtraction++;

                return carta;
            }
        }

    }
}
