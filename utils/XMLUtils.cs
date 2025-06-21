using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyStickyNotes.utils
{
    internal class XMLUtils
    {
        public string serialize(object obj)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);

            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            serializer.Serialize(writer, obj);

            return Encoding.UTF8.GetString(stream.ToArray()); 
        }

        public T deserialize<T>(Type objType, string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            T obj = (T) serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xml)));
            return obj;
        }
    }
}
