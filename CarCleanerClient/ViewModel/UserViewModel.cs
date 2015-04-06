using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.ObjectModel;

namespace CarCleanerClient.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class UserViewModel : ViewModelBase
    {
        private Model.UserDataService ds = new Model.UserDataService();

        public UserViewModel()
        {
            this.UserList = new ObservableCollection<Model.User>(ds.GetData(0, 100, null));
        }


        #region UserList
        public const string UserListPropertyName = "UserList";
        private ObservableCollection<Model.User> _myProperty = new ObservableCollection<Model.User>();
        public ObservableCollection<Model.User> UserList
        {
            get
            {
                return _myProperty;
            }

            set
            {
                if (_myProperty == value)
                {
                    return;
                }

                _myProperty = value;
                RaisePropertyChanged(UserListPropertyName);
            }
        }
        #endregion

        private RelayCommand<Model.User> _getOrders;

        /// <summary>
        /// Gets the GetOrders.
        /// </summary>
        public RelayCommand<Model.User> GetOrders
        {
            get
            {
                return _getOrders ?? (_getOrders = new RelayCommand<Model.User>(
                    ExecuteGetOrders,
                    CanExecuteGetOrders));
            }
        }

        private void ExecuteGetOrders(Model.User user)
        {
            if (!GetOrders.CanExecute(user))
            {
                return;
            }
            Messenger.Default.Send<GenericMessage<Model.User>>(new GenericMessage<Model.User>(user), "getOrders");


        }

        private bool CanExecuteGetOrders(Model.User user)
        {
            if (user != null)
                return true;
            else
                return
                     false;
        }

    }
}