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
        public string? TextValue { get; set; } = null;
        public DateTime? FromDateValue { get; set; } = null;
        public DateTime? ToDateValue { get; set; } = null;
        public SortOrder SortSetting { get; set; } = SortOrder.Ascending;

        public bool Pass(string? value)
        {
            var res = string.IsNullOrEmpty(TextValue) ||
                      (value != null &&
                       value.Contains(TextValue, StringComparison.CurrentCultureIgnoreCase));
            return res;
        }

        public bool Pass(DateTime? value)
        {
            var res = (FromDateValue == null && ToDateValue == null) ||
                      (value != null &&
                       value >= (FromDateValue ?? DateTime.MinValue) &&
                       value <= (ToDateValue ?? DateTime.MaxValue));
            return res;
        }

        public IEnumerable<Seminar> OrderBy<T>(IEnumerable<Seminar> collection, Func<Seminar, T?> selector)
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
