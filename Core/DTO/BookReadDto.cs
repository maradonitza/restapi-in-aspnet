using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookstoreApi.Core.DTO
{
    public class BookReadDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Authors { get; set; }
        public float Price { get; set; }
    }
}