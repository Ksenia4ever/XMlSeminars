using Controllers;
using DataModel;

namespace Commands
{
    public class SaveXmlCommand : LoadXmlCommand
    {
        public List<Seminar>? Seminars { get; set; } = null;

        public override void Execute()
        {
            if (string.IsNullOrEmpty(FilePath))
            {
                throw new FileNotFoundException("Empty filepath");
            }

            if (Seminars == null)
            {
                throw new ArgumentNullException("Empty seminars");
            }

            Parser = new Parser() { FilePath = FilePath };
            var factory = new AnalyzerFactory();
            var serializer = (ISerializer)factory.Create(AnalyzerType.SAX, Parser);

            serializer.Save(Seminars);
        }
    }
}
