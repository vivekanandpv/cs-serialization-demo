using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SerializationDemo
{
    [Serializable]
    abstract class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public Author Author { get; set; }
    }

    [Serializable]
    internal class Author
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }

    [Serializable]
    class Publisher
    {
        
        public string Name { get; set; }
        public string Country { get; set; }
    }

    [Serializable]
    class Novel:Book
    {
        public int Pages { get; set; }
        public int Edition { get; set; }
        public Publisher Publisher { get; set; }
    }
}
