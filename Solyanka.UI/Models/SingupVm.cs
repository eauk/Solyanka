using System.ComponentModel.DataAnnotations;

namespace Solyanka.UI.Models
{
    public class SingupVm
    {
        [Required(ErrorMessage = @"The field is required")]
        [Display(Name = "Name")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = @"The field must be minimum length of 4")]
        public string UserName { get; set; }

        [Required(ErrorMessage = @"The field is required")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = @"Email is invalid")]
        [EmailAddress(ErrorMessage = @"Email is invalid")]
        public string Email { get; set; }

        [Required(ErrorMessage = @"The field is required")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 7, ErrorMessage = @"The field must be minimum length of 7")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = @"The field is required")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 7, ErrorMessage = @"The field must be minimum length of 7")]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }
    }
}