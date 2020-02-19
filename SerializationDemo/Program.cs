using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SerializationDemo
{

    class Program
    {
        static void Main(string[] args)
        {
            var novel1 = new Novel
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

            var serializationStream = Serialize(novel1);
            var streamReaderInstance = new StreamReader(serializationStream);

            Console.WriteLine(streamReaderInstance.ReadToEnd());

            serializationStream.Position = 0;

            var deserializedNovel = Deserialize<Novel>(serializationStream);
        }

        static Stream Serialize<T>(T source)
        {
            var memoryStream = new MemoryStream();
            var formatter = new BinaryFormatter();

            formatter.Serialize(memoryStream, source);
            memoryStream.Position = 0;

            return memoryStream;
        }

        static T Deserialize<T>(Stream serializationStream)
        {
            var formatter = new BinaryFormatter();
            return (T)formatter.Deserialize(serializationStream);
        }
    }
}
