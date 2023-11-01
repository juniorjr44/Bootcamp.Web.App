using AutoMapper;
using Bootcamp.Api.Helpers;
using Bootcamp.Api.Model;
using Bootcamp.Api.ViewModel;
using Newtonsoft.Json;

namespace Bootcamp.Api.Bls
{
    public class ContactBL : BaseBl, IContactBL
    {
        private readonly IMapper _mapper;
        public ContactBL(IMapper mapper) 
        { 
            _mapper = mapper;
        }
        public async Task<List<Contact>> GetAll() => JsonConvert.DeserializeObject<List<Contact>>(await ReadData());
        public async Task<List<Contact>> List(int pageIndex)
        {
            var pageSize = 5;
            var skip = (pageIndex - 1) * pageSize;
            var returnList = JsonConvert.DeserializeObject<List<Contact>>(await ReadData());
            var result = returnList.Skip(skip).Take(pageSize).ToList();
            return result;
        }

        public async Task<Contact> Get(int id)
        {
            var returnList = JsonConvert.DeserializeObject<List<Contact>>(await ReadData()); 
            return returnList.SingleOrDefault(x => x.Id == id);
        }
        public async Task<Contact> Create(ContactRequest contact)
        {
            var contactObj = _mapper.Map<Contact>(contact);
            var returnList = JsonConvert.DeserializeObject<List<Contact>>(await ReadData());
            contactObj.Id = returnList.Select(x => x.Id).ToList().generateId();
            returnList.Add(contactObj);
            await WriteData(JsonConvert.SerializeObject(returnList));

            return contactObj;
        }
        public async Task<Contact> Update(ContactRequest contact)
        {
            var contactObj = _mapper.Map<Contact>(contact);

            //remove the obj from the file
            await Remove(contactObj.Id);

            //then recreate the object
            await Create(contact);

            return contactObj;
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
