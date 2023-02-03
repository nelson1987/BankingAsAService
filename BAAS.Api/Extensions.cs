using System.Text.Json;

namespace Baas.Api
{
    public static class Extensions
    {
        public static string ToJson(this object model)
        {
            return JsonSerializer.Serialize(model);
        }
    }
}
