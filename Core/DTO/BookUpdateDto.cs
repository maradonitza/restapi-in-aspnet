using BookstoreApi.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookstoreApi.Core.DTO
{
    public class BookUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int PublishingHouseId { get; set; }
        public int CategoryId { get; set; }
        public ICollection<Author> Authors { get; set; }

    }
}