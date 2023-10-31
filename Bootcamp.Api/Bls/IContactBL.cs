using Bootcamp.Api.Model;

namespace Bootcamp.Api.Bls
{
    public interface IContactBL
    {
        Task<List<Contact>> GetAllContacts();
    }
}