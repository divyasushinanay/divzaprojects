using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Auth
{

  
        public interface IAuthService
        {
            Task<string> SendCoachOtp(string email);
            Task<string> VerifyCoachOtp(string email, string otp);

        }
    }

   
