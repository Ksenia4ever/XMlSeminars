using DataModel;

namespace Controllers
{
    internal class DOMAnalyzer : IAnalyser
    {
        public string FilePath { get; set; } = string.Empty;
        public List<Criteria>? InputCriteria { get; set; } = null;

        public List<Seminar> Analyze()
        {
            throw new NotImplementedException();
        }
    }
}
