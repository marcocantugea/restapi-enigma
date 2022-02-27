using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using enigma_core.Services;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;

namespace enigma_restapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        UserService service = new UserService();

        private readonly IConfiguration Configuration;

        public UsersController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpGet]
        [Authorize(Roles ="Administrator")]
        public async Task<IActionResult> user()
        {

            string secretKey = Configuration["Authentication:secretKey"];

            return Ok(await service.GetAllUsersAsync(10));
            //return Ok(secretKey);
        }

    }
}