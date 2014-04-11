using System.Collections.Generic;
using System.IO;
using System.Net;
using System.ServiceModel.Web;
using Infrastructure;

namespace ServiceLayer
{
    public static class DataInformation
    {
        private static void GetTheImageBytes()
        {
            ImageBytes = new List<byte[]>();

            foreach(var imageName in ImageNames)
                ImageBytes.Add(File.ReadAllBytes(IMAGE_DIRECTORY + imageName));
        }

        //public const string IMAGE_DIRECTORY = @"D:\Source\Whim\FedEx\Images\";
        public const string IMAGE_DIRECTORY = @"C:\Code\gitHub\Whim\FedEx\CineRest\TheService\SampleImages\";

        public static IList<byte[]> ImageBytes { get; set; }
        public static IList<string> ImageNames { get; set; }

        static DataInformation()
        {
            ImageNames = new List<string>
            {
                "Cantina.jpg",
                "Chewy.jpg",
                "Luke.jpg",
                "NoIdea.jpg",
                "Obiwan.jpg"
            };

            GetTheImageBytes();
        }
    }

    public class CineRestService : ICineRestService
    {
        private static int CreateTheImageId(string id)
        {
            return id.ToInt().Clamp(DataInformation.ImageNames.Count - 1, 0);
        }

        public Stream FindImage(string id)
        {
            SetContentToImage();

            var imageStream = new MemoryStream(DataInformation.ImageBytes[CreateTheImageId(id)]);

            return imageStream;
        }

        public void SetContentToImage()
        {
            if (WebOperationContext.Current == null)
                return;

            WebOperationContext.Current.OutgoingResponse.Headers[HttpResponseHeader.ContentType] = "image/jpeg";
        }

        public void SetContentToJson()
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