using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Models
{
    public class Link
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        [ForeignKey("CustomersId")]
        [JsonIgnore]
        public Customer Customer { get; set; }
        [JsonIgnore]
        public int? LinksId { get; set; }
        [JsonIgnore]
        public int Position { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string? StyleCss { get; set; }

        [JsonIgnore]
        public bool IsActive { get; set; }
    }
}
