using DataModel;

namespace Controllers
{
    public interface IAnalyser
    {
        string FilePath { get; set; }

        public List<Criteria>? InputCriteria { get; set; }

        public List<Seminar> Analyze();
    }
}
