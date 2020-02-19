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
        public int Id;
        public string Title;

        public Author Author;
    }

    [Serializable]
    internal class Author
    {
        public string Name;
        public string Email;
    }

    [Serializable]
    class Publisher
    {
        public string Name;
        public string Country;
    }

    [Serializable]
    class Novel:Book
    {
        public int Pages;
        public int Edition;
        public Publisher Publisher;
    }
}
