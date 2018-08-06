namespace Lands.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Models;

    public class AlumnoViewModel : BaseViewModel
    {
        #region Attributes
      
        #endregion

        #region Propperties
        public Hijo Alumno
        {
            get;
            set;
        }

      

        #endregion

        #region Constructors
        public AlumnoViewModel(Hijo alumno)
        {
           
        
            this.Alumno = alumno;
        
            MainViewModel.GetInstance().hijo = this.Alumno;

            var   mainViewModel = MainViewModel.GetInstance();
            mainViewModel.Avisosalumno = new AvisosalumnoViewModel();
            mainViewModel.Calendario = new CalendarioViewModel(1);

        //    mainViewModel.Servicios = new ServiciosViewModel();
         //  mainViewModel.Actividades = new ActividadesViewModel();
        
            //    this.MainPage = new NavigationPage(new AvisosPage());

        }
        #endregion

        #region Methods

        #endregion
    }
}