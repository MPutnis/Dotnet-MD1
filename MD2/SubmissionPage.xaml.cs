using StudyClasses;
using System.Collections.ObjectModel;
using System.Diagnostics;
namespace MD2;

public partial class SubmissionPage : ContentPage
{
	public StudyXMLDataManager dataManager = App.DataManager;
    public ObservableCollection<Submission> SubmissionsList { get; set; }
    public ObservableCollection<Assignment> AssignmentsList { get; set; }
    public ObservableCollection<Student> StudentsList { get; set; }

    private bool isValidSC = false;

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
        // gather data from submission and populate form
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
            // check if fields are filled and valid
            if (pAssignment.SelectedItem == null)
            {
                throw new Exception("Assignment must be selected");
            }
            else if (pStudent.SelectedItem == null)
            {
                throw new Exception("Student must be selected");
            }
            else if (txtScore.Text == null || txtScore.Text == "" || !isValidSC)
            {
                throw new Exception("Score must be filled");
            }
            else
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
                DisplayAlert("Success", $"New submission \"{newSubmission.ToString()}\" added", "OK");
            }
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", ex.Message, "OK");
        }
    }

    private void btnEditSubmission_Clicked(object sender, EventArgs e)
    {
        try
        {
            // check if fields are filled and valid
            if (pAssignment.SelectedItem == null)
            {
                throw new Exception("Assignment must be selected");
            }
            else if (pStudent.SelectedItem == null)
            {
                throw new Exception("Student must be selected");
            }
            else if (txtScore.Text == null || txtScore.Text == "" || !isValidSC)
            {
                throw new Exception("Score must be filled");
            }
            else
            {
                _submission.Assignment = (Assignment)pAssignment.SelectedItem;
                _submission.Student = (Student)pStudent.SelectedItem;
                _submission.Score = int.Parse(txtScore.Text);
                // update submission time
                _submission.SubmissionTime = DateTime.Now;
                DisplayAlert("Success", $"Submission \"{_submission.ToString()}\" updated", "OK");
            }
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", ex.Message, "OK");
        }
        {

        }
    }
    // score validation
    private void txtScore_Unfocused(object sender, FocusEventArgs e)
    {
        var entry = sender as Entry;
        try
        {
            if (entry != null)
            {
                if (int.Parse(txtScore.Text) < 0 || int.Parse(txtScore.Text) > 100)
                {
                    throw new Exception("Score must be between 0 and 100");
                }
                else
                {
                    isValidSC = true;
                    errorSC.IsVisible = false;
                    Debug.WriteLine($"Score entry lost focus. Value: {entry.Text}");
                }
            }
        }
        catch (Exception ex)
        {

            errorSC.Text = ex.Message;
            errorSC.IsVisible = true;
            isValidSC = false;
        }
    }
}