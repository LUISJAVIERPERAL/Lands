namespace Lands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Models;
    using System.Windows.Input;
    using Views;
    using Xamarin.Forms;

    public class AvisoItemViewModel : Aviso
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
         
        }

        public ICommand Respuestacommand
        {
            get
            {
                return new RelayCommand(Respuestaaviso);
            }
        }

        private async void Respuestaaviso()
        {
            
            await App.Navigator.PushAsync(new RespuestaAvisoPage());

        }

    }
#endregion
}