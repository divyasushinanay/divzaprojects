using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Auth
{

  
        public interface IAuthService
        {
        //Task<string> SendCoachOtp(string email);
        //Task<string> VerifyCoachOtp(string email, string otp);

        //Task<string> SendParentOtp(string email);
        //Task<string> VerifyParentOtp(string email, string otp);
        Task<string> SendCoachOtpAsync(string email);
        Task<string> VerifyCoachOtpAsync(string email, string otp);

        Task<string> SendParentOtpAsync(string email);
        Task<string> VerifyParentOtpAsync(string email, string otp);
    }
    }

   
