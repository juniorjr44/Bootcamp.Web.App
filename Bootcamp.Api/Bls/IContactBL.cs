using Bootcamp.Api.Model;

namespace Bootcamp.Api.Bls
{
    public interface IContactBL
    {
        Task<List<Contact>> GetAll();
        Task<Contact> Get(int id);
        Task<Contact> Create(Contact contact);
    }
}