namespace Lands.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Helpers;
    using Models;
    using Services;
    using Xamarin.Forms;

    public class ActividadesViewModel : BaseViewModel
    {
        #region Services
        private ApiService apiService;
        #endregion

        #region Attributes
        private ObservableCollection<ActividadItemViewModel> actividades;
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


        public ObservableCollection<ActividadItemViewModel> Actividades
        {
            get { return this.actividades; }
            set { SetValue(ref this.actividades, value); }
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
        public ActividadesViewModel()
        {
            this.Nomcompleto = MainViewModel.GetInstance().hijo.Nom_alum + " " + MainViewModel.GetInstance().hijo.Apellido1 + " " + MainViewModel.GetInstance().hijo.Apellido2;
            this.apiService = new ApiService();
            //       this.LoadActividades();
            this.CogeActividades();
        }
        #endregion

        #region Methods
        private async void CogeActividades()
        {
            this.Actividades = new ObservableCollection<ActividadItemViewModel>(
          this.ToActividadItemViewModel());
        }

        private async void LoadActividades()
        {

            var tokin = MainViewModel.GetInstance().Mitoken;
            var alumnoactual = MainViewModel.GetInstance().hijo;
            var centro = MainViewModel.GetInstance().Centro;

            var diaactualtmp = $"{DateTime.Now.Day}";
            var diaactual = "0" + diaactualtmp;
            // para meterle el 0 en el dia
            if (diaactual.Length == 2)
            {
                diaactual = diaactual.Substring(0, 2);
            }
            else
            {
                diaactual = diaactual.Substring(1, 2);
            }

            //
            var mesactualtmp = $"{DateTime.Now.Month}";
            var mesactual = "0" + mesactualtmp;
            // para meterle el 0 en el dia
            if (mesactual.Length == 2)
            {
                mesactual = mesactual.Substring(0, 2);
            }
            else
            {
                mesactual = mesactual.Substring(1, 2);
            }

            //



            var fechaactual = $"{DateTime.Now.Year}" + mesactual + diaactual;

          


            this.IsRefreshing = true;
            var connection = await this.apiService.CheckConnection();

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

            var response = await this.apiService.CogeActividades<Actividad>(
           "https://comocomen.com/main_control/servidor_ws.php",
           tokin.AccessToken,
             centro,
             alumnoactual.Num_expediente,
             fechaactual);

          

            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    response.Message,
                    Languages.Accept);
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }
           



            MainViewModel.GetInstance().ActividadesList = (List<Actividad>)response.Result;

            this.Hijoactual = MainViewModel.GetInstance().hijo;
            this.IsRefreshing = false;
            this.Actividades = new ObservableCollection<ActividadItemViewModel>(
            this.ToActividadItemViewModel());
            this.IsRefreshing = false;
            var kk = Hijoactual;
            var ll = "hh";
      
        }
        #endregion

        #region Methods
        private IEnumerable<ActividadItemViewModel> ToActividadItemViewModel()
        {
            return MainViewModel.GetInstance().ActividadesList.Select(l => new ActividadItemViewModel
            {
                Diassemana = l.Diassemana,
                Codigoactividad = l.Codigoactividad,
                DomDesde = l.DomDesde,
                DomHasta = l.DomHasta,
                LunDesde = l.LunDesde,
                LunHasta = l.LunHasta,
                MarDesde = l.MarDesde,
                MarHasta = l.MarHasta,
                MieDesde = l.MieDesde,
                MieHasta = l.MieHasta,
                JueDesde = l.JueDesde,
                JueHasta = l.JueHasta,
                VieDesde = l.VieDesde,
                VieHasta = l.VieHasta,
                SabDesde = l.SabDesde,
                SabHasta = l.SabHasta,
                Nombreactividad = l.Nombreactividad,
            });

        }

        #endregion

        #region Commands
        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadActividades);
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
                this.Actividades = new ObservableCollection<ActividadItemViewModel>(
                    this.ToActividadItemViewModel());
            }
            else
            {
                this.Actividades = new ObservableCollection<ActividadItemViewModel>(
                    this.ToActividadItemViewModel().Where(
                        l => l.Nombreactividad.ToLower().Contains(this.Filter.ToLower()) ||
                             l.Diassemana.ToLower().Contains(this.Filter.ToLower())));
            }
        }
        #endregion
    }
}