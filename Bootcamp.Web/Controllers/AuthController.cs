﻿using System;
using Bootcamp.Web.Hubs;
using Bootcamp.Web.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;

namespace Bootcamp.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthController : ControllerBase
    {
        private readonly IHubContext<UsersHub> _hubContext;

        public AuthController(IHubContext<UsersHub> usersHub)
        {
            _hubContext = usersHub;
        }

        [HttpPost]
        [ProducesResponseType(typeof(AuthUser), StatusCodes.Status200OK)]
        public async Task<IActionResult> Login([FromBody]Credentials request)
        {
            await _hubContext.Clients.All.SendAsync("UserLogin");

            var token = Guid.NewGuid().ToString();
            var authUser = new AuthUser("success", token, request?.UserName ?? "");

            return Ok(authUser);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Logout()
        {
            await _hubContext.Clients.All.SendAsync("UserLogout");
            return Ok();
        }
    }
}