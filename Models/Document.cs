using System.ComponentModel.DataAnnotations;

namespace WebsiteNoiBoCongTy.Models
{
    public class Document
    {
        [Key]
        public int DocId { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? DocUrl { get; set; }
        [Required]
        public string? Type { get; set; }
    }
}
