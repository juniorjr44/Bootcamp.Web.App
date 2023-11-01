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
        public async Task<IActionResult> Get() => Ok(await _contactBL.GetAll());

        [HttpGet(RouteHelper.Contact.Get)]
        public async Task<IActionResult> Get(int id) => Ok(await _contactBL.Get(id));

        [HttpPost(RouteHelper.Contact.Get)]
        public async Task<IActionResult> Create(int id) => Ok(await _contactBL.Get(id));
    }
}