using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebsiteNoiBoCongTy.Models
{
    public class WorkSchedule
    {
        [Key]
        public int WsgId { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Content { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime Deadline { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
