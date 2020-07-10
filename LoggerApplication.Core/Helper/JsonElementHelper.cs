using System.Text.Json;

namespace LoggerApplication.Core.Helper
{
    public static class JsonElementHelper
    {
        public static string GetString(JsonElement jsonElement)
        {
            string json = JsonSerializer.Serialize(jsonElement);

            return json;
        }
    }
}
