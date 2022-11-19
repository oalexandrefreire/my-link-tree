using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Data.Models
{
    public class Template
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? PreviewImageUrl { get; set; }
        public string? StyleCss { get; set; }

        [JsonIgnore]
        public bool? IsActive { get; set; }
        public string? FooterLogoUrl { get; set; }
    }
}
