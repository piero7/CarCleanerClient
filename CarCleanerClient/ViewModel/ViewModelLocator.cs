﻿/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:CarCleanerClient.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using CarCleanerClient.Model;

namespace CarCleanerClient.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<IDataService, Design.DesignDataService>();
            }
            else
            {
                SimpleIoc.Default.Register<IDataService, DataService>();
            }

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<UserViewModel>();
            SimpleIoc.Default.Register<OrderViewModel>();
            SimpleIoc.Default.Register<OrderTypeViewModel>();

        }
        #region Locators
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
     "CA1822:MarkMembersAsStatic",
     Justification = "This non-static member is needed for data binding purposes.")]
        public OrderTypeViewModel OrderType
        {
            get
            {
                return ServiceLocator.Current.GetInstance<OrderTypeViewModel>();
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
                   "CA1822:MarkMembersAsStatic",
                   Justification = "This non-static member is needed for data binding purposes.")]
        public OrderViewModel Order
        {
            get
            {
                return ServiceLocator.Current.GetInstance<OrderViewModel>();
            }
        }

        /// <summary>
        /// Gets the User property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public UserViewModel User
        {
            get
            {
                return ServiceLocator.Current.GetInstance<UserViewModel>();
            }
        }
        /// <summary>
        /// Gets the Main property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        #endregion

        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
        }
    }
}