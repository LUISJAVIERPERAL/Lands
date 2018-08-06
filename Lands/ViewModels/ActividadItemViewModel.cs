namespace Lands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Models;
    using System.Windows.Input;
    using Views;
    using Xamarin.Forms;
   
    public class ActividadItemViewModel : Actividad
    {
      
      


        #region Commands
        public ICommand SelectActividadCommand
        {
            get
            {
                return new RelayCommand(SelectActividad);
            }
        }

        private async void SelectActividad()
        {
            MainViewModel.GetInstance().Actividad = new ActividadViewModel(this);
            await App.Navigator.PushAsync(new ActividadPage());
        }
        #endregion
    }
}