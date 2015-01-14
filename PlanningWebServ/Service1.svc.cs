using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;

namespace PlanningWebServ
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Service1 : IService1
    {
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

           /* SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\v11.0;AttachDbFilename='f:\\users\\yechoua\\documents\\visual studio 2013\\Projects\ProjetLabo Dev\\ProjetLabo Dev\\Database1.mdf'");
            SqlCommand cmd = new SqlCommand("SELECT * FROM Message", connection);
            connection.Open();
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                msg = "ok";
            }
            else
            {
                msg = "failure";
            }
            connection.Close();*/ 
            return msg;

        }

        public List<Artisan> selectArtisans()
        {
            
            throw new NotImplementedException();
        }

        public Artisan ArtisanSelectByDetails()
        {
            throw new NotImplementedException();
        }

        public void ArtisanAdd(Artisan artisan)
        {
            throw new NotImplementedException();
        }

        public void ArtisanRemove(int idArtisan)
        {
            throw new NotImplementedException();
        }

        public List<Artisan> ArtisanTmpTravail()
        {

            throw new NotImplementedException();
        }
    }
}
