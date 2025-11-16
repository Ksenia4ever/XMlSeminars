using DataModel;

namespace Controllers
{
    public interface ISerializer
    {
        static readonly string RootName = "Seminars";

        string FilePath { get; set; }

        List<Seminar> Load();
        void Save(List<Seminar> seminars);
    }
}
