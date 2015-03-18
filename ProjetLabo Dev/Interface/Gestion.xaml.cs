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
using ProjetLabo_Dev.ServiceReference1;

namespace ProjetLabo_Dev.Interface
{
    /// <summary>
    /// Logique d'interaction pour Gestion.xaml
    /// </summary>
    public partial class Gestion : UserControl
    {

        private Service1Client SC;
        private bool add;
        public Artisan actualArtisan;

        public Gestion()
        {
            InitializeComponent();
            SC = new Service1Client();
            actualArtisan = new Artisan();
            List<Artisan> allArt = SC.selectArtisans();
            this.GestionGrid.ItemsSource = allArt;
            this.txtNom.TextChanged += _TextChanged;
        }

        private void _TextChanged(object sender, TextChangedEventArgs e)
        {
            add = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //this.NavigationService.Navigate(new Acceuil());
        }

        private void GestionGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (add == true)
            {
                add = false;
            }
            else
            {
                actualArtisan = e.AddedItems[0] as Artisan;
                this.txtNom.Text = (e.AddedItems[0] as Artisan).Nom;
                this.txtAdresse.Text = (e.AddedItems[0] as Artisan).Adresse;

                this.txtTelephone.Text = (e.AddedItems[0] as Artisan).Telephone.ToString();
                this.cmbxSigle.Text = (e.AddedItems[0] as Artisan).Sigle;
                this.txtPrenom.Text = (e.AddedItems[0] as Artisan).Prenom;
                this.txtCodePostal.Text = (e.AddedItems[0] as Artisan).CodePostal.ToString();
                this.txtMail.Text = (e.AddedItems[0] as Artisan).Email;
            }
        }

        private void GestionGrid_OnLoaded(object sender, RoutedEventArgs e)
        {
            this.GestionGrid.Columns.Single(column => column.Header.ToString() == "idArtisan").Visibility = Visibility.Hidden;// DisplayIndex = 0;
            this.GestionGrid.Columns.Single(c => c.Header.ToString() == "Sigle").Visibility = Visibility.Hidden;//.DisplayIndex = 1;
            this.GestionGrid.Columns.Single(c => c.Header.ToString() == "Nom").DisplayIndex = 0;
            this.GestionGrid.Columns.Single(c => c.Header.ToString() == "Nom").Width = 50;
            this.GestionGrid.Columns.Single(c => c.Header.ToString() == "Prenom").DisplayIndex = 1;
            this.GestionGrid.Columns.Single(c => c.Header.ToString() == "Prenom").Width = 50;
            this.GestionGrid.Columns.Single(c => c.Header.ToString() == "Adresse").Visibility = Visibility.Hidden;//.DisplayIndex = 4;
            this.GestionGrid.Columns.Single(c => c.Header.ToString() == "CodePostal").Visibility = Visibility.Hidden;//.DisplayIndex = 5;
            this.GestionGrid.Columns.Single(c => c.Header.ToString() == "Telephone").Visibility = Visibility.Hidden;//.DisplayIndex = 7;
            this.GestionGrid.Columns.Single(c => c.Header.ToString() == "Email").DisplayIndex = 2;

            this.GestionGrid.IsReadOnly = true;

        }

        private void GestionGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "ExtensionData")
                e.Cancel = true;
        }

        private void refresh(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AddNewArtisan(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void RemoveArtisan(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
