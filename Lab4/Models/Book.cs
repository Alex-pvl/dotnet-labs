using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Lab4.Models
{
    [Serializable]
    public class Book
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string Title { get; set; }

        public string? Description { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Author { get; set; }

        [Required]
        public int Count { get; set; }
    }
}
