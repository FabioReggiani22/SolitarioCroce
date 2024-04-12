using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolitarioCroce
{
    public enum TipoMazzetto
    {
        BASE,
        CROCE
    }
    public class Mazzetto
    {
        private TipoMazzetto _tipoMazzetto;
        private Carta[,] _carte;

        public Mazzetto(TipoMazzetto tipoMazzetto)
        {
            throw new System.NotImplementedException();
        }

        public Carta[,] Carte
        {
            get => default;
            set
            {
            }
        }

        public void AggiungiCarta(Carta carta)
        {
            throw new System.NotImplementedException();
        }

        private void VerificaOrdineBasi(Carta carta)
        {
            throw new System.NotImplementedException();
        }

        private void VerificaOrdineCroci(Carta carta)
        {
            throw new System.NotImplementedException();
        }
    }
}