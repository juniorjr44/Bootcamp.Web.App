using Bootcamp.Api.Bls;
using Bootcamp.Api.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp.Api.Controllers
{
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactBL _contactBL;
        public ContactController(IContactBL contactBL)
        {
            _contactBL = contactBL;
        }

        [HttpGet(RouteHelper.Contact.Main)]
        public async Task<IActionResult> Get() => Ok(await _contactBL.GetAllContacts());
    }
}