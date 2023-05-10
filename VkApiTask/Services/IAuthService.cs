using VkApiTask.Entities;

namespace VkApiTask.Services
{
	public interface IAuthService
	{
		Task<User> Authenticate(string login, string password);
	}
}
