using RSWEBBookShop.Models;

namespace RSWEBBookShop.ViewModels
{
    public class BookGenreViewModel
    {
        public IList<Book> Books { get; set; }
        public string SearchString { get; set; }
    }
}
