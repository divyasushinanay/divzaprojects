using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Auth
{
    
       
        public interface IJwtService
        {
            string GenerateToken(Guid id, string name, string email, string role);

           
            string GenerateAcademyToken(Guid id, string username, string email, Role role);
        }
    }
    


