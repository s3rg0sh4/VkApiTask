using VkApiTask.Entities;

namespace VkApiTask.Services
{
	public interface IUserService
	{
		Task AddUserAsync(string login, string password, bool? isAdmin);
		Task BlockUserAsync(string login);
		Task<List<User>> UserList();
		Task<User> FindUser(string login);

	}
}
