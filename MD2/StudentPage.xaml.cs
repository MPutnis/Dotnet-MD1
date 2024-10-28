using StudyClasses;
using System.Diagnostics;
using System.Text.RegularExpressions;
namespace MD2;

public partial class StudentPage : ContentPage
{
    public StudyXMLDataManager dataManager;
    private bool isValidFN = false;
    private bool isValidIDN = false;
    private bool isValidSN = false;
    // DONE: Gender binding
    public StudentPage()
	{
        dataManager = App.DataManager;        
        InitializeComponent();
        //Asked Copilot for the most basic way to bind Gender to the picker
        pGender.ItemsSource = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
	    pGender.SelectedIndex = -1;
    }
    // DONE:  Iplement Save new student
    private void btnSaveNewStudent_Clicked(object sender, EventArgs e)
    {
        try
        {
            // check if fields are filled and valid
            if (txtFirstName.Text == null || txtFirstName.Text == "" || !isValidFN)
            {
                throw new Exception("First name must be filled");
            }
            else if (txtIdNumber.Text == null || txtIdNumber.Text == "" || !isValidIDN)
            {
                throw new Exception("ID number must be filled");
            }
            else if (txtSurname.Text == null || txtSurname.Text == "" || !isValidSN)
            {
                throw new Exception("Surname must be filled");
            }
            else if (pGender.SelectedItem == null)
            {
                throw new Exception("Gender must be selected");
            }
            // if everything is filled and valid, create new student
            else
            {
                string firstName = txtFirstName.Text;
                string idNumber = txtIdNumber.Text;
                string surname = txtSurname.Text;
                Gender selectedGender = (Gender)pGender.SelectedItem;
                Student newStudent = new Student(firstName, surname, selectedGender, idNumber);
                dataManager.dataHolder.AddStudent(newStudent);
                DisplayAlert("Success", $"New student \"{newStudent.ToString()}\" added", "OK");
            }
        }
        // Copilot explained how throw- catch works
        catch (Exception ex)
        {
            DisplayAlert("Error", ex.Message, "OK");
        }
    }
    // DONE: First name validation
    private void txtFirstName_Unfocused(object sender, FocusEventArgs e)
    {
        var entry = sender as Entry;
        try 
        {
            // regex for first name, copilot came up with regex and throws
            if (entry != null) {
                if (!Regex.IsMatch(entry.Text, @"^[a-zA-Z]+$"))
                {
                    throw new Exception("First name must contain only letters");
                }
                else if (entry.Text.Length < 2 || entry.Text.Length > 20)
                {
                    throw new Exception("First name must be between 2 and 20 characters long");
                }
                else 
                {
                    Debug.WriteLine($"First name entry lost focus. Value: {entry.Text}");
                    errorFN.IsVisible = false;
                    isValidFN = true;
                }
            }        
        }
        catch (Exception ex)
        {
            errorFN.Text = ex.Message;
            errorFN.IsVisible = true;
            isValidFN = false;
        }
    }
    // DONE: ID number validation
    private void txtIdNumber_Unfocused(object sender, FocusEventArgs e)
    {
        var entry = sender as Entry;
        try
        {
            if (entry != null)
            { 
                if(!Regex.IsMatch(entry.Text, @"^[a-z]{2}[0-9]{5}$"))
                {
                    throw new Exception("ID number must be 2 letters followed by 5 digits.");
                }
                else
                {
                    Debug.WriteLine($"ID number entry lost focus. Value: {entry.Text}");
                    errorIDN.IsVisible = false;
                    isValidIDN = true;
                }
            }
        }
        catch (Exception ex)
        {
            errorIDN.Text = ex.Message;
            errorIDN.IsVisible = true;
            isValidIDN = false;
        }
    }
    // TODO: Surname validation
    private void txtSurname_Unfocused(object sender, FocusEventArgs e)
    {
        var entry = sender as Entry;
        try
        {
            // regex for first name, copilot mostly came up with regex and throws
            if (entry != null)
            {
                if (!Regex.IsMatch(entry.Text, @"^[a-zA-Z]+$"))
                {
                    throw new Exception("Surname must contain only letters");
                }
                else if (entry.Text.Length < 2 || entry.Text.Length > 20)
                {
                    throw new Exception("Surname must be between 2 and 20 characters long");
                }
                else
                {
                    Debug.WriteLine($"Surname entry lost focus. Value: {entry.Text}");
                    errorSN.IsVisible = false;
                    isValidSN = true;
                }
            }
        }
        catch (Exception ex)
        {
            errorSN.Text = ex.Message;
            errorSN.IsVisible = true;
            isValidSN = false;
        }
    }
}