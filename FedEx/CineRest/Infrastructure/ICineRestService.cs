using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Infrastructure
{
    [ServiceContract]
    public interface ICineRestService
    {
        [OperationContract]
        [WebGet(UriTemplate = "GetData/{value}", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        Stream Test(string value);
    }
}