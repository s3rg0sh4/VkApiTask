using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace VkApiTask.Entities
{
	public class User
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Login { get; set; }
		public string Password { get; set; }
		public DateTime Created { get; set; }

		public virtual UserGroup UserGroup { get; set; } = new UserGroup();
		public virtual UserState UserState { get; set; } = new UserState();

		public User() { }

		public User(string login, string password, bool? isAdmin)
		{
			Login = login;
			Password = password;
			Created = DateTime.Now.ToUniversalTime();

			if (isAdmin.HasValue && isAdmin.Value)
				UserGroup.Code = Enums.GroupCodes.Admin;
		}
	}
}
