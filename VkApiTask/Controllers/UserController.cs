using Microsoft.AspNetCore.Mvc;

using VkApiTask.DTOs;
using VkApiTask.Entities;
using VkApiTask.Services;

namespace VkApiTask.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class UserController : Controller
	{
		private readonly IUserService _userService;

		public UserController(IUserService userService)
		{
			_userService = userService;
		}

		[HttpPost]
		public async Task<IActionResult> CreateUser(CreateUserDTO dto)
		{
			await _userService.AddUserAsync(dto.Login, dto.Password, dto.IsAdmin);

			return Ok();
		}

		[HttpGet]
		public async Task<IActionResult> GetUserByEmail(string login)
		{
			return Ok(await _userService.FindUser(login));
		}

		[HttpGet]
		[Route("/List")]
		public async Task<IActionResult> GetUserList()
		{
			var list = await _userService.UserList();
			return Ok(list);
		}


		[HttpGet]
		[Route("/Page")]
		public async Task<IActionResult> GetPaginatedUsers(int items, int offset)
		{
			var userList = await _userService.UserList();
			var paginatedUsers = new List<User>();

			

			for (int i = offset; i < items + offset; i++)
			{
				try
				{
					paginatedUsers.Add(userList[i]);
				}
				catch
				{
					break;
				}
			}

			return Ok(paginatedUsers);
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteUser(string login)
		{
			await _userService.BlockUserAsync(login);

			return Ok();
		}
	}
}
