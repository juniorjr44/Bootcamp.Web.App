using Newtonsoft.Json;
using System.Reflection;

namespace Bootcamp.Api.Helpers
{
    public static class UtilHelper
    {
        public static int generateId(this List<int> ids)
        {
            var (number, index) = ids.Select((n, i) => (n, i)).Max();
            return (int)number + 1;
        }
    }
}
