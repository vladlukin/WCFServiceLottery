using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServiceLibrary
{
    [ServiceContract]
    public interface IServiceMain
    {

        [OperationContract]
        [WebGet(UriTemplate = "getName?id={id}")]
        string GetNameById(int id);

        [OperationContract]
        [WebGet(UriTemplate = "GetCustomers",
            ResponseFormat = WebMessageFormat.Json)]
        List<string> GetCustomers();

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "makeWinners",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]  
        void MakeWinners(List<int> winners);
    }

    // Используйте контракт данных, как показано на следующем примере, чтобы добавить сложные типы к сервисным операциям.
    // В проект можно добавлять XSD-файлы. После построения проекта вы можете напрямую использовать в нем определенные типы данных с пространством имен "WcfServiceLibrary.ContractType".
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
