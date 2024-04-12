using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolitarioCroce
{

    public class Gioco
    {
        private Mazzo _mazzo;
        private List<Carta> _pozzo;
        private Mazzetto[] _basi;
        private Mazzetto[] _croci;


        public Gioco( Mazzo mazzo)
        {
            if (mazzo == null) throw new ArgumentNullException("il mazzo non può essere nulla");
            _mazzo = mazzo;
            _pozzo = new List<Carta>();

        }
        private void InizializzaBasiECroci()
        {

        }
        public Mazzetto[] Basi
        {
            get => _basi;
        }

        public Mazzetto[] Croci
        {
            get => _croci;
        }

        public Mazzo Mazzo
        {
            get => _mazzo;
        }

        public List<Carta> Pozzo
        {
            get => _pozzo;
        }
        public void SpostaCarte(Carta carta)
        {
            throw new System.NotImplementedException();
        }

        public bool Vittoria()
        {
            bool vittoria = true;
            for(int j=0;j<_basi.GetLength(0);j++)
            {
                for (int i = 0; i < _basi.GetLength(1); i++)
                {
                    if (_basi[j, i] == null)
                    {
                        vittoria = false;
                        break;
                    }
                }
            }
            return vittoria;
            
        }

        private void PescaCarta()
        {
            _pozzo.Add(_mazzo.EstraiPrimaCarta);
        }
    }


}