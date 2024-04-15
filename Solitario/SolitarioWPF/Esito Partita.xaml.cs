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
        public Esito_Partita()
        {
            InitializeComponent();
            
           
        }

        private void btn_TerminaProgramma_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
