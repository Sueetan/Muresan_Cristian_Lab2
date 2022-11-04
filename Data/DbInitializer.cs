﻿using Microsoft.EntityFrameworkCore;
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

                context.Books.AddRange( 
                new Book {
                    Title = "Baltagul",
                    Author = "Mihail Sadoveanu",Price=Decimal.Parse("22")
                },
                new Book
                {
                    Title = "Enigma Otiliei",
                    Author = "George Calinescu",Price=Decimal.Parse("18")
                },
                new Book
                {
                    Title = "Maytrei",
                    Author = "Mircea Eliade",Price=Decimal.Parse("27")
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