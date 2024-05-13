using SolitarioCroce;
using SolitarioWPF;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Solitario_A_Croce_WPF
{
    /// <summary>
    /// Logica di interazione per Finestra_Gioco.xaml
    /// </summary>
    public partial class Finestra_Gioco : Window
    {
        Gioco _giocoSolitario;

        Carta _cartaSelezionata;
        private bool _primoBottoneSelezionato = false;
        private Button _primoBottone;
        public bool vittoria;
        private Image _immagineAnimazione;


        public Finestra_Gioco()
        {
            InitializeComponent();

            //mescolo il mazzo e inizializzo il gioco.
            Mazzo mazzo = new Mazzo();
            mazzo.MescolaMazzo();
            _giocoSolitario = new Gioco(mazzo);
            AggiornaImmagini();
        }

        private void btnMazzo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_giocoSolitario.Mazzo.Lunghezza == 1) btnMazzo.Visibility = Visibility.Collapsed;
                if (_giocoSolitario.Mazzo.Lunghezza == 2) rettangoloMazzo.Visibility = Visibility.Collapsed;
                _giocoSolitario.PescaCarta();

                Carta carta;
                carta = _giocoSolitario.Pozzo.Last();


                Img_DaMazzo_APozzo.Visibility = Visibility.Visible;

                Img_DaMazzo_APozzo.Source = new BitmapImage(new Uri(carta.NomeFile, UriKind.Relative));

                //animazione
                Storyboard animazione = (Storyboard)FindResource("Storyboard_DAMazzo_APozzo");
                animazione.Completed += (o, s) =>
                {
                    Img_DaMazzo_APozzo.Visibility = Visibility.Collapsed;
                    AggiornaImmagini();
                };
                animazione.Begin();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void AggiornaImmagini()
        {
            if (_giocoSolitario.Basi[0].VisualizzaPrimaCarta != null)
            {
                Img_btnBase1.Visibility = Visibility.Visible;
                Img_btnBase1.Source = new BitmapImage(new Uri(_giocoSolitario.Basi[0].VisualizzaPrimaCarta.NomeFile, UriKind.Relative));
            }
            else
            {
                Img_btnBase1.Visibility = Visibility.Collapsed;
            }
            if (_giocoSolitario.Basi[1].VisualizzaPrimaCarta != null)
            {
                Img_btnBase2.Visibility = Visibility.Visible;
                Img_btnBase2.Source = new BitmapImage(new Uri(_giocoSolitario.Basi[1].VisualizzaPrimaCarta.NomeFile, UriKind.Relative));
            }
            else
            {
                Img_btnBase2.Visibility = Visibility.Collapsed;
            }
            if (_giocoSolitario.Basi[2].VisualizzaPrimaCarta != null)
            {
                Img_btnBase3.Visibility = Visibility.Visible;
                Img_btnBase3.Source = new BitmapImage(new Uri(_giocoSolitario.Basi[2].VisualizzaPrimaCarta.NomeFile, UriKind.Relative));
            }
            else
            {
                Img_btnBase3.Visibility = Visibility.Collapsed;
            }
            if (_giocoSolitario.Basi[3].VisualizzaPrimaCarta != null)
            {
                Img_btnBase4.Visibility = Visibility.Visible;
                Img_btnBase4.Source = new BitmapImage(new Uri(_giocoSolitario.Basi[3].VisualizzaPrimaCarta.NomeFile, UriKind.Relative));
            }
            else
            {
                Img_btnBase4.Visibility = Visibility.Collapsed;
            }
            //croci
            if (_giocoSolitario.Croci[0].VisualizzaPrimaCarta != null)
            {

                Img_btnMazzetto1.Visibility = Visibility.Visible;
                Img_btnMazzetto1.Source = new BitmapImage(new Uri(_giocoSolitario.Croci[0].VisualizzaPrimaCarta.NomeFile, UriKind.Relative));
            }
            else
            {
                Img_btnMazzetto1.Visibility = Visibility.Collapsed;
            }
            if (_giocoSolitario.Croci[1].VisualizzaPrimaCarta != null)
            {
                Img_btnMazzetto2.Visibility = Visibility.Visible;
                Img_btnMazzetto2.Source = new BitmapImage(new Uri(_giocoSolitario.Croci[1].VisualizzaPrimaCarta.NomeFile, UriKind.Relative));
            }
            else
            {
                Img_btnMazzetto2.Visibility = Visibility.Collapsed;
            }
            if (_giocoSolitario.Croci[2].VisualizzaPrimaCarta != null)
            {
                Img_btnMazzetto3.Visibility = Visibility.Visible;
                Img_btnMazzetto3.Source = new BitmapImage(new Uri(_giocoSolitario.Croci[2].VisualizzaPrimaCarta.NomeFile, UriKind.Relative));
            }
            else
            {
                Img_btnMazzetto3.Visibility = Visibility.Collapsed;
            }
            if (_giocoSolitario.Croci[3].VisualizzaPrimaCarta != null)
            {
                Img_btnMazzetto4.Visibility = Visibility.Visible;
                Img_btnMazzetto4.Source = new BitmapImage(new Uri(_giocoSolitario.Croci[3].VisualizzaPrimaCarta.NomeFile, UriKind.Relative));
            }
            else
            {
                Img_btnMazzetto4.Visibility = Visibility.Collapsed;
            }
            if (_giocoSolitario.Croci[4].VisualizzaPrimaCarta != null)
            {
                Img_btnMazzetto5.Visibility = Visibility.Visible;
                Img_btnMazzetto5.Source = new BitmapImage(new Uri(_giocoSolitario.Croci[4].VisualizzaPrimaCarta.NomeFile, UriKind.Relative));
            }
            else
            {
                Img_btnMazzetto5.Visibility = Visibility.Collapsed;
            }
            if (_giocoSolitario.Pozzo.LastOrDefault() != null)
            {
                Img_btnPozzo.Visibility = Visibility.Visible;
                Img_btnPozzo.Source = new BitmapImage(new Uri(_giocoSolitario.Pozzo.Last().NomeFile, UriKind.Relative));
            }
            else
            {
                Img_btnPozzo.Visibility = Visibility.Collapsed;
            }

        }

        private void btnPozzo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _cartaSelezionata = _giocoSolitario.Pozzo.Last();

                btnMazzetto_Click(sender, e);
            }
            catch
            {
                MessageBox.Show("Non ci sono carte nel pozzo!", "Pozzo Vuoto", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnMazzetto_Click(object sender, RoutedEventArgs e)
        {
            Button bottoneCliccato = (Button)sender;
            string nomeBottone = bottoneCliccato.Name;
            bottoneCliccato.Background = Brushes.Green;
            // Se è stato già selezionato un  bottone
            if (_primoBottoneSelezionato)
            {
                string idMazzettoDestinazione = TrovaIdMazzettoDaNomeBottone(nomeBottone);
                try
                {
                    // Sposta la carta solo se ho selezionato un posto diverso da quello di partenza.
                    if (idMazzettoDestinazione != null && idMazzettoDestinazione != TrovaIdMazzettoDaNomeBottone(_primoBottone.Name))
                    {
                        _giocoSolitario.SpostaCarte(_cartaSelezionata, idMazzettoDestinazione);
                        ScegliEAvviaAnimazioneMazzetto(idMazzettoDestinazione, _cartaSelezionata, TrovaIdMazzettoDaNomeBottone(_primoBottone.Name)); ///test animazione

                        AggiornaImmagini();
                    }
                    else
                    {
                        MessageBox.Show("Seleziona un mazzetto diverso per lo spostamento della carta.", "Avviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Errore durante lo scambio della carta: {ex.Message}", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                // Resetta lo stato della selezione
                _primoBottoneSelezionato = false;
                _primoBottone.Background = Brushes.Silver; // Torna al colore silver
                bottoneCliccato.Background = Brushes.Silver;
            }
            else  // Se è il primo bottone selezionato, memorizza il bottone e imposta il flag a true
            {
                _primoBottone = bottoneCliccato;
                _primoBottoneSelezionato = true;

                List<Carta> pozzo = _giocoSolitario.Pozzo;
                string nome = _primoBottone.Name;
                string id = TrovaIdMazzettoDaNomeBottone(nome);
                Mazzetto[] croci = _giocoSolitario.Croci;
                bool trovato = false;
                foreach (Mazzetto mazzetto in croci)
                {
                    if (mazzetto.Id == id)
                    {
                        _cartaSelezionata = mazzetto.VisualizzaPrimaCarta;
                        trovato = true;
                        break;
                    }
                }
                if (!trovato)
                {
                    Mazzetto[] basi = _giocoSolitario.Basi;
                    foreach (Mazzetto mazzetto in basi)
                    {
                        if (mazzetto.Id == id)
                        {
                            _cartaSelezionata = mazzetto.VisualizzaPrimaCarta;
                            trovato = true;
                            break;
                        }
                    }
                    if (!trovato)
                    {
                        _cartaSelezionata = _giocoSolitario.Pozzo[_giocoSolitario.Pozzo.Count - 1];
                    }
                }
                _primoBottone.Background = Brushes.Green;

            }
            if (_giocoSolitario.StatoDellaPartita == StatoPartita.VITTORIA)
            {
                vittoria = true;
                CambiaPaginaInEsitoPartita();
            }



        }

        private string TrovaIdMazzettoDaNomeBottone(string nomeBottone)
        {
            switch (nomeBottone)
            {
                case "btnMazzetto1": return "C1";
                case "btnMazzetto2": return "C2";
                case "btnMazzetto3": return "C3";
                case "btnMazzetto4": return "C4";
                case "btnMazzetto5": return "C5";
                case "btnBase1": return "B1";
                case "btnBase2": return "B2";
                case "btnBase3": return "B3";
                case "btnBase4": return "B4";
                case "btnPozzo": return "P";
                default: return null;
            }
        }


        private void btnFinePartita_Click(object sender, RoutedEventArgs e)
        {
            vittoria = false;
            _giocoSolitario.Resa();
            CambiaPaginaInEsitoPartita();
        }
        private void CambiaPaginaInEsitoPartita()
        {
            Thread.Sleep(869);
            Esito_Partita esito_Partita = new Esito_Partita(vittoria);
            esito_Partita.Show();
            this.Close();
        }

        private void ScegliEAvviaAnimazioneMazzetto(string idMazzettoDaFareAnimazione, Carta cartaDaAnimare, string idMazzettoCliccatoPrima)
        {
            if (idMazzettoCliccatoPrima == "P")
            {
                if (idMazzettoDaFareAnimazione == "C1")
                {
                    EseguiAnimazione("Storyboard_DAPozzo_AMazzetto1", cartaDaAnimare);
                }
                else if (idMazzettoDaFareAnimazione == "C2")
                {
                    EseguiAnimazione("Storyboard_DAPozzo_AMazzetto2", cartaDaAnimare);
                }
                else if (idMazzettoDaFareAnimazione == "C3")
                {
                    EseguiAnimazione("Storyboard_DAPozzo_AMazzetto3", cartaDaAnimare);
                }
                else if (idMazzettoDaFareAnimazione == "C4")
                {
                    EseguiAnimazione("Storyboard_DAPozzo_AMazzetto4", cartaDaAnimare);
                }
                else if (idMazzettoDaFareAnimazione == "C5")
                {
                    EseguiAnimazione("Storyboard_DAPozzo_AMazzetto5", cartaDaAnimare);
                }
                else if (idMazzettoDaFareAnimazione == "B1")
                {
                    EseguiAnimazione("Storyboard_DAPozzo_ABase1", cartaDaAnimare);
                }
                else if (idMazzettoDaFareAnimazione == "B2")
                {
                    EseguiAnimazione("Storyboard_DAPozzo_ABase2", cartaDaAnimare);
                }
                else if (idMazzettoDaFareAnimazione == "B3")
                {
                    EseguiAnimazione("Storyboard_DAPozzo_ABase3", cartaDaAnimare);
                }
                else if (idMazzettoDaFareAnimazione == "B4")
                {
                    EseguiAnimazione("Storyboard_DAPozzo_ABase4", cartaDaAnimare);
                }
            }
            else if (idMazzettoCliccatoPrima == "C1")
            {
                if (idMazzettoDaFareAnimazione == "B1")
                {
                    EseguiAnimazione("Storyboard_DAMazzetto1_ABase1", cartaDaAnimare);
                }
                else if (idMazzettoDaFareAnimazione == "B2")
                {
                    EseguiAnimazione("Storyboard_DAMazzetto1_ABase2", cartaDaAnimare);
                }
                else if (idMazzettoDaFareAnimazione == "B3")
                {
                    EseguiAnimazione("Storyboard_DAMazzetto1_ABase3", cartaDaAnimare);
                }
                else if (idMazzettoDaFareAnimazione == "B4")
                {
                    EseguiAnimazione("Storyboard_DAMazzetto1_ABase4", cartaDaAnimare);
                }
                else if (idMazzettoDaFareAnimazione == "C2")
                {
                    EseguiAnimazione("Storyboard_DAMazzetto1_AMazzetto2", cartaDaAnimare);
                }
                else if (idMazzettoDaFareAnimazione == "C3")
                {
                    EseguiAnimazione("Storyboard_DAMazzetto1_AMazzetto3", cartaDaAnimare);
                }
                else if (idMazzettoDaFareAnimazione == "C4")
                {
                    EseguiAnimazione("Storyboard_DAMazzetto1_AMazzetto4", cartaDaAnimare);
                }
                else if (idMazzettoDaFareAnimazione == "C5")
                {
                    EseguiAnimazione("Storyboard_DAMazzetto1_AMazzetto5", cartaDaAnimare);
                }


            }
            else if (idMazzettoCliccatoPrima == "C2")
            {
                if (idMazzettoDaFareAnimazione == "B1")
                {
                    EseguiAnimazione("Storyboard_DAMazzetto2_ABase1", cartaDaAnimare);
                }
                else if (idMazzettoDaFareAnimazione == "B2")
                {
                    EseguiAnimazione("Storyboard_DAMazzetto2_ABase2", cartaDaAnimare);
                }
                else if (idMazzettoDaFareAnimazione == "B3")
                {
                    EseguiAnimazione("Storyboard_DAMazzetto2_ABase3", cartaDaAnimare);
                }
                else if (idMazzettoDaFareAnimazione == "B4")
                {
                    EseguiAnimazione("Storyboard_DAMazzetto2_ABase4", cartaDaAnimare);
                }
                else if (idMazzettoDaFareAnimazione == "C1")
                {
                    EseguiAnimazione("Storyboard_DAMazzetto2_AMazzetto1", cartaDaAnimare);
                }
                else if (idMazzettoDaFareAnimazione == "C3")
                {
                    EseguiAnimazione("Storyboard_DAMazzetto2_AMazzetto3", cartaDaAnimare);
                }
                else if (idMazzettoDaFareAnimazione == "C4")
                {
                    EseguiAnimazione("Storyboard_DAMazzetto2_AMazzetto4", cartaDaAnimare);
                }
                else if (idMazzettoDaFareAnimazione == "C5")
                {
                    EseguiAnimazione("Storyboard_DAMazzetto2_AMazzetto5", cartaDaAnimare);
                }


            }


        }

        private void EseguiAnimazione(string nomeStoryboard, Carta cartaDaAnimare)
        {
            Img_Animazione.Visibility = Visibility.Visible;
            Img_Animazione.Source = new BitmapImage(new Uri(cartaDaAnimare.NomeFile, UriKind.Relative));

            Storyboard animazione = (Storyboard)FindResource(nomeStoryboard);
            _immagineAnimazione = Img_Animazione;
            animazione.Completed += Animazione_Completata;

            animazione.Begin();
        }

        private void Animazione_Completata(object sender, EventArgs e)
        {

            _immagineAnimazione.Visibility = Visibility.Collapsed;
            AggiornaImmagini();
        }



        private void AnnullaSelezione_ConClick_TastoDestro(object sender, MouseButtonEventArgs e)
        {

            if (e.RightButton == MouseButtonState.Pressed)
            {
                if (_primoBottone != null)
                {
                    _primoBottone.Background = Brushes.Silver;
                    _primoBottone = null;
                    _primoBottoneSelezionato = false;
                }

            }
        }


    }
}
