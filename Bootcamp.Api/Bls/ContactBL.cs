using AutoMapper;
using Bootcamp.Api.Helpers;
using Bootcamp.Api.Model;
using Newtonsoft.Json;
using System.Linq;

namespace Bootcamp.Api.Bls
{
    public class ContactBL : BaseBl, IContactBL
    {
        public async Task<List<Contact>> GetAll()
        {
            var returnObj = await ReadData();
            return JsonConvert.DeserializeObject<List<Contact>>(returnObj);
        }
        public async Task<Contact> Get(int id)
        {
            var returnList = JsonConvert.DeserializeObject<List<Contact>>(await ReadData()); 
            return returnList.SingleOrDefault(x => x.Id == id);
        }
        public async Task<Contact> Create(Contact contact)
        {
            var returnList = JsonConvert.DeserializeObject<List<Contact>>(await ReadData());
            contact.Id = returnList.Select(x => x.Id).ToList().generateId();
            returnList.Add(contact);
            await WriteData(JsonConvert.SerializeObject(returnList));

            return contact;
        }
        public async Task<Contact> Update(Contact contact)
        {
            IMapper.Map<BudgetDetail_Response>(obj);
            var returnList = JsonConvert.DeserializeObject<List<Contact>>(await ReadData());
            var obj = returnList.SingleOrDefault(x => x.Id == contact.Id);
            returnList.Remove(obj);
            await WriteData(JsonConvert.SerializeObject(returnList));

            return obj;
        }
        public async Task<Contact> Remove(int id)
        {
            var returnList = JsonConvert.DeserializeObject<List<Contact>>(await ReadData());
            var obj = returnList.SingleOrDefault(x => x.Id == id);
            returnList.Remove(obj);
            await WriteData(JsonConvert.SerializeObject(returnList));

            return obj;
        }
    }
}
