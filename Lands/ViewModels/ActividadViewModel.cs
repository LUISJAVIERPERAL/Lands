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
    public class ActividadViewModel : BaseViewModel
    {
        #region Services
        private ApiService apiService;

        #endregion

        #region Attributes
        #endregion

        #region Propperties
      


        public Actividad Actividad
        {
            get;
            set;
        }


        #endregion

        #region Constructors
        public ActividadViewModel(Actividad actividad)
        {

            this.Actividad = actividad;
            this.apiService = new ApiService();
          
            

        }


        #endregion

        #region Methods
            #endregion
        }
    }