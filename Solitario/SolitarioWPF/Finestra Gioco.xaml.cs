using SolitarioCroce;
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
        
        bool _applicaSwitch;
        Button _bottoneConCuiFareSwitch;
        Carta _cartaSelezionata;



        public Finestra_Gioco()
        {
            InitializeComponent();
            
            //mescolo il mazzo e inizializzo il gioco.
            Mazzo mazzo = new Mazzo();
            mazzo.MescolaMazzo();

            _giocoSolitario = new Gioco(mazzo);

            InizializzaCarteInizioPartita();
            _bottoneConCuiFareSwitch = new Button();
            

        }


        private async void btnMazzo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                _giocoSolitario.PescaCarta();
                _bottoneConCuiFareSwitch.Name = "btnPozzo";


                Carta carta;
                carta = _giocoSolitario.Pozzo[_giocoSolitario.Pozzo.Count - 1];
                string valCarta = carta.ValoreCarta.ToString();
                string semCarta = carta.SemeCarta.ToString();


                Img_DaMazzo_APozzo.Visibility = Visibility.Visible;


                //animazione
                Storyboard animazione = (Storyboard)FindResource("Storyboard_DAMazzo_APozzo");
                animazione.Begin();
                Img_DaMazzo_APozzo.Source= new BitmapImage(new Uri($"carte/{valCarta}_{semCarta}.jpg", UriKind.Relative));

                animazione.Completed += (o, s) => {
                    Img_btnPozzo.Source = null;
                    Img_btnPozzo.Source = new BitmapImage(new Uri($"carte/{valCarta}_{semCarta}.jpg", UriKind.Relative));
                    
                    Img_DaMazzo_APozzo.Visibility = Visibility.Hidden;

                };
                // 

            }
            catch
            {
                MessageBox.Show("Il mazzo è finito non puoi pescare altre carte!","Mazzo Terminato",MessageBoxButton.OK,MessageBoxImage.Warning);
                btnMazzo.IsEnabled= false;
                btnMazzo.Visibility = Visibility.Collapsed;
                rettangoloMazzo.Visibility = Visibility.Collapsed;
            }
        }

        private void InizializzaCarteInizioPartita()
        {
            List<Mazzetto> listaCroci = new List<Mazzetto>();
            listaCroci = _giocoSolitario.Croci.ToList();

            Carta CartaMazzetto1;
            
            CartaMazzetto1 = listaCroci[0].VisualizzaPrimaCarta;

            
           
                string valCartaMazz1 = CartaMazzetto1.ValoreCarta.ToString();
                string semCartaMazz1 = CartaMazzetto1.SemeCarta.ToString();
                Img_btnMazzetto1.Source = new BitmapImage(new Uri($"carte/{valCartaMazz1}_{semCartaMazz1}.jpg", UriKind.Relative));
            
            

            //mazzetto2
            Carta CartaMazzetto2;

            CartaMazzetto2 = listaCroci[1].VisualizzaPrimaCarta;

           

                string valCartaMazz2 = CartaMazzetto2.ValoreCarta.ToString();
                string semCartaMazz2 = CartaMazzetto2.SemeCarta.ToString();
                Img_btnMazzetto2.Source = new BitmapImage(new Uri($"carte/{valCartaMazz2}_{semCartaMazz2}.jpg", UriKind.Relative));
            
            


            Carta CartaMazzetto3;
            
            CartaMazzetto3 = listaCroci[2].VisualizzaPrimaCarta;

           
                string valCartaMazz3 = CartaMazzetto3.ValoreCarta.ToString();
                string semCartaMazz3 = CartaMazzetto3.SemeCarta.ToString();
                Img_btnMazzetto3.Source = new BitmapImage(new Uri($"carte/{valCartaMazz3}_{semCartaMazz3}.jpg", UriKind.Relative));

           
            

            Carta CartaMazzetto4;
            
            CartaMazzetto4 = listaCroci[3].VisualizzaPrimaCarta;

           
                string valCartaMazz4 = CartaMazzetto4.ValoreCarta.ToString();
                string semCartaMazz4 = CartaMazzetto4.SemeCarta.ToString();
                Img_btnMazzetto4.Source = new BitmapImage(new Uri($"carte/{valCartaMazz4}_{semCartaMazz4}.jpg", UriKind.Relative));
            
            

            Carta CartaMazzetto5;
            
             CartaMazzetto5 = listaCroci[4].VisualizzaPrimaCarta;

          
                string valCartaMazz5 = CartaMazzetto5.ValoreCarta.ToString();
                string semCartaMazz5 = CartaMazzetto5.SemeCarta.ToString();
                Img_btnMazzetto5.Source = new BitmapImage(new Uri($"carte/{valCartaMazz5}_{semCartaMazz5}.jpg", UriKind.Relative));
            


           

        }



        private void InizializzaCarteNellaPartita(Carta cartaSelezionata, string idMazzettoDestinazione,Button primoBottone)
        {
            List<Mazzetto> listaCroci = new List<Mazzetto>();
            listaCroci = _giocoSolitario.Croci.ToList();

            string idPrimoMazzetto=TrovaIdMazzettoDaNomeBottone(primoBottone.Name);
                



            if (idMazzettoDestinazione == "F")
            {

                if (_giocoSolitario.Pozzo.Count != 0)
                {
                    Carta CartaPozzo;

                    CartaPozzo = _giocoSolitario.Pozzo.Last();
                    cartaSelezionata = CartaPozzo;
                    if (CartaPozzo == null)
                    {
                        CartaPozzo = cartaSelezionata;
                        Img_btnPozzo.Source = null;

                    }

                    if (CartaPozzo != null)
                    {
                        Img_btnPozzo.Source = null;

                        Carta nuovaUltimaCartaPozzo = _giocoSolitario.Pozzo.Last();
                        string valCartaPozzo = nuovaUltimaCartaPozzo.ValoreCarta.ToString();
                        string semCartaPozzo = nuovaUltimaCartaPozzo.SemeCarta.ToString();
                        Img_btnPozzo.Source = new BitmapImage(new Uri($"carte/{valCartaPozzo}_{semCartaPozzo}.jpg", UriKind.Relative));

                    }
                }
            }

            Carta CartaMazzetto1;

            CartaMazzetto1 = listaCroci[0].VisualizzaPrimaCarta;
            Carta CartaMazzetto2;

            CartaMazzetto2 = listaCroci[1].VisualizzaPrimaCarta;

            Carta CartaMazzetto3;

            CartaMazzetto3 = listaCroci[2].VisualizzaPrimaCarta;
            Carta CartaMazzetto4;

            CartaMazzetto4 = listaCroci[3].VisualizzaPrimaCarta;
            Carta CartaMazzetto5;

            CartaMazzetto5 = listaCroci[4].VisualizzaPrimaCarta;


            if (idMazzettoDestinazione=="C1")
            {
 
                CartaMazzetto1 = cartaSelezionata;
                string valCartaMazz1 = CartaMazzetto1.ValoreCarta.ToString();
                string semCartaMazz1 = CartaMazzetto1.SemeCarta.ToString();
                Img_btnMazzetto1.Source = new BitmapImage(new Uri($"carte/{valCartaMazz1}_{semCartaMazz1}.jpg", UriKind.Relative));
                
                if(idPrimoMazzetto=="C2")
                {
                    
                    string valCartaMazz2 = CartaMazzetto2.ValoreCarta.ToString();
                    string semCartaMazz2 = CartaMazzetto2.SemeCarta.ToString();
                    Img_btnMazzetto1.Source = new BitmapImage(new Uri($"carte/{valCartaMazz1}_{semCartaMazz1}.jpg", UriKind.Relative));
                }
                else if (idPrimoMazzetto == "C3")
                {

                }
                else if (idPrimoMazzetto == "C4")
                {

                }
                else if (idPrimoMazzetto == "C5")
                {

                }
            }


            if (idMazzettoDestinazione == "C2")
            {
                //mazzetto2
                



                CartaMazzetto2 = cartaSelezionata;
                string valCartaMazz2 = CartaMazzetto2.ValoreCarta.ToString();
                string semCartaMazz2 = CartaMazzetto2.SemeCarta.ToString();
                Img_btnMazzetto2.Source = new BitmapImage(new Uri($"carte/{valCartaMazz2}_{semCartaMazz2}.jpg", UriKind.Relative));
            }

            if (idMazzettoDestinazione == "C3")
            {




                CartaMazzetto3 = cartaSelezionata;
                string valCartaMazz3 = CartaMazzetto3.ValoreCarta.ToString();
                string semCartaMazz3 = CartaMazzetto3.SemeCarta.ToString();
                Img_btnMazzetto3.Source = new BitmapImage(new Uri($"carte/{valCartaMazz3}_{semCartaMazz3}.jpg", UriKind.Relative));

            }





            if (idMazzettoDestinazione == "C4")
            {

               



                CartaMazzetto4 = cartaSelezionata;
                string valCartaMazz4 = CartaMazzetto4.ValoreCarta.ToString();
                string semCartaMazz4 = CartaMazzetto4.SemeCarta.ToString();
                Img_btnMazzetto4.Source = new BitmapImage(new Uri($"carte/{valCartaMazz4}_{semCartaMazz4}.jpg", UriKind.Relative));
            }


            if (idMazzettoDestinazione == "C5")
            {
                



                CartaMazzetto5 = cartaSelezionata;
                string valCartaMazz5 = CartaMazzetto5.ValoreCarta.ToString();
                string semCartaMazz5 = CartaMazzetto5.SemeCarta.ToString();
                Img_btnMazzetto5.Source = new BitmapImage(new Uri($"carte/{valCartaMazz5}_{semCartaMazz5}.jpg", UriKind.Relative));


            }





        }

        private void btnPozzo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _cartaSelezionata = _giocoSolitario.Pozzo[_giocoSolitario.Pozzo.Count-1];
                _applicaSwitch = true;
                Img_btnPozzo = null;
                btnMazzetto_Click(sender,e);
            }
            catch
            {
                MessageBox.Show("Non ci sono carte nel pozzo!", "Pozzo Vuoto", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        
        private bool _primoBottoneSelezionato = false;
        private Button _primoBottone;


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
                    // Sposta la carta solo se ho selezionato un posto diverso da qwuello di partenza.
                    if (idMazzettoDestinazione != null && idMazzettoDestinazione != TrovaIdMazzettoDaNomeBottone(_primoBottone.Name))
                    {
                        _giocoSolitario.SpostaCarte(_cartaSelezionata, idMazzettoDestinazione);

                        //aggiornare la SOURCE DELLA CARTAAAA QUII DENTRO 
                        InizializzaCarteNellaPartita(_cartaSelezionata, idMazzettoDestinazione, _primoBottone);
                      

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
            
                else if(pozzo.Count!=0)
                {
                    
     
                    _cartaSelezionata = pozzo.Last();
               
                  
                }
                _primoBottone.Background = Brushes.Green;
               
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
            _giocoSolitario.Resa();
        }
    }
}
