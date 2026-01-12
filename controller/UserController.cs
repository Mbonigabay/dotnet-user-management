using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using user_management_api.common;
using user_management_api.dto.request;
using user_management_api.dto.response;
using user_management_api.model;
using user_management_api.service;

namespace user_management_api.controller
{
    [ApiController]
    [Route("api/v1/users")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        private readonly UserService _userService;


        public UserController(ILogger<UserController> logger, UserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetUsers();
            return Ok(ApiResponse<List<UserResponse>>.SuccessResponse(
    users,
    "Users fetched successfully"
));
        }

        [HttpGet("by-username/{username}")]
        public async Task<IActionResult> GetUserByUsername(string username)
        {
            var user = await _userService.GetUserByUsername(username);

            if (user == null)
            {
                return NotFound(ApiResponse<UserResponse>.FailureResponse(
                    "User not found",
                    new List<string> { $"User with username '{username}' does not exist" }
                ));
            }

            return Ok(ApiResponse<UserResponse>.SuccessResponse(
                user,
                "User retrieved successfully"
            ));
        }


        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            var user = await _userService.CreateUser(request);
            return CreatedAtAction(nameof(GetUsers), new { id = user.Id }, ApiResponse<UserResponse>.SuccessResponse(
            user,
            "User created successfully"
        ));
        }

    }
}

