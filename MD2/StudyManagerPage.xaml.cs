using StudyClasses;
using System.Xml;

namespace MD2;

public partial class StudyManagerPage : ContentPage
{
	IDataManager dataManager;
	public StudyManagerPage()
	{
		InitializeComponent();

        dataManager = App.DataManager;
    }
    // DONE: Implement StudyXMLDataManager methods

    // Print all data to StudyManagerPage
    private void btnPrint_Clicked(object sender, EventArgs e)
    {
        ediText.Text = dataManager.Print();
    }

    // Load data from file
    private void btnLoad_Clicked(object sender, EventArgs e)
    {
        dataManager.Load();
    }

    // Save data to file
    private void btnSave_Clicked(object sender, EventArgs e)
    {
        dataManager.Save();
    }

    // Create test data for all classes
    private void btnCreateTestData_Clicked(object sender, EventArgs e)
    {
        dataManager.CreateTestData();
    }

    // Clear all Study data from memory 
    private void btnReset_Clicked(object sender, EventArgs e)
    {
        dataManager.Reset();
    }

    // Display data in StudyManagerPage
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        ediText.Text = dataManager.Print();
    }
}