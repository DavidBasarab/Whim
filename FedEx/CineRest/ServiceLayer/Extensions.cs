using System.IO;
using System.Text;

namespace ServiceLayer
{
    public static class Extensions
    {
        public static Stream ToStream(this string result)
        {
            var results = new MemoryStream();

            results.Write(Encoding.ASCII.GetBytes(result), 0, result.Length);
            results.Position = 0;

            return results;
        }

        public static string ConvertToString(this Stream data)
        {
            var reader = new StreamReader(data);

            return reader.ReadToEnd();
        }
    }
}