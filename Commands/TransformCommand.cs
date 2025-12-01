using Controllers;

namespace Commands
{
    public class TransformCommand : ICommand
    {
        public string SourceFile { get; set; } = string.Empty;
        public string OutputFile { get; set; } = string.Empty;

        public void Execute()
        {
            if (string.IsNullOrEmpty(SourceFile))
            {
                throw new FileNotFoundException("Empty source file path");
            }

            if (string.IsNullOrEmpty(OutputFile))
            {
                throw new FileNotFoundException("Empty output file path");
            }

            var transformer = new Transformer()
            { 
                SourceFile = SourceFile,
                OutputFile = OutputFile
            };

            transformer.Transform();
        }
    }
}
