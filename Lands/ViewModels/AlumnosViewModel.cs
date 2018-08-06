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
    public class AlumnosViewModel : BaseViewModel
    {
        #region Services
        private ApiService apiService;
        #endregion

        #region Attributes
        private ObservableCollection<AlumnoItemViewModel> alumnos;
        private bool isRefreshing;
        private string filter;
        #endregion

        #region Properties
        public ObservableCollection<AlumnoItemViewModel> Alumnos
        {
            get { return this.alumnos; }
            set { SetValue(ref this.alumnos, value); }
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
        public AlumnosViewModel()
        {
            this.apiService = new ApiService();
            this.LoadAlumnos();
        }
        #endregion

        #region Methods
        private async void LoadAlumnos()
        {
            this.IsRefreshing = true;
            var connection = await this.apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    connection.Message,
                    Languages.Accept);
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }
            var familiactual = MainViewModel.GetInstance().Familiadata;
            var centro = MainViewModel.GetInstance().Centro;
            var mitoken = MainViewModel.GetInstance().Mitoken;


            //var apiLands = Application.Current.Resources["APILands"].ToString();
            var response = await this.apiService.CogeAlumnos<infofamiliar>(
                "https://comocomen.com/main_control/servidor_ws.php",
                mitoken.AccessToken,
                centro,
                mitoken.Cod_alumf);
               
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
            var mio = (infofamiliar)(response.Result);
            


            
            MainViewModel.GetInstance().AlumnosList = (List<Hijo>)mio.Hijos;
            MainViewModel.GetInstance().Familiadata = (Familia)mio.Fam;
            var mia2 = (Familia)mio.Fam;
            var traer = MainViewModel.GetInstance().Familiadata.Nombre;
            this.Alumnos = new ObservableCollection<AlumnoItemViewModel>(
            this.ToAlumnoItemViewModel());



            MainViewModel.GetInstance().menuList = MainViewModel.GetInstance().Menus;
            foreach (Hijo item in (List<Hijo>)mio.Hijos)
            {

                var mimenu = MainViewModel.GetInstance().menuList.
                                   Where(l => l.PageName == item.Cod_alum).
                                   FirstOrDefault();
                if (mimenu == null)
                {

                    MainViewModel.GetInstance().Menus.Add(new MenuItemViewModel
                    {
                        Icon = "icoderechoblanco",
                        PageName = item.Cod_alum,
                        Title = item.Nom_alum,
                    });
                }
            }
            MainViewModel.GetInstance().Menus.Add(new MenuItemViewModel
            {
                Icon = " ",
                PageName = " ",
                Title = " ",
            });



            MainViewModel.GetInstance().Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_exit_to_app",
                PageName = "LoginPage",
                Title = Languages.LogOut,
            });



            this.IsRefreshing = false;

            var  mainViewModel =  MainViewModel.GetInstance();
                  mainViewModel.Avisos = new AvisosViewModel();
        
            


                Application.Current.MainPage = new MasterPage();
                    }


        #endregion

        #region Methods
        private IEnumerable<AlumnoItemViewModel> ToAlumnoItemViewModel()
        {
            return MainViewModel.GetInstance().AlumnosList.Select(l => new AlumnoItemViewModel
            {
                Num_expediente = l.Num_expediente,
                Cod_alum = l.Cod_alum,
                Nom_alum = l.Nom_alum,
                Apellido1 = l.Apellido1,
                Apellido2 = l.Apellido2,
                R_baja = l.R_baja,
                Fec_baja = l.Fec_baja,
                Grupo_menu = l.Grupo_menu,
            });
            
        }

        #endregion

        #region Commands
        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadAlumnos);
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
                this.Alumnos = new ObservableCollection<AlumnoItemViewModel>(
                    this.ToAlumnoItemViewModel());
            }
            else
            {
                this.Alumnos = new ObservableCollection<AlumnoItemViewModel>(
                    this.ToAlumnoItemViewModel().Where(
                        l => l.Nom_alum.ToLower().Contains(this.Filter.ToLower()) ||
                             l.Num_expediente.ToLower().Contains(this.Filter.ToLower())));
            }
        }
        #endregion
    }
}