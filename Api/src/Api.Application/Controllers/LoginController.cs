﻿using Domain.Dtos;
using Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        public async Task<object> Login([FromBody] LoginDto loginDto, [FromServices] ILoginService service) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (loginDto == null)
                return BadRequest();

            try
            {
                var result = await service.FindByLogin(loginDto);
                if (result != null)
                    return Ok(result);

                return NotFound();
            }
            catch(ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}
