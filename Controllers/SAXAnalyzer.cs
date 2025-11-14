using DataModel;

namespace Controllers
{
    internal class SAXAnalyzer : IAnalyser
    {
        public List<Criteria>? InputCriteria { get; set; } = null;

        public List<Seminar> Analyze()
        {
            throw new NotImplementedException();
        }
    }
}
