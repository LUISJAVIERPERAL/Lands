namespace Lands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Services;
    using Views;
    using Xamarin.Forms;
    using Helpers;
    using Models;
    using System.Globalization;
    using Interfaces;
    using Resources;

    public class PruebaViewModel : BaseViewModel
    {
        #region Services
        private ApiService apiService;
        private DataService dataService;
        #endregion

        #region Attributes
        private string email;
        private string password;
        private bool centro;
        private string centro2;
        private bool isRunning;
        private bool isEnabled;
        private bool isReme;
        private string primero;
        #endregion

        #region Properties

        public string Email
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }
        public string Primero
        {
            get { return this.primero; }
            set { SetValue(ref this.primero, value); }
        }
        private async void Probando1()
        {
            await Application.Current.MainPage.DisplayAlert(
                   "he pulsado",
                   " ",
                   "Aceptar");
            return;
        }



        public bool Centro
        {
            get { return this.centro; }
            set { SetValue(ref this.centro, value); }
        }
        public string Centro2
        {
            get { return this.centro2; }
            set { SetValue(ref this.centro2, value); }
        }
        public string Password
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }

        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }

        public bool IsRemembered
        {
            get
            {
                return this.isReme;
            }
            set
            {
                SetValue(ref this.isReme, Probando(value));
               
                
            }
        }

        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }
        #endregion

        #region Constructors
        public PruebaViewModel()
        {
            this.apiService = new ApiService();
            this.dataService = new DataService();
            this.centro = false;
            this.email = "11111111h";
            this.password = "1234";
            this.IsRemembered = false;
            this.IsEnabled = true;
            this.Primero = "1";
        }
        #endregion

        #region Commands
     


        private bool Probando(bool dato)
       
        {
            if (this.primero == "1")
            {
                Application.Current.MainPage.DisplayAlert(
                        "pulsado",
                        "",
                        "Aceptar");

                this.Centro = dato;
                return dato;
            }
            else
                this.primero = "1";
            this.Centro = dato;
          return dato;
        }
    




    public ICommand LoginFacebookComand
        {
            get
            {
                return new RelayCommand(LoginFacebook);
            }
        }

        private async void LoginFacebook()
        {
            await Application.Current.MainPage.Navigation.PushAsync(
                new LoginFacebookPage());
        }

    
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }

        private async void Login()
        {



            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.EmailValidation,
                    Languages.Accept);
                return;
            }
            if (string.IsNullOrEmpty(this.Centro2))
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.CentroValidation,
                    Languages.Accept);
                return;
            }
            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.PasswordValidation,
                    Languages.Accept);
                return;
            }

            this.IsRunning = true;
            this.IsEnabled = true;

            var connection = await this.apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    connection.Message,
                    Languages.Accept);
                return;
            }
            /// aqui la llamada a pedir login
            /// 

            var apiSecurity = Application.Current.Resources["APISecurity"].ToString();
            var loginresponse = await this.apiService.GetLogin(

                //apiSecurity,
                "https://comocomen.com/main_control/servidor_ws.php",
              this.Email,
              this.Password,
              this.Centro2);



            if (loginresponse.AccessToken == null)
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.SomethingWrong,
                    Languages.Accept);
                return;
            }

            if (string.IsNullOrEmpty(loginresponse.AccessToken))
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.LoginError,
                    Languages.Accept);
                this.Password = string.Empty;
                return;
            }

        
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.Mitoken = loginresponse;
            
            mainViewModel.RegisterDevice();
            mainViewModel.Centro = this.Centro2;
                if (Settings.LenguajePersonal == string.Empty  || Settings.LenguajePersonal != mainViewModel.Mitoken.Cultura)
            {

                await Application.Current.MainPage.DisplayAlert(
                       Languages.Aviso,
                       Languages.CambioIdioma,
                        Languages.Accept);
                Settings.LenguajePersonal = mainViewModel.Mitoken.Cultura;
                var ci = new CultureInfo(Settings.LenguajePersonal);
                Resource.Culture = ci;
                DependencyService.Get<ILocalize>().SetLocale(ci);
            }
                 

            //    this.dataService.DeleteAllAndInsert(userLocal);
            //    this.dataService.DeleteAllAndInsert(token);



            mainViewModel = MainViewModel.GetInstance();
            mainViewModel.Alumnos =  new AlumnosViewModel();
       //     mainViewModel =  MainViewModel.GetInstance();
       //     mainViewModel.Avisos = new AvisosViewModel();
       //     Application.Current.MainPage = new MasterPage();

           // this.IsRunning = false;
         //   this.IsEnabled = true;

        //    this.Email = string.Empty;
        //    this.Password = string.Empty;
         //   this.Centro = string.Empty;
        }

   
     //   public ICommand RegisterCommand
     //   {
     //       get
       //     {
       //         return new RelayCommand(Register);
       //     }
       // }

      //  private async void Register()
      //  {
      //      MainViewModel.GetInstance().Register = new RegisterViewModel();   
      //      await Application.Current.MainPage.Navigation.PushAsync(new RegisterPage());
      //  }
        #endregion
    }
}