using FanturApp.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FanturApp.Interface.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpamController : ControllerBase
    {
        private readonly ISpamBusiness _spamBusiness;

        public SpamController(ISpamBusiness spamBusiness)
        {
            _spamBusiness = spamBusiness;
        }

        [HttpGet()]
        //[Authorize(Roles = "Admin")]
        [ProducesResponseType(200, Type = typeof(ICollection<String>))]
        public IActionResult GetAllSubscribedUsersEmail()
        {

            var emails = _spamBusiness.GetSubUsersEmails();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(emails);
        }
    }
}
