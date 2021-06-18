using System;
using ApplicationService.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
        #region "Position"
        [OperationContract]
        List<PositionDTO> GetPositions();

        [OperationContract]
        PositionDTO GetPositionById(int id);

        [OperationContract]
        string SetPosition(PositionDTO position);

        [OperationContract]
        string DeletePosition(int id);
        #endregion
        #region "Person"
        [OperationContract]
        List<PersonDTO> GetPerson();

        [OperationContract]
        PersonDTO GetPersonById(int id);

        [OperationContract]
        string SetPerson(PersonDTO personDTO);

        [OperationContract]
        string DeletePerson(int id);

        [OperationContract]
        bool Authorize(PersonDTO personDTO);

        [OperationContract]
        List<PersonDTO> GetPersonByUsername(string Username);
        #endregion
        #region "Cars"
        [OperationContract]
        List<CarDTO> GetCars();

        [OperationContract]
        CarDTO GetCarsById(int id);

        [OperationContract]
        string SetCar(CarDTO car);

        [OperationContract]
        string DeleteCar(int id);
        #endregion
        #region "Zones"
        [OperationContract]
        List<ZoneDTO> GetZones();

        [OperationContract]
        ZoneDTO GetZoneById(int id);

        [OperationContract]
        string SetZone(ZoneDTO zone);

        [OperationContract]
        string DeleteZone(int id);
        #endregion
        #region "Parts"
        [OperationContract]
        List<PartDTO> GetParts();

        [OperationContract]
        PartDTO GetPartById(int id);

        [OperationContract]
        string SetPart(PartDTO part);

        [OperationContract]
        string DeletePart(int id);
        #endregion
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "WcfService.ContractType".
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
}
