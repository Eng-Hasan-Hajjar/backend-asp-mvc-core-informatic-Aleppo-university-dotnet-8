using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace informatic_asp_mvc.Models;

public partial class User
{
    public int Id { get; set; }

    public string? FullName { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }

    public string? PasswordHash { get; set; }

    public string? Role { get; set; }

    [StringLength(10)]
    public string UniversityId { get; set; }

    public DateTime? CreatedAt { get; set; }


  


}
