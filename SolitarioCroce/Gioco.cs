using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolitarioCroce
{
    public enum Mazzetto
    {
        BASE,
        CROCE
    }
    public class Gioco
    {
        private Mazzo _mazzo;
        private List<Carta> _pozzo;
        private Carta[][] _basi;
        private Carta[][] _croci;

        public Carta[][] Basi
        {
            get => _basi;
            set
            {
            }
        }

        public Carta[][] Croci
        {
            get => _croci;
            set
            {
            }
        }

        public Mazzo Mazzo
        {
            get => _mazzo;
            set
            {
            }
        }

        public List<Carta> Pozzo
        {
            get => _pozzo;
            set
            {
            }
        }

        private void VerificaOrdineBase(Carta carta, int numeroBase)
        {
            throw new System.NotImplementedException();
        }

        private void VerificaOrdineCroce(Carta carta, int numeroCroce)
        {
            throw new System.NotImplementedException();
        }

        public void SpostaCarte(Carta carta, Mazzetto mazzetto, int numeroMaz)
        {
            throw new System.NotImplementedException();
        }

        public void Vittoria()
        {
            throw new System.NotImplementedException();
        }
    }


}