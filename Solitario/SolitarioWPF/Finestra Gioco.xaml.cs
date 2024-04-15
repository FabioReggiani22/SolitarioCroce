using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Solitario_A_Croce_WPF
{
    /// <summary>
    /// Logica di interazione per Finestra_Gioco.xaml
    /// </summary>
    public partial class Finestra_Gioco : Window
    {
        List<Button> _posizioniPresenti;
        public Finestra_Gioco()
        {
            InitializeComponent();
            _posizioniPresenti = new List<Button>();
            
            RiempiPosizioni();
            
            
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void RiempiPosizioni()
        {
            ComboBox_SceltePosizioni.Items.Add("Mazzetto1");
            ComboBox_SceltePosizioni.Items.Add("Mazzetto2");
            ComboBox_SceltePosizioni.Items.Add("Mazzetto3");
            ComboBox_SceltePosizioni.Items.Add("Mazzetto4");
            ComboBox_SceltePosizioni.Items.Add("Mazzetto5");
            ComboBox_SceltePosizioni.Items.Add("Base1");
            ComboBox_SceltePosizioni.Items.Add("Base2");
            ComboBox_SceltePosizioni.Items.Add("Base3");
            ComboBox_SceltePosizioni.Items.Add("Base4");
        }
    }
}
