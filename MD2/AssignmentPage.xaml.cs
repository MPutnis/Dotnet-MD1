using StudyClasses;
using System.Collections.ObjectModel;
namespace MD2;

public partial class AssignmentPage : ContentPage
{
    public StudyXMLDataManager dataManager = App.DataManager;
    public ObservableCollection<Course> Courses { get; set; }
    public ObservableCollection<Assignment> Assignments { get; set; }

    public AssignmentPage()
    {
        InitializeComponent();
        InitializePage();
        lblPageName.Text = "Create new assignment.";
        pCourse.SelectedIndex = -1;
    }

    // constructor for edit assignment
    private Assignment _assignment;
    public AssignmentPage(Assignment assignment)
    {
        InitializeComponent();
        InitializePage();
        // gather data from assignment and populate form
        _assignment = assignment;
        lblPageName.Text = "Edit assignment.";
        pCourse.SelectedItem = _assignment.Course;
        txtAssignmentName.Text = _assignment.Name;
        txtAssignmentDescription.Text = _assignment.Description;
        // asked Copilot how to best split date and time from DateTime
        // extraxt date from Deadline dateTime
        dpDeadline.Date = _assignment.Deadline.Date;
        // extract time from Deadline dateTime
        tpDeadline.Time = _assignment.Deadline.TimeOfDay;
        btnSaveNewAssignment.IsVisible = false;
        btnEditAssignment.IsVisible = true;
    }
    // copilot offered this method to initialize page for common classes
    private void InitializePage()
    {
        Courses = new ObservableCollection<Course>(dataManager.dataHolder.Courses);
        pCourse.ItemsSource = Courses;
        // asked Copilot how to display course name in picker
        pCourse.ItemDisplayBinding = new Binding("Name");
        Assignments = new ObservableCollection<Assignment>(dataManager.dataHolder.Assignments);
    }
    // TODO: data validation
    private void btnSaveNewAssignment_Clicked(object sender, EventArgs e)
    {
        try 
        {
            // check if fields are filled
            if (txtAssignmentName.Text == null || txtAssignmentName.Text == "")
            {
                throw new Exception("Assignment name must be filled");
            }
            else if (txtAssignmentDescription.Text == null || txtAssignmentDescription.Text == "")
            {
                throw new Exception("Assignment description must be filled");
            }
            else if (pCourse.SelectedItem == null)
            {
                throw new Exception("Course must be selected");
            }
            else if ((dpDeadline.Date + tpDeadline.Time) <= DateTime.Now)
            {
                throw new Exception("Deadline must be in the future");
            }
            else
            {
                // collect data from form and create new assignment
                string name = txtAssignmentName.Text;
                string description = txtAssignmentDescription.Text;
                Course selectedCourse = (Course)pCourse.SelectedItem;
                DateTime deadline = dpDeadline.Date + tpDeadline.Time;
                Assignment newAssignment = new Assignment();
                newAssignment.Name = name;
                newAssignment.Description = description;
                newAssignment.Course = selectedCourse;
                newAssignment.Deadline = deadline;
                dataManager.dataHolder.AddAssignment(newAssignment);
                DisplayAlert("Success", $"New assignment \"{newAssignment.Name.ToString()}\" added", "OK");
            }
        }
        catch (Exception ex) 
        {
            DisplayAlert("Error", ex.Message, "OK");
        }
    }

    private void btnEditAssignment_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (txtAssignmentName.Text == null || txtAssignmentName.Text == "")
            {
                throw new Exception("Assignment name must be filled");
            }
            else if (txtAssignmentDescription.Text == null || txtAssignmentDescription.Text == "")
            {
                throw new Exception("Assignment description must be filled");
            }
            else if (pCourse.SelectedItem == null)
            {
                throw new Exception("Course must be selected");
            }
            else if ((dpDeadline.Date + tpDeadline.Time) <= DateTime.Now)
            {
                throw new Exception("Deadline must be in the future");
            }
            else
            {
                _assignment.Name = txtAssignmentName.Text;
                _assignment.Description = txtAssignmentDescription.Text;
                _assignment.Course = (Course)pCourse.SelectedItem;
                _assignment.Deadline = dpDeadline.Date + tpDeadline.Time;
                DisplayAlert("Success", $"Assignment \"{_assignment.Name.ToString()}\" updated", "OK");
            }
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", ex.Message, "OK");
        }
    }
}