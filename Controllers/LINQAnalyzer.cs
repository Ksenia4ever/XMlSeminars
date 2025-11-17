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
                                 new XElement(nameof(Seminar.Topic), s.Topic),
                                 new XElement(nameof(Seminar.Cathedra), s.Cathedra),
                                 new XElement(nameof(Seminar.Date), s.Date?.ToString("o")),
                                 new XElement(nameof(Seminar.Description), s.Description),

                                 s.Faculty != null
                                     ? new XElement(nameof(Seminar.Faculty),
                                         new XElement(nameof(Faculty.Department), s.Faculty.Department),
                                         new XElement(nameof(Faculty.Branch), s.Faculty.Branch))
                                     : null,

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

            if (InputCriteria != null)
            {
                foreach (var criteria in InputCriteria)
                {
                    switch (criteria.Attribute)
                    {
                        case DataModel.Attribute.Topic:
                            col = col.Where(x => criteria.Pass((string?)x.Element(nameof(Seminar.Topic))));
                            break;
                        case DataModel.Attribute.FacultyDepartment:
                            col = col.Where(x => criteria.Pass((string?)x.Element(nameof(Seminar.Faculty))?.Element(nameof(Faculty.Department))));
                            break;
                        case DataModel.Attribute.FacultyBranch:
                            col = col.Where(x => criteria.Pass((string?)x.Element(nameof(Seminar.Faculty))?.Element(nameof(Faculty.Branch))));
                            break;
                        case DataModel.Attribute.Cathedra:
                            col = col.Where(x => criteria.Pass((string?)x.Element(nameof(Seminar.Cathedra))));
                            break;
                        case DataModel.Attribute.Date:
                            col = col.Where(x => criteria.Pass((DateTime?)x.Element(nameof(Seminar.Date))));
                            break;
                        case DataModel.Attribute.Description:
                            col = col.Where(x => criteria.Pass((string?)x.Element(nameof(Seminar.Description))));
                            break;
                        case DataModel.Attribute.HeaderName:
                            col = col.Where(x => criteria.Pass((string?)x.Element(nameof(Seminar.Header))?.Element(nameof(Person.Name))));
                            break;
                        case DataModel.Attribute.HeaderSurname:
                            col = col.Where(x => criteria.Pass((string?)x.Element(nameof(Seminar.Header))?.Element(nameof(Person.Surname))));
                            break;
                    }
                }
            }

            var res = col.Select(LoadSeminar)
                         .ToList()
                         .AsEnumerable();

            if (InputCriteria != null)
            {
                foreach (var criteria in InputCriteria)
                {
                    switch (criteria.Attribute)
                    {
                        case DataModel.Attribute.Topic:
                            res = criteria.OrderBy(res, s => s.Topic);
                            break;
                        case DataModel.Attribute.FacultyDepartment:
                            res = criteria.OrderBy(res, s => s.Faculty?.Department);
                            break;
                        case DataModel.Attribute.FacultyBranch:
                            res = criteria.OrderBy(res, s => s.Faculty?.Branch);
                            break;
                        case DataModel.Attribute.Cathedra:
                            res = criteria.OrderBy(res, s => s.Cathedra);
                            break;
                        case DataModel.Attribute.Date:
                            res = criteria.OrderBy(res, s => s.Date);
                            break;
                        case DataModel.Attribute.Description:
                            res = criteria.OrderBy(res, s => s.Description);
                            break;
                        case DataModel.Attribute.HeaderName:
                            res = criteria.OrderBy(res, s => s.Header?.Name);
                            break;
                        case DataModel.Attribute.HeaderSurname:
                            res = criteria.OrderBy(res, s => s.Header?.Surname);
                            break;
                    }
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
