using System.ComponentModel.DataAnnotations;

namespace AiGenericPostTool.Models
{
    public class Base
    {
        [Key]
        public int Id { get; set; }
        public string? CreatedBy { get; set; } = "";
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; } = "";
        public DateTime? UpdatedDate { get; set; } = null;

        public bool IsDelete { get; set; } = false; // Soft Delete 
        public string? DeletedBy { get; set; } = "";

        public DateTime? DeletedDate { get; set; } = null;
    }
}
