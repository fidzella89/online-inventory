using System.ComponentModel.DataAnnotations;

namespace OnlineInventory.ViewModels;

public class LoginViewModel
{
    [Required]
    [Display(Name = "Email/Username")]
    public string Email { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; } = string.Empty;

    [Display(Name = "Remember me")]
    public bool RememberMe { get; set; }
}

