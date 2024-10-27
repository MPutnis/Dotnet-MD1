using StudyClasses;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MD2;
// more or less copy-paste from AssignmentListPage.xaml.cs
public partial class SubmissionListPage : ContentPage, INotifyPropertyChanged
{
	public event PropertyChangedEventHandler PropertyChanged;
    public StudyXMLDataManager dataManager;
    private ObservableCollection<Submission> submissionsList;
    public ObservableCollection<Submission> SubmissionsList
    {
        get => submissionsList;
        set
        {
            submissionsList = value;
            OnPropertyChanged();
        }

    }
    public SubmissionListPage()
	{
        dataManager = App.DataManager;
        SubmissionsList = new ObservableCollection<Submission>(dataManager.dataHolder.Submissions);
        BindingContext = this;
        InitializeComponent();
        Debug.WriteLine($"Number of submissions in SubmissionList: {SubmissionsList.Count}");
    }

    private async void CreateNewSubmission_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SubmissionPage());
    }

    private async void btnEditSubmission_Clicked(object sender, EventArgs e)
    {
        var b = sender as Button;
        if (b != null)
        {
            if (b.BindingContext is Submission)
            {
                var submission = (Submission)b.BindingContext;
                var submissionPage = new SubmissionPage(submission);
                await Navigation.PushAsync(submissionPage);
            }
        }
    }

    private async void btnDeleteSubmission_Clicked(object sender, EventArgs e)
    {
        var b = sender as Button;
        if (b != null)
        { 
            var subm = (Submission)b.BindingContext;
            if (subm != null)
            {
                var answer = await DisplayAlert("Delete", "Are you sure you want to delete this submission?" + subm.ToString(), "Yes", "No");
                if (answer)
                {
                    dataManager.dataHolder.Submissions.Remove(subm);
                    SubmissionsList = new ObservableCollection<Submission>(dataManager.dataHolder.Submissions);
                }
            }
        }
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        SubmissionsList = new ObservableCollection<Submission>(dataManager.dataHolder.Submissions);
    }

    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}