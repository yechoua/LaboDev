using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.ServiceModel.Configuration;
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
using ServiceStack.Text;

namespace ProjetLabo_Dev.Interface
{
    /// <summary>
    /// Logique d'interaction pour Clients.xaml
    /// </summary>
    public partial class Clients : UserControl
    {
        private Service1Client SC;
        private bool add;
        public Client actualClient;
        public Clients()
        {
            InitializeComponent();
            SC = new Service1Client();
            //var ClientList = new BindingList<Client>(SC.SelectAllClients());
            //var source = new BindingSource(ClientList, null);
            //this.ClientGrid.DataContext = ClientList;
            actualClient = new Client();
            List<Client> allCli = SC.SelectAllClients();
            this.ClientGrid.ItemsSource = allCli;

            this.txtNom.TextChanged += _TextChanged;
        }

        void _TextChanged(object sender, TextChangedEventArgs e)
        {
            add = true;
        }

        private void AddNewUser(object sender, RoutedEventArgs e)
        {
            
            Client test = new Client();

            test.Nom = this.txtNom.Text;
            test.Prenom = this.txtPrenom.Text;
            test.Sigle = this.cmbxSigle.Text;
            test.Adresse = this.txtAdresse.Text;
            test.CodePostal = Convert.ToInt32(this.txtCodePostal.Text);
            test.Pays = this.txtPays.Text;
            test.Telephone = Convert.ToInt32(this.txtTelephone.Text);
            test.Mail = this.txtMail.Text;

            SC.ClientAdd(test);
            
        }

        private void refresh(object sender, RoutedEventArgs e)
        {

            List<Client> allCli = SC.SelectAllClients();
            this.ClientGrid.ItemsSource = allCli;

        }

        private void ClientGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "ExtensionData")
                e.Cancel = true;
        }


        private void ClientGrid_OnLoaded(object sender, RoutedEventArgs e)
        {
            this.ClientGrid.Columns.Single(column => column.Header.ToString() == "idClient").Visibility = Visibility.Hidden;// DisplayIndex = 0;
            this.ClientGrid.Columns.Single(c => c.Header.ToString() == "Sigle").Visibility = Visibility.Hidden;//.DisplayIndex = 1;
            this.ClientGrid.Columns.Single(c => c.Header.ToString() == "Nom").DisplayIndex = 0;
            this.ClientGrid.Columns.Single(c => c.Header.ToString() == "Nom").Width = 50;
            this.ClientGrid.Columns.Single(c => c.Header.ToString() == "Prenom").DisplayIndex = 1;
            this.ClientGrid.Columns.Single(c => c.Header.ToString() == "Prenom").Width = 50;
            this.ClientGrid.Columns.Single(c => c.Header.ToString() == "Adresse").Visibility = Visibility.Hidden;//.DisplayIndex = 4;
            this.ClientGrid.Columns.Single(c => c.Header.ToString() == "CodePostal").Visibility = Visibility.Hidden;//.DisplayIndex = 5;
            this.ClientGrid.Columns.Single(c => c.Header.ToString() == "Pays").Visibility = Visibility.Hidden;//.DisplayIndex = 6;
            this.ClientGrid.Columns.Single(c => c.Header.ToString() == "Telephone").Visibility = Visibility.Hidden;//.DisplayIndex = 7;
            this.ClientGrid.Columns.Single(c => c.Header.ToString() == "Mail").DisplayIndex = 2;
            this.ClientGrid.Columns.Single(c => c.Header.ToString() == "DateEntree").Visibility = Visibility.Hidden;//.DisplayIndex = 9;
            this.ClientGrid.Columns.Single(c => c.Header.ToString() == "DateDerniereFacturation").Visibility = Visibility.Hidden;//.DisplayIndex = 10;

            this.ClientGrid.IsReadOnly = true;
        }

        private void ClientGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (add == true)
            {
                add = false;
            }
            else
            {
                actualClient = e.AddedItems[0] as Client;
                this.txtNom.Text = (e.AddedItems[0] as Client).Nom;
                this.txtAdresse.Text = (e.AddedItems[0] as Client).Adresse;

                this.txtTelephone.Text = (e.AddedItems[0] as Client).Telephone.ToString();
                this.cmbxSigle.Text = (e.AddedItems[0] as Client).Sigle;
                this.txtPrenom.Text = (e.AddedItems[0] as Client).Prenom;
                this.txtCodePostal.Text = (e.AddedItems[0] as Client).CodePostal.ToString();
                this.txtPays.Text = (e.AddedItems[0] as Client).Pays;
                this.txtMail.Text = (e.AddedItems[0] as Client).Mail;
            }
            //this.lbName.Content = e.AddedItems[0].ToString();
            //this.lbName.Content = sender["Nom"].ToString(); //.Content as string; ;
        }

        private void RemoveUser(object sender, RoutedEventArgs e)
        {
            SC.ClientRemove(actualClient);
        }
    }
}
