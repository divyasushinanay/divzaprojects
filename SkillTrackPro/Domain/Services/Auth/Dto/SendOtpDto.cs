using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Auth.Dto
{
    public class SendOtpDto
    {
        public string Email { get; set; } = string.Empty;
    }
}
