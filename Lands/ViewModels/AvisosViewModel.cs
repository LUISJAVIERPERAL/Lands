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

    public class AvisosViewModel : BaseViewModel
    {
        #region Services
        private ApiService apiService;
        #endregion

        #region Attributes
        private ObservableCollection<AvisoItemViewModel> avisos;

        private bool isRefreshing;
        private string filter;
        #endregion

        #region Properties
        public Familia familia
        {
            get;
            set;
        }

        public ObservableCollection<AvisoItemViewModel> Avisos
        {
            get { return this.avisos; }
            set { SetValue(ref this.avisos, value); }
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
        public AvisosViewModel()
        {
            this.familia = MainViewModel.GetInstance().Familiadata;
            var kk = "kk";                   
            this.apiService = new ApiService();
            this.LoadAvisos();

        }
        #endregion

        #region Methods
        private async void LoadAvisos()
        {
            this.IsRefreshing = true;
            var connection = await this.apiService.CheckConnection();
            var tokin = MainViewModel.GetInstance().Mitoken;
            var centro = MainViewModel.GetInstance().Centro;
            var fam = tokin.Cod_alumf;
         
            var response = await this.apiService.CogeAvisos<Aviso>(
            "https://comocomen.com/main_control/servidor_ws.php",
                tokin.AccessToken,
                centro,
                fam);
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
           



            MainViewModel.GetInstance().AvisosList = (List<Aviso>)response.Result;
            
            var kk = "kk";
            this.Avisos = new ObservableCollection<AvisoItemViewModel>(
            this.ToAvisoItemViewModel());
            this.IsRefreshing = false;
        }
        #endregion

        #region Methods
        private IEnumerable<AvisoItemViewModel> ToAvisoItemViewModel()
        {
            return MainViewModel.GetInstance().AvisosList.Select(l => new AvisoItemViewModel
            {
                Fecha = l.Fecha,
                Texto = l.Texto,
                Nexp = l.Nexp,
                Autor = l.Autor,
                Tipo = l.Tipo,
                ParaAlumnos = l.ParaAlumnos,
                Destinatarios = metedestinos(l.Nexp,l.ParaAlumnos),
                hayavisos = l.hayavisos
            });

        }

        #endregion

        #region Commands
        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadAvisos);
            }
        }

        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand(Search);
            }
        }


        private List<Destinatario> metedestinos(string Nexp,string Alumnos)
        {

            string[] milis = Nexp.Split(',');
            string[] milisnombres = Alumnos.Split(',');  
            List<Destinatario> milis2 = new List<Destinatario>();

            for (int i = 0; i < milis.Length; i++)
            {
                milis2.Add(new Destinatario
                {
                    Expediente = milis[i] ,
                    Nombre = milisnombres[i]
                   });
              
            }
            return milis2;
         }

    private void Search()
        {
            if (string.IsNullOrEmpty(this.Filter))
            {
                this.Avisos = new ObservableCollection<AvisoItemViewModel>(
                    this.ToAvisoItemViewModel());
            }
            else
            {
                this.Avisos = new ObservableCollection<AvisoItemViewModel>(
                    this.ToAvisoItemViewModel().Where(
                        l => l.Fecha.ToLower().Contains(this.Filter.ToLower()) ||
                             l.Tipo.ToLower().Contains(this.Filter.ToLower())));
            }
        }
        #endregion
    }
}