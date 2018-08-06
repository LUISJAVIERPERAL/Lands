namespace Lands.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using Acr.UserDialogs;
    using Helpers;
    using Lands.Interfaces;
    using Lands.Services;
    using Models;
    using Xamarin.Forms;

    public class MainViewModel : BaseViewModel
    {
        #region Attibrutes
        private UserLocal user;
        private ObservableCollection<ServicioItemViewModel> serviciosmes2;
        private ApiService apiService;
        #endregion

        #region Properties
        public ObservableCollection<ServicioItemViewModel> Serviciosmes2
        {
            get { return this.serviciosmes2; }
            set { SetValue(ref this.serviciosmes2, value); }
        }

        public bool IsRunning
        {
            get;
            set ; 
        }

        public ObservableCollection<MenuItemViewModel> menuList
        {
            get;
            set;
        }
        public ObservableCollection<Diamodel> GrillaList
        {
            get;
            set;
        }
        public string Fechacalendario
        {
            get;
            set;
        }
        public Grilla GrillaCalendario
        {
            get;
            set;
        }
        public Hijo hijo
        {
            get;
            set;
        }
        public string botonpulsado
        {
            get;
            set;
        }
        public List<Aviso> AvisosList
        {
            get;
            set;
        }
        public List<Aviso> AvisosalumnoList
        {
            get;
            set;
        }

        public List<Acceso> AccesosList
        {
            get;
            set;
        }
        public List<Servicio> ServiciosList
        {
            get;
            set;
        }

        public List<Servicio> ServiciosListMes
        {
            get;
            set;
        }
        public List<Menuses> MenusesListMes
        {
            get;
            set;
        }
        public List<Menuses> MenusesListDia
        {
            get;
            set;
        }
        public List<Actividad> ActividadesList
        {
            get;
            set;
        }
        public List<Land> LandsList
        {
            get;
            set;
        }
        public List<Hijo> AlumnosList
        {
            get;
            set;
        }
        public Familia Familiadata
        {
            get;
            set;
        }

        public TokenResponse Token 
        { 
            get; 
            set; 
        }
        public string Centro
        {
            get;
            set;
        }
        public LoginResponse Mitoken
        {
            get;
            set;
        }

        public ObservableCollection<MenuItemViewModel> Menus
        {
            get;
            set;
        }

        public UserLocal User
        {
            get { return this.user; }
            set { SetValue(ref this.user, value); }
        }
        #endregion

        #region ViewModels
        public LoginViewModel Login
        {
            get;
            set;
        }
        public CalendarioViewModel Calendario
        {
            get;
            set;
        }

        public LandsViewModel Lands
        {
            get;
            set;
        }
        public AvisosViewModel Avisos
        {
            get;
            set;
        }
        public AvisosalumnoViewModel Avisosalumno
        {
            get;
            set;
        }
        public AvisoViewModel Aviso
        {
            get;
            set;
        }
        public ServiciosViewModel Servicios
        {
            get;
            set;
        }
        public ServicioViewModel Servicio
        {
            get;
            set;
        }
        public ActividadesViewModel Actividades
        {
            get;
            set;
        }
        public ActividadViewModel Actividad
        {
            get;
            set;
        }
        public ToastsViewModel Toast
        {
            get;
            set;
        }

        public CargandoViewModel Cargando
        {
            get;
            set;
        }

        public LandViewModel Land
        {
            get;
            set;
        }
        public AlumnosViewModel Alumnos
        {
            get;
            set;
        }

        public AlumnoViewModel Alumno
        {
            get;
            set;
        }

    




        #endregion

        #region Constructors
        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
            this.LoadMenu();
        }
        #endregion

        #region Singleton
        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }

            return instance;
        }
        #endregion

        #region Methods
        public void RegisterDevice()
        {
            var register = DependencyService.Get<IRegisterDevice>();
            register.RegisterDevice();
        

        }



        private void LoadMenu()
        {
            this.Menus = new ObservableCollection<MenuItemViewModel>();

        
           

       //     this.Menus.Add(new MenuItemViewModel
       //     {
       //         Icon = "ic_exit_to_app",
       //         PageName = "LoginPage",
        //        Title = Languages.LogOut,
        //    });

       //     foreach (Hijo item in AlumnosList)
        //    {
          //     this.Menus.Add(new MenuItemViewModel
          //      {
          //          Icon = "ic_exit_to_app",
           //         PageName = "AlumnoTabbedPage",
            //        Title = "ll",
            //    });
          //  }

        }
        

        #endregion
    }
}