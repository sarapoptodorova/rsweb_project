using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace RSWEBBookShop.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [StringLength(50)]
        [Required]
        [Display(Name = "Genre Name")]
        public string GenreName { get; set; }
        public ICollection<BookGenre>? Books { get; set; }
    }
}
