using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace SerializationDemo
{

    class Program
    {
        static void Main(string[] args)
        {
            Book novelAsBook = new Novel
            {
                Author = new Author { Email = "author@domain.com", Name = "Author One" },
                Edition = 12,
                Id = 1234,
                Pages = 300,
                Publisher = new Publisher
                {
                    Name = "Publisher One",
                    Country = "India"
                },
                Title = "Some Good Novel"
            };

            var serializationStream = Serialize(novelAsBook);
            var streamReaderInstance = new StreamReader(serializationStream);

            Console.WriteLine(streamReaderInstance.ReadToEnd());

            serializationStream.Position = 0;

            //  This is now polymorphic. Type is Book but implementation is Novel
            var deserializedNovel = Deserialize<Book>(serializationStream);
        }

        static Stream Serialize<T>(T source)
        {
            var memoryStream = new MemoryStream();
            var serializer = new DataContractSerializer(typeof(T));

            serializer.WriteObject(memoryStream, source);
            memoryStream.Position = 0;

            return memoryStream;
        }

        static T Deserialize<T>(Stream serializationStream)
        {
            var serializer = new DataContractSerializer(typeof(T));
            return (T) serializer.ReadObject(serializationStream);
        }
    }
}
