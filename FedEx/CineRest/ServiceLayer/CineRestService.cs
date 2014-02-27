using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.ServiceModel.Web;
using Infrastructure;

namespace ServiceLayer
{
    public static class DataInformation
    {
        public const string IMAGE_DIRECTORY = @"D:\Source\Whim\FedEx\Images\";

        public static IList<string> ImageNames { get; set; }

        public static IList<byte[]> ImageBytes { get; set; }

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

        private static void GetTheImageBytes()
        {
            ImageBytes = new List<byte[]>();

            foreach(var imageName in ImageNames)
            {
                ImageBytes.Add(File.ReadAllBytes(IMAGE_DIRECTORY + imageName));
            }
        }
    }

    public class CineRestService : ICineRestService
    {
        public Stream FindImage(string id)
        {
            SetContentToImage();

            var imageStream = new MemoryStream(DataInformation.ImageBytes[imageId(id)]);

            return imageStream;
        }

        private static int imageId(string id)
        {
            return id.ToInt().Clamp(DataInformation.ImageNames.Count - 1, 0);
        }

        public void SetContentToJson()
        {
            if (WebOperationContext.Current == null)
                return;

            WebOperationContext.Current.OutgoingResponse.Headers[HttpResponseHeader.ContentType] = "application/json";
            WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Json;
        }

        public void SetContentToImage()
        {
            if (WebOperationContext.Current == null)
                return;

            WebOperationContext.Current.OutgoingResponse.Headers[HttpResponseHeader.ContentType] = "image/jpeg";
        }

        public Stream Test(string value)
        {
            SetContentToJson();

            return "Hello Worm".ToStream();
        }
    }
}