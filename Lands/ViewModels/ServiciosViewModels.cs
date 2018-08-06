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
    using System;
    public class ServiciosViewModel : BaseViewModel
    {
        #region Services
        private ApiService apiService;
        #endregion

        #region Attributes
        private ObservableCollection<ServicioItemViewModel> servicios;
        private bool isRefreshing;
        private string filter;
        private Hijo hijoactual;
        private string nomcompleto;
        #endregion

        #region Properties
        public Hijo Hijoactual
        {
            get { return this.hijoactual; }
            set { SetValue(ref this.hijoactual, value); }
        }

        public string Nomcompleto
        {
            get { return this.nomcompleto; }
            set { SetValue(ref this.nomcompleto, value); }
        }


        public ObservableCollection<ServicioItemViewModel> Servicios
        {
            get { return this.servicios; }
            set { SetValue(ref this.servicios, value); }
        }

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }

        public string Filter
        {
            get { return this.filter; }
            set
            {
                SetValue(ref this.filter, value);
                this.Search();
            }
        }
        #endregion

        #region Constructors
        public ServiciosViewModel()
        {
            this.Nomcompleto = MainViewModel.GetInstance().hijo.Nom_alum.ToUpper() + " " + MainViewModel.GetInstance().hijo.Apellido1.ToUpper() + " " + MainViewModel.GetInstance().hijo.Apellido2.ToUpper();

          //  this.Nomcompleto = MainViewModel.GetInstance().hijo.Nom_alum + " " + MainViewModel.GetInstance().hijo.Apellido1 + " " + MainViewModel.GetInstance().hijo.Apellido2;
            this.apiService = new ApiService();
        //    this.LoadServicios();

        }
        #endregion

        #region Methods
        private async void LoadServicios()
        {
            var tokin = MainViewModel.GetInstance().Mitoken;
            var alumnoactual = MainViewModel.GetInstance().hijo;
            var centro = MainViewModel.GetInstance().Centro;
            var CalendarioACT = MainViewModel.GetInstance().GrillaCalendario;
            this.IsRefreshing = true;
            var connection = await this.apiService.CheckConnection();
            var mimes = "0" + CalendarioACT.Mesactual;
            var hayservicios = 0;

            // para meterle el 0 en el mes
            if (mimes.Length == 2)
            {
                mimes = mimes.Substring(0, 2);
            }
            else
            {
                mimes = mimes.Substring(1, 2);
            }

            //
            var f1 = CalendarioACT.Anyactual + "-" + mimes + "-" + "01";



            //        if (!connection.IsSuccess)
            //        {
            //           this.IsRefreshing = false;
            //           await Application.Current.MainPage.DisplayAlert(
            //               Languages.Error,
            //              connection.Message,
            //              Languages.Accept);
            //         await Application.Current.MainPage.Navigation.PopAsync();
            //        return;
            //    }

            //var apiLands = Application.Current.Resources["APILands"].ToString();
            var response1 = await this.apiService.CogeServiciosMes<Servicio>(
               "https://comocomen.com/main_control/servidor_ws.php",
                tokin.AccessToken,
               centro,
               alumnoactual.Num_expediente,
               f1,
              "0");
            if (response1.IsSuccess == false)
            {
                hayservicios = 0;
            }
            else
            {

                hayservicios = 1;


                MainViewModel.GetInstance().ServiciosListMes = (List<Servicio>)response1.Result;

            }


            MainViewModel.GetInstance().ServiciosList = (List<Servicio>)response1.Result;
      
            this.Hijoactual = MainViewModel.GetInstance().hijo;
            this.IsRefreshing = false;
            this.Servicios = new ObservableCollection<ServicioItemViewModel>(
            this.ToServicioItemViewModel());
            this.IsRefreshing = false;
            var kk = Hijoactual;
            var ll = "hh";
      
        }
        #endregion

        #region Methods
        private IEnumerable<ServicioItemViewModel> ToServicioItemViewModel()
        {
            return MainViewModel.GetInstance().ServiciosList.Select(l => new ServicioItemViewModel
            {
                Codservicio = l.Codservicio,
                Tipoasistencia = l.Tipoasistencia,
                Diasasistencia = l.Diasasistencia,
                Numeroasistencias = l.Numeroasistencias,
                Codmesa = l.Codmesa,
                Codturno = l.Codturno,
                Nombreservicio = l.Nombreservicio,
                Nombreturno = l.Nombreturno,
                Fecha = l.Fecha,
                conmenu = l.conmenu,
                Tipocomidas = l.Tipocomidas,
                FechaCambio = l.FechaCambio,
                Monitores = l.Monitores,
                Dia = l.Dia,
                Mes = l.Mes,
                Any = l.Any,
                Iconoasistencia = l.Iconoasistencia,
                Iconoausencia = l.Iconoausencia,
                Avisoasistencia = l.Avisoasistencia,
                Avisodieta = l.Avisodieta,
                Avisoausencia = l.Avisoausencia,
                entrante1 = l.entrante1,
                nombremenu1 = l.nombremenu1,
                primerplato1 = l.primerplato1,
                segundoplato1 = l.segundoplato1,
                elmenu = l.elmenu,
                postre1 = l.postre1,
                sinmenu = l.sinmenu,
                tieneacesso = l.tieneacesso,
                notieneacesso = l.notieneacesso,
                Coloracceso = l.Coloracceso,
                modelo1 = l.modelo1,
                modelo2 = l.modelo2,
                Pulsato = l.Pulsato,
                Accesotxt = l.Accesotxt,
                Cantidadplato1 = l.Cantidadplato1,
                Cantidadplato2 = l.Cantidadplato2,
                Cantidadplato3 = l.Cantidadplato3,
                Cantidadplato4 = l.Cantidadplato4,
                Infonutrimenu = l.Infonutrimenu,
                Infonutriplato1 = l.Infonutriplato1,
                Infonutriplato2 = l.Infonutriplato2,
                Infonutriplato3 = l.Infonutriplato3,
                Infonutriplato4 = l.Infonutriplato4,
                Mencomidas = l.Mencomidas,
                Nomgrupomenu = l.Nomgrupomenu,
                Nommenu = l.Nommenu,
                Nomplato1 = l.Nomplato1,
                Nomplato2 = l.Nomplato2,
                Nomplato3 = l.Nomplato3,
                Nomplato4 = l.Nomplato4,
                Numplatos = l.Numplatos,
                Obscomidas = l.Obscomidas,
                Codgrupomenu = l.Codgrupomenu,
                Codigotipoasistencia = l.Codigotipoasistencia,
                Flag = l.Flag,
                Sercomidas = l.Sercomidas,
                Tienemenu = l.Tienemenu,
                Tipoplato1 = l.Tipoplato1,
                Tipoplato2 = l.Tipoplato2,
                Tipoplato3 = l.Tipoplato3,
                Tipoplato4 = l.Tipoplato4,
                Iconoestrella1 = l.Iconoestrella1,
                Iconoestrella2 = l.Iconoestrella2,
                Iconoestrella3 = l.Iconoestrella3,
                Iconoestrella4 = l.Iconoestrella4,


            });

        }

        #endregion

        #region Commands
        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadServicios);
            }
        }

        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand(Search);
            }
        }

        private void Search()
        {
            if (string.IsNullOrEmpty(this.Filter))
            {
                this.Servicios = new ObservableCollection<ServicioItemViewModel>(
                    this.ToServicioItemViewModel());
            }
            else
            {
                this.Servicios = new ObservableCollection<ServicioItemViewModel>(
                    this.ToServicioItemViewModel().Where(
                        l => l.Nombreservicio.ToLower().Contains(this.Filter.ToLower()) ||
                             l.Nombreturno.ToLower().Contains(this.Filter.ToLower())));
            }
        }
        #endregion
    }
}