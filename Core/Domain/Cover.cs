using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookstoreApi.Core.Domain
{
    public class Cover
    {
        public int Id { get; set; }
        public Book Book { get; set; }
    }
}