using StudyClasses;

namespace MD2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            DataManager = new StudyXMLDataManager();
        }

        public static StudyXMLDataManager DataManager { get; set; }
    }
}
