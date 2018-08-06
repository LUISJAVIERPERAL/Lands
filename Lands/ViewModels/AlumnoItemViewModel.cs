namespace Lands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Models;
    using System.Windows.Input;
    using Views;
    using Xamarin.Forms;

    public class AlumnoItemViewModel : Hijo
    {
        #region Commands
        public ICommand SelectAlumnoCommand
        {
            get
            {
                return new RelayCommand(SelectAlumno);
            }
        }

        private async void SelectAlumno()
        {
            MainViewModel.GetInstance().Alumno = new AlumnoViewModel(this);
            await App.Navigator.PushAsync(new AlumnoPage());
        }
        #endregion
    }
}