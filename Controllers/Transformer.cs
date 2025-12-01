using System.Xml.Xsl;

namespace Controllers
{
    public class Transformer
    {
        public string SourceFile { get; set; } = string.Empty;
        public string OutputFile { get; set; } = string.Empty;
        string TransformFile => "TransformSeminars.xslt";

        public void Transform()
        {
            if (string.IsNullOrEmpty(SourceFile))
            {
                throw new FileNotFoundException("Empty source file path");
            }

            if (string.IsNullOrEmpty(OutputFile))
            {
                throw new FileNotFoundException("Empty output file path");
            }

            var xslt = new XslCompiledTransform();
            xslt.Load(TransformFile);
            xslt.Transform(SourceFile, OutputFile);
        }
    }
}
