using Restaurant.Application.Models.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Interfaces
{
    public interface IEmailSender
    {
        Task<bool> SendEmail( EmailMessage emailMessage);
    }
}
