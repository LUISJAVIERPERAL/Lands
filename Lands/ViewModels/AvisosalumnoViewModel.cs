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

    public class AvisosalumnoViewModel : BaseViewModel
    {
        #region Services
        private ApiService apiService;
        #endregion

        #region Attributes
        private ObservableCollection<AvisoalumnoItemViewModel> avisos;
        public string hijoActual;
        public string expedienteactual;
        private bool isRefreshing;
        private string filter;
        #endregion

        #region Properties
        public string HijoActual
        {
            get { return this.hijoActual; }
            set { SetValue(ref this.hijoActual, value); }
        }
        public string Expedienteactual
        {
            get { return this.expedienteactual; }
            set { SetValue(ref this.expedienteactual, value); }
        }

        public Familia familia
        {
            get;
            set;
        }

        public ObservableCollection<AvisoalumnoItemViewModel> Avisos
        {
            get { return this.avisos; }
            set { SetValue(ref this.avisos, value); }
        }

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }

       
        #endregion

        #region Constructors
        public AvisosalumnoViewModel()
        {
            this.HijoActual = MainViewModel.GetInstance().hijo.Nom_alum + " " + MainViewModel.GetInstance().hijo.Apellido1 + " " + MainViewModel.GetInstance().hijo.Apellido2;
            this.Expedienteactual = MainViewModel.GetInstance().hijo.Num_expediente;
            this.familia = MainViewModel.GetInstance().Familiadata;
            var kk = "kk";                   
            this.apiService = new ApiService();
            this.LoadAvisos();
            //this.Filtra();
        }
        #endregion

        #region Methods
        private async void LoadAvisos()
        {
            this.IsRefreshing = true;
           




            MainViewModel.GetInstance().AvisosalumnoList = MainViewModel.GetInstance().AvisosList;
            
            var kk = "kk";
          
            this.Avisos = new ObservableCollection<AvisoalumnoItemViewModel>(this.ToAvisoalumnoItemViewModel().Where(l => l.Nexp.Contains(this.Expedienteactual)));
            
            this.IsRefreshing = false;
        }
        #endregion

        #region Methods
        private IEnumerable<AvisoalumnoItemViewModel> ToAvisoalumnoItemViewModel()
        {
            return MainViewModel.GetInstance().AvisosalumnoList.Select(l => new AvisoalumnoItemViewModel
            {
                Fecha = l.Fecha,
                Texto = l.Texto,
                Nexp = l.Nexp,
                Autor = l.Autor,
                Tipo = l.Tipo,
                ParaAlumnos = l.ParaAlumnos,
                Destinatarios = metedestinos(l.Nexp,l.ParaAlumnos)
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

    private void Filtra()
        {
                 this.Avisos = new ObservableCollection<AvisoalumnoItemViewModel>(this.ToAvisoalumnoItemViewModel());

        }
        #endregion
    }
}