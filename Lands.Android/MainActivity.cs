namespace Lands.Droid
{
    using Acr.UserDialogs;
    using Android.App;
    using Android.Content.PM;
    using Android.OS;
    using Android.Runtime;
    using FFImageLoading.Forms.Droid;
    using Plugin.Permissions;

    [Activity(
        Label = "Lands",
        Icon = "@drawable/icon",
        Theme = "@style/MainTheme",
        MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        #region Singleton
        private static MainActivity instance;

        public static MainActivity GetInstance()
        {
            if (instance == null)
            {
                instance = new MainActivity();
            }

            return instance;
        }
        #endregion
        #region Methods
        protected override void OnCreate(Bundle bundle)
        {



            instance = this;
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            CachedImageRenderer.Init(true);

            UserDialogs.Init(this);
  

            LoadApplication(new App());


        }
        #endregion
        public override void OnRequestPermissionsResult(
            int requestCode, 
            string[] permissions, 
            [GeneratedEnum] Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(
                requestCode, 
               permissions, 
               grantResults);
        }
    }
}