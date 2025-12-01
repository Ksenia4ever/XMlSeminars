using DataModel;
using System.Xml;

namespace Controllers
{
    public class Parser
    {
        public string FilePath { get; set; } = string.Empty;

        public List<object> GetOptions(DataModel.Attribute attribute)
        {
            if (string.IsNullOrEmpty(FilePath))
            {
                throw new FileNotFoundException("Empty filepath");
            }

            var res = new List<object>();

            var doc = new XmlDocument();
            doc.Load(FilePath);

            var xPath = string.Empty;

            var criteria = new Criteria() { Attribute = attribute };
            switch (criteria.Attribute)
            {
                case DataModel.Attribute.Topic:
                    xPath = $"{nameof(Seminar)}/{nameof(Seminar.Topic)}";
                    break;
                case DataModel.Attribute.FacultyDepartment:
                    xPath = $"{nameof(Seminar)}/{nameof(Seminar.Faculty)}/{nameof(Faculty.Department)}";
                    break;
                case DataModel.Attribute.FacultyBranch:
                    xPath = $"{nameof(Seminar)}/{nameof(Seminar.Faculty)}/{nameof(Faculty.Branch)}";
                    break;
                case DataModel.Attribute.Cathedra:
                    xPath = $"{nameof(Seminar)}/{nameof(Seminar.Cathedra)}";
                    break;
                case DataModel.Attribute.Date:
                    xPath = $"{nameof(Seminar)}/{nameof(Seminar.Date)}";
                    break;
                case DataModel.Attribute.Description:
                    xPath = $"{nameof(Seminar)}/{nameof(Seminar.Description)}";
                    break;
                case DataModel.Attribute.HeaderName:
                    xPath = $"{nameof(Seminar)}/{nameof(Seminar.Header)}/{nameof(Person.Name)}";
                    break;
                case DataModel.Attribute.HeaderSurname:
                    xPath = $"{nameof(Seminar)}/{nameof(Seminar.Header)}/{nameof(Person.Surname)}";
                    break;
            }

            if (!string.IsNullOrEmpty(xPath))
            {
                var valueNodes = doc.DocumentElement!.SelectNodes(xPath);
                if (valueNodes!=null)
                {
                    if (criteria.IsTextAttribute)
                    {
                        res = valueNodes.Cast<XmlNode>()
                                        .Select(n => n.InnerText)
                                        .Distinct()
                                        .Order()
                                        .Cast<object>()
                                        .ToList();
                    }
                    else if (criteria.IsDateAttribute)
                    {
                        res = valueNodes.Cast<XmlNode>()
                                        .Select(n =>
                                        {
                                            DateTime? date = null;
                                            if (DateTime.TryParse(n.InnerText, out var parsedDate))
                                            {
                                                date = parsedDate;
                                            }
                                            return date;
                                        })
                                        .Where(d => d != null)
                                        .Distinct()
                                        .Order()
                                        .Cast<object>()
                                        .ToList();
                    }
                }
            }

            return res;
        }
    }
}
