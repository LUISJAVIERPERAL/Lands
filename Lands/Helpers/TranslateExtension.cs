namespace Lands.Helpers
{
    using System;
    using System.Globalization;
    using System.Reflection;
    using System.Resources;
    using Interfaces;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        readonly CultureInfo ci;
        const string ResourceId = "Lands.Resources.Resource";

        static readonly Lazy<ResourceManager> ResMgr =
            new Lazy<ResourceManager>(() => new ResourceManager(
                ResourceId,
                typeof(TranslateExtension).GetTypeInfo().Assembly));

        public TranslateExtension()
        {
            var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            if (Settings.LenguajePersonal == String.Empty)
            {

                //     ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            //    Resource.Culture = ci;
            //    DependencyService.Get<ILocalize>().SetLocale(ci);
            }
            else
            {

                //    Settings.LenguajePersonal = String.Empty;
                ci = new CultureInfo(Settings.LenguajePersonal);
            //    Resource.Culture = ci;
            //    DependencyService.Get<ILocalize>().SetLocale(ci);
            }


          //  ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
        }

        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
            {
                return "";
            }

            var translation = ResMgr.Value.GetString(Text, ci);

            if (translation == null)
            {
#if DEBUG
                throw new ArgumentException(
                    String.Format(
                        "Key '{0}' was not found in resources '{1}' for culture '{2}'.",
                        Text, ResourceId, ci.Name), "Text");
#else
                translation = Text; // returns the key, which GETS DISPLAYED TO THE USER
#endif
            }

            return translation;
        }
    }
}
