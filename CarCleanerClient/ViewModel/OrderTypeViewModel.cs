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
    public class OrderTypeViewModel : ViewModelBase
    {
        private Model.OrderTypeDataService ds = new Model.OrderTypeDataService();

        /// <summary>
        /// Initializes a new instance of the OrderTypeViewModel class.
        /// </summary>
        public OrderTypeViewModel()
        {
            this.OrderTypeList = new ObservableCollection<Model.OrderType>(ds.GetData(null));

         
        }

        /// <summary>
        /// The <see cref="OrderTypeList" /> property's name.
        /// </summary>
        public const string OrderTypeListPropertyName = "OrderTypeList";
        private ObservableCollection<Model.OrderType> _typeList = new ObservableCollection<Model.OrderType>();
        public ObservableCollection<Model.OrderType> OrderTypeList
        {
            get
            {
                return _typeList;
            }

            set
            {
                if (_typeList == value)
                {
                    return;
                }

                _typeList = value;
                RaisePropertyChanged(OrderTypeListPropertyName);
            }
        }

        private RelayCommand<Model.OrderType> _getOrders;

        /// <summary>
        /// Gets the GetOrders.
        /// </summary>
        public RelayCommand<Model.OrderType> GetOrders
        {
            get
            {
                return _getOrders ?? (_getOrders = new RelayCommand<Model.OrderType>(
                    ExecuteGetOrders,
                    CanExecuteGetOrders));
            }
        }

        private void ExecuteGetOrders(Model.OrderType parameter)
        {
            if (GetOrders.CanExecute(parameter))
            {
                Messenger.Default.Send<GenericMessage<Model.OrderType>>(new GenericMessage<Model.OrderType>(parameter), "getOrders");
            }
        }

        private bool CanExecuteGetOrders(Model.OrderType parameter)
        {
            if (parameter == null)
                return false;
            return true;
        }
    }
}