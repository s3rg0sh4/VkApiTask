﻿namespace VkApiTask.DTOs
{
	public class CreateUserDTO
	{
		public string Login { get; set; }
		public string Password { get; set; }
		public bool? IsAdmin { get; set; }
	}
}
