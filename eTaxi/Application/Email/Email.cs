using Application.Interfaces;
using Model.Others;
using Persistence;

namespace Application.Email
{
    public partial class Email : IEmail
    {
        private readonly EmailConfiguration _emailConfig;
        private  readonly ApplicationSettings _applicationSettings;
        private readonly eTaxiDbContext _context;

        public Email(EmailConfiguration emailConfig, ApplicationSettings applicationSettings, eTaxiDbContext context)
        {
            _emailConfig = emailConfig;
            _applicationSettings = applicationSettings;
            _context = context;
        }

       
    }
}
