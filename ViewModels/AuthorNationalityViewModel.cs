using Microsoft.AspNetCore.Mvc.Rendering;
using RSWEBBookShop.Models;

namespace RSWEBBookShop.ViewModels
{
    public class AuthorNationalityViewModel
    {
        public IList<Author> Authors { get; set; }
        public SelectList Nationalities { get; set; }
        public string authorNationality { get; set; }
        public string searchString { get; set; }
    }
}
