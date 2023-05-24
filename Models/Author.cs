﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace RSWEBBookShop.Models
{
    public class Author
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get { return String.Format("{0} {1}", FirstName, LastName); } }

        [DataType(DataType.Date)]
        [Display(Name = "Birth Date")]
        public DateTime? BirthDate { get; set; }
        [StringLength(50)]
        public string? Nationality { get; set; }
        [StringLength(50)]
        public string? Gender { get; set; }
        [Display(Name = "Books")]
        public ICollection<Book>? Books { get; set; }
    }

}
