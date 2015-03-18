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
using ProjetLabo_Dev.Interface;
using ProjetLabo_Dev.ServiceReference1;

namespace ProjetLabo_Dev
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            Service1Client SC = new Service1Client();

            //this.TesTextBoxCoonection.Text = SC.TestConnection();
            //this._mainFrame.Children.Add(new Acceuil());
            //_mainFrame.NavigationService.Navigate(new Acceuil());

        }

        private void btnGestion_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Children.Clear();
            this._mainFrame.Children.Add(new Gestion());
        }
       
        private void btnPlanning_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Children.Clear();
            this._mainFrame.Children.Add(new Planning());
        }

        private void btnSupport_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Children.Clear();
            this._mainFrame.Children.Add(new Support());
        }

        public void btnClients_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Children.Clear();
            this._mainFrame.Children.Add(new Clients());

        }

        private void BtnParametre_OnClick(object sender, RoutedEventArgs e)
        {
            _mainFrame.Children.Clear();
            this._mainFrame.Children.Add(new Parametres());
        }
    }
}
