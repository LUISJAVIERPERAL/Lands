namespace Lands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Models;
    using System.Windows.Input;
    using Views;
    using Xamarin.Forms;

    public class AvisoalumnoItemViewModel : Aviso
    {
        #region Commands
        public ICommand SelectAvisoCommand
        {
            get
            {
                return new RelayCommand(SelectAviso);
            }
        }

        private async void SelectAviso()
        {
            MainViewModel.GetInstance().Aviso = new AvisoViewModel(this);
            await App.Navigator.PushAsync(new AvisoPage());
            #endregion
        }
    }
}