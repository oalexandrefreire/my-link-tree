using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    [Table("Contents")]
    public class Content
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("SectionsId")]
        public Section Section { get; set; }

        [ForeignKey("ProfilesId")]
        public Profile Profile { get; set; }

        public string? Description { get; set; }
        public string? Place { get; set; }
        public string? Position { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? FinishedAt { get; set; }
        public string? AttachmentUrl { get; set; }
        public bool IsVisible { get; set; }
    }
}
