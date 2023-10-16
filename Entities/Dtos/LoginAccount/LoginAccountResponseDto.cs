using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.LoginAccount
{
    public class LoginAccountResponseDto : ResponseResultDto
    {
        public LoginAccount LoginData { get; set; }
    }
    public class LoginAccount
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
