using DataModel;
using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace Controllers
{
    internal class DOMAnalyzer : IAnalyser, ISerializer
    {
        public string FilePath { get; set; } = string.Empty;
        public List<Criteria>? InputCriteria { get; set; } = null;

        public void Save(List<Seminar> seminars)
        {
            if (string.IsNullOrEmpty(FilePath))
            {
                throw new FileNotFoundException("Empty filepath");
            }

            var doc = new XmlDocument();

            var root = doc.CreateElement(ISerializer.RootName);
            doc.AppendChild(root);

            foreach (var seminar in seminars)
            {
                var semEl = doc.CreateElement(nameof(Seminar));

                WriteValue(doc, semEl, nameof(Seminar.Topic), seminar.Topic);
                WriteValue(doc, semEl, nameof(Seminar.Description), seminar.Description);
                WriteValue(doc, semEl, nameof(Seminar.Cathedra), seminar.Cathedra);
                WriteValue(doc, semEl, nameof(Seminar.Date), seminar.Date?.ToString("o"));

                // Faculty
                if (seminar.Faculty != null)
                {
                    var facultyEl = doc.CreateElement(nameof(Seminar.Faculty));
                    WriteValue(doc, facultyEl, nameof(Faculty.Department), seminar.Faculty.Department);
                    WriteValue(doc, facultyEl, nameof(Faculty.Branch), seminar.Faculty.Branch);
                    semEl.AppendChild(facultyEl);
                }

                // Header
                if (seminar.Header != null)
                {
                    var headerEl = doc.CreateElement(nameof(Seminar.Header));
                    WriteValue(doc, headerEl, nameof(Person.Name), seminar.Header.Name);
                    WriteValue(doc, headerEl, nameof(Person.Surname), seminar.Header.Surname);
                    semEl.AppendChild(headerEl);
                }

                root.AppendChild(semEl);
            }

            doc.Save(FilePath);
        }

        public List<Seminar> Load()
        {
            if (string.IsNullOrEmpty(FilePath))
            {
                throw new FileNotFoundException("Empty filepath");
            }

            var res = new List<Seminar>();
            var doc = new XmlDocument();
            doc.Load(FilePath);

            var seminarNodes = doc.DocumentElement!.SelectNodes(nameof(Seminar));
            if (seminarNodes != null)
            {
                res = Load(seminarNodes);
            }

            return res;
        }

        public List<Seminar> Analyze()
        {
            if (string.IsNullOrEmpty(FilePath))
            {
                throw new FileNotFoundException("Empty filepath");
            }

            var res = Enumerable.Empty<Seminar>();
            var doc = new XmlDocument();
            doc.Load(FilePath);

            var seminarNodes = (XmlNodeList?)(null);

            if (InputCriteria != null)
            {
                var filters = new List<string>();

                foreach (var criteria in InputCriteria)
                {
                    switch (criteria.Attribute)
                    {
                        case DataModel.Attribute.Topic:
                            filters.Add(BuildXmlFilter(nameof(Seminar.Topic), criteria.TextValue));
                            break;
                        case DataModel.Attribute.FacultyDepartment:
                            filters.Add(BuildXmlFilter($"{nameof(Seminar.Faculty)}/{nameof(Faculty.Department)}", criteria.TextValue));
                            break;
                        case DataModel.Attribute.FacultyBranch:
                            filters.Add(BuildXmlFilter($"{nameof(Seminar.Faculty)}/{nameof(Faculty.Branch)}", criteria.TextValue));
                            break;
                        case DataModel.Attribute.Cathedra:
                            filters.Add(BuildXmlFilter(nameof(Seminar.Cathedra), criteria.TextValue));
                            break;
                        case DataModel.Attribute.Date:
                            // XPath does not support filtering by date, we will use this criteria later
                            break;
                        case DataModel.Attribute.Description:
                            filters.Add(BuildXmlFilter(nameof(Seminar.Description), criteria.TextValue));
                            break;
                        case DataModel.Attribute.HeaderName:
                            filters.Add(BuildXmlFilter($"{nameof(Seminar.Header)}/{nameof(Person.Name)}", criteria.TextValue));
                            break;
                        case DataModel.Attribute.HeaderSurname:
                            filters.Add(BuildXmlFilter($"{nameof(Seminar.Header)}/{nameof(Person.Surname)}", criteria.TextValue));
                            break;
                    }
                }

                if (filters.Count > 0)
                {
                    var xPath = string.Join(" and ", filters.Where(f => !string.IsNullOrEmpty(f)));
                    if (!string.IsNullOrEmpty(xPath))
                    {
                        seminarNodes = doc.DocumentElement!.SelectNodes($"{nameof(Seminar)}[{xPath}]");
                    }
                }
            }

            if (seminarNodes == null)
            {
                seminarNodes = doc.DocumentElement!.SelectNodes(nameof(Seminar));
            }

            if (seminarNodes != null)
            {
                res = Load(seminarNodes).AsEnumerable();

                if (InputCriteria != null)
                {
                    // build Enumerable LINQ for criterias missed by XPath
                    foreach (var criteria in InputCriteria)
                    {
                        if (criteria.Attribute == DataModel.Attribute.Date)
                        {
                            res = criteria.AddWhere(res);
                        }
                    }

                    // now update LINQ with sorting rules to get the result sorted as required
                    foreach (var criteria in InputCriteria)
                    {
                        res = criteria.AddOrderBy(res);
                    }
                }
            }

            // execute Enumerable LINQ and get final result as List of Seminars
            return res.ToList();
        }

        List<Seminar> Load(XmlNodeList seminarNodes)
        {
            var res = new List<Seminar>();

            foreach (XmlNode semEl in seminarNodes)
            {
                var seminar = new Seminar
                {
                    Topic = semEl[nameof(Seminar.Topic)]?.InnerText,
                    Description = semEl[nameof(Seminar.Description)]?.InnerText,
                    Cathedra = semEl[nameof(Seminar.Cathedra)]?.InnerText
                };

                if (DateTime.TryParse(semEl[nameof(Seminar.Date)]?.InnerText, out var parsedDate))
                {
                    seminar.Date = parsedDate;
                }

                // Faculty
                var facultyEl = semEl.SelectSingleNode(nameof(Seminar.Faculty));
                if (facultyEl != null)
                {
                    seminar.Faculty = new Faculty
                    {
                        Department = facultyEl[nameof(Faculty.Department)]?.InnerText,
                        Branch = facultyEl[nameof(Faculty.Branch)]?.InnerText
                    };
                }

                // Header
                var headerEl = semEl.SelectSingleNode(nameof(Seminar.Header));
                if (headerEl != null)
                {
                    seminar.Header = new Person
                    {
                        Name = headerEl[nameof(Person.Name)]?.InnerText,
                        Surname = headerEl[nameof(Person.Surname)]?.InnerText
                    };
                }

                res.Add(seminar);
            }

            return res;
        }

        void WriteValue(XmlDocument doc, XmlElement parentElement, string elementName, string? elementValue)
        {
            if (elementValue != null)
            {
                var el = doc.CreateElement(elementName);
                el.InnerText = elementValue;

                parentElement.AppendChild(el);
            }
        }

        string BuildXmlFilter(string elementName, string? filterValue)
        {
            var res = string.IsNullOrEmpty(filterValue) ? string.Empty : $"contains({elementName}, '{EscapeXmlValue(filterValue)}')";
            return res;
        }

        string EscapeXmlValue(string value)
        {
            return value.Replace("'", "&apos;");
        }
    }
}
