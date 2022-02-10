using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model.Others;

namespace Rezervisi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmail _service;
        public EmailController(IEmail service)
        {
            _service = service;
        }
        [HttpPost("SendMail")]
        public virtual Response SendMail(MailSender model)
        {
            return _service.SendMail(model);
        }
        [HttpPost("SendConnMail")]
        public virtual Response SendConnMail(VisitMail model)
        {
            return _service.SendConnMail(model);
        }
    }
}
