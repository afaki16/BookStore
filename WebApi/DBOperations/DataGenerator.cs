using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi;
using WebApi.DBOperations;

namespace WepApi.DBOperations
{
    public class DataGenerator
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }

                context.Books.AddRange(
                    new Book
                    {
                       // Id = 1,
                        Title = "Lean Startup",
                        GenreId = 1,
                        PageCount = 100,
                        PublishDate = new DateTime(2021, 6, 12)

                    },
                    new Book
                    {
                        //Id = 2,
                        Title = "Herland",
                        GenreId = 2,
                        PageCount = 300,
                        PublishDate = new DateTime(2010, 4, 22)

                    },
                    new Book
                    {
                       // Id = 3,
                        Title = "Dune",
                        GenreId = 2,
                        PageCount = 700,
                        PublishDate = new DateTime(2012, 3, 27)

                    });

                    context.SaveChanges();
            }
        }
    }



}