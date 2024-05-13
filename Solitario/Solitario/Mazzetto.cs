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
        private Carta?[] _carte;
        private int _indice;
        private string _id;

        public Mazzetto(TipoMazzetto tipoMazzetto, string id)
        {
            if (String.IsNullOrEmpty(id)) throw new ArgumentNullException("L'id non può essere vuoto");
            _carte = new Carta[10];
            _indice = 0;
            Tipo=tipoMazzetto;
            _id = id;
        }

        public Carta[] Carte
        {
            get => _carte;
        }
        public TipoMazzetto Tipo
        {
            get => _tipoMazzetto;
            private set
            {
                if (!Enum.IsDefined<TipoMazzetto>(value)) throw new ArgumentException("Il tipo del mazzetto non è accettabile");
                _tipoMazzetto = value;
            }
        }
        public int Indice
        {
            get => _indice;
        }
        public string Id
        {
            get => _id;
        }
        public Carta? VisualizzaPrimaCarta
        {
            get
            {
                if (_indice == 0) { return null; }
                return _carte[_indice-1];
            }
        }

        public void AggiungiCarta(Carta carta)
        {
            if (carta == null) throw new ArgumentNullException("La carta non può essere nulla");
            if (_indice == 10) throw new ArgumentException("Il mazzetto è pieno");
            try
            {
                bool verifica;
                if (Tipo == TipoMazzetto.BASE) verifica=VerificaOrdineBasi(carta);
                else verifica=VerificaOrdineCroci(carta);
                if(verifica) 
                {
                    _carte[_indice] = carta;
                    _indice++;
                }
                else
                {
                    throw new ArgumentException("La carta non può essere inserita");
                }

            }
            catch(Exception ex) { throw ex; }


        }
        public void TogliPrimaCarta()
        {
            if (_indice == 0) throw new ArgumentException ("Non ci sono carte nel mazzetto");
            _carte[_indice-1] = null;
            _indice--;
        }

        public bool VerificaOrdineBasi(Carta carta)
        {
            if (carta == null) return false;
            bool errore = false;
            if (_indice == 0 && carta.ValoreCarta != Valore.Asso) errore = true;
            else
            {
                if (_indice != 0 && ((int)carta.ValoreCarta - 1 != (int)_carte[_indice-1].ValoreCarta || carta.SemeCarta != _carte[_indice-1].SemeCarta)) errore = true;
            }
            if (errore) { return false; }
            else return true;
        }

        public bool VerificaOrdineCroci(Carta carta)
        {
            if(_indice!=0 && ((int)carta.ValoreCarta + 1 != (int)_carte[_indice-1].ValoreCarta || carta.SemeCarta == _carte[_indice-1].SemeCarta))return false;
            return true;
        }
        public override bool Equals(object? obj)
        {
            if(obj == null) return false;
            Mazzetto mazzetto = obj as Mazzetto;
            if(mazzetto.Id==Id) return true;
            return false;

        }
    }
}