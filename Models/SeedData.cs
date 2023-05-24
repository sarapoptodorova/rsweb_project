using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RSWEBBookShop.Areas.Identity.Data;
using RSWEBBookShop.Data;

namespace RSWEBBookShop.Models
{
    public class SeedData
    {
        public static async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            var RoleManager=serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<RSWEBBookShopUser>>();
            IdentityResult roleResult;

            var roleCheck = await RoleManager.RoleExistsAsync("Admin");
            if (!roleCheck)
            {
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Admin"));
            }

            RSWEBBookShopUser user = await UserManager.FindByEmailAsync("admin@mvcbook.com");
            if (user == null)
            {
                var User = new RSWEBBookShopUser();
                User.Email = "admin@mvcbook.com";
                User.UserName = "admin@mvcbook.com";
                string userPWD = "Admin123";
                IdentityResult chkUser = await UserManager.CreateAsync(User, userPWD);

                if (chkUser.Succeeded)
                {
                    var result = await UserManager.AddToRoleAsync(User, "Admin"); 
                }
            }
            IdentityResult roleResultUser;
            var roleCheckUser = await RoleManager.RoleExistsAsync("User");
            if (!roleCheckUser)
            {
                roleResultUser = await RoleManager.CreateAsync(new IdentityRole("User"));
            }
            RSWEBBookShopUser registered_user = await UserManager.FindByEmailAsync("sara@yahoo.com");
            if (registered_user == null)
            {
                var regUser = new RSWEBBookShopUser();
                regUser.Email = "sara@yahoo.com";
                regUser.UserName = "Sara";
                string regUserPWD = "Sara1234";
                IdentityResult chkRegUser = await UserManager.CreateAsync(regUser, regUserPWD);
                if (chkRegUser.Succeeded)
                {
                    var result1 = await UserManager.AddToRoleAsync(regUser, "User");
                }
            }
        }
        public static void Initalize(IServiceProvider serviceProvider)
        {
            using (var context = new RSWEBBookShopContext(
            serviceProvider.GetRequiredService<
            DbContextOptions<RSWEBBookShopContext>>()))
            {
                CreateUserRoles(serviceProvider).Wait();
                if (context.Book.Any() || context.Author.Any() || context.Review.Any() || context.Genre.Any() || context.UserBook.Any())
                {
                    return;
                }

                context.Author.AddRange(
                    new Author
                    {
                        //Id=1
                        FirstName = "Stephen",
                        LastName = "King",
                        BirthDate = DateTime.Parse("1947-09-27"),
                        Nationality = "American",
                        Gender = "Male"
                    },
                    new Author
                    {
                        //Id=2
                        FirstName = "Leo",
                        LastName = "Tolstoy",
                        BirthDate = DateTime.Parse("1937-02-10"),
                        Nationality = "Russian",
                        Gender = "Male"
                    },
                    new Author
                    {
                        //Id=3
                        FirstName = "Jane",
                        LastName = "Austen",
                        BirthDate = DateTime.Parse("1922-02-05"),
                        Nationality = "British",
                        Gender = "Female"
                    },
                    new Author
                    {
                        //Id=4
                        FirstName = "Joanne",
                        LastName = "Rowling",
                        BirthDate = DateTime.Parse("1952-11-15"),
                        Nationality = "British",
                        Gender = "Female"
                    },
                    new Author
                    {
                        //Id=5
                        FirstName = "James",
                        LastName = "Patterson",
                        BirthDate = DateTime.Parse("1922-12-12"),
                        Nationality = "American",
                        Gender = "Male"
                    },
                    new Author
                    {
                        //  Id = 6,
                        FirstName = "Kazuo",
                        LastName = "Ishiguro",
                        BirthDate = DateTime.Parse("1955-02-22"),
                        Nationality = "Japanese",
                        Gender = "Male"
                    },
                    new Author
                    {
                        // Id = 7,
                        FirstName = "Dan",
                        LastName = "Brown",
                        BirthDate = DateTime.Parse("1943-02-28"),
                        Nationality = "American",
                        Gender = "Male"
                    },
                    new Author
                    {
                        //Id = 8,
                        FirstName = "Colleen",
                        LastName = "Hoover",
                        BirthDate = DateTime.Parse("1925-04-01"),
                        Nationality = "American",
                        Gender = "Female"
                    }
                    );
                context.SaveChanges();

                context.Book.AddRange(
                    new Book
                    {
                        // Id = 1,
                        Title = "It starts with us",
                        YearPublished = 2020,
                        NumPages = 545,
                        Publisher = "Atria books",
                        FrontPage = "\\Images\\71PNGYHykrL._AC_UF1000,1000_QL80_.jpg",
                        DownloadUrl = "https://instapdf.in/it-starts-with-us/",
                        AuthorId = context.Author.Single(d => d.FirstName == "Colleen" && d.LastName == "Hoover").Id
                    },
                    new Book
                    {
                        // Id = 2,
                        Title = "It ends with us",
                        YearPublished = 2020,
                        NumPages = 455,
                        Publisher = "Simon",
                        FrontPage = "C:\\Users\\Sara\\Desktop\\sara\\VI semestar\\rsweb\\MVCBookApp\\MVCBookApp\\Images\\81s0B6NYXML._AC_UF1000,1000_QL80_.jpg",
                        DownloadUrl = "https://icrrd.com/media/15-05-2021-052358It-Ends-with-Us.pdf",
                        AuthorId = context.Author.Single(d => d.FirstName == "Colleen" && d.LastName == "Hoover").Id

                    },
                    new Book
                    {
                        //Id = 3,
                        Title = "The Da Vinci Code",
                        YearPublished = 2003,
                        NumPages = 806,
                        Publisher = "UK Bantam Books ",
                        FrontPage = "C:\\Users\\Sara\\Desktop\\sara\\VI semestar\\rsweb\\MVCBookApp\\MVCBookApp\\Images\\91Q5dCjc2KL._AC_UF1000,1000_QL80_.jpg",
                        DownloadUrl = "https://www.booksfree.org/the-da-vinci-code-pdf-free-download/",
                        AuthorId = context.Author.Single(d => d.FirstName == "Dan" && d.LastName == "Brown").Id
                    },
                    new Book
                    {
                        //Id = 4,
                        Title = "Angels and Demons",
                        YearPublished = 2006,
                        NumPages = 775,
                        Publisher = " Schuster",
                        FrontPage = "C:\\Users\\Sara\\Desktop\\sara\\VI semestar\\rsweb\\MVCBookApp\\MVCBookApp\\Images\\71H1acpbGaL.jpg",
                        DownloadUrl = "https://pubhtml5.com/aouj/jswg/Angels_and_Demons_-_Dan_Brown/495",
                        AuthorId = context.Author.Single(d => d.FirstName == "Dan" && d.LastName == "Brown").Id
                    },
                    new Book
                    {
                        // Id = 5,
                        Title = "Never Let Me Go",
                        YearPublished = 2005,
                        NumPages = 1003,
                        Publisher = "Faber",
                        FrontPage = "C:\\Users\\Sara\\Desktop\\sara\\VI semestar\\rsweb\\MVCBookApp\\MVCBookApp\\Images\\71m61vu42YL._AC_UF1000,1000_QL80_.jpg",
                        DownloadUrl = "https://www.swgs.wilts.sch.uk/wp-content/uploads/2021/05/Never-Let-Me-Go-by-Kazuo-Ishiguro.pdf",
                        AuthorId = context.Author.Single(d => d.FirstName == "Kazuo" && d.LastName == "Ishiguro").Id
                    },
                    new Book
                    {
                        // Id = 6,
                        Title = "Klara and the Sun",
                        YearPublished = 2021,
                        NumPages = 987,
                        Publisher = "Faber",
                        FrontPage = "C:\\Users\\Sara\\Desktop\\sara\\VI semestar\\rsweb\\MVCBookApp\\MVCBookApp\\Images\\71smjph9agl_custom-5d6f226a6893cad600edd5b03d35568fe7db5d7b-s1100-c50.jpg",
                        DownloadUrl = "https://yes-pdf.com/electronic-book/3387",
                        AuthorId = context.Author.Single(d => d.FirstName == "Kazuo" && d.LastName == "Ishiguro").Id
                    },
                    new Book
                    {
                        //  Id = 7,
                        Title = "Along Came a Spider",
                        YearPublished = 2021,
                        NumPages = 801,
                        Publisher = "Hachette Book Group",
                        FrontPage = "C:\\Users\\Sara\\Desktop\\sara\\VI semestar\\rsweb\\MVCBookApp\\MVCBookApp\\Images\\91as5fVKQQL._AC_UF1000,1000_QL80_.jpg",
                        DownloadUrl = "https://yes-pdf.com/book/4923/read",
                        AuthorId = context.Author.Single(d => d.FirstName == "James" && d.LastName == "Patterson").Id
                    },
                    new Book
                    {
                        //  Id = 8,
                        Title = "The Ink Black Heart",
                        YearPublished = 2022,
                        NumPages = 1220,
                        Publisher = "Giruus",
                        FrontPage = "C:\\Users\\Sara\\Desktop\\sara\\VI semestar\\rsweb\\MVCBookApp\\MVCBookApp\\Images\\51+zEqsKK8L.jpg",
                        DownloadUrl = "https://www.pdfread.net/ebook/the-ink-black-heart-robert-galbraith/",
                        AuthorId = context.Author.Single(d => d.FirstName == "Joanne" && d.LastName == "Rowling").Id
                    },
                    new Book
                    {
                        //  Id = 9,
                        Title = "Emma",
                        YearPublished = 1815,
                        NumPages = 922,
                        Publisher = "John murray",
                        FrontPage = "C:\\Users\\Sara\\Desktop\\sara\\VI semestar\\rsweb\\MVCBookApp\\MVCBookApp\\Images\\51nrg1To-kL._AC_UF1000,1000_QL80_.jpg",
                        DownloadUrl = "https://www.planetebook.com/emma/",
                        AuthorId = context.Author.Single(d => d.FirstName == "Jane" && d.LastName == "Austen").Id
                    },
                    new Book
                    {
                        // Id = 10,
                        Title = "War and Peace",
                        YearPublished = 1867,
                        NumPages = 1198,
                        Publisher = "The Russian Messenger",
                        FrontPage = "C:\\Users\\Sara\\Desktop\\sara\\VI semestar\\rsweb\\MVCBookApp\\MVCBookApp\\Images\\A1aDb5U5myL._AC_UF1000,1000_QL80_.jpg",
                        DownloadUrl = "https://www.planetebook.com/war-and-peace/",
                        AuthorId = context.Author.Single(d => d.FirstName == "Leo" && d.LastName == "Tolstoy").Id
                    },
                    new Book
                    {
                        // Id = 11,
                        Title = "The Shining",
                        YearPublished = 1977,
                        NumPages = 768,
                        Publisher = "Doubleday",
                        FrontPage = "C:\\Users\\Sara\\Desktop\\sara\\VI semestar\\rsweb\\MVCBookApp\\MVCBookApp\\Images\\11588.jpg",
                        DownloadUrl = "https://yes-pdf.com/book/3456/read",
                        AuthorId = context.Author.Single(d => d.FirstName == "Stephen" && d.LastName == "King").Id
                    }
                    );
                context.SaveChanges();

                context.Genre.AddRange(
                    new Genre
                    {
                        //Id=1
                        GenreName = "Science Fiction"
                    },
                    new Genre
                    {
                        //Id=2
                        GenreName = "Mystery"
                    },
                    new Genre
                    {
                        //Id=3
                        GenreName = "Action Fiction"
                    },
                    new Genre
                    {
                        //Id=4
                        GenreName = "Romance Novel"
                    }
                    );
                context.SaveChanges();

                context.BookGenre.AddRange(
                    new BookGenre { BookId = 1, GenreId = 1 },
                    new BookGenre { BookId = 2, GenreId = 1 },
                    new BookGenre { BookId = 3, GenreId = 1 },
                    new BookGenre { BookId = 4, GenreId = 2 },
                    new BookGenre { BookId = 5, GenreId = 2 },
                    new BookGenre { BookId = 6, GenreId = 3 },
                    new BookGenre { BookId = 7, GenreId = 3 },
                    new BookGenre { BookId = 8, GenreId = 3 },
                    new BookGenre { BookId = 9, GenreId = 2 }
                    );
                context.SaveChanges();

                context.Review.AddRange(
                    new Review
                    {
                        // Id = 1,
                        BookId = context.Book.Single(d => d.Title == "War and Peace").Id,
                        AppUser = "selpakcomfort",
                        Comment = "Cool...",
                        Rating = 60
                    },
                    new Review
                    {
                        //  Id = 2,
                        BookId = context.Book.Single(d => d.Title == "The Shining").Id,
                        AppUser = "fort333",
                        Comment = "Great...",
                        Rating = 80
                    },
                    new Review
                    {
                        // Id = 3,
                        BookId = context.Book.Single(d => d.Title == "Emma").Id,
                        AppUser = "catchme21",
                        Comment = "Wonderfull...",
                        Rating = 77
                    },
                    new Review
                    {
                        // Id = 4,
                        BookId = context.Book.Single(d => d.Title == "Angels and Demons").Id,
                        AppUser = "passion1",
                        Comment = "Amazing...",
                        Rating = 84
                    },
                    new Review
                    {
                        //  Id = 5,
                        BookId = context.Book.Single(d => d.Title == "The Ink Black Heart").Id,
                        AppUser = "catchme21",
                        Comment = "Wonderfull...",
                        Rating = 77
                    },
                    new Review
                    {
                        //   Id = 6,
                        BookId = context.Book.Single(d => d.Title == "The Ink Black Heart").Id,
                        AppUser = "catchme21",
                        Comment = "Wonderfull...",
                        Rating = 81
                    },
                    new Review
                    {
                        // Id = 7,
                        BookId = context.Book.Single(d => d.Title == "Emma").Id,
                        AppUser = "catchme21",
                        Comment = "Wonderfull...",
                        Rating = 91
                    }
                    );
                context.SaveChanges();

                context.UserBook.AddRange(
                    new UserBook
                    {
                        // Id = 1,
                        BookId = context.Book.Single(d => d.Title == "It starts with us").Id,
                        AppUser = "catchme21",
                    },
                    new UserBook
                    {
                        // Id = 2,
                        BookId = context.Book.Single(d => d.Title == "It ends with us").Id,
                        AppUser = "freelance21",
                    },
                    new UserBook
                    {
                        // Id = 3,
                        BookId = context.Book.Single(d => d.Title == "The Da Vinci Code").Id,
                        AppUser = "robert5",
                    },
                    new UserBook
                    {
                        //  Id = 4,
                        BookId = context.Book.Single(d => d.Title == "Angels and Demons").Id,
                        AppUser = "aweb111",
                    },
                    new UserBook
                    {
                        // Id = 5,
                        BookId = context.Book.Single(d => d.Title == "Never Let Me Go").Id,
                        AppUser = "aweb111",
                    },
                    new UserBook
                    {
                        // Id = 6,
                        BookId = context.Book.Single(d => d.Title == "Klara and the Sun").Id,
                        AppUser = "aweb111",
                    },
                    new UserBook
                    {
                        // Id = 7,
                        BookId = context.Book.Single(d => d.Title == "Along Came a Spider").Id,
                        AppUser = "selpakcomfort",
                    },
                    new UserBook
                    {
                        // Id = 8,
                        BookId = context.Book.Single(d => d.Title == "The Ink Black Heart").Id,
                        AppUser = "selpakcomfort",
                    },
                    new UserBook
                    {
                        // Id = 9,
                        BookId = context.Book.Single(d => d.Title == "Emma").Id,
                        AppUser = "passion1",
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
