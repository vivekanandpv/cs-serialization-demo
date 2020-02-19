using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;

namespace SerializationDemo
{

    class Program
    {
        static void Main(string[] args)
        {
            //  Now, Author doesn't have Serializable attribute. The formatter is unaware of this,
            //  till the time it tries to serialize the object graph. At this time, part of the novel
            //  is serialized. Hence the corruption in underlying memory stream. Therefore an exception
            //  is thrown.
            var publisher = new Publisher
            {
                Name = "Publisher One",
                Country = "India"
            };

            var novel1 = new Novel
            {
                Author = new Author { Email = "author@domain.com", Name = "Author One" },
                Edition = 12,
                Id = 1234,
                Pages = 300,
                Publisher =  publisher,
                Promoter = publisher,
                Title = "Some Good Novel"
            };

            IFormatter soapFormatter = new SoapFormatter();
            //  IFormatter binaryFormatter = new BinaryFormatter();

            var serializationStream = Serialize(novel1, soapFormatter);
            var streamReaderInstance = new StreamReader(serializationStream);

            Console.WriteLine(streamReaderInstance.ReadToEnd());

            serializationStream.Position = 0;

            //  this will not have publisher's name deserialized
            var deserializedNovel = Deserialize<Novel>(serializationStream, soapFormatter);

            //  By default, the reference integrity is preserved in binary and soap serialization
            //  this is a significant gain in performance in larger object graphs
            Console.WriteLine(object.ReferenceEquals(deserializedNovel.Publisher, deserializedNovel.Promoter));
        }

        static Stream Serialize<T>(T source, IFormatter formatter)
        {
            var memoryStream = new MemoryStream();
            formatter.Serialize(memoryStream, source);
            memoryStream.Position = 0;

            return memoryStream;
        }

        static T Deserialize<T>(Stream serializationStream, IFormatter formatter)
        {
            return (T)formatter.Deserialize(serializationStream);
        }
    }
}
