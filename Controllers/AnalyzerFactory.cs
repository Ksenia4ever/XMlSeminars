namespace Controllers
{
    public enum AnalyzerType
    {
        SAX,
        DOM,
        LINQ
    }

    public class AnalyzerFactory
    {
        public IAnalyser Create(AnalyzerType type, Parser parser)
        {
            var res = (IAnalyser?)null;

            switch(type)
            {
                case AnalyzerType.SAX:
                    res = new SAXAnalyzer() { FilePath = parser.FilePath };
                    break;
                case AnalyzerType.DOM:
                    res = new DOMAnalyzer() { FilePath = parser.FilePath };
                    break;
                case AnalyzerType.LINQ:
                    res = new LINQAnalyzer() { FilePath = parser.FilePath };
                    break;
                default:
                    throw new ArgumentException("Invalid AnalyzerType", nameof(type));
            }

            return res;
        }
    }
}
