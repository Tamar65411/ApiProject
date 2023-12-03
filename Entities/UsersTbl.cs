using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities;

public partial class UsersTbl
{
    public int UserId { get; set; }

    public string? Password { get; set; }
    //[MinLength(3, ErrorMessage = "incorrect first name")]
    public string? FirstName { get; set; }
    //[MinLength(3, ErrorMessage = "incorrect last name")]
    public string? LastName { get; set; }

    //[EmailAddress(ErrorMessage = "your email not correct")]
    public string? Email { get; set; }

    public virtual ICollection<OrdersTbl> OrdersTbls { get; set; } = new List<OrdersTbl>();
}
