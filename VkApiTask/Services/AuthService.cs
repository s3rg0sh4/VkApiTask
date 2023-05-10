using VkApiTask.DB;
using VkApiTask.Entities;

namespace VkApiTask.Services
{
	public class AuthService : IAuthService
	{
		private readonly Context _context;

		public AuthService(Context context) 
		{
			_context = context;
		}

		public async Task<User> Authenticate(string login, string password)
		{
			var user = await Task.FromResult(_context.Users.SingleOrDefault(x => x.Login == login && x.Password == password));

			return user;
		}
	}
}
