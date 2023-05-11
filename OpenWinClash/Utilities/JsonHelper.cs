using System.Text.Json;

namespace OpenWinClash.Utilities
{
    static class JsonUtils
    {
        public static readonly JsonSerializerOptions Options = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };
    }
}
