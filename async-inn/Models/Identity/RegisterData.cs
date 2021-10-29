﻿using System;
using System.ComponentModel.DataAnnotations;

namespace async_inn.Models.Identity
{

    public class RegisterData
    {
     [Required]
     [EmailAddress]

     public string Email { get; set; }

     [Required]
     public string Username { get; set; }

     [Required]
     public string Password { get; set; }

     public bool AcceptedTerms { get; set; }

     public string[] Roles { get; set; }

    }
}
