using System.IO;
using System.Text;

namespace ServiceLayer
{
    public static class Extensions
    {
        public static int Clamp(this int value, int maxValue, int minValue)
        {
            if (value > maxValue)
                return maxValue;

            return value < minValue ? minValue : value;
        }

        public static string ConvertToString(this Stream data)
        {
            var reader = new StreamReader(data);

            return reader.ReadToEnd();
        }

        /// <summary>
        /// Example
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int ToInt(this string value, int? defaultValue = null)
        {
            if (!defaultValue.HasValue)
                return int.Parse(value);

            int number;

            return int.TryParse(value, out number) ? number : defaultValue.Value;
        }

        public static Stream ToStream(this string result)
        {
            var results = new MemoryStream();

            results.Write(Encoding.ASCII.GetBytes(result), 0, result.Length);
            results.Position = 0;

            return results;
        }
    }
}