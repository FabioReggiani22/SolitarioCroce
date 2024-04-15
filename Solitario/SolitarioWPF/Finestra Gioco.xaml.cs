using SolitarioCroce;
using System;
using System.Collections;
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
        Gioco _giocoSolitario;
        



        public Finestra_Gioco()
        {
            InitializeComponent();
            //List<int> lista = new List<int>();
            //int[] lis =  { 1,2,34,5};
            //lista = lis.ToList();

            //mescolo il mazzo e inizializzo il gioco.
            Mazzo mazzo = new Mazzo();
            mazzo.MescolaMazzo();    
            _giocoSolitario = new Gioco(mazzo);
            
            



        }

       
    }
}
