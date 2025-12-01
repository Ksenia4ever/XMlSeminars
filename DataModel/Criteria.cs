using System.Xml.Linq;

namespace DataModel
{
    public enum Attribute
    {
        Topic,
        FacultyDepartment,
        FacultyBranch,
        Cathedra,
        Date,
        Description,
        HeaderName,
        HeaderSurname
    }

    public enum SortOrder
    {
        Ascending,
        Descending
    }

    public class Criteria
    {
        public Attribute Attribute { get; set; } = Attribute.Topic;
        public bool IsDateAttribute => Attribute == Attribute.Date;
        public bool IsTextAttribute => !IsDateAttribute;
        public string? TextValue { get; set; } = null;
        public DateTime? FromDateValue { get; set; } = null;
        public DateTime? ToDateValue { get; set; } = null;
        public SortOrder SortSetting { get; set; } = SortOrder.Ascending;

        public IEnumerable<Seminar> AddWhere(IEnumerable<Seminar> res)
        {
            switch (Attribute)
            {
                case DataModel.Attribute.Topic:
                    res = res.Where(s => Pass(s.Topic));
                    break;
                case DataModel.Attribute.FacultyDepartment:
                    res = res.Where(s => Pass(s.Faculty?.Department));
                    break;
                case DataModel.Attribute.FacultyBranch:
                    res = res.Where(s => Pass(s.Faculty?.Branch));
                    break;
                case DataModel.Attribute.Cathedra:
                    res = res.Where(s => Pass(s.Cathedra));
                    break;
                case DataModel.Attribute.Date:
                    res = res.Where(s => Pass(s.Date));
                    break;
                case DataModel.Attribute.Description:
                    res = res.Where(s => Pass(s.Description));
                    break;
                case DataModel.Attribute.HeaderName:
                    res = res.Where(s => Pass(s.Header?.Name));
                    break;
                case DataModel.Attribute.HeaderSurname:
                    res = res.Where(s => Pass(s.Header?.Surname));
                    break;
            }

            return res;
        }

        public IEnumerable<XElement> AddWhere(IEnumerable<XElement> res)
        {
            switch (Attribute)
            {
                case DataModel.Attribute.Topic:
                    res = res.Where(x => Pass((string?)x.Element(nameof(Seminar.Topic))));
                    break;
                case DataModel.Attribute.FacultyDepartment:
                    res = res.Where(x => Pass((string?)x.Element(nameof(Seminar.Faculty))?.Element(nameof(Faculty.Department))));
                    break;
                case DataModel.Attribute.FacultyBranch:
                    res = res.Where(x => Pass((string?)x.Element(nameof(Seminar.Faculty))?.Element(nameof(Faculty.Branch))));
                    break;
                case DataModel.Attribute.Cathedra:
                    res = res.Where(x => Pass((string?)x.Element(nameof(Seminar.Cathedra))));
                    break;
                case DataModel.Attribute.Date:
                    res = res.Where(x => Pass((DateTime?)x.Element(nameof(Seminar.Date))));
                    break;
                case DataModel.Attribute.Description:
                    res = res.Where(x => Pass((string?)x.Element(nameof(Seminar.Description))));
                    break;
                case DataModel.Attribute.HeaderName:
                    res = res.Where(x => Pass((string?)x.Element(nameof(Seminar.Header))?.Element(nameof(Person.Name))));
                    break;
                case DataModel.Attribute.HeaderSurname:
                    res = res.Where(x => Pass((string?)x.Element(nameof(Seminar.Header))?.Element(nameof(Person.Surname))));
                    break;
            }

            return res;
        }

        public IEnumerable<Seminar> AddOrderBy(IEnumerable<Seminar> res)
        {
            switch (Attribute)
            {
                case DataModel.Attribute.Topic:
                    res = OrderBy(res, s => s.Topic);
                    break;
                case DataModel.Attribute.FacultyDepartment:
                    res = OrderBy(res, s => s.Faculty?.Department);
                    break;
                case DataModel.Attribute.FacultyBranch:
                    res = OrderBy(res, s => s.Faculty?.Branch);
                    break;
                case DataModel.Attribute.Cathedra:
                    res = OrderBy(res, s => s.Cathedra);
                    break;
                case DataModel.Attribute.Date:
                    res = OrderBy(res, s => s.Date);
                    break;
                case DataModel.Attribute.Description:
                    res = OrderBy(res, s => s.Description);
                    break;
                case DataModel.Attribute.HeaderName:
                    res = OrderBy(res, s => s.Header?.Name);
                    break;
                case DataModel.Attribute.HeaderSurname:
                    res = OrderBy(res, s => s.Header?.Surname);
                    break;
            }

            return res;
        }

        bool Pass(string? value)
        {
            var res = string.IsNullOrEmpty(TextValue) ||
                      (value != null &&
                       value.Contains(TextValue, StringComparison.CurrentCultureIgnoreCase));
            return res;
        }

        bool Pass(DateTime? value)
        {
            var res = (FromDateValue == null && ToDateValue == null) ||
                      (value != null &&
                       value >= (FromDateValue ?? DateTime.MinValue) &&
                       value <= (ToDateValue ?? DateTime.MaxValue));
            return res;
        }

        IEnumerable<Seminar> OrderBy<T>(IEnumerable<Seminar> collection, Func<Seminar, T?> selector)
        {
            var res = collection;

            var ordered = collection as IOrderedEnumerable<Seminar>;
            if (ordered != null)
            {
                res = (SortSetting == SortOrder.Ascending) ? ordered.ThenBy(selector) :
                                                             ordered.ThenByDescending(selector);
            }
            else
            {
                res = (SortSetting == SortOrder.Ascending) ? collection.OrderBy(selector) :
                                                             collection.OrderByDescending(selector);
            }

            return res;
        }
    }
}
