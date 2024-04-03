using System.ComponentModel.DataAnnotations.Schema;

namespace AiGenericPostTool.Models
{
    public class Prompt : Base
    {
        public string? Name { get; set; } = "";
        public string? Content { get; set; } = "";
        public string? ExtraProperty { get; set; } = "";
        public int PlatformId { get; set; }

        [ForeignKey("PlatformId")]

        public Platform GetPlatform { get; set; }
    }
}
