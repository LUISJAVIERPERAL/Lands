namespace Lands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Models;
    using System.Windows.Input;
    using Views;
    using Xamarin.Forms;

    public class AccesoItemViewModel : Acceso
    {
        #region Commands
        public ICommand SelectAccesoCommand
        {
            get
            {
                return new RelayCommand(SelectAcceso);
            }
        }

        private async void SelectAcceso()
        {
    //        MainViewModel.GetInstance().Acceso = new AccesoViewModel(this);
    //        await App.Navigator.PushAsync(new AlumnoPage());
        }
        #endregion
    }
}