using Microsoft.AspNetCore.Mvc.Rendering;
using RSWEBBookShop.Models;

namespace RSWEBBookShop.ViewModels
{
    public class BookGenresEditViewModel
    {
        public Book? Book { get; set; }
        public IEnumerable<int>? SelectedGenres { get; set; }
        public IEnumerable<SelectListItem>? GenresList { get; set; }
    }
}
