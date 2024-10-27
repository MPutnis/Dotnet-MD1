using StudyClasses;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MD2;

public partial class AssignmentListPage : ContentPage, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    public StudyXMLDataManager dataManager;
    private ObservableCollection<Assignment> assignmentsList;
    public ObservableCollection<Assignment> AssignmentsList
    {
        get => assignmentsList;
        set
        {
            assignmentsList = value;
            OnPropertyChanged();
        }

    }
    public AssignmentListPage()
	{
        dataManager = App.DataManager;
        // TODO: AssignemtsList binding to dataManager.Assignments
        AssignmentsList = new ObservableCollection<Assignment>(dataManager.dataHolder.Assignments);
        BindingContext = this;
        InitializeComponent();
        Debug.WriteLine($"Number of assignments in AssignmentList: {AssignmentsList.Count}");
    }
    
    // TODO: Open assignemnt page with empty form and save new assignment button
    private async void CreateNewAssignment_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AssignmentPage());
    }
    // TODO: Open assignemnt page with filled form and edit assignment button
    private async void btnEditAssignment_Clicked(object sender, EventArgs e)
    {
        var b = sender as Button;
        if (b != null)
        {
            if (b.BindingContext is Assignment)
            {
                var assign = (Assignment)b.BindingContext;
                var assignPage = new AssignmentPage(assign);
                await Navigation.PushAsync(assignPage);
            }
        }
    }
    // TODO: Ask for confirmation and delete assignment
    private async void btnDeleteAssignment_Clicked(object sender, EventArgs e)
    {
        var b = sender as Button;
        if (b != null)
        { 
            var assign = (Assignment)b.BindingContext;
            if (assign != null)
            {
                bool answer = await DisplayAlert("Delete", "Are you sure you want to delete this assignment? " + assign.ToString(), "Yes", "No");
                if (answer)
                {
                    dataManager.dataHolder.Assignments.Remove(assign);
                    AssignmentsList = new ObservableCollection<Assignment>(dataManager.dataHolder.Assignments);
                    
                }
            }
        }
    }
    // TODO: Refresh assignment list when opening page
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        AssignmentsList = new ObservableCollection<Assignment>(dataManager.dataHolder.Assignments);
    }

    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}