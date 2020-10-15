using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityVerificationAPI.Business;
using IdentityVerificationAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityVerificationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class IdentityVerification : ControllerBase
    {

        private IVerifyManager _verifyManager;
        public IdentityVerification(IVerifyManager verifyManager)
        {
            _verifyManager = verifyManager;
        }

        [HttpGet]
        public IActionResult Get([FromBody] Person person)
        {
            var durum = _verifyManager.VerifyPerson(person).Result;
            if (durum)
            {
                return Ok(durum);
            }
            return NotFound(durum);

        }
    }
}
