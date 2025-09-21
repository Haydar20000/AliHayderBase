using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AliHayderBase.Shared.DTOs.Request
{
    public class ResetPasswordRequestDto
    {
        [Required(ErrorMessage = "Password is required")]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public required string Password { get; set; }
        public required string Otp { get; set; }
        public required string Email { get; set; }
    }
}