using Newtonsoft.Json;

namespace OptoCoderEcommerceApi.Data.Utilities
{
    public class ConvertDate
    {
        public static string GetFromDate(DateTime date)
        {
            return date.ToString("yyyy'-'MM'-'dd") + " 00:00:00";
        }

        public static string GetToDate(DateTime date)
        {
            return date.ToString("yyyy'-'MM'-'dd") + " 23:59:59";
        }

        public static DateTime GetEmptyDate()
        {
            return new DateTime(1900, 1, 1, 0, 0, 0, 0);
        }

        public static T ConvertJsonToObject<T>(object jsonString)
        {
            try
            {
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };

                return JsonConvert.DeserializeObject<T>(jsonString.ToString(), settings);
            }
            catch (Exception ex)
            {
                throw new Exception("Request Data is not valid");
            }
        }
    }
}
