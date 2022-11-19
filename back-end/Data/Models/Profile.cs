using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Models
{
    public class Profile
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        [ForeignKey("CustomersId")]
        [JsonIgnore]
        public Customer Customer { get; set; }

        public string? Nationality { get; set; }
        public string? MaritalStatus { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Address { get; set; }
        public string? Neighborhood { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? FullName { get; set; }
        public string? ImageUrl { get; set; }
        public string? LinkedinUrl { get; set; }
        public ICollection<Content> Contents { get; set; }
    }
}
