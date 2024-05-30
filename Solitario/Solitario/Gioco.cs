using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolitarioCroce
{
    public enum StatoPartita
    {
        VITTORIA,
        SCONFITTA,
        PARTITA_IN_CORSO
    }

    public class Gioco
    {
        private Mazzo _mazzo;
        private List<Carta> _pozzo;
        private Mazzetto[] _basi;
        private Mazzetto[] _croci;
        private StatoPartita _statoPartita;


        public Gioco( Mazzo mazzo)
        {
            if (mazzo == null) throw new ArgumentNullException("il mazzo non può essere nulla");
            _mazzo = mazzo;
            _pozzo = new List<Carta>();
            _statoPartita=StatoPartita.PARTITA_IN_CORSO;
            InizializzaBasiECroci();

        }
        private void InizializzaBasiECroci()
        {
            _basi = new Mazzetto[4];
            for(int i=0; i<_basi.Length; i++)
            {
                _basi[i] = new Mazzetto(TipoMazzetto.BASE,$"B{i+1}");
            }
            _croci = new Mazzetto[5];
            for (int i = 0; i < _croci.Length; i++)
            {
                _croci[i] = new Mazzetto(TipoMazzetto.CROCE, $"C{i + 1}");
                _croci[i].AggiungiCarta(_mazzo.EstraiPrimaCarta);
            }

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
        public void SpostaCarte(Carta carta, string idMazzetto)
        {
            if (StatoDellaPartita == StatoPartita.PARTITA_IN_CORSO)
            {
                Mazzetto? mazzetto = null;
                try
                {
                    if (carta == null) throw new ArgumentException("La carta non è valida");
                    TrovaMazzetto(idMazzetto, out mazzetto);
                    if (mazzetto == null) throw new ArgumentException("L'id non corrisponde a nessun mazzetto");

                    CercaERimuoviCarta(carta,mazzetto); 
                    mazzetto.AggiungiCarta(carta);
                    ControlloVincita();
                }
                catch (Exception ex) { throw ex; }
            }
            else throw new ArgumentException("La partita si è già conclusa, non puoi più continuare a giocare");

        }
        private void CercaERimuoviCarta(Carta carta, Mazzetto mazzetto)
        {
            bool trovato = false;
            for (int i = 0; i < _basi.Length; i++)
            {
                if (_basi[i].VisualizzaPrimaCarta == carta) 
                {
                    if ((mazzetto.Tipo == TipoMazzetto.CROCE && !mazzetto.VerificaOrdineCroci(carta)) || (mazzetto.Tipo == TipoMazzetto.BASE && !mazzetto.VerificaOrdineBasi(carta))) throw new ArgumentException("La carta non può essere inserita");
                    _basi[i].TogliPrimaCarta();trovato = true;  break; 
                }
            }
            if (!trovato)
            {
                for (int i = 0; i < _croci.Length; i++)
                {
                   
                    if (_croci[i].VisualizzaPrimaCarta == carta) 
                    {
                        if ((mazzetto.Tipo == TipoMazzetto.CROCE && !mazzetto.VerificaOrdineCroci(carta)) || (mazzetto.Tipo == TipoMazzetto.BASE && !mazzetto.VerificaOrdineBasi(carta))) throw new ArgumentException("La carta non può essere inserita");
                        _croci[i].TogliPrimaCarta();trovato = true; break;
                    }
                }
                if(!trovato)
                {
                    if (_pozzo[_pozzo.Count-1] == carta) 
                    {
                        if ((mazzetto.Tipo == TipoMazzetto.CROCE && !mazzetto.VerificaOrdineCroci(carta)) || (mazzetto.Tipo == TipoMazzetto.BASE && !mazzetto.VerificaOrdineBasi(carta))) throw new ArgumentException("La carta non può essere inserita");
                        _pozzo.Remove(carta);trovato = true;
                    }
                }
            }
        }
        private bool TrovaMazzetto(string id, out Mazzetto? mazzetto)
        {
            bool trovato = false;
            mazzetto = null;
            for (int i = 0; i < _basi.Length; i++)
            {
                if (_basi[i].Id==id) { trovato = true; mazzetto = _basi[i]; break; }
            }
            if(!trovato)
            {
                for (int i = 0; i < _croci.Length; i++)
                {
                    if (_croci[i].Id == id) { trovato = true; mazzetto = _croci[i]; break; }
                }
            }
            return trovato;
        }
        public StatoPartita StatoDellaPartita
        {
            get
            {
                return _statoPartita;
            }
        }
        private void ControlloVincita()
        {
            bool vittoria=true;
            foreach(Mazzetto mazzetto in _basi)
            {
                if (mazzetto.Carte[9] !=new Carta(10,Seme.Denara) || mazzetto.Carte[9] != new Carta(10, Seme.Bastoni) || mazzetto.Carte[9] != new Carta(10, Seme.Coppe) || mazzetto.Carte[9] != new Carta(10, Seme.Spade))
                {
                    vittoria=false; break;
                }
            }
            if(vittoria)_statoPartita=StatoPartita.VITTORIA;
        }
        public void Resa()
        {
            _statoPartita = StatoPartita.SCONFITTA;
        }

        public void PescaCarta()
        {
            if (_mazzo.Lunghezza == 0) throw new ArgumentOutOfRangeException("Il mazzo è vuoto");
            _pozzo.Add(_mazzo.EstraiPrimaCarta);
        }
    }


}