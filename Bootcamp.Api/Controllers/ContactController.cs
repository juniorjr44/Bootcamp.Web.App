using Bootcamp.Api.Bls;
using Bootcamp.Api.Helpers;
using Bootcamp.Api.ViewModel;
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

        [HttpGet(RouteHelper.Contact.All)]
        public async Task<IActionResult> GetAll() => Ok(await _contactBL.GetAll());

        [HttpGet(RouteHelper.Contact.List)]
        public async Task<IActionResult> List(int pageIndex) => Ok(await _contactBL.List(pageIndex));

        [HttpGet(RouteHelper.Contact.Get)]
        public async Task<IActionResult> Get(int id) => Ok(await _contactBL.Get(id));

        [HttpPost(RouteHelper.Contact.Create)]
        public async Task<IActionResult> Create([FromBody] ContactRequest request) => Ok(await _contactBL.Create(request));


        [HttpPut(RouteHelper.Contact.Update)]
        public async Task<IActionResult> Update([FromBody] ContactRequest request) => Ok(await _contactBL.Update(request));

        [HttpDelete(RouteHelper.Contact.Delete)]
        public async Task<IActionResult> Delete(int id) => Ok(await _contactBL.Remove(id));
    }
}