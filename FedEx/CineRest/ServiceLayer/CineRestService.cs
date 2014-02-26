using System.IO;
using System.Net;
using System.ServiceModel.Web;
using Infrastructure;

namespace ServiceLayer
{
    public class CineRestService : ICineRestService
    {
        public static void SetContentToJson()
        {
            if (WebOperationContext.Current == null)
                return;

            WebOperationContext.Current.OutgoingResponse.Headers[HttpResponseHeader.ContentType] = "application/json";
            WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Json;
        }

        public Stream Test(string value)
        {
            SetContentToJson();

            return "Hello Worm".ToStream();
        }
    }
}