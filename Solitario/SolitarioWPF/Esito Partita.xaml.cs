using Solitario_A_Croce_WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SolitarioWPF
{
    /// <summary>
    /// Logica di interazione per Esito_Partita.xaml
    /// </summary>
    public partial class Esito_Partita : Window
    {
        public Esito_Partita(bool vittoria)
        {
            InitializeComponent();
            if (vittoria)
            {
                txtBox_EsitoPartita.Text = "HAI VINTO!";
                
            }
            else
            {
                txtBox_EsitoPartita.Text = "HAI PERSO!";
            }

        }

        private void btn_TerminaProgramma_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_RicominciaPartita_Click(object sender, RoutedEventArgs e)
        {
            Finestra_Gioco fg = new Finestra_Gioco();
            fg.Show();
            this.Close();
        }
    }
}
