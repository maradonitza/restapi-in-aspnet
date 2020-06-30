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
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Book Book { get; set; }
    }
}