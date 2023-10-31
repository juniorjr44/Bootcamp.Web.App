using Newtonsoft.Json;
using System.Reflection;

namespace Bootcamp.Api.Helpers
{
    public static class FileHelper
    {
        public static async Task<T> LoadJsonFile<T>(string fullFilename) where T : new()
        {
                using (var reader = new StreamReader(fullFilename))
                {
                    var json = await reader.ReadToEndAsync();
                    return JsonConvert.DeserializeObject<T>(json);
                }
        }
    }
}
