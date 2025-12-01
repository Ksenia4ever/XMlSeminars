using Controllers;
using DataModel;

namespace Commands
{
    public class AnalyzeCommand : ICommand
    {
        public Parser? Parser { get; set; } = null;
        public List<Criteria>? InputCriteria { get; set; }
        public AnalyzerType Analyzer { get; set; } = AnalyzerType.SAX;
        public List<Seminar>? Seminars { get; private set; } = null;

        public void Execute()
        {
            if (Parser == null)
            {
                throw new ArgumentException("Source data parser is empty");
            }

            var factory = new AnalyzerFactory();
            var analyzer = factory.Create(Analyzer, Parser);

            analyzer.InputCriteria = InputCriteria;
            Seminars = analyzer.Analyze();
        }
    }
}
