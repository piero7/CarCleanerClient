using GalaSoft.MvvmLight;
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
    public class OrderViewModel : ViewModelBase
    {
        Model.OrderDataService ds = new Model.OrderDataService();

        public OrderViewModel()
        {
            Messenger.Default.Register<GenericMessage<Model.User>>(this, "setOrdetUser", msg =>
            {
                if (msg.Content == null)
                {
                    return;
                }
                this.User = msg.Content;
            });
        }

        /// <summary>
        /// The <see cref="User" /> property's name.
        /// </summary>
        public const string UserPropertyName = "User";

        private Model.User _user = new Model.User();

        /// <summary>
        /// Sets and gets the User property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Model.User User
        {
            get
            {
                return _user;
            }

            set
            {
                if (_user == value)
                {
                    return;
                }

                _user = value;
                this.OrderList = new ObservableCollection<Model.Order>(ds.GetData(this.User, null));
                RaisePropertyChanged(UserPropertyName);
            }
        }


        /// <summary>
        /// The <see cref="OrderList" /> property's name.
        /// </summary>
        public const string OrderListPropertyName = "OrderList";

        private ObservableCollection<Model.Order> _orderList = new ObservableCollection<Model.Order>();

        /// <summary>
        /// Sets and gets the OrderList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<Model.Order> OrderList
        {
            get
            {
                return _orderList;
            }

            set
            {
                if (_orderList == value)
                {
                    return;
                }

                _orderList = value;
                RaisePropertyChanged(OrderListPropertyName);
            }
        }
    }
}