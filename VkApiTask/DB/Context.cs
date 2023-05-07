using Microsoft.EntityFrameworkCore;

using VkApiTask.Entities;
using VkApiTask.Enums;

namespace VkApiTask.DB
{
	public class Context : DbContext
	{
		public DbSet<User> Users { get; set; } = null!;
		public DbSet<UserGroup> UserGroups { get; set; } = null!;
		public DbSet<UserState> UserStates { get; set; } = null!;

		public Context(DbContextOptions<Context> options) : base (options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<UserState>()
				.Property(s => s.Code)
				.HasConversion<string>();

			modelBuilder.Entity<UserGroup>()
				.Property(g => g.Code)
				.HasConversion<string>();

			base.OnModelCreating(modelBuilder);
		}
	}
}
