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
            //  Xml serialization is done by DataContractSerializer
            //  DataContractSerializer was released with WCF and more attuned with messaging architecture
            //  However, it also works with Serializable attributes. Surprisingly, it works for public properties
            //  that have no attributes. Another supported interface is the IXmlSerializable

            //  In contrast with binary serialization, DataContracts are opt-in. This means, the required fields
            //  should be explicitly marked for serialization. The reason for this is to allow the
            //  flexible serialization under abstraction needs.


        }
    }
}
