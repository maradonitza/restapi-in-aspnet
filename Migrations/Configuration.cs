namespace BookstoreApi.Migrations
{
    using BookstoreApi.Core.Domain;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BookstoreApi.Persistence.BookstoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BookstoreApi.Persistence.BookstoreContext context)
        {
            var authors = new List<Author>
            {
                new Author
                {
                    Id = 1,
                    Name = "Bertrand Russel"
                },
                new Author
                {
                    Id = 2,
                    Name = "George Orwell"
                },
                new Author
                {
                    Id = 3,
                    Name = "Lev Tolstoi"
                },
                new Author
                {
                    Id = 4,
                    Name = "Alvin Toffler"
                },
                new Author
                {
                    Id = 5,
                    Name = "Parinoush Saniee"
                },
                new Author
                {
                    Id = 6,
                    Name = "Shahaab Shahaab"
                }
            };

            foreach (var author in authors)
                context.Authors.AddOrUpdate(a => a.Id, author);

            var publishingHouses = new List<PublishingHouse>() {
                new PublishingHouse
                {
                    Id = 1,
                    Name = "Bed and breakfast"
                },
                new PublishingHouse
                {
                    Id = 2,
                    Name = "Wisdom House"
                },
                new PublishingHouse
                {
                    Id = 3,
                    Name = "Thompson"
                },
                new PublishingHouse
                {
                    Id = 4,
                    Name = "Penguin Random House"
                },
                new PublishingHouse
                {
                    Id = 5,
                    Name = "Hachette Livre"
                },
                new PublishingHouse
                {
                    Id = 6,
                    Name = "Routledge Classics"
                }
            };

            foreach (var publishingHouse in publishingHouses)
                context.PublishingHouses.AddOrUpdate(p => p.Id, publishingHouse);


            var categories = new List<Category>() {
                new Category
                {
                    Id = 1,
                    Name = "Science fiction"
                },
                new Category
                {
                    Id = 2,
                    Name = "Literature"
                },
                new Category
                {
                    Id = 3,
                    Name = "Science & Technology"
                },
                new Category
                {
                    Id = 4,
                    Name = "Historical fiction"
                },
                new Category
                {
                    Id = 5,
                    Name = "Poetry"
                }
            };

            foreach (var category in categories)
                context.Categories.AddOrUpdate(c => c.Id, category);


            var books = new List<Book>()
            {
                new Book()
                {
                    Id = 1,
                    Name = "The third wave",
                    Authors = new Collection<Author>() { authors[3] },
                    Category = categories[1],
                    Description = "The classic study of tomorrow",
                    Price = 50,
                    PublishingHouseId = 4
                },
                new Book()
                {
                    Id = 2,
                    Name = "Impact of science of society",
                    Authors = new Collection<Author>() { authors[1] },
                    Category = categories[3],
                    Description = "In this concise and luminous book, the winner of the 1950 Nobel Prize for Literature and perhaps the outstanding philosopher of our time - regarded by many educators, scholars and critics as the most original English thinker since David Hume - examines the changes in modern life brought about by science. He suggests that its work in transforming society is only just beginning,,, He shows that science now offeres the possibility of far greater well-being for humanity than it has ever known before..., In his final chapter the suthor faces the fundamental question of our time: can a scientific society be stable? He groups the possible causes of instability under three heads: physical, biological, and psychological. - excerpts from book's synopsis",
                    Price = 100,
                    PublishingHouseId = 5
                },
                new Book()
                {
                    Id = 3,
                    Name = "I hid my voice",
                    Authors = new Collection<Author>() { authors[4], authors[5] },
                    Category = categories[2],
                    Description = "This is the story, based on fact, of a boy who couldn't speak until the age of seven. Now twenty, he describes the events of his life.",
                    Price = 55,
                    PublishingHouseId = 3
                }
            };

            foreach (var book in books)
                context.Books.AddOrUpdate(b => b.Id, book);


            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
