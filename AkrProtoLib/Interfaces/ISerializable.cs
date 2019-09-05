using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkrProtoLib
{
    public interface ISerializable
    {
        string Serilize();
        void Parse(string serializedObject);
    }
}
