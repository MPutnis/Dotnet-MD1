using StudyClasses;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MD2;

public partial class StudentListPage : ContentPage, INotifyPropertyChanged
{
	public event PropertyChangedEventHandler PropertyChanged;
    /*
        At the beggining tried to do implement binding as it was done in Your GitHub example,
        but instead of using CollectionView used ListView( spoiler: that was the problem) and it 
        didn't work. So the more complicated solution was what Copilot was suggesting, not that 
        it worked. After changing ListView to CollectionView, it worked.
     */
    private StudyXMLDataManager dataManager;
    private ObservableCollection<Student> studentsList;
	public ObservableCollection<Student> StudentsList 
    { 
        get => studentsList;
        set
        { 
            studentsList = value;
            OnPropertyChanged();
        }
    }
    public StudentListPage()
	{
		dataManager = App.DataManager;
		StudentsList = new ObservableCollection<Student>(dataManager.dataHolder.Students);
        BindingContext = this;
        InitializeComponent();
		Debug.WriteLine($"Number of students in StudentList: {StudentsList.Count}");
    }

    // DONE: OnClick CreateNewStudent button, open StudentPage
    private async void CreateNewStudent_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new StudentPage());
    }

	//Refresh Stundent list, when opening page
	private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
	{
        StudentsList = new ObservableCollection<Student>(dataManager.dataHolder.Students);
        Debug.WriteLine($"Number of students after navigation: {StudentsList.Count}");
    }

    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}