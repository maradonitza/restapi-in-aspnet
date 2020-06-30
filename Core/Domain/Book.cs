using System.Collections.Generic;

namespace BookstoreApi.Core.Domain
{
    public class Book
    {
        public Book()
        {
            Authors = new HashSet<Author>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public float Price { get; set; }

        public virtual PublishingHouse PublishingHouse { get; set; }

        public int PublishingHouseId { get; set; }

        public virtual ICollection<Author> Authors { get; set; }
        public Category Category { get; set; }

        public Cover Cover { get; set; }

    }
}