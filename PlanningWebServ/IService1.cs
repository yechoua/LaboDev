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

        // TODO: ajoutez vos opérations de service ici
        
        
        [OperationContract]
        List<Artisan> selectArtisans();

        [OperationContract]
        Artisan ArtisanSelectByDetails();

        [OperationContract]
        void ArtisanAdd(Artisan artisan);

        [OperationContract]
        void ArtisanRemove(int idArtisan);

        [OperationContract]
        List<Artisan> ArtisanTmpTravail();


        /*
        [OperationContract]
        CompositeType FacturesSelect();

        [OperationContract]
        CompositeType FacturesbyDetailsSelect();

        [OperationContract]
        CompositeType FactureAdd();
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
        public string idArtisan { get; set; }
        [DataMember]
        public string Sigle { get; set; }
        [DataMember]
        public string Nom { get; set; }
        [DataMember]
        public string Prenom { get; set; }
        [DataMember]
        public string Adresse { get; set; }
        [DataMember]
        public string CodePostal { get; set; }
        [DataMember]
        public string Telephone { get; set; }
        [DataMember]
        public string Email { get; set; }
    }
}
