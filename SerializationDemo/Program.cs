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
            //  This should be done by applying [Serializable] attribute, failing to which
            //  produces SerializationException.

            //  All primitive types, non-generic and generic collection types, delegates, and enums
            //  are serializable as they already have the [Serializable] attribute already applied.

            //  All fields irrespective of their access-level are serialized, Properties are serialized
            //  by actually serializing their backing fields. However, the problem may surface for auto properties
            //  The reason is the backing field is generated at the runtime by the compiler and this may be different
            //  for the deserialization, particularly if deserialization happens outside the assembly.
            //  At any rate, this automatic property serialization cannot be relied upon.
            //  In such cases, ISerializable is necessary.

            //  Child classes do not inherit the Serializable of the parent. Apply explicitly.

            //  If the base-class is not marked as Serializable, then the child class cannot apply
            //  Serializable either! It could be due to a design decision or the base class implementer
            //  forgot. In such cases the implementation of ISerializable interface becomes a necessity.

            //  Please note that object is marked as Serializable!
        }
    }
}
