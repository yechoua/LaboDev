using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PlanningWebServ
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IService1
    {
        
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);



        [OperationContract]
        string TestConnection();

        /*
         * Artisans
         * **/

        [OperationContract]
        List<Artisan> selectArtisans();

        [OperationContract]
        List<Artisan> ArtisanSelectByDetails(Artisan artisanInfo);

        [OperationContract]
        void ArtisanAdd(Artisan artisan);

        [OperationContract]
        void ArtisanRemove(Artisan idArtisan);




        /*
         * Clients
         * **/
        [OperationContract]
        List<Client> SelectAllClients();

        [OperationContract]
        List<Client> ClientSelectByDetails(Client artisanInfo);

        [OperationContract]
        void ClientAdd(Client client);

        [OperationContract]
        void ClientRemove(Client idClient);


        /*
         * taches
         * **/
        /*
        [OperationContract]
        List<Client> SelectAllTache();

        [OperationContract]
        List<Client> TacheSelectByDetails(Tache tacheInfo);

        [OperationContract]
        void TacheAdd(Tache tache);

        [OperationContract]
        void TacheRemove(Tache idTache);
        */
    }


    // Utilisez un contrat de données comme indiqué dans l'exemple ci-après pour ajouter les types composites aux opérations de service.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }


    [DataContract]
    public class Artisan
    {
        [DataMember]
        public int idArtisan { get; set; }
        [DataMember]
        public string Sigle { get; set; }
        [DataMember]
        public string Nom { get; set; }
        [DataMember]
        public string Prenom { get; set; }
        [DataMember]
        public string Adresse { get; set; }
        [DataMember]
        public int CodePostal { get; set; }
        [DataMember]
        public string Telephone { get; set; }
        [DataMember]
        public string Email { get; set; }
    }

    [DataContract]
    public class Client
    {
        [DataMember]
        public int idClient { get; set; }
        [DataMember]
        public string Sigle { get; set; }
        [DataMember]
        public string Nom { get; set; }
        [DataMember]
        public string Prenom { get; set; }
        [DataMember]
        public string Adresse { get; set; }
        [DataMember]
        public int CodePostal { get; set; }
        [DataMember]
        public string Pays { get; set; }
        [DataMember]
        public int Telephone { get; set; }
        [DataMember]
        public string Mail { get; set; }
        [DataMember]
        public string DateEntree { get; set; }
        [DataMember]
        public string DateDerniereFacturation { get; set; }
    }

    [DataContract]
    public class Tache
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string NomTache { get; set; }
        [DataMember]
        public int IdClient { get; set; }
        [DataMember]
        public string IdArtisan { get; set; }
        [DataMember]
        public string Statut { get; set; }
        [DataMember]
        public int idCommentaire { get; set; }
        [DataMember]
        public string Debut { get; set; }
        [DataMember]
        public string Duree { get; set; }
    }
    
}
