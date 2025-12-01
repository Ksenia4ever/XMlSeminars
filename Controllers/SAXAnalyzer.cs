using DataModel;
using System.Xml;

namespace Controllers
{
    internal class SAXAnalyzer : IAnalyser, ISerializer
    {
        public string FilePath { get; set; } = string.Empty;
        public List<Criteria>? InputCriteria { get; set; } = null;

        public void Save(List<Seminar> seminars)
        {
            if (string.IsNullOrEmpty(FilePath))
            {
                throw new FileNotFoundException("Empty filepath");
            }

            var settings = new XmlWriterSettings
            {
                Indent = true,
                Encoding = System.Text.Encoding.UTF8
            };

            using (var writer = XmlWriter.Create(FilePath, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement(ISerializer.RootName);

                foreach (var seminar in seminars)
                {
                    writer.WriteStartElement(nameof(Seminar));

                    // Seminar
                    WriteValue(writer, nameof(Seminar.Topic), seminar.Topic);
                    WriteValue(writer, nameof(Seminar.Description), seminar.Description);
                    WriteValue(writer, nameof(Seminar.Cathedra), seminar.Cathedra);
                    WriteValue(writer, nameof(Seminar.Date), seminar.Date?.ToString("o"));

                    // Faculty
                    if (seminar.Faculty != null)
                    {
                        writer.WriteStartElement(nameof(Seminar.Faculty));
                        WriteValue(writer, nameof(Faculty.Department), seminar.Faculty.Department);
                        WriteValue(writer, nameof(Faculty.Branch), seminar.Faculty.Branch);
                        writer.WriteEndElement();
                    }

                    // Header
                    if (seminar.Header != null)
                    {
                        writer.WriteStartElement(nameof(Seminar.Header));
                        WriteValue(writer, nameof(Person.Name), seminar.Header.Name);
                        WriteValue(writer, nameof(Person.Surname), seminar.Header.Surname);
                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        public List<Seminar> Load()
        {
            if (string.IsNullOrEmpty(FilePath))
            {
                throw new FileNotFoundException("Empty filepath");
            }

            var result = new List<Seminar>();

            using (var reader = XmlReader.Create(FilePath))
            {
                var seminar = (Seminar?)null;
                var faculty = (Faculty?)null;
                var header = (Person?)null;
                var currentElement = (string?)null;

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        currentElement = reader.Name;

                        switch (reader.Name)
                        {
                            case nameof(Seminar):
                                seminar = new Seminar();
                                break;

                            case nameof(Seminar.Faculty):
                                faculty = new Faculty();
                                break;

                            case nameof(Seminar.Header):
                                header = new Person();
                                break;
                        }
                    }
                    else if (reader.NodeType == XmlNodeType.Text && currentElement != null)
                    {
                        string value = reader.Value;

                        // Faculty
                        if (faculty != null)
                        {
                            switch (currentElement)
                            {
                                case nameof(Faculty.Department): faculty.Department = value; break;
                                case nameof(Faculty.Branch): faculty.Branch = value; break;
                            }
                        }
                        // Header
                        else if (header != null)
                        {
                            switch (currentElement)
                            {
                                case nameof(Person.Name): header.Name = value; break;
                                case nameof(Person.Surname): header.Surname = value; break;
                            }
                        }
                        // Seminar
                        else if (seminar != null)
                        {
                            switch (currentElement)
                            {
                                case nameof(Seminar.Topic): seminar.Topic = value; break;
                                case nameof(Seminar.Cathedra): seminar.Cathedra = value; break;
                                case nameof(Seminar.Date): if (DateTime.TryParse(value, out var parsedDate)) { seminar.Date = parsedDate; }; break;
                                case nameof(Seminar.Description): seminar.Description = value; break;
                            }
                        }

                    }
                    else if (reader.NodeType == XmlNodeType.EndElement)
                    {
                        switch (reader.Name)
                        {
                            case nameof(Seminar.Faculty):
                                if (seminar != null)
                                {
                                    seminar.Faculty = faculty;
                                }
                                faculty = null;
                                break;

                            case nameof(Seminar.Header):
                                if (seminar != null)
                                {
                                    seminar.Header = header;
                                }
                                header = null;
                                break;

                            case nameof(Seminar):
                                if (seminar != null)
                                {
                                    result.Add(seminar);
                                }
                                seminar = null;
                                break;
                        }
                    }
                }
            }

            return result;
        }

        public List<Seminar> Analyze()
        {
            // load whole XML to the memory as collection of Seminar objects
            var res = Load().AsEnumerable();

            if (InputCriteria != null)
            {
                // build Enumerable LINQ request to select the required Seminars only
                foreach (var criteria in InputCriteria)
                {
                    res = criteria.AddWhere(res);
                }

                // now update LINQ with sorting rules to get the result sorted as required
                foreach (var criteria in InputCriteria)
                {
                    res = criteria.AddOrderBy(res);
                }
            }

            // execute Enumerable LINQ and get final result as List of Seminars
            return res.ToList();
        }

        void WriteValue(XmlWriter writer, string elementName, string? elementValue)
        {
            if (elementValue != null)
            {
                writer.WriteElementString(elementName, elementValue);
            }
        }
    }
}
