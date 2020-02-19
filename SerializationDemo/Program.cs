using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializationDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Serialization formatters should implement IFormatter interface
            //  Type fidelity is preserved in binary serialization, but not in Xml serialization
            //  Custom types such as classes, generic classes, enums, structs can be serialized
            //  This should be done by applying [Serialization] attribute, failing to which
            //  produces SerializationException.
        }
    }
}
