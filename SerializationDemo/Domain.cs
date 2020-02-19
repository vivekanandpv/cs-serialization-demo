using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SerializationDemo
{
    [DataContract]
    abstract class Book
    {
        [DataMember]
        public int Id;
        [DataMember]
        public string Title;
        [DataMember]
        public Author Author;
    }

    [DataContract]
    internal class Author
    {
        [DataMember]
        public string Name;
        public string Email;
    }

    [Serializable]
    class Publisher
    {
        
        public string Name;
        public string Country;
    }

    [DataContract]
    class Novel:Book
    {
        [DataMember]
        public int Pages;
        public int Edition;
        [DataMember]
        public Publisher Publisher;
    }
}
