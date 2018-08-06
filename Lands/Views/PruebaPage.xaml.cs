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
	public partial class PruebaPage : ContentPage
	{
		public PruebaPage ()
		{
			InitializeComponent ();
		}

        void Handle_Toggled(object sender, Xamarin.Forms.ToggledEventArgs e)
        {
           
        }
    }
 

}