using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

using VkApiTask.Enums;

namespace VkApiTask.Entities
{
	public class UserState
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[JsonConverter(typeof(JsonStringEnumConverter))]
		public StateCodes Code { get; set; }
		public string Description { get; set; } = string.Empty;
	}
}
