using AutoMapper;
using Bootcamp.Api.Model;
using Bootcamp.Api.ViewModel;

namespace Bootcamp.Api.Data
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Contact, ContactResponse>();
            CreateMap<ContactRequest, Contact>();
        }
           
    }
}
