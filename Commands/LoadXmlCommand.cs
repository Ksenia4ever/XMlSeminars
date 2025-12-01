using Controllers;

namespace Commands
{
    public class LoadXmlCommand : ICommand
    {
        public string FilePath { get; set; } = string.Empty;
        public Parser? Parser { get; protected set; } = null;

        public virtual void Execute()
        {
            if (string.IsNullOrEmpty(FilePath))
            {
                throw new FileNotFoundException("Empty filepath");
            }

            Parser = new Parser() { FilePath = FilePath };
        }
    }
}
