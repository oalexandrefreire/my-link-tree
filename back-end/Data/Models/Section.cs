using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Models
{
    public class Section
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
