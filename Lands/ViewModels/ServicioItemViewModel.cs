namespace Lands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Models;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using Views;
    using Xamarin.Forms;
    using Services;

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
    using System.Threading.Tasks;
    using Domain;
    using Acr.UserDialogs;
    using System;

    public class ServicioItemViewModel : Servicio
    {
        #region Services
        private ApiService apiService;
        #endregion

        public ObservableCollection<Menuses> menudia
        {
            get
            {
                var Menusesmes = MainViewModel.GetInstance().MenusesListDia;


                return  new ObservableCollection<Menuses>(Menusesmes.Where((l => l.Codigoservicio == this.Codservicio)));
            }
          
    }
      


        #region Commands
        public ICommand SelectServicioCommand
        {
            get
            {
                return new RelayCommand(SelectServicio);
            }
        }
       

        public ICommand VermenuCommand
        {
            get
            {
                return new RelayCommand(Vermenu );
            }
        }
        private async void SelectServicio()
        {
         //   MainViewModel.GetInstance().Servicio = new ServicioViewModel(this);
            await App.Navigator.PushAsync(new ServiciodiaPage());
        }
        private async void Vermenu()
        {



            MainViewModel.GetInstance().Servicio = new ServicioViewModel(this);


            await App.Navigator.PushAsync(new MenusesPage());
        }
        private ICommand micomando;
        public ICommand CambiarCommand 
        {
            get
            {

                {
                    micomando = new Command((e) =>
                                    {
                                        envio($"{e}");
                                       



                                     MainViewModel.GetInstance().Calendario = new CalendarioViewModel(2);
                                     
                                    });

              
                    return micomando;
                }
            }
        
        }
     
        public async void envio(string e)
        {
            var vtoken = MainViewModel.GetInstance().Mitoken.AccessToken;
            var vcentro = MainViewModel.GetInstance().Centro;
            var vidfam = MainViewModel.GetInstance().Mitoken.Cod_alumf;
            var vnexp = MainViewModel.GetInstance().hijo.Num_expediente;
            var vfecha = this.Fecha;
            var vservicio = this.Codservicio;
            var vtipo = e;
            this.apiService = new ApiService();
            using (UserDialogs.Instance.Loading("Actualizando..", null, null, true, MaskType.Black))
            {


                var resultado = await this.apiService.Avisarsistencia(

                   "https://comocomen.com/main_control/servidor_ws.php",

                 vtoken,
                 vcentro,
                 vidfam,
                 vnexp,
                 vfecha,
                 vservicio,
                 vtipo);

                string miresul = resultado.ToString();


                await Application.Current.MainPage.DisplayAlert(
                            miresul,
                            "",
                            "Aceptar");
            
                MainViewModel.GetInstance().Calendario = new CalendarioViewModel(2);

                using (UserDialogs.Instance.Loading("Actualizando...", null, null, true, MaskType.Black))
                {
                    await Task.Delay(3000);
                }
            }
        }


        public ICommand ToggleSwitchCommand
        {
            get
            {
                return new RelayCommand(Selectswitch);
            }
        }

        private void Selectswitch()
        {
            Application.Current.MainPage.DisplayAlert(
                       "Vas a marcar asistencia",
                       "",
                       "Aceptar");
   }







        public ICommand SelectAsistenciaCommand
        {
            get
            {
                return new RelayCommand(SelectAsistencia);
            }
        }

        private void SelectAsistencia()
        {
            Application.Current.MainPage.DisplayAlert(
                       "Vas a marcar asistencia",
                       "",
                       "Aceptar");

            if (this.Avisoausencia == "1")
            {
                this.Avisoausencia = "0";
            }
            else
            {
                this.Avisoausencia = "1";
            }

        }


        #endregion
    }
}