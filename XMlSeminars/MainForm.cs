using Controllers;
using DataModel;

namespace XMlSeminars
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void OnClose(object sender, EventArgs e)
        {
            var gen = new SeminarGenerator();
            var seminars = gen.CreateSeminars();

            var factory = new AnalyzerFactory();
            var analizer = factory.Create(AnalyzerType.LINQ);
            analizer.FilePath = "SeminarsSAX.xml";

            var serializer = (analizer as ISerializer);
            if (serializer != null)
            {
                serializer.Save(seminars);
            }

            var criteria = new List<Criteria>();
            criteria.Add(new Criteria() { Attribute = DataModel.Attribute.Topic, SortSetting = DataModel.SortOrder.Descending });

            analizer.InputCriteria = criteria;
            var res = analizer.Analyze();
        }
    }
}
