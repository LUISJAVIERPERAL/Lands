namespace Lands.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Helpers;
    using Models;
    using Services;
    using Xamarin.Forms;
    using Views;
    public class CargandoViewModel : BaseViewModel
    {
        #region Services
        private ApiService apiService;
        #endregion

        #region Attributes
        private ObservableCollection<AlumnoItemViewModel> alumnos;
        private bool isRefreshing;
        private string filter;
        #endregion

        #region Properties
      
        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }

      
        #endregion

        #region Constructors
        public CargandoViewModel()
        {
            Application.Current.MainPage = new MasterPage();
            App.Navigator.PushAsync(new AlumnoTabbedPage());
             var mainViewModel = MainViewModel.GetInstance();

          
        }
        #endregion

        #region Methods
     

        #endregion

        #region Methods
      

        #endregion

        #region Commands
     
        #endregion
    }
}