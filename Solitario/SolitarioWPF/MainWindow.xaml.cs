using SolitarioWPF;
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
using static System.Net.WebRequestMethods;

namespace Solitario_A_Croce_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonIniziaPartita_Click(object sender, RoutedEventArgs e)
        {
            Finestra_Gioco finestra_Gioco= new Finestra_Gioco();
            finestra_Gioco.Show();
            this.Close();
        }

        private void OpenLink(object sender, RoutedEventArgs e)
        {
            string url = "https://docs.google.com/document/d/1QcCqljWaj1_OJeTMCJd6ZT2AEmJBYhfx2dd0lCFIo0g/edit?usp=sharing";
            Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
        }
    }
}
