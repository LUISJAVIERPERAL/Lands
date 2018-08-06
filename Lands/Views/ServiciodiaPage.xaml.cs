using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lands.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ServiciodiaPage : ContentPage
	{
		public ServiciodiaPage ()
		{
			InitializeComponent ();
		}
        void Handle_Toggled(object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            if (e.Value == true)
            {
                Application.Current.MainPage.DisplayAlert(
                          "ahora esta ok",
                      " ",
    
                          "Aceptar");
            }
            if (e.Value == false)
            {
                Application.Current.MainPage.DisplayAlert(
                          "ahora esta off",
                      " ",

                          "Aceptar");
            }
        }

    }
}