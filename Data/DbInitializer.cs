using Microsoft.EntityFrameworkCore;
using Muresan_Cristian_Lab2.Models;

namespace Muresan_Cristian_Lab2.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LibraryContext(serviceProvider.GetRequiredService<DbContextOptions<LibraryContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }

                context.AddRange(
                    new Author { 
                        FirstName = "Mihail", 
                        LastName = "Sadoveanu"
                    },
                    new Author
                    {
                        FirstName = "George",
                        LastName = "Calinescu"
                    },
                    new Author
                    {
                        FirstName = "Mircea",
                        LastName = "Eliade"
                    });

                context.SaveChanges();

                context.Books.AddRange( 
                new Book {
                    Title = "Baltagul",
                    AuthorId = context.Authors.Where(x => x.FirstName == "Mihail").Select(x => x.Id).First(),
                    Price = Decimal.Parse("22")
                },
                new Book
                {
                    Title = "Enigma Otiliei",
                    AuthorId = context.Authors.Where(x => x.FirstName == "George").Select(x => x.Id).First(),
                    Price = Decimal.Parse("18")
                },
                new Book
                {
                    Title = "Maytrei",
                    AuthorId = context.Authors.Where(x => x.FirstName == "Mircea").Select(x => x.Id).First(),
                    Price = Decimal.Parse("27")
                });


                context.Customers.AddRange(
                new Customer
                {
                    Name = "Popescu Marcela",
                    Address = "Str. Plopilor, nr. 24",
                    BirthDate = DateTime.Parse("1979-09-01")
                },
                new Customer
                {
                    Name = "Mihailescu Cornel",
                    Address = "Str. Bucuresti, nr.45, ap. 2",
                    BirthDate=DateTime.Parse("1969-07-08")
                });

                context.SaveChanges();
            }

        }
    }
}
