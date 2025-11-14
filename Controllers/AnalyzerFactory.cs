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
        public IAnalyser Create(AnalyzerType type)
        {
            var res = (IAnalyser?)null;

            switch(type)
            {
                case AnalyzerType.SAX:
                    res = new SAXAnalyzer();
                    break;
                case AnalyzerType.DOM:
                    res = new DOMAnalyzer();
                    break;
                case AnalyzerType.LINQ:
                    res = new LINQAnalyzer();
                    break;
                default:
                    throw new ArgumentException("Invalid AnalyzerType", nameof(type));
            }

            return res;
        }
    }
}
