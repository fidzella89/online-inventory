using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineInventory.Models;
using OnlineInventory.ViewModels;

namespace OnlineInventory.Controllers;

[ApiController]
[Route("api/auth")]
[Produces("application/json")]
public class AuthApiController : ControllerBase
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public AuthApiController(
        SignInManager<ApplicationUser> signInManager,
        UserManager<ApplicationUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    /// <summary>
    /// Login with email/username and password
    /// </summary>
    /// <param name="model">Login credentials</param>
    /// <returns>Login result with user information</returns>
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginApiRequest model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new { message = "Invalid request data", errors = ModelState });
        }

        try
        {
            // Try to find user by email or username
            var user = await _userManager.FindByEmailAsync(model.Email) ?? 
                      await _userManager.FindByNameAsync(model.Email);

            if (user == null)
            {
                return Unauthorized(new { message = "Invalid email/username or password" });
            }

            var result = await _signInManager.PasswordSignInAsync(
                user.UserName!, 
                model.Password, 
                model.RememberMe, 
                lockoutOnFailure: true);

            if (result.Succeeded)
            {
                // Get user roles
                var roles = await _userManager.GetRolesAsync(user);
                
                return Ok(new
                {
                    message = "Login successful",
                    user = new
                    {
                        id = user.Id,
                        email = user.Email,
                        userName = user.UserName,
                        fullName = user.FullName,
                        roles = roles,
                        isActive = user.LockoutEnabled
                    }
                });
            }

            if (result.IsLockedOut)
            {
                return Unauthorized(new { message = "Account locked due to multiple failed attempts. Try again later." });
            }

            return Unauthorized(new { message = "Invalid email/username or password" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred during login", error = ex.Message });
        }
    }

    /// <summary>
    /// Logout the current user
    /// </summary>
    /// <returns>Logout confirmation</returns>
    [HttpPost("logout")]
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        try
        {
            await _signInManager.SignOutAsync();
            return Ok(new { message = "Logout successful" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred during logout", error = ex.Message });
        }
    }

    /// <summary>
    /// Get current user information
    /// </summary>
    /// <returns>Current user details</returns>
    [HttpGet("me")]
    [Authorize]
    public async Task<IActionResult> GetCurrentUser()
    {
        try
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized(new { message = "User not found" });
            }

            var roles = await _userManager.GetRolesAsync(user);
            
            return Ok(new
            {
                id = user.Id,
                email = user.Email,
                userName = user.UserName,
                fullName = user.FullName,
                roles = roles,
                isActive = user.LockoutEnabled
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred", error = ex.Message });
        }
    }
}

/// <summary>
/// Login request model for API
/// </summary>
public class LoginApiRequest
{
    /// <summary>
    /// Email or Username
    /// </summary>
    /// <example>admin@inventory.com</example>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Password
    /// </summary>
    /// <example>admin123</example>
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// Remember me option
    /// </summary>
    /// <example>false</example>
    public bool RememberMe { get; set; } = false;
}
