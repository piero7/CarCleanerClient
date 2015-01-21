using GalaSoft.MvvmLight;
using CarCleanerClient.Model;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.CommandWpf;
using System.Data;

namespace CarCleanerClient.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;

        public const string WelcomeTitlePropertyName = "WelcomeTitle";

        private string _welcomeTitle = string.Empty;

        public const string TestPropertyName = "Test";
        private ObservableCollection<User> _myProperty = new ObservableCollection<User> { 
            new User{ Name="1" , PhoneNumber="1"},
            new User { Name="2" , PhoneNumber="2"},
            new User { PhoneNumber ="3" , Name ="3"}
        };

        public ObservableCollection<User> Test
        {
            get
            {
                return this._myProperty;
            }
            set
            {
                return;
            }
        }



        public override void Cleanup()
        {
            // Clean up if needed

            base.Cleanup();
        }
    }
}