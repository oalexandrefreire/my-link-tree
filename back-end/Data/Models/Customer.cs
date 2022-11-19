using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Models
{
    public class Customer
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        [ForeignKey("TemplatesId")]
        public Template? Template { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }    
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? GithubEmail { get; set; }
        public bool? IsIndexable { get; set; }
        public string? DefaultLang { get; set; }
    }
}
