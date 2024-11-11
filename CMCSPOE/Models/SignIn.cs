﻿using System.ComponentModel.DataAnnotations;

namespace CMCSPOE.Models
{
    public class SignIn
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string? Email { get; set; }
        
        [Required(ErrorMessage = "Password is required.")]
        public string? Password { get; set; } 
    
        public string? Username { get; set; }
    }
}