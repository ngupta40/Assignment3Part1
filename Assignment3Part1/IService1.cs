using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Assignment3Part1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        String[] Top10Words(string url);

        [OperationContract]
        string WordFilter(string str);

        [OperationContract]
        string TransactionSummary(string filePath);

        [OperationContract]
        String[] TopNearByPlaceFinder(string zipCode);

        [OperationContract]
        string StringPurifier(string str, string parentFunc);

    // TODO: Add your service operations here
    }
}
