using System.Text.Json;

namespace LoggerApplication.Core.Helper
{
    public static class JsonElementHelper
    {
        public static string GetString(JsonElement jsonElement)
        {
            string json = JsonSerializer.Serialize(jsonElement);

            if (jsonElement.ValueKind == JsonValueKind.String)
                return JsonSerializer.Deserialize<string>(json);
            else
                return json;
        }
    }
}
