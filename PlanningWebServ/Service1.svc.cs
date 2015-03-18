using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;
using Microsoft.SqlServer.Server;

namespace PlanningWebServ
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Service1 : IService1
    {
        private string connString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename='f:\\users\\yechoua\\documents\\visual studio 2013\\Projects\\ProjetLabo Dev\\PlanningWebServ\\App_Data\\PlanningDB.mdf'";

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public string TestConnection()
        {
            string msg = "toto";

            /*SqlCommand cmd = new SqlCommand("SELECT * FROM Message", connection);
            connection.Open();
            string result = cmd.ExecuteNonQuery().ToString();
            if (result == "1")
            {
                msg = "ok";
            }
            else
            {
                msg = result;
            }
            connection.Close();*/

            using (SqlConnection connection = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("SELECT idArtisan FROM Artisan WHERE idArtisan = 1", connection);
                try
                {
                    connection.Open();
                    msg = cmd.ExecuteScalar().ToString();
                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                }

            }

            return msg;

        }

        #region Artisans

        public List<Artisan> selectArtisans()
        {
            List<Artisan> AllArtisan = new List<Artisan>();
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Artisan", connection);
                SqlDataReader reader = cmd.ExecuteReader(); 

                while (reader.Read())
                {

                    Artisan item = new Artisan()
                    {
                        idArtisan = (int)reader["idArtisan"],
                        Sigle = reader["Sigle"].ToString(),
                        Nom = reader["Nom"].ToString(),
                        Prenom = reader["Prenom"].ToString(),
                        Adresse = reader["Adresse"].ToString(),
                        CodePostal = (int)reader["CodePostal"],
                        Telephone = reader["Telephone"].ToString(),
                        Email = reader["Email"].ToString()

                    };
                    AllArtisan.Add(item);
                }
                connection.Close();
                
            }
            
            return AllArtisan;
        }

        public List<Artisan> ArtisanSelectByDetails(Artisan artisanInfo)
        {
            string requeteSelectArtisansByDetails = "SELECT * FROM Artisan WHERE (0=0)";

            if (artisanInfo.idArtisan != null || artisanInfo.idArtisan != 0)
            {
                requeteSelectArtisansByDetails += "AND idArtisan = '" + artisanInfo.idArtisan + "'";
            }
            if (artisanInfo.Sigle != null || artisanInfo.Sigle != "")
            {
                requeteSelectArtisansByDetails += "AND Sigle = '" + artisanInfo.Sigle + "'";
            }
            if (artisanInfo.Nom != null || artisanInfo.Nom != "")
            {
                requeteSelectArtisansByDetails += "AND Nom = '" + artisanInfo.Nom + "'";
            }
            if (artisanInfo.Prenom != null || artisanInfo.Prenom != "")
            {
                requeteSelectArtisansByDetails += "AND Prenom = '" + artisanInfo.Prenom + "'";
            }
            if (artisanInfo.Adresse != null || artisanInfo.Adresse != "")
            {
                requeteSelectArtisansByDetails += "AND Adresse = '" + artisanInfo.Adresse + "'";
            }
            if (artisanInfo.CodePostal != null || artisanInfo.CodePostal != 0)
            {
                requeteSelectArtisansByDetails += "AND CodePostal = '" + artisanInfo.CodePostal + "'";
            }
            if (artisanInfo.Telephone != null || artisanInfo.Telephone != "")
            {
                requeteSelectArtisansByDetails += "AND Telephone = '" + artisanInfo.Telephone + "'";
            }
            if (artisanInfo.Email != null || artisanInfo.Email != "")
            {
                requeteSelectArtisansByDetails += "AND Email = '" + artisanInfo.Email + "'";
            }

            requeteSelectArtisansByDetails += "ORDER BY idArtisan ASC";

            List<Artisan> SelectedArtisans = new List<Artisan>();
            using (SqlConnection connection = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(requeteSelectArtisansByDetails, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    Artisan item = new Artisan()
                    {
                        idArtisan = (int)reader["idArtisan"],
                        Sigle = reader["Sigle"].ToString(),
                        Nom = reader["Nom"].ToString(),
                        Prenom = reader["Prenom"].ToString(),
                        Adresse = reader["Adresse"].ToString(),
                        CodePostal = (int)reader["CodePostal"],
                        Telephone = reader["Telephone"].ToString(),
                        Email = reader["Email"].ToString()

                    };
                    SelectedArtisans.Add(item);
                }
            }
            return SelectedArtisans;

        }

        public void ArtisanAdd(Artisan artisan)
        {
            string RequeteInsertArtisan =
                "INSERT INTO Artisan (idArtisan, Sigle, Nom, Prenom, Adresse, CodePostal, Telephone,Email)" +
                "VALUES ('" + artisan.Sigle + "' ,'" + artisan.Nom + "' ,'" + artisan.Prenom + "' ,'" + artisan.Adresse +
                "'," +
                "'" + artisan.CodePostal + "','" + artisan.Telephone + "','" + artisan.Email + "')";

            using (SqlConnection connection = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(RequeteInsertArtisan, connection);
                int returnExec = cmd.ExecuteNonQuery(); 
            }
        }

        public void ArtisanRemove(Artisan artisan)
        {
                string RequeteRemoveArtisan =
                    "DELETE FROM Artisan WHERE idArtisan = '"+artisan.idArtisan+"'";

                using (SqlConnection connection = new SqlConnection(connString))
                {
                    SqlCommand cmd = new SqlCommand(RequeteRemoveArtisan, connection);
                    int returnExec = cmd.ExecuteNonQuery(); 
                }
        }

        #endregion Artisans

        #region Client


        public List<Client> SelectAllClients()
        {
            List<Client> AllClient = new List<Client>();
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Client", connection);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Client item = new Client();
                    item.idClient = (int)reader["idClient"];
                    item.Sigle = reader["Sigle"].ToString();
                    item.Nom = reader["Nom"].ToString();
                    item.Prenom = reader["Prenom"].ToString();
                    item.Adresse = reader["Adresse"].ToString();
                    item.CodePostal = (int)reader["CodePostal"];
                    item.Pays = reader["Pays"].ToString();
                    item.Telephone = Int32.Parse(reader["Telephone"].ToString());
                    item.Mail = reader["Mail"].ToString();
                    item.DateEntree = reader["DateEntree"].ToString();
                    item.DateDerniereFacturation = reader["DateDerniereFacturation"].ToString();
                    AllClient.Add(item);
                }
                connection.Close();
            }
            return AllClient;
        }

        public List<Client> ClientSelectByDetails(Client clientInfo)
        {
            string requeteSelectArtisansByDetails = "SELECT * FROM Client WHERE (0=0)";

            if (clientInfo.idClient != null || clientInfo.idClient != 0)
            {
                requeteSelectArtisansByDetails += "AND idClient = '" + clientInfo.idClient + "'";
            }
            if (clientInfo.Sigle != null || clientInfo.Sigle != "")
            {
                requeteSelectArtisansByDetails += "AND Sigle = '" + clientInfo.Sigle + "'";
            }
            if (clientInfo.Nom != null || clientInfo.Nom != "")
            {
                requeteSelectArtisansByDetails += "AND Nom = '" + clientInfo.Nom + "'";
            }
            if (clientInfo.Prenom != null || clientInfo.Prenom != "")
            {
                requeteSelectArtisansByDetails += "AND Prenom = '" + clientInfo.Prenom + "'";
            }
            if (clientInfo.Adresse != null || clientInfo.Adresse != "")
            {
                requeteSelectArtisansByDetails += "AND Adresse = '" + clientInfo.Adresse + "'";
            }
            if (clientInfo.CodePostal != null || clientInfo.CodePostal != 0)
            {
                requeteSelectArtisansByDetails += "AND CodePostal = '" + clientInfo.CodePostal + "'";
            }
            if (clientInfo.Pays != null || clientInfo.Pays != "")
            {
                requeteSelectArtisansByDetails += "AND Pays = '" + clientInfo.Pays + "'";
            }
            if (clientInfo.Telephone != null || clientInfo.Telephone != 0)
            {
                requeteSelectArtisansByDetails += "AND Telephone = '" + clientInfo.Telephone + "'";
            }
            if (clientInfo.Mail != null || clientInfo.Mail != "")
            {
                requeteSelectArtisansByDetails += "AND Mail = '" + clientInfo.Mail + "'";
            }
            if (clientInfo.DateEntree != null || clientInfo.DateEntree != "")
            {
                requeteSelectArtisansByDetails += "AND DateEntree = '" + clientInfo.DateEntree + "'";
            }
            if (clientInfo.DateDerniereFacturation != null || clientInfo.DateDerniereFacturation != "")
            {
                requeteSelectArtisansByDetails += "AND DateDerniereFacturation = '" + clientInfo.DateDerniereFacturation + "'";
            }

            requeteSelectArtisansByDetails += "ORDER BY idClient ASC";

            List<Client> SelectedClient = new List<Client>();
            using (SqlConnection connection = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(requeteSelectArtisansByDetails, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    Client item = new Client()
                    {
                        idClient = (int)reader["idArtisan"],
                        Sigle = reader["Sigle"].ToString(),
                        Nom = reader["Nom"].ToString(),
                        Prenom = reader["Prenom"].ToString(),
                        Adresse = reader["Adresse"].ToString(),
                        CodePostal = (int)reader["CodePostal"],
                        Pays = reader["Pays"].ToString(),
                        Telephone = Int32.Parse(reader["Telephone"].ToString()),
                        Mail = reader["Email"].ToString(),
                        DateEntree = reader["DateEntree"].ToString(),
                        DateDerniereFacturation = reader["DateDerniereFacturation"].ToString()

                    };
                    SelectedClient.Add(item);
                }
            }
            return SelectedClient;
        }

        public void ClientAdd(Client client)
        {
            string RequeteInsertClient =
                            "INSERT INTO Client (" +
                            "Sigle, " +
                            "Nom, " +
                            "Prenom, " +
                            "Adresse, " +
                            "CodePostal, " +
                            "Pays, " +
                            "Telephone," +
                            "Mail, " +
                            "DateEntree) " +
                            "VALUES ('" + client.Sigle + "' ," +
                            "'" + client.Nom + "' ," +
                            "'" + client.Prenom + "' ," +
                            "'" + client.Adresse +"'," +
                            "'" + client.CodePostal + "'," +
                            "'" + client.Pays + "'," +
                            "'" + client.Telephone + "'," +
                            "'" + client.Mail + "'," +
                            "'" + DateTime.Now.Date.ToString(CultureInfo.InvariantCulture) + "')";

            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(RequeteInsertClient, connection);
                int returnExec = cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void ClientRemove(Client client)
        {
            string RequeteRemoveClient =
                "DELETE FROM Client WHERE idClient = '" + client.idClient + "'";

            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(RequeteRemoveClient, connection);
                int returnExec = cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        #endregion Client

        #region taches

        public List<Tache> SelectAllTaches()
        {
            List<Tache> AllTaches = new List<Tache>();
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Taches", connection);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Tache singleTache = new Tache();
                    singleTache.id = (int)reader["id"];
                    singleTache.NomTache = reader["NomTache"].ToString();
                    singleTache.IdClient = (int)reader["IdClient"];
                    singleTache.IdArtisan = (int)reader["IdArtisan"];
                    singleTache.Statut = reader["Statut"].ToString();
                    singleTache.idCommentaire = (int)reader["idCommentaire"];
                    singleTache.Debut = reader["Debut"].ToString();
                    singleTache.Duree = reader["Duree"].ToString();
                    AllTaches.Add(singleTache);
                }
                connection.Close();
            }
            return AllTaches;
        }

        public List<Client> TachesSelectByArtisan(Client clientInfo)
        {
            string requeteSelectArtisansByDetails = "SELECT * FROM Client WHERE (0=0)";

            if (clientInfo.idClient != null || clientInfo.idClient != 0)
            {
                requeteSelectArtisansByDetails += "AND idClient = '" + clientInfo.idClient + "'";
            }
            if (clientInfo.Sigle != null || clientInfo.Sigle != "")
            {
                requeteSelectArtisansByDetails += "AND Sigle = '" + clientInfo.Sigle + "'";
            }
            if (clientInfo.Nom != null || clientInfo.Nom != "")
            {
                requeteSelectArtisansByDetails += "AND Nom = '" + clientInfo.Nom + "'";
            }
            if (clientInfo.Prenom != null || clientInfo.Prenom != "")
            {
                requeteSelectArtisansByDetails += "AND Prenom = '" + clientInfo.Prenom + "'";
            }
            if (clientInfo.Adresse != null || clientInfo.Adresse != "")
            {
                requeteSelectArtisansByDetails += "AND Adresse = '" + clientInfo.Adresse + "'";
            }
            if (clientInfo.CodePostal != null || clientInfo.CodePostal != 0)
            {
                requeteSelectArtisansByDetails += "AND CodePostal = '" + clientInfo.CodePostal + "'";
            }
            if (clientInfo.Pays != null || clientInfo.Pays != "")
            {
                requeteSelectArtisansByDetails += "AND Pays = '" + clientInfo.Pays + "'";
            }
            if (clientInfo.Telephone != null || clientInfo.Telephone != 0)
            {
                requeteSelectArtisansByDetails += "AND Telephone = '" + clientInfo.Telephone + "'";
            }
            if (clientInfo.Mail != null || clientInfo.Mail != "")
            {
                requeteSelectArtisansByDetails += "AND Mail = '" + clientInfo.Mail + "'";
            }
            if (clientInfo.DateEntree != null || clientInfo.DateEntree != "")
            {
                requeteSelectArtisansByDetails += "AND DateEntree = '" + clientInfo.DateEntree + "'";
            }
            if (clientInfo.DateDerniereFacturation != null || clientInfo.DateDerniereFacturation != "")
            {
                requeteSelectArtisansByDetails += "AND DateDerniereFacturation = '" + clientInfo.DateDerniereFacturation + "'";
            }

            requeteSelectArtisansByDetails += "ORDER BY idClient ASC";

            List<Client> SelectedClient = new List<Client>();
            using (SqlConnection connection = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(requeteSelectArtisansByDetails, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    Client item = new Client()
                    {
                        idClient = (int)reader["idArtisan"],
                        Sigle = reader["Sigle"].ToString(),
                        Nom = reader["Nom"].ToString(),
                        Prenom = reader["Prenom"].ToString(),
                        Adresse = reader["Adresse"].ToString(),
                        CodePostal = (int)reader["CodePostal"],
                        Pays = reader["Pays"].ToString(),
                        Telephone = Int32.Parse(reader["Telephone"].ToString()),
                        Mail = reader["Email"].ToString(),
                        DateEntree = reader["DateEntree"].ToString(),
                        DateDerniereFacturation = reader["DateDerniereFacturation"].ToString()

                    };
                    SelectedClient.Add(item);
                }
            }
            return SelectedClient;
        }
       
        public List<Client> TachesSelectByDateAndArtisan(Client clientInfo)
        {
            string requeteSelectArtisansByDetails = "SELECT * FROM Client WHERE (0=0)";

            if (clientInfo.idClient != null || clientInfo.idClient != 0)
            {
                requeteSelectArtisansByDetails += "AND idClient = '" + clientInfo.idClient + "'";
            }
            if (clientInfo.Sigle != null || clientInfo.Sigle != "")
            {
                requeteSelectArtisansByDetails += "AND Sigle = '" + clientInfo.Sigle + "'";
            }
            if (clientInfo.Nom != null || clientInfo.Nom != "")
            {
                requeteSelectArtisansByDetails += "AND Nom = '" + clientInfo.Nom + "'";
            }
            if (clientInfo.Prenom != null || clientInfo.Prenom != "")
            {
                requeteSelectArtisansByDetails += "AND Prenom = '" + clientInfo.Prenom + "'";
            }
            if (clientInfo.Adresse != null || clientInfo.Adresse != "")
            {
                requeteSelectArtisansByDetails += "AND Adresse = '" + clientInfo.Adresse + "'";
            }
            if (clientInfo.CodePostal != null || clientInfo.CodePostal != 0)
            {
                requeteSelectArtisansByDetails += "AND CodePostal = '" + clientInfo.CodePostal + "'";
            }
            if (clientInfo.Pays != null || clientInfo.Pays != "")
            {
                requeteSelectArtisansByDetails += "AND Pays = '" + clientInfo.Pays + "'";
            }
            if (clientInfo.Telephone != null || clientInfo.Telephone != 0)
            {
                requeteSelectArtisansByDetails += "AND Telephone = '" + clientInfo.Telephone + "'";
            }
            if (clientInfo.Mail != null || clientInfo.Mail != "")
            {
                requeteSelectArtisansByDetails += "AND Mail = '" + clientInfo.Mail + "'";
            }
            if (clientInfo.DateEntree != null || clientInfo.DateEntree != "")
            {
                requeteSelectArtisansByDetails += "AND DateEntree = '" + clientInfo.DateEntree + "'";
            }
            if (clientInfo.DateDerniereFacturation != null || clientInfo.DateDerniereFacturation != "")
            {
                requeteSelectArtisansByDetails += "AND DateDerniereFacturation = '" + clientInfo.DateDerniereFacturation + "'";
            }

            requeteSelectArtisansByDetails += "ORDER BY idClient ASC";

            List<Client> SelectedClient = new List<Client>();
            using (SqlConnection connection = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(requeteSelectArtisansByDetails, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    Client item = new Client()
                    {
                        idClient = (int)reader["idArtisan"],
                        Sigle = reader["Sigle"].ToString(),
                        Nom = reader["Nom"].ToString(),
                        Prenom = reader["Prenom"].ToString(),
                        Adresse = reader["Adresse"].ToString(),
                        CodePostal = (int)reader["CodePostal"],
                        Pays = reader["Pays"].ToString(),
                        Telephone = Int32.Parse(reader["Telephone"].ToString()),
                        Mail = reader["Email"].ToString(),
                        DateEntree = reader["DateEntree"].ToString(),
                        DateDerniereFacturation = reader["DateDerniereFacturation"].ToString()

                    };
                    SelectedClient.Add(item);
                }
            }
            return SelectedClient;
        }

        public void TacheAdd(Client client)
        {
            string RequeteInsertClient =
                            "INSERT INTO Client (" +
                            "Sigle, " +
                            "Nom, " +
                            "Prenom, " +
                            "Adresse, " +
                            "CodePostal, " +
                            "Pays, " +
                            "Telephone," +
                            "Mail, " +
                            "DateEntree) " +
                            "VALUES ('" + client.Sigle + "' ," +
                            "'" + client.Nom + "' ," +
                            "'" + client.Prenom + "' ," +
                            "'" + client.Adresse + "'," +
                            "'" + client.CodePostal + "'," +
                            "'" + client.Pays + "'," +
                            "'" + client.Telephone + "'," +
                            "'" + client.Mail + "'," +
                            "'" + DateTime.Now.Date.ToString(CultureInfo.InvariantCulture) + "')";

            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(RequeteInsertClient, connection);
                int returnExec = cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void TacheRemove(Client client)
        {
            string RequeteRemoveClient =
                "DELETE FROM Client WHERE idClient = '" + client.idClient + "'";

            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(RequeteRemoveClient, connection);
                int returnExec = cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void TacheUpdate(Client client)
        {
            string RequeteRemoveClient =
                "DELETE FROM Client WHERE idClient = '" + client.idClient + "'";

            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(RequeteRemoveClient, connection);
                int returnExec = cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        #endregion taches

    }
}
