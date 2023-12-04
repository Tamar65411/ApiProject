using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserDTO

    {

        public string? Password { get; set; }

        [MinLength(3, ErrorMessage = "incorrect first name")]
        public string? FirstName { get; set; }

        [MinLength(3, ErrorMessage = "incorrect last name")]
        public string? LastName { get; set; }

       [EmailAddress(ErrorMessage = "your email not correct")]
        public string? Email { get; set; }



    }
}
