using StudyClasses;
using System.Collections.ObjectModel;
namespace MD2;

public partial class SubmissionPage : ContentPage
{
	public StudyXMLDataManager dataManager = App.DataManager;
    public ObservableCollection<Submission> SubmissionsList { get; set; }
    public ObservableCollection<Assignment> AssignmentsList { get; set; }
    public ObservableCollection<Student> StudentsList { get; set; }

    public SubmissionPage()
	{
		InitializeComponent();
        InitializePage();
        lblPageName.Text = "Create new submission.";
        pAssignment.SelectedIndex = -1;
        pStudent.SelectedIndex = -1;
    }

    // constructor for editing existing submission
    private Submission _submission;
    public SubmissionPage(Submission submission)
    {
        InitializeComponent();
        InitializePage();
        _submission = submission;
        lblPageName.Text = "Edit submission.";
        pAssignment.SelectedItem = _submission.Assignment;
        pStudent.SelectedItem = _submission.Student;
        txtScore.Text = _submission.Score.ToString();
        btnSaveNewSubmission.IsVisible = false;
        btnEditSubmission.IsVisible = true;
    }
    private void InitializePage()
    {
        // retrieve data from dataHolder and populate pickers
        SubmissionsList = new ObservableCollection<Submission>(dataManager.dataHolder.Submissions);
        AssignmentsList = new ObservableCollection<Assignment>(dataManager.dataHolder.Assignments);
        pAssignment.ItemsSource = AssignmentsList;
        pAssignment.ItemDisplayBinding = new Binding("Name");
        StudentsList = new ObservableCollection<Student>(dataManager.dataHolder.Students);
        pStudent.ItemsSource = StudentsList;
        pStudent.ItemDisplayBinding = new Binding("NameID");
    }

    private void btnSaveNewSubmission_Clicked(object sender, EventArgs e)
    {
        try
        {
            // collect data from form and create new submission
            Assignment selectedAssignment = (Assignment)pAssignment.SelectedItem;
            Student selectedStudent = (Student)pStudent.SelectedItem;
            int score = int.Parse(txtScore.Text);
            Submission newSubmission = new Submission();
            newSubmission.Assignment = selectedAssignment;
            newSubmission.Student = selectedStudent;
            newSubmission.Score = score;
            dataManager.dataHolder.AddSubmission(newSubmission);
        }
        catch 
        {

        }
    }

    private void btnEditSubmission_Clicked(object sender, EventArgs e)
    {
        try
        {
            _submission.Assignment = (Assignment)pAssignment.SelectedItem;
            _submission.Student = (Student)pStudent.SelectedItem;
            _submission.Score = int.Parse(txtScore.Text);
            // update submission time
            _submission.SubmissionTime = DateTime.Now;
        }
        catch 
        {

        }
    }
}