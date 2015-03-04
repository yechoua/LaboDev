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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjetLabo_Dev.Interface
{
    /// <summary>
    /// Logique d'interaction pour Acceuil.xaml
    /// </summary>
    public partial class Acceuil : Page
    {
        public Acceuil()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Gestion());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Gestion());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Planning());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Support());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Clients());
        }

        private void btnGestion_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnPlanning_Click(object sender, RoutedEventArgs e)
        {
            ProjetLabo_Dev.Form1 p = new Form1();
            p.Show();
       
        }
    }
}
