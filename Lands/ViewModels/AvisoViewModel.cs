namespace Lands.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Models;
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Views;
    public class AvisoViewModel : BaseViewModel
    {
        #region Attributes
        private ObservableCollection<Destinatario> destinatarios;
        private string mirespuesta;
        #endregion

        #region Propperties
        public string Mirespuesta
        {
            get { return this.mirespuesta; }
            set { this.SetValue(ref this.mirespuesta, value); }
        }

        public ObservableCollection<Destinatario> Destinatarios
        {
            get { return this.destinatarios; }
            set { this.SetValue(ref this.destinatarios, value); }
        }



        public Aviso Aviso
        {
            get;
            set;
        }

      
        #endregion

        #region Constructors
        public AvisoViewModel(Aviso aviso)
        {
          
            this.Aviso = aviso;
            this.Destinatarios = new ObservableCollection<Destinatario>(this.Aviso.Destinatarios);
        }
        #endregion

        #region Methods

        #endregion
        public ICommand Respuestacommand
        {
            get
            {
                return new RelayCommand(Respuestaaviso);
            }
        }

        private async void Respuestaaviso()
        {

            await App.Navigator.PushAsync(new RespuestaAvisoPage());

        }

    }
}