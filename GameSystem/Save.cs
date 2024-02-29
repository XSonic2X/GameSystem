using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace GameSystem
{
    /// <summary>
    /// Сохраннение
    /// </summary>
    public static class Save
    {
        public static void WriteBF<T>(T save, string Name)
        {
            MemoryStream mem_stream = new MemoryStream();
            new BinaryFormatter().Serialize(mem_stream, save);
            File.WriteAllBytes(Name, mem_stream.ToArray());
        }
        public static T ReadBF<T>(string Name) => (T)new BinaryFormatter().Deserialize(new MemoryStream(File.ReadAllBytes(Name)));
        public static void WriteXml<T>(T save, string Name)
        {
            MemoryStream mem_stream = new MemoryStream();
            new XmlSerializer(typeof(T)).Serialize(mem_stream, save);
            File.WriteAllBytes(Name, mem_stream.ToArray());
        }
        public static T ReadXml<T>(string Name) => (T)new XmlSerializer(typeof(T)).Deserialize(new MemoryStream(File.ReadAllBytes(Name)));
    }
}
