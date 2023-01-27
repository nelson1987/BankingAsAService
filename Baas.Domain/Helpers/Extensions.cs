using System.Text.Json;

namespace Baas.Domain.Helpers
{
    public static class Extensions
    {
        public static string ToJson(this object model) 
        {
            return JsonSerializer.Serialize(model);
        }
    }
}
