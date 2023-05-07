using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

using VkApiTask.Enums;
using System.Text.Json.Serialization;

namespace VkApiTask.Entities
{
	public class UserGroup
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[JsonConverter(typeof(JsonStringEnumConverter))]
		public GroupCodes Code { get; set; }
		public string Description { get; set; } = string.Empty;
	}
}
