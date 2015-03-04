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
using System.Windows.Forms;

namespace ProjetLabo_Dev.Interface
{
    /// <summary>
    /// Logique d'interaction pour Planning.xaml
    /// </summary>
    public partial class Planning : Page
    {
        public Planning()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Acceuil());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ProjetLabo_Dev.Form1.ActiveForm.ShowDialog();


        }

        
    }
}
