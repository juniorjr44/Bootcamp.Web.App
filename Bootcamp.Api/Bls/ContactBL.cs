using Bootcamp.Api.Model;
using Newtonsoft.Json;

namespace Bootcamp.Api.Bls
{
    public class ContactBL : BaseBl, IContactBL
    {
        public async Task<List<Contact>> GetAllContacts()
        {
            var test = await ReadData();
            return JsonConvert.DeserializeObject<List<Contact>>(test);
        }
    }
}
