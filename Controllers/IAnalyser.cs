using DataModel;

namespace Controllers
{
    public interface IAnalyser
    {
        public List<Criteria>? InputCriteria { get; set; }

        public List<Seminar> Analyze();
    }
}
