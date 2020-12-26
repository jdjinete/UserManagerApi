using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace UserManagerApi.Helpers
{
    public class Convert
    {
        
        public static T FromByteArray<T>(byte[] data)
        {
            if (data == null)
                return default;
            BinaryFormatter bf = new BinaryFormatter();
            using MemoryStream ms = new MemoryStream(data);
            object obj = bf.Deserialize(ms);
            return (T)obj;
        }
    }
}
