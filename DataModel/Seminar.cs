namespace DataModel
{
    public class Seminar
    {
        public string? Name { get; set; } = null;
        public Faculty? Faculty { get; set; } = null;
        public string? Cathedra { get; set; } = null;
        public DateTime? Date { get; set; } = null;
        public string? Description { get; set; } = null;
        public Person? Header { get; set; } = null;
    }
}
