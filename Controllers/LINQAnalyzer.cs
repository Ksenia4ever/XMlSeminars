using DataModel;
using System.Xml.Linq;

namespace Controllers
{
    internal class LINQAnalyzer : IAnalyser, ISerializer
    {
        public string FilePath { get; set; } = string.Empty;
        public List<Criteria>? InputCriteria { get; set; } = null;

        public void Save(List<Seminar> seminars)
        {
            if (string.IsNullOrEmpty(FilePath))
            {
                throw new FileNotFoundException("Empty filepath");
            }

            var doc = new XDocument(
            new XElement(ISerializer.RootName,
                         seminars.Select(s =>
                             new XElement(nameof(Seminar),
                                 // Seminar
                                 new XElement(nameof(Seminar.Topic), s.Topic),
                                 new XElement(nameof(Seminar.Cathedra), s.Cathedra),
                                 new XElement(nameof(Seminar.Date), s.Date?.ToString("o")),
                                 new XElement(nameof(Seminar.Description), s.Description),

                                 // Faculty
                                 s.Faculty != null
                                     ? new XElement(nameof(Seminar.Faculty),
                                         new XElement(nameof(Faculty.Department), s.Faculty.Department),
                                         new XElement(nameof(Faculty.Branch), s.Faculty.Branch))
                                     : null,

                                 // Header
                                 s.Header != null
                                     ? new XElement(nameof(Seminar.Header),
                                         new XElement(nameof(Person.Name), s.Header.Name),
                                         new XElement(nameof(Person.Surname), s.Header.Surname))
                                     : null
                                )
                            )
                        )
            );

            doc.Save(FilePath);
        }

        public List<Seminar> Load()
        {
            if (string.IsNullOrEmpty(FilePath))
            {
                throw new FileNotFoundException("Empty filepath");
            }

            var doc = XDocument.Load(FilePath);
            var res = doc.Root!
                         .Elements(nameof(Seminar))
                         .Select(LoadSeminar)
                         .ToList();
            return res;
        }

        public List<Seminar> Analyze()
        {
            if (string.IsNullOrEmpty(FilePath))
            {
                throw new FileNotFoundException("Empty filepath");
            }

            var doc = XDocument.Load(FilePath);
            var col = doc.Root!.Elements(nameof(Seminar));

            // build XML LINQ request for getting required Seminar XML nodes
            // (use InputCriteria to create XML LINQ)
            if (InputCriteria != null)
            {
                foreach (var criteria in InputCriteria)
                {
                    col = criteria.AddWhere(col);
                }
            }

            // execute XML LINQ and convert the result to collection of Seminar objects
            var res = col.Select(LoadSeminar)
                         .ToList()
                         .AsEnumerable();

            // now, sort the result of of Seminar objects according to requirements
            if (InputCriteria != null)
            {
                foreach (var criteria in InputCriteria)
                {
                    res = criteria.AddOrderBy(res);
                }
            }

            return res.ToList();
        }

        Seminar LoadSeminar(XElement element)
        {
            var res = new Seminar
            {
                Topic = (string?)element.Element(nameof(Seminar.Topic)),
                Cathedra = (string?)element.Element(nameof(Seminar.Cathedra)),
                Date = (DateTime?)element.Element(nameof(Seminar.Date)),
                Description = (string?)element.Element(nameof(Seminar.Description)),

                Faculty = element.Element(nameof(Seminar.Faculty)) is XElement f
                        ? new Faculty
                        {
                            Department = (string?)f.Element(nameof(Faculty.Department)),
                            Branch = (string?)f.Element(nameof(Faculty.Branch))
                        }
                        : null,

                Header = element.Element(nameof(Seminar.Header)) is XElement h
                        ? new Person
                        {
                            Name = (string?)h.Element(nameof(Person.Name)),
                            Surname = (string?)h.Element(nameof(Person.Surname))
                        }
                        : null
            };
            return res;
        }
    }
}
