using System.ComponentModel.DataAnnotations;

namespace Solyanka.UI.Models
{
    public class LoginVm
    {
            [Required(ErrorMessage = @"The field is required")]
            [Display(Name = "Name or email")]
            [StringLength(20, MinimumLength = 4, ErrorMessage = @"The field must be minimum length of 4")]
            public string UserName { get; set; }

            [Required(ErrorMessage = @"The field is required")]
            [DataType(DataType.Password)]
            [StringLength(20, MinimumLength = 7, ErrorMessage = @"The field must be minimum length of 7")]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
         
    }
}