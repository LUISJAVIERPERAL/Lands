namespace Lands.ViewModels
{
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Views;
    using Xamarin.Forms;
    using Helpers;
    using Models;
    using Acr.UserDialogs;
    using System.Threading.Tasks;

    public class MenuItemViewModel
    {
        #region Properties
        public string Icon { get; set; }

        public string Title { get; set; }

        public string PageName { get; set; }

        public Hijo mialumno {get;set;}
        
    #endregion

        #region Commands
        public ICommand NavigateCommand
        {
            get
            {
                return new RelayCommand(Navigate);
            }
        }

        private async void  Navigate()
        {

        //    App.Master.IsPresented = false;

            if (this.PageName == "LoginPage")
            {
                //     Settings.IsRemembered = "false";
                //   var mainViewModel = MainViewModel.GetInstance();
                //  mainViewModel.Token = null;
                //  mainViewModel.User = null;
               
                    //     MainViewModel.GetInstance().Menus.Add(new MenuItemViewModel
                    //     {
                    //        Icon = "ic_exit_to_app",
                    //        PageName = "LoginPage",
                    //       Title = Languages.LogOut,
                    //   });

                    Application.Current.MainPage = new NavigationPage(
                    new LoginPage());
            }
         //  if (this.PageName == "AlumnoTabbedPage")
          //  {
                //     Settings.IsRemembered = "false";

                //    var seleccion = MainViewModel.GetInstance().AlumnosList.Select(l => new AlumnoItemViewModel

                foreach (Hijo item in (MainViewModel.GetInstance().AlumnosList))
                {
                    if (item.Cod_alum ==  this.PageName )
                    { this.mialumno = item; }
                }

                MainViewModel.GetInstance().Alumno = new AlumnoViewModel(this.mialumno);

            //     await   Application.Current.MainPage.DisplayActionSheet("hola",null,null);
            //      await task. Application.Current.MainPage.DisplayActionSheet("")
            using (UserDialogs.Instance.Loading("Cargando..", null, null, true, MaskType.Black))
            {
                await Task.Delay(3000);
            }



            using (UserDialogs.Instance.Loading("Cargando..", null, null, true, MaskType.Black))
            {
                await App.Navigator.PushAsync(new AlumnoTabbedPage());
                App.Master.IsPresented = false;
            }




        //    App.Navigator.PushAsync(new AlumnoTabbedPage());
            
            return;
            //      var mainViewModel = MainViewModel.GetInstance();
            //   App.Navigator.PushAsync(new CargandoPage());
          //  MainViewModel.GetInstance().Cargando = new CargandoViewModel();
         //   Application.Current.MainPage = new CargandoPage();


            //           }

            //        else if (this.PageName == "MyProfilePage")
            //      {
            //        MainViewModel.GetInstance().MyProfile = new MyProfileViewModel();
            //       App.Navigator.PushAsync(new MyProfilePage());
            //    }
        }
        #endregion
    }
}