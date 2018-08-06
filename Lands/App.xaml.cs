namespace Lands
{
    using Xamarin.Forms;
    using Views;
    using ViewModels;
    using Helpers;
    using Models;
    using Services;
    using System;
    using System.Threading.Tasks;
    using System.Globalization;
    using Resources;
    using Interfaces;
    using Acr.UserDialogs;

    public partial class App : Application
	{
        #region Properties
        public static NavigationPage Navigator
        {
            get;
            internal set;
        }

		public static MasterPage Master 
        { 
            get; 
            internal set; 
        }
		#endregion

		#region Constructors
		public App()
        {
            InitializeComponent();

            if (Settings.LenguajePersonal == String.Empty)


                       {
            }
            else
            {
                
            //    Settings.LenguajePersonal = String.Empty;
                var ci = new CultureInfo(Settings.LenguajePersonal);
                               Resource.Culture = ci;
                    DependencyService.Get<ILocalize>().SetLocale(ci);
            }
            //       var dataService = new DataService();
            //         var token = dataService.First<LoginResponse>(false);

            //    if (token != null )
            //   {
            //   var mainViewModel = MainViewModel.GetInstance();
            //      mainViewModel.Mitoken = token;
            //    mainViewModel = MainViewModel.GetInstance();
            //   mainViewModel.Alumnos = new AlumnosViewModel();
            //   mainViewModel = MainViewModel.GetInstance();
            //         mainViewModel.Avisos = new AvisosViewModel();
            //         Application.Current.MainPage = new MasterPage();

            //              }
            //         else
            //          {
            //              this.MainPage = new NavigationPage(new LoginPage());
            //            }
            //         }
            //         else

            //solo de pruebas volver a desmarcar

            using (UserDialogs.Instance.Loading("Loading", null, null, true, MaskType.Black))
            {
                 Task.Delay(5000);
            }
            this.MainPage = new NavigationPage(new LoginPage());
          
            //  var mainViewModel = MainViewModel.GetInstance();
          //  mainViewModel.Toast = new ToastsViewModel(UserDialogs.Instance);
          //  this.MainPage = new NavigationPage(new ToastsPage());

            //   var   mainViewModel = MainViewModel.GetInstance();
            //     mainViewModel.Avisos = new AvisosViewModel();
            //    this.MainPage = new NavigationPage(new AvisosPage());


        }
      //  }
        #endregion

        #region Methods
        public static Action HideLoginView
        {
            get
            {
                return new Action(() => Application.Current.MainPage =
                                  new NavigationPage(new LoginPage()));
            }
        }

      //  public static async Task NavigateToProfile(FacebookResponse profile)
      //  {
      //      if (profile == null)
       //     {
        //        Application.Current.MainPage = new NavigationPage(new LoginPage());
        //        return;
        //    }

//            var apiService = new ApiService();
  //          var dataService = new DataService();
  //
    //        var apiSecurity = Application.Current.Resources["APISecurity"].ToString();
         //   var token = await apiService.LoginFacebook(
          //      apiSecurity,
          //      "/api",
           //     "/Users/LoginFacebook",
           //     profile);

          //  if (token == null)
//            {
          //      Application.Current.MainPage = new NavigationPage(new LoginPage());
           //     return;
          // }

      ///      var user = await apiService.GetUserByEmail(
       ///         apiSecurity,
        //        "/api",
        //        "/Users/GetUserByEmail",
        //        token.TokenType,
         //       token.AccessToken,
          //      token.UserName);

           // UserLocal userLocal = null;
          //  if (user != null)
          //  {
          //      userLocal = Converter.ToUserLocal(user);
           //     dataService.DeleteAllAndInsert(userLocal);
           //     dataService.DeleteAllAndInsert(token);
           // }

           // var mainViewModel = MainViewModel.GetInstance();
          //  mainViewModel.Token = token;
          //  mainViewModel.User = userLocal;
          //  mainViewModel.Lands = new LandsViewModel();
          //  Application.Current.MainPage = new MasterPage();
           // Settings.IsRemembered = "true";

//            mainViewModel.Lands = new LandsViewModel();
 //           Application.Current.MainPage = new MasterPage();
   //     }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
        #endregion
    }
}
