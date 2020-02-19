using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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
            
            var serializer = new DataContractSerializer(typeof(Book), null, int.MaxValue, false, false, null, new NovelResolver());
            var serializationStream = Serialize(novelAsBook, serializer);
            var streamReaderInstance = new StreamReader(serializationStream);

            Console.WriteLine(streamReaderInstance.ReadToEnd());

            serializationStream.Position = 0;

            //  This is now polymorphic. Type is Book but implementation is Novel
            var deserializedNovel = Deserialize(serializationStream, serializer);
        }

        static Stream Serialize(Book source, DataContractSerializer serializer)
        {
            var memoryStream = new MemoryStream();

            serializer.WriteObject(memoryStream, source);
            memoryStream.Position = 0;

            return memoryStream;
        }

        static Book Deserialize(Stream serializationStream, DataContractSerializer serializer)
        {
            return (Book)serializer.ReadObject(serializationStream);
        }
    }

    class NovelResolver : DataContractResolver
    {
        public override bool TryResolveType(Type type, Type declaredType, DataContractResolver knownTypeResolver,
            out XmlDictionaryString typeName, out XmlDictionaryString typeNamespace)
        {
            if (type == typeof(Novel))
            {
                var dictionary = new XmlDictionary();
                typeName = dictionary.Add("Novel");
                typeNamespace = dictionary.Add("SerializationDemo");
                return true;
            }
            else
            {
                return knownTypeResolver.TryResolveType(type, declaredType, null, out typeName, out typeNamespace);
            }
        }

        public override Type ResolveName(string typeName, string typeNamespace, Type declaredType, DataContractResolver knownTypeResolver)
        {
            if (typeName == "Novel" && typeNamespace == "SerializationDemo")
            {
                return typeof(Novel);
            }
            else
            {
                return knownTypeResolver.ResolveName(typeName, typeNamespace, declaredType, null);
            }
        }
    }
}
