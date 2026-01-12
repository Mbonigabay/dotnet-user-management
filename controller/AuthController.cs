using Microsoft.AspNetCore.Mvc;
using user_management_api.common;
using user_management_api.dto.request;
using user_management_api.dto.response;
using user_management_api.service;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly UserService _userService;

    public AuthController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var result = await _userService.LoginAsync(
            request.Username,
            request.Password
        );

        if (result == null)
        {
            return Unauthorized(ApiResponse<AuthResponse>.FailureResponse(
                "Invalid credentials"
            ));
        }

        return Ok(ApiResponse<AuthResponse>.SuccessResponse(
            result,
            "Login successful"
        ));
    }
}
