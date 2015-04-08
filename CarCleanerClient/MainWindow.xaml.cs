using System.Windows;
using CarCleanerClient.ViewModel;
using GalaSoft.MvvmLight.Messaging;

namespace CarCleanerClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MahApps.Metro.Controls.MetroWindow
    {
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Closing += (s, e) => ViewModelLocator.Cleanup();

            Messenger.Default.Register<GenericMessage<Model.User>>(this, "getOrders", msg =>
            {
                if (msg.Content != null)
                {
                    var of = new View.OrderView();
                    Messenger.Default.Send<GenericMessage<Model.User>>(new GenericMessage<Model.User>(msg.Content), "setOrdetUser");
                    GalaSoft.MvvmLight.Threading.DispatcherHelper.CheckBeginInvokeOnUI(new System.Action(() =>
                    {
                        of.ShowDialog();
                    }));
                }
            });
            Messenger.Default.Register<GenericMessage<Model.OrderType>>(this, "getOrders", msg =>
            {
                var of = new View.OrderView();
                if (msg.Content != null)
                {

                    Messenger.Default.Send<GenericMessage<Model.OrderType>>(new GenericMessage<Model.OrderType>(msg.Content), "setOrderType");
                    GalaSoft.MvvmLight.Threading.DispatcherHelper.CheckBeginInvokeOnUI(new System.Action(() =>
                    {
                        of.ShowDialog();
                    }));
                }
            });
        }
    }
}