using DataModel;
using System.Xml.Serialization;

namespace Controllers
{
    internal class XmlSerializer : ISerializer
    {
        public string FilePath { get; set; } = string.Empty;

        public List<Seminar> Load()
        {
            if (string.IsNullOrEmpty(FilePath))
            {
                throw new FileNotFoundException("Empty filepath");
            }

            var root = new XmlRootAttribute(ISerializer.RootName);
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<Seminar>), root);

            var res = (List<Seminar>?)null;

            using (var stream = new FileStream(FilePath, FileMode.Open, FileAccess.Read))
            {
                res = serializer.Deserialize(stream) as List<Seminar>;
                if (res == null)
                {
                    throw new FormatException("No seminars");
                }
            }
         
            return res;
        }

        public void Save(List<Seminar> seminars)
        {
            if (string.IsNullOrEmpty(FilePath))
            {
                throw new FileNotFoundException("Empty filepath");
            }

            var root = new XmlRootAttribute(ISerializer.RootName);
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<Seminar>), root);

            using (var stream = new FileStream(FilePath, FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(stream, seminars);
            }
        }
    }
}
