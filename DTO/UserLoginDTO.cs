using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserLoginDTO
    {
        public string? Password { get; set; }

        //[EmailAddress(ErrorMessage = "your email not correct")]
        public string? Email { get; set; }



    }
}
