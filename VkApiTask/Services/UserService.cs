using Microsoft.EntityFrameworkCore;

using VkApiTask.DB;
using VkApiTask.Entities;

namespace VkApiTask.Services
{
	public class UserService : IUserService
	{
		private static readonly List<string> logins = new();

		private readonly Context _context;

		public UserService(Context context)
		{
			_context = context;
		}

		public async Task AddUserAsync(string login, string password, bool? isAdmin)
		{
			if (isAdmin.HasValue && isAdmin.Value
				&& (await _context.Users.FirstOrDefaultAsync(u => u.UserGroup.Code == Enums.GroupCodes.Admin) != null))
				throw new Exception("Admin already exist");

			if (logins.Contains(login))
				throw new Exception("User is currently creating");

			if (await _context.Users.FirstOrDefaultAsync(u => u.Login == login) != null)
				throw new Exception("User already exist");

			logins.Add(login);
			Thread.Sleep(5000);

			var user = new User(login, password, isAdmin);
			await _context.Users.AddAsync(user);
			await _context.SaveChangesAsync();

			logins.Remove(login);
		}

		public async Task BlockUserAsync(string login)
		{
			var user = _context.Users.Single(user => user.Login == login);
			user.UserState.Code = Enums.StateCodes.Blocked;
			await _context.SaveChangesAsync();
		}

		public async Task<User> FindUser(string login)
		{
			var user = await _context.Users.FirstOrDefaultAsync(u => u.Login == login);

			if (user == null)
				throw new Exception("User doesn`t exist");

			return user;
		}

		public async Task<List<User>> UserList()
		{
			var list = await _context.Users.ToListAsync();
			return list;
		}
	}
}
