namespace DataModel
{
    public enum Attribute
    {
        Name,
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
        public Attribute Attribute { get; set; } = Attribute.Name;
        public string? TextValue { get; set; } = null;
        public DateTime? FromDateValue { get; set; } = null;
        public DateTime? ToDateValue { get; set; } = null;
        public SortOrder SortSetting { get; set; } = SortOrder.Ascending;
    }
}
