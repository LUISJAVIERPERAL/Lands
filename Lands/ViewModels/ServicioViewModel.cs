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


    using System;
    //   using System.Collections.ObjectModel;
    //   using System.Linq;
    //   using Models;
    //   using Services;
    public class ServicioViewModel : BaseViewModel
    {
        #region Services
        private ApiService apiService;

        #endregion

        #region Attributes
        private ObservableCollection<AccesoItemViewModel> accesos;
        private ObservableCollection<Menuses> menudia;
        private string hijoactual,fechapulsada;
        #endregion

        #region Propperties
        public string HijoActual
        {
            get { return this.hijoactual; }
            set { this.SetValue(ref this.hijoactual, value); }
        }
        public string Fechapulsada
        {
            get { return this.fechapulsada; }
            set { this.SetValue(ref this.fechapulsada, value); }
        }

        public ObservableCollection<AccesoItemViewModel> Accesos
        {
            get { return this.accesos; }
            set { this.SetValue(ref this.accesos, value); }
        }
        public ObservableCollection<Menuses> Menudia
        {
            get { return this.menudia; }
            set { this.SetValue(ref this.menudia, value); }
        }


        public Servicio Servicio
        {
            get;
            set;
        }


        #endregion

        #region Constructors
        public ServicioViewModel(Servicio servicio)
        {
            this.HijoActual = MainViewModel.GetInstance().hijo.Nom_alum + " " + MainViewModel.GetInstance().hijo.Apellido1 + " " + MainViewModel.GetInstance().hijo.Apellido2;
            this.Fechapulsada = MainViewModel.GetInstance().Fechacalendario; 
            this.Servicio = servicio;
            this.apiService = new ApiService();
            //  this.loadAccesos();
            this.recuperaAccesos();


        }


        #endregion

        #region Methods
        private async void recuperaAccesos()
        {

            var Menusesmes = MainViewModel.GetInstance().MenusesListDia;

            this.Accesos = new ObservableCollection<AccesoItemViewModel>(this.ToAccesoItemViewModel().Where((l => l.Codigoservicio == Servicio.Codservicio && (l.Turnoservicio == Servicio.Codturno) )));
          this.Menudia = new ObservableCollection<Menuses>(Menusesmes.Where((l => l.Codigoservicio == Servicio.Codservicio)));

        }

        private async void loadAccesos()
        {
            var CalendarioACT = MainViewModel.GetInstance().GrillaCalendario;
            var ListaCalendarioACT = MainViewModel.GetInstance().GrillaList;
            var tokin = MainViewModel.GetInstance().Mitoken;
            var alumnoactual = MainViewModel.GetInstance().hijo;
            var centro = MainViewModel.GetInstance().Centro;
            var f1 = CalendarioACT.Anyactual + "-" + CalendarioACT.Mesactual + "-" + "01";


            // pongo el numero de dias del mes
            var numdias = DateTime.DaysInMonth(CalendarioACT.Anyactual, CalendarioACT.Mesactual);
            var f2 = CalendarioACT.Anyactual + "-" + CalendarioACT.Mesactual + "-" + $"{numdias}";
            var servicio = "1";




            // this.IsRefreshing = true;
            var connection = await this.apiService.CheckConnection();


            var response = await this.apiService.CogeAccesos<Acceso>(
                "https://comocomen.com/main_control/servidor_ws.php",
                tokin.AccessToken,
                centro,
                alumnoactual.Num_expediente,
                f1,
                f2,
                servicio);


            MainViewModel.GetInstance().AccesosList = (List<Acceso>)response.Result;

            

            this.Accesos = new ObservableCollection<AccesoItemViewModel>(
               this.ToAccesoItemViewModel());

        
            //   MainViewModel.GetInstance().AccesosList = (ObservableCollection<Acceso>)response.Result


           

        }
        private IEnumerable<AccesoItemViewModel> ToAccesoItemViewModel()
        {
            return MainViewModel.GetInstance().AccesosList.Select(l => new AccesoItemViewModel
            {
                Fechaacceso = l.Fechaacceso,
                Codigoservicio = l.Codigoservicio,
                Nombreacceso = textoacceso(l.Tipoacceso),
                Tipoacceso = l.Tipoacceso,
                Iconor = sacaicono(l.Tipoacceso),
                Turnoservicio = l.Turnoservicio,

              

            });

        }
        private string textoacceso(string Tipo)
        {

            if (Tipo == "A")
            {
                return "Acceso Correcto";

            }
            if (Tipo == "J")
            {
                return "Ausencia justificada";


            }
            if (Tipo == "X")
            {
                return "Ausencia no justificada";


            }
            else
            {
                return "Sin datos del acceso";
            }
        }

        private string sacaicono(string Tipo)
        {

            if (Tipo == "A")
            {
                return "ico_enverde";

            }
            if (Tipo == "J")
            {
                return "carasosa";


            }
            if (Tipo == "X")
            {
                return "ico_enrojo";


            }
            else
            {
                return "carasosa";
                    }
        }
            #endregion
        }
    }