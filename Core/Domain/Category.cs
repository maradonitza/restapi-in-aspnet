using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookstoreApi.Core.Domain
{
    public class Category
    {
        public Category()
        {
            Books = new HashSet<Book>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}