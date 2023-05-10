using System.Net.Http.Headers;
using System.Text;
using VkApiTask.Services;

namespace VkApiTask.Middleware
{
	public class AuthMiddleware
	{
		private readonly RequestDelegate _next;

		public AuthMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext context, IAuthService authService)
		{
			try
			{
				var authHeader = AuthenticationHeaderValue.Parse(context.Request.Headers["Authorization"]);
				var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
				var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':', 2);
				var username = credentials[0];
				var password = credentials[1];

				// authenticate credentials with user service and attach user to http context
				context.Items["User"] = await authService.Authenticate(username, password);
			}
			catch { }

			await _next(context);
		}
	}
}
