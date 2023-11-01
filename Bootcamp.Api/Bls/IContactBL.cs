using Bootcamp.Api.Model;
using Bootcamp.Api.ViewModel;

namespace Bootcamp.Api.Bls
{
    public interface IContactBL
    {
        Task<List<Contact>> GetAll();
        Task<List<Contact>> List(int pageIndex);
        Task<Contact> Get(int id);
        Task<Contact> Create(ContactRequest contact);
        Task<Contact> Update(ContactRequest contact);
        Task<Contact> Remove(int id);
    }
}