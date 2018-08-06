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
    using System.Threading.Tasks;
    using Domain;
    using Acr.UserDialogs;

    using System;
    //   using System.Collections.ObjectModel;
    //   using System.Linq;
    //   using Models;
    //   using Services;
    public class CalendarioViewModel : BaseViewModel
    {
        #region Services
        private ApiService apiService;

        #endregion

        #region Attributes
        public Grilla grillaActual;
        public int ultimonumero;
        public DateTime primerdia;
        private ObservableCollection<AccesoItemViewModel> accesos;
        private ObservableCollection<ServicioItemViewModel> serviciosmes;
        private ObservableCollection<ActividadItemViewModel> actividades;
        private List<Menuses> menusesmes;
        private List<Menuses> menusestodomes;
        private bool isRunning;
        private bool isReme;
        public int meselegido;
        public string fechapulsada;
        public int anyelegido;
        public int botonelegido; 
        public ObservableCollection<Diamodel> listagrilla;
        public string hijoActual;
        public int diapulsado;
        public int hayactividades;
        public bool muestraccesos;
        public bool muestraasistencia;
        public bool pulsato;
        private string primero;
        private ObservableCollection<Menuses> menudia;
        #endregion

        #region Propperties

        public bool Pulsato
        {
            get
            {
                return pulsato;
            }
            set
            {
                pulsato = value;
                Application.Current.MainPage.DisplayAlert(
                        "Vas a marcar algo",
                        "",
                        "Aceptar");
            }
        }



        public ObservableCollection<ActividadItemViewModel> Actividades
        {
            get { return this.actividades; }
            set { SetValue(ref this.actividades, value); }
        }
      

        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }
        public ObservableCollection<Menuses> Menudia
        {
            get { return this.menudia; }
            set { this.SetValue(ref this.menudia, value); }
        }

        public bool Muestraaccesos
        {
            get { return this.muestraccesos; }
            set { SetValue(ref this.muestraccesos, value); }
        }
        public bool Muestraasistencia
        {
            get { return this.muestraasistencia; }
            set { SetValue(ref this.muestraasistencia, value); }
        }
        public ObservableCollection<AccesoItemViewModel> Accesos
        {
            get { return this.accesos; }
            set { SetValue(ref this.accesos, value); }
        }

        public ObservableCollection<ServicioItemViewModel> Serviciosmes
        {
            get { return this.serviciosmes; }
            set { SetValue(ref this.serviciosmes, value); }
        }
        public int Diapulsado
        {
            get { return this.diapulsado; }
            set { SetValue(ref this.diapulsado, value); }
        }


        public List<Menuses> Menusesmes
        {
            get { return this.menusesmes; }
            set { SetValue(ref this.menusesmes, value); }
        }
       
        public List<Menuses> Menusestodomes
        {
            get { return this.menusestodomes; }
            set { SetValue(ref this.menusestodomes, value); }
        }

        public Grilla GrillaActual
        {
            get { return this.grillaActual; }
            set { SetValue(ref this.grillaActual, value); }
        }
        public string HijoActual
        {
            get { return this.hijoActual; }
            set { SetValue(ref this.hijoActual, value); }
        }
        public ObservableCollection<Diamodel> Listagrilla
        {
            get { return this.listagrilla; }
            set { SetValue(ref this.listagrilla, value); }
        }

        public int Meselegido
        {
            get
            {
               
                this.Rellenagrilla();

                //  this.GrillaActual = new Grilla { Grilla1 = new Diamodel { Texto = "mi texto", Fecha = this.meselegido } };

                return this.meselegido;
            }
            set
            {
                //       this.GrillaActual = new Grilla { Grilla1 = new Diamodel { Texto = "mi texto", Fecha = this.meselegido } };

                SetValue(ref this.meselegido, value);
            }
        }


        public string Fechapulsada

        {
           get
                { 
                return this.fechapulsada;
            }

            set {
                SetValue(ref this.fechapulsada, value);
            }
        }

        public string Primero
        {
            get { return this.primero; }
            set { SetValue(ref this.primero, value); }
        }





        #endregion

        #region Constructors


        public CalendarioViewModel(int paso)
        {



            //   string fecha = string.Format("{0:d}", this.Meselegido);
            if (paso == 1)
            {
                var queeshoy = DateTime.Today;

                this.meselegido = queeshoy.Month;
                this.anyelegido = queeshoy.Year;
                this.HijoActual = MainViewModel.GetInstance().hijo.Nom_alum.ToUpper() + " " + MainViewModel.GetInstance().hijo.Apellido1.ToUpper() + " " + MainViewModel.GetInstance().hijo.Apellido2.ToUpper();
 
                this.apiService = new ApiService();

                ultimonumero = 1;
                using (UserDialogs.Instance.Loading("Cargando..", null, null, true, MaskType.Black))
                {
                  Rellenagrilla();
                }
              

            }
            if (paso == 2)
            {
                using (UserDialogs.Instance.Loading("Actualizando..", null, null, true, MaskType.Black))
                {
                    var queeshoy = DateTime.Today;

                    this.meselegido = queeshoy.Month;
                    this.anyelegido = queeshoy.Year;
             //       this.HijoActual = MainViewModel.GetInstance().hijo.Nom_alum + " " + MainViewModel.GetInstance().hijo.Apellido1 + " " + MainViewModel.GetInstance().hijo.Apellido2;
                    this.HijoActual = MainViewModel.GetInstance().hijo.Nom_alum.ToUpper() + " " + MainViewModel.GetInstance().hijo.Apellido1.ToUpper() + " " + MainViewModel.GetInstance().hijo.Apellido2.ToUpper();

                    this.apiService = new ApiService();

               //     ultimonumero = 1;


                    
                    MarcaAccesos(2);

                    var actualmenusesmes = MainViewModel.GetInstance().MenusesListMes;

                    var listaactual = MainViewModel.GetInstance().GrillaList;
                    var grillapresente = MainViewModel.GetInstance().GrillaCalendario;


              //      this.HijoActual = MainViewModel.GetInstance().hijo.Nom_alum + " " + MainViewModel.GetInstance().hijo.Apellido1 + " " + MainViewModel.GetInstance().hijo.Apellido2;
                    this.HijoActual = MainViewModel.GetInstance().hijo.Nom_alum.ToUpper() + " " + MainViewModel.GetInstance().hijo.Apellido1.ToUpper() + " " + MainViewModel.GetInstance().hijo.Apellido2.ToUpper();

                    string h = MainViewModel.GetInstance().botonpulsado;

                    int numVal = Int32.Parse(h);

                    if (listaactual[numVal].Activo == "False")
                    {

                    }
                    else
                    {


                        var diapulsado = new DateTime(grillapresente.Anyactual, grillapresente.Mesactual, Int32.Parse(listaactual[numVal].Fecha));
                        int numdia = (int)(diapulsado.DayOfWeek);
                        var nomdia = "D";
                        var nomdia2 = "DOMINGO";
                        this.diapulsado = numdia;
                        switch (numdia)
                        {
                            case 1:
                                nomdia = "L";
                                nomdia2 = "LUNES";

                                break;
                            case 2:
                                nomdia = "M";
                                nomdia2 = "MARTES";
                                break;
                            case 3:
                                nomdia = "X";
                                nomdia2 = "MIERCOLES";
                                break;
                            case 4:
                                nomdia = "J";
                                nomdia2 = "JUEVES";
                                break;
                            case 5:
                                nomdia = "V";
                                nomdia2 = "VIERNES";
                                break;
                            case 6:
                                nomdia = "S";
                                nomdia2 = "SABADO";
                                break;
                            case 0:
                                nomdia = "D";
                                nomdia2 = "DOMINGO";
                                break;

                        }
                        this.Fechapulsada = nomdia2 + " " + listaactual[numVal].Fecha + "/" + grillapresente.Mesactual + "/" + grillapresente.Anyactual;
                        MainViewModel.GetInstance().Serviciosmes2 = new ObservableCollection<ServicioItemViewModel>(this.ToServicioItemViewModel().Where(l => (Int32.Parse(l.Dia) == Int32.Parse(listaactual[numVal].Fecha)) && (Int32.Parse(l.Mes) == grillapresente.Mesactual) && (l.Nombreservicio != "0")));

                        //     this.Serviciosmes = new ObservableCollection<ServicioItemViewModel>(this.ToServicioItemViewModel().Where(l => (Int32.Parse(l.Dia) == Int32.Parse(listaactual[numVal].Fecha)) && (Int32.Parse(l.Mes) == grillapresente.Mesactual)));

                        //   MainViewModel.GetInstance().MenusesListDia = new List<Menuses>(actualmenusesmes.Where(l => (Int32.Parse(l.Dia) == Int32.Parse(listaactual[numVal].Fecha)) && (Int32.Parse(l.Mes) == grillapresente.Mesactual)));
                        MainViewModel.GetInstance().Fechacalendario = this.fechapulsada;
                        listaactual[ultimonumero].Color = "Transparent";
                        listaactual[numVal].Color = "LightGray";
                        ultimonumero = numVal;
                        if (hayactividades == 1)
                        {
                            this.Actividades = new ObservableCollection<ActividadItemViewModel>(this.ToActividadItemViewModel().Where(l => l.Diassemana.Contains(nomdia)));
                        }

                        //     listaactual[numVal].Color = "LightGray";
                        //          App.Navigator.PushAsync(new DiarioPage());
                        MainViewModel.GetInstance().GrillaList = listaactual;
                        RepintaGrilla();

                        //   Application.Current.MainPage.DisplayAlert(tetxo, "h", "Acept");
                        //     var Menusesmes = MainViewModel.GetInstance().MenusesListDia;

                        //     this.Menudia = new ObservableCollection<Menuses>(Menusesmes.Where((l => l.Codigoservicio == Servicio.Codservicio)));

                        if (diapulsado > DateTime.Today)
                        {
                            this.Muestraaccesos = false;
                            this.Muestraasistencia = true;
                        }
                        else
                        {
                            this.Muestraaccesos = true;
                            this.Muestraasistencia = false;
                        }
                    }



                }



            }
        }

        #endregion





        #region Methods




        private ICommand micomando;
        public ICommand PulsadoCommand2 
        {
         
                get
        {
                    {
                            micomando = new Command((e) =>
                            {





                                var actualmenusesmes = MainViewModel.GetInstance().MenusesListMes;

                               var listaactual = MainViewModel.GetInstance().GrillaList;
                               var grillapresente = MainViewModel.GetInstance().GrillaCalendario;


                                this.HijoActual = MainViewModel.GetInstance().hijo.Nom_alum + " " + MainViewModel.GetInstance().hijo.Apellido1 + " " + MainViewModel.GetInstance().hijo.Apellido2;
                                string h = $"{e}";
                                    int numVal = Int32.Parse(h);

                                if (listaactual[numVal].Activo == "False")
                                {

                                }
                                else
                                {
                                    

                                    var diapulsado = new DateTime(grillapresente.Anyactual, grillapresente.Mesactual, Int32.Parse(listaactual[numVal].Fecha));
                                    int numdia = (int)(diapulsado.DayOfWeek);
                                    var nomdia = "D";
                                    var nomdia2 = "DOMINGO";
                                    this.diapulsado = numdia;
                                    switch (numdia)
                                    {
                                        case 1:
                                            nomdia = "L";
                                            nomdia2 = "LUNES";
                                          
                                            break;
                                        case 2:
                                            nomdia = "M";
                                            nomdia2 = "MARTES";
                                            break;
                                        case 3:
                                            nomdia = "X";
                                            nomdia2 = "MIERCOLES";
                                            break;
                                        case 4:
                                            nomdia = "J";
                                            nomdia2 = "JUEVES";
                                            break;
                                        case 5:
                                            nomdia = "V";
                                            nomdia2 = "VIERNES";
                                            break;
                                        case 6:
                                            nomdia = "S";
                                            nomdia2 = "SABADO";
                                            break;
                                        case 0:
                                            nomdia = "D";
                                            nomdia2 = "DOMINGO";
                                            break;

                                    }

                                    this.Fechapulsada = nomdia2 +" " +  listaactual[numVal].Fecha + "/" + grillapresente.Mesactual + "/" + grillapresente.Anyactual;
                                    this.Serviciosmes = new ObservableCollection<ServicioItemViewModel>(this.ToServicioItemViewModel().Where(l => (Int32.Parse(l.Dia) == Int32.Parse(listaactual[numVal].Fecha)) && (Int32.Parse(l.Mes) == grillapresente.Mesactual) && (l.Codservicio != "0" )));

                                    MainViewModel.GetInstance().MenusesListDia =  new List<Menuses>(actualmenusesmes.Where(l => (Int32.Parse(l.Dia) == Int32.Parse(listaactual[numVal].Fecha)) && (Int32.Parse(l.Mes) == grillapresente.Mesactual)));
                                    MainViewModel.GetInstance().Fechacalendario = this.fechapulsada;

                                    if (hayactividades == 1)
                                        {
                                        this.Actividades = new ObservableCollection<ActividadItemViewModel>(this.ToActividadItemViewModel().Where(l => l.Diassemana.Contains(nomdia)));
                                    }

                                    //   listaactual[numVal].Color = "#FFFFFF";
                                    App.Navigator.PushAsync(new DiarioPage());
                                    // MainViewModel.GetInstance().GrillaList = listaactual;
                                    // RepintaGrilla();

                                    //   Application.Current.MainPage.DisplayAlert(tetxo, "h", "Acept");


                                }
                            });

                        return micomando;
                    }

                }
            }


        public ICommand PulsadoCommand
        {

            get
            {
                {
                    micomando = new Command((e) =>
                    {





                        var actualmenusesmes = MainViewModel.GetInstance().MenusesListMes;

                        var listaactual = MainViewModel.GetInstance().GrillaList;
                        var grillapresente = MainViewModel.GetInstance().GrillaCalendario;

                        this.HijoActual = MainViewModel.GetInstance().hijo.Nom_alum.ToUpper() + " " + MainViewModel.GetInstance().hijo.Apellido1.ToUpper() + " " + MainViewModel.GetInstance().hijo.Apellido2.ToUpper();

               //         this.HijoActual = MainViewModel.GetInstance().hijo.Nom_alum + " " + MainViewModel.GetInstance().hijo.Apellido1 + " " + MainViewModel.GetInstance().hijo.Apellido2;
                        string h = $"{e}";
                        int numVal = Int32.Parse(h);

                        if (listaactual[numVal].Activo == "False")
                        {

                        }
                        else
                        {
                            

                            var diapulsado = new DateTime(grillapresente.Anyactual, grillapresente.Mesactual, Int32.Parse(listaactual[numVal].Fecha));
                            int numdia = (int)(diapulsado.DayOfWeek);
                            var nomdia = "D";
                            var nomdia2 = "DOMINGO";
                            this.diapulsado = numdia;
                            switch (numdia)
                            {
                                case 1:
                                    nomdia = "L";
                                    nomdia2 = "LUNES";

                                    break;
                                case 2:
                                    nomdia = "M";
                                    nomdia2 = "MARTES";
                                    break;
                                case 3:
                                    nomdia = "X";
                                    nomdia2 = "MIERCOLES";
                                    break;
                                case 4:
                                    nomdia = "J";
                                    nomdia2 = "JUEVES";
                                    break;
                                case 5:
                                    nomdia = "V";
                                    nomdia2 = "VIERNES";
                                    break;
                                case 6:
                                    nomdia = "S";
                                    nomdia2 = "SABADO";
                                    break;
                                case 0:
                                    nomdia = "D";
                                    nomdia2 = "DOMINGO";
                                    break;

                            }
                            this.Fechapulsada = nomdia2 + " " + listaactual[numVal].Fecha + "/" + grillapresente.Mesactual + "/" + grillapresente.Anyactual;
                            MainViewModel.GetInstance().Serviciosmes2 = new ObservableCollection<ServicioItemViewModel>(this.ToServicioItemViewModel().Where(l => (Int32.Parse(l.Dia) == Int32.Parse(listaactual[numVal].Fecha)) && (Int32.Parse(l.Mes) == grillapresente.Mesactual) && (l.Nombreservicio != "0")));

                       //     this.Serviciosmes = new ObservableCollection<ServicioItemViewModel>(this.ToServicioItemViewModel().Where(l => (Int32.Parse(l.Dia) == Int32.Parse(listaactual[numVal].Fecha)) && (Int32.Parse(l.Mes) == grillapresente.Mesactual)));

                         //   MainViewModel.GetInstance().MenusesListDia = new List<Menuses>(actualmenusesmes.Where(l => (Int32.Parse(l.Dia) == Int32.Parse(listaactual[numVal].Fecha)) && (Int32.Parse(l.Mes) == grillapresente.Mesactual)));
                            MainViewModel.GetInstance().Fechacalendario = this.fechapulsada;
                            MainViewModel.GetInstance().botonpulsado = $"{e}";
                            listaactual[ultimonumero].Color = "Transparent";
                            listaactual[numVal].Color = "LightGray";
                            ultimonumero = numVal;
                            if (hayactividades == 1)
                            {
                                this.Actividades = new ObservableCollection<ActividadItemViewModel>(this.ToActividadItemViewModel().Where(l => l.Diassemana.Contains(nomdia)));
                            }

                          //     listaactual[numVal].Color = "LightGray";
                  //          App.Navigator.PushAsync(new DiarioPage());
                             MainViewModel.GetInstance().GrillaList = listaactual;
                             RepintaGrilla();

                            //   Application.Current.MainPage.DisplayAlert(tetxo, "h", "Acept");
                       //     var Menusesmes = MainViewModel.GetInstance().MenusesListDia;

                       //     this.Menudia = new ObservableCollection<Menuses>(Menusesmes.Where((l => l.Codigoservicio == Servicio.Codservicio)));

                            if (diapulsado > DateTime.Today)
                            {
                                this.Muestraaccesos = false;
                                this.Muestraasistencia = true;
                            }
                           else
                            {
                                this.Muestraaccesos = true;
                                this.Muestraasistencia = false;
                            }
                        }


                    });

                    return micomando;
                }

            }
        }

        public void Cargodiaactual()
        {

            var hoyeshoy = DateTime.Today;

            var mimes = "0" + $"{hoyeshoy.Month}";


            // para meterle el 0 en el mes

            if (mimes.Length == 2)
            {
                mimes = mimes.Substring(0, 2);
            }
            else
            {
                mimes = mimes.Substring(1, 2);
            }

            var diaactualtmp = $"{hoyeshoy.Day}";
            var diaactual = "0" + diaactualtmp;
            // para meterle el 0 en el dia
            if (diaactual.Length == 2)
            {
                diaactual = diaactual.Substring(0, 2);
            }
            else
            {
                diaactual = diaactual.Substring(1, 2);
            }




            var hoyformato = $"{hoyeshoy.Year}" + "." + mimes + "." + diaactual;

            var actualmenusesmes = MainViewModel.GetInstance().MenusesListMes;

                        var listaactual = MainViewModel.GetInstance().GrillaList;
                        var grillapresente = MainViewModel.GetInstance().GrillaCalendario;


                        this.HijoActual = MainViewModel.GetInstance().hijo.Nom_alum + " " + MainViewModel.GetInstance().hijo.Apellido1 + " " + MainViewModel.GetInstance().hijo.Apellido2;
                      //  string h = $"{e}";
                        int numVal = hoyeshoy.Day;

                        if (listaactual[numVal].Activo == "False")
                        {

                        }
                        else
                        {

                 string h = $"{numVal}";
                this.Fechapulsada = "Dia :" + h + "/" + grillapresente.Mesactual + "/" + grillapresente.Anyactual;

                            var diapulsado = hoyeshoy;

                           int numdia = (int)(diapulsado.DayOfWeek);
                            var nomdia = "D";
                            this.diapulsado = numdia;
                            switch (numdia)
                            {
                                case 1:
                                    nomdia = "L";
                                    break;
                                case 2:
                                    nomdia = "M";
                                    break;
                                case 3:
                                    nomdia = "X";
                                    break;
                                case 4:
                                    nomdia = "J";
                                    break;
                                case 5:
                                    nomdia = "V";
                                    break;
                                case 6:
                                    nomdia = "S";
                                    break;
                                case 0:
                                    nomdia = "D";
                                    break;

                            }

                            this.Serviciosmes = new ObservableCollection<ServicioItemViewModel>(this.ToServicioItemViewModel().Where(l => (l.Fecha == hoyformato) && (l.Nombreservicio != "0")));


                            MainViewModel.GetInstance().MenusesListDia = new List<Menuses>(actualmenusesmes.Where(l => (l.Fechamenu == hoyformato)));
                            MainViewModel.GetInstance().Fechacalendario = this.fechapulsada;

                            if (hayactividades == 1)
                            {
                                this.Actividades = new ObservableCollection<ActividadItemViewModel>(this.ToActividadItemViewModel().Where(l => l.Diassemana.Contains(nomdia)));
                            }

                   

                        }
                    

                   
        }


        public ICommand SiguienteCommand
        {
            get
            {
            
                return new RelayCommand(SiguienteMes);
            }
        }



        private async void SiguienteMes()
        {
           



            if (this.meselegido == 12)
            {
                this.anyelegido = this.anyelegido + 1;
                this.meselegido = 1;
                using (UserDialogs.Instance.Loading("Cargando..", null, null, true, MaskType.Black))
                {
                    Rellenagrilla();
                }

            //    Rellenagrilla();
            }
            else

            {
                this.meselegido = this.meselegido + 1;
                using (UserDialogs.Instance.Loading("Cargando..", null, null, true, MaskType.Black))
                {
                     Rellenagrilla();
                }
              //  Rellenagrilla();
            }
  //         this.IsRunning = false;
        }

        public ICommand AnteriorCommand
        {
            get
            {
                return new RelayCommand(AnteriorMes);
            }
        }



        private async void AnteriorMes()
        {
            this.IsRunning = true;
            if (this.meselegido == 1)
            {
                this.anyelegido = this.anyelegido - 1;
                this.meselegido = 12;
                using (UserDialogs.Instance.Loading("Cargando..", null, null, true, MaskType.Black))
                {
                     Rellenagrilla();
                }

            //    Rellenagrilla();
            }
            else

            {
                this.meselegido = this.meselegido - 1;
                using (UserDialogs.Instance.Loading("Cargando..", null, null, true, MaskType.Black))
                {
                    Rellenagrilla();
                }
            //    Rellenagrilla();
            }
            this.IsRunning = false;
        }








        private async Task Rellenagrilla()

        {


            int m = this.meselegido;
            int y = this.anyelegido;
            string bisiesto = "n";
            var nombremesactual = "enero";

            // List<Diamodel> Listagrilla;



            switch (m)
            {
                case 1:
                    nombremesactual = "Enero " + this.anyelegido;
                    break;
                case 2:
                    nombremesactual = "Febrero " + this.anyelegido;
                    break;
                case 3:
                    nombremesactual = "Marzo " + this.anyelegido;
                    break;
                case 4:
                    nombremesactual = "Abril " + this.anyelegido;
                    break;
                case 5:
                    nombremesactual = "Mayo " + this.anyelegido;
                    break;
                case 6:
                    nombremesactual = "Junio " + this.anyelegido;
                    break;
                case 7:
                    nombremesactual = "Julio " + this.anyelegido;
                    break;
                case 8:
                    nombremesactual = "Agosto " + this.anyelegido;
                    break;
                case 9:
                    nombremesactual = "Septiembre " + this.anyelegido;
                    break;
                case 10:
                    nombremesactual = "Octubre " + this.anyelegido;
                    break;
                case 11:
                    nombremesactual = "Noviembre " + this.anyelegido;
                    break;

                case 12:
                    nombremesactual = "Diciembre " + this.anyelegido;
                    break;
            }
            DateTime fechita = new DateTime(y, m, 1);

            if (DateTime.IsLeapYear(y))
            {
                bisiesto = "s";
            }

            int d = (int)fechita.DayOfWeek;

            if (d == 0)
            {
                d = 7;
            }
            //     string s = $"{d}";
            this.Listagrilla = new ObservableCollection<Diamodel>();
            this.Listagrilla.Add(new Diamodel
            {
                Fecha = "",
                Color = "Transparent",
                Activo = "False",
                Taman = "18",
                Colorfont = "Black",
                Icono = "GG",
            });
            for (int i = 1; i <= 42; i++)
            {

                if (d > i)
                {
                    this.Listagrilla.Add(new Diamodel
                    {
                        Fecha = "0",
                        Color = "Transparent",
                        Activo = "False",
                        Taman = "18",
                        Icono = "GG",
                        Colorfont = "Black",

                    });
                }
                else
                {
                    if (i - (d - 1) > 28 && m == 2)
                    {
                        if (bisiesto == "s")
                        {
                            Listagrilla.Add(new Diamodel
                            {
                                Fecha = $"{i - (d - 1)}",
                                Color = "Transparent",
                                Activo = "True",
                                Taman = "18",
                                Icono = "GG",
                                Colorfont = "Black",

                            });
                        }
                        else
                        {
                            Listagrilla.Add(new Diamodel
                            {
                                Fecha = "f1",
                                Color = "Transparent",
                                Activo = "False",
                                Taman = "18",
                                Icono = "GG",
                                Colorfont = "Black",

                            });
                        }

                    }

                    else
                    {
                        if ((i - (d - 1) >= 31) && (m == 4 || m == 6 || m == 9 || m == 11))
                        {

                            Listagrilla.Add(new Diamodel
                            {
                                Fecha = "f2",
                                Color = "Transparent",
                                Activo = "False",
                                Taman = "18",
                                Icono = "GG",
                                Colorfont = "Black",
                            });

                        }
                        else
                        {

                            if (i - (d - 1) <= 31)
                            {

                                Listagrilla.Add(new Diamodel
                                {
                                    Fecha = $"{i - (d - 1)}",
                                    Color = "Transparent",
                                    Activo = "True",
                                    Taman = "18",
                                    Icono = "GG",
                                    Colorfont = "Black",

                                });
                            }
                            else
                            {
                                Listagrilla.Add(new Diamodel
                                {
                                    Fecha = "f3",
                                    Color = "Transparent",
                                    Activo = "False",
                                    Taman = "18",
                                    Icono = "GG",
                                    Colorfont = "Black",
                                });
                            }
                        }
                    }
                }


            }
        
        
            var prueba = Listagrilla[1];

            //     Listagrilla[1+d] = (new Diamodel
            //      {
            //          Fecha = "",
            //          Color = "#FFFFFF",
            //         Activo = "False"
            ///     });

            //    Listagrilla[1 + d].Fecha = "d";



            MainViewModel.GetInstance().GrillaList = this.Listagrilla;
            


            this.GrillaActual = new Grilla
            {
                Mesactual = m,
                Anyactual = y,
                NombreMesactual = nombremesactual,
                EmpiezaDia = d-1,
                Grilla1 = Listagrilla[1],
                Grilla2 = Listagrilla[2],
                Grilla3 = Listagrilla[3],
                Grilla4 = Listagrilla[4],
                Grilla5 = Listagrilla[5],
                Grilla6 = Listagrilla[6],
                Grilla7 = Listagrilla[7],
                Grilla8 = Listagrilla[8],
                Grilla9 = Listagrilla[9],
                Grilla10 = Listagrilla[10],
                Grilla11 = Listagrilla[11],
                Grilla12 = Listagrilla[12],
                Grilla13 = Listagrilla[13],
                Grilla14 = Listagrilla[14],
                Grilla15 = Listagrilla[15],
                Grilla16 = Listagrilla[16],
                Grilla17 = Listagrilla[17],
                Grilla18 = Listagrilla[18],
                Grilla19 = Listagrilla[19],
                Grilla20 = Listagrilla[20],
                Grilla21 = Listagrilla[21],
                Grilla22 = Listagrilla[22],
                Grilla23 = Listagrilla[23],
                Grilla24 = Listagrilla[24],
                Grilla25 = Listagrilla[25],
                Grilla26 = Listagrilla[26],
                Grilla27 = Listagrilla[27],
                Grilla28 = Listagrilla[28],
                Grilla29 = Listagrilla[29],
                Grilla30 = Listagrilla[30],
                Grilla31 = Listagrilla[31],
                Grilla32 = Listagrilla[32],
                Grilla33 = Listagrilla[33],
                Grilla34 = Listagrilla[34],
                Grilla35 = Listagrilla[35],
                Grilla36 = Listagrilla[36],
                Grilla37 = Listagrilla[37],
                Grilla38 = Listagrilla[38],
                Grilla39 = Listagrilla[39],
                Grilla40 = Listagrilla[40],
                Grilla41 = Listagrilla[41],
                Grilla42 = Listagrilla[42]
            };
            MainViewModel.GetInstance().GrillaCalendario = this.GrillaActual;
            this.apiService = new ApiService();
        //    using (UserDialogs.Instance.Loading("Cargando..", null, null, true, MaskType.Black))
        //    {
              //  using (UserDialogs.Instance.Loading("Cargando..", null, null, true, MaskType.Black))
              //  {
                  await MarcaAccesos(1);

              //  }

              
          //  }
      //     MarcaAccesos();
            
         

        }



            private async Task MarcaAccesos(int modo)
        {
            var CalendarioACT = MainViewModel.GetInstance().GrillaCalendario;
            var ListaCalendarioACT = MainViewModel.GetInstance().GrillaList;
            var tokin = MainViewModel.GetInstance().Mitoken;
            var alumnoactual = MainViewModel.GetInstance().hijo;
            var centro = MainViewModel.GetInstance().Centro;
            var haymenus = 0;
            var hayactividad = 0;
            var hayaccesos = 0;
            var hayservicios = 0;
            var mimes = "0" + CalendarioACT.Mesactual;
            var miany = $"{CalendarioACT.Anyactual}";

            // para meterle el 0 en el mes
            if (mimes.Length == 2)
            {
                mimes = mimes.Substring(0, 2);
            }
            else
            {
                mimes = mimes.Substring(1, 2);
            }

            //
            var f1 = CalendarioACT.Anyactual + "-" + mimes + "-" + "01";
            var f11 = CalendarioACT.Anyactual + "-" + mimes + "-" + "01";
            primerdia = new DateTime(CalendarioACT.Anyactual, Int32.Parse(mimes),1);

            // pongo el numero de dias del mes
            var numdias = DateTime.DaysInMonth(CalendarioACT.Anyactual, CalendarioACT.Mesactual);
            var f2 = CalendarioACT.Anyactual + "-" + mimes + "-" + $"{numdias}";
            var servicio = "0";
            var fam = tokin.Cod_alumf;


            var diaactualtmp = $"{DateTime.Now.Day}";
            var diaactual = "0" + diaactualtmp;
            // para meterle el 0 en el dia
            if (diaactual.Length == 2)
            {
                diaactual = diaactual.Substring(0, 2);
            }
            else
            {
                diaactual = diaactual.Substring(1, 2);
            }

            //
            var mesactualtmp = $"{DateTime.Now.Month}";
            var mesactual = "0" + mesactualtmp;
            var anyactual = $"{DateTime.Now.Year}";
            // para meterle el 0 en el dia
            if (mesactual.Length == 2)
            {
                mesactual = mesactual.Substring(0, 2);
            }
            else
            {
                mesactual = mesactual.Substring(1, 2);
            }

     



                    var fechaactual = $"{DateTime.Now.Year}" + mesactual + diaactual;

            var connection = await this.apiService.CheckConnection();


            //CARGO ACTIVIDADES DEL MES

            var response3 = await this.apiService.CogeActividades<Actividad>(
              "https://comocomen.com/main_control/servidor_ws.php",
              tokin.AccessToken,
                centro,
                alumnoactual.Num_expediente,
                fechaactual);
            /// compruebo que haya 

            if (response3.IsSuccess == false)
            {
                hayactividades = 0;

                List<Actividad> SINACTI = new List<Actividad>();

                SINACTI.Add(new Actividad
                {
                    Diassemana = "",
                    Error = "SIN ACTIVIDADES"
                });

                MainViewModel.GetInstance().ActividadesList = SINACTI;

            }
            else
            {
                hayactividades = 1;
                MainViewModel.GetInstance().ActividadesList = (List<Actividad>)response3.Result;

            }





            ///CARGO MENUS DEL MES

            var response2 = await this.apiService.CogeMenusesMes<Menuses>(
                "https://comocomen.com/main_control/servidor_ws.php",
                tokin.AccessToken,
                centro,
                alumnoactual.Num_expediente,
                fam,
                f1,
                f2,
                servicio);

            /// compruebo que haya menusmes
            if (response2.IsSuccess == false)
            {
                haymenus = 0;
            }
            else
            {
                haymenus = 1;
                MainViewModel.GetInstance().MenusesListMes = (List<Menuses>)response2.Result;

            }


            ///CARGO SERVICIOS DEL MES
            var response1 = await this.apiService.CogeServiciosMes<Servicio>(
                "https://comocomen.com/main_control/servidor_ws.php",
                 tokin.AccessToken,
                centro,
                alumnoactual.Num_expediente,
                f1,
                servicio);
            if (response1.IsSuccess == false)
            {
                hayservicios = 0;
            }
            else
            {

                hayservicios = 1;

                MainViewModel.GetInstance().ServiciosListMes = (List<Servicio>)response1.Result;

            }



            ///









      //      var response = await this.apiService.CogeAccesos<Acceso>(
      //          "https://comocomen.com/main_control/servidor_ws.php",
      //          tokin.AccessToken,
      //          centro,
      //          alumnoactual.Num_expediente,
       //         f1,
       //         f2,
       //         servicio);
            /// compruebo que haya accessos
      //      if (response.IsSuccess == false)
       //     {
                hayaccesos = 0;
       //     }
       //     else
       //     {

       //         hayaccesos = 1;
       //         MainViewModel.GetInstance().AccesosList = (List<Acceso>)response.Result;

       //     }







       //     var AccesosACT = MainViewModel.GetInstance().AccesosList;
            var ServiciosACT = MainViewModel.GetInstance().ServiciosListMes;
            var MenusesACT = MainViewModel.GetInstance().MenusesListMes;
            var ActividadesACT = MainViewModel.GetInstance().ActividadesList;
            this.Menusestodomes = MainViewModel.GetInstance().MenusesListMes;



            for (int n = 0; n < ServiciosACT.Count(); n++)
            {

           //     if (hayaccesos == 1)
           //     {
             //       var busco = from num in AccesosACT where (num.Fechacorta == ServiciosACT[n].Fecha && num.Codigoservicio == ServiciosACT[n].Codservicio && num.Turnoservicio == ServiciosACT[n].Codturno && ServiciosACT[n].Nombreservicio != "0") select num;
           //         var busco = from num in AccesosACT where (num.Fechacorta == ServiciosACT[n].Fecha && num.Codigoservicio == ServiciosACT[n].Codservicio && ServiciosACT[n].Nombreservicio != "0") select num;


             //       if (busco.Count() > 0)
             //       {
              //          List<Acceso> mibusco = new List<Acceso>();

                //        foreach (var l in busco) mibusco.Add(new Acceso()
                 //       {
                 //           Fechaacceso = l.Fechaacceso,
                 //           Codigoservicio = l.Codigoservicio,
                  //          Nombreacceso = l.Nombreacceso,
                   //         Tipoacceso = l.Tipoacceso,
                    //        Iconor = l.Iconor,
                    //        Mes = l.Mes,
                     //       Dia = l.Dia,
                     //       Any = l.Any


                     //   });
                        var colorin = "G";
                        if (ServiciosACT[n].Tipocomidas == "X")
                        { colorin = "R"; }
                        if (ServiciosACT[n].Tipocomidas == "A")
                        { colorin = "V"; }
                        if (ServiciosACT[n].Tipocomidas == "J")
                        { colorin = "A"; }
                        string iconoactual = ListaCalendarioACT[(Int32.Parse(ServiciosACT[n].Dia) + CalendarioACT.EmpiezaDia)].Icono;
                        if (iconoactual.Substring(0, 1) == "G")
                        {
                            colorin = colorin + "G";
                        }
                        else
                        {
                            colorin = ListaCalendarioACT[(Int32.Parse(ServiciosACT[n].Dia) + CalendarioACT.EmpiezaDia)].Icono.Substring(0, 1) + colorin;
                        }
                        ListaCalendarioACT[(Int32.Parse(ServiciosACT[n].Dia) + CalendarioACT.EmpiezaDia)].Icono = colorin;





                       // ServiciosACT[n].Acceso = mibusco[0].Tipoacceso;
                      //  ServiciosACT[n].Fechaacceso = mibusco[0].hora;
                 //   }

                  //  else
                  //  {
                   //ServiciosACT[n].Acceso = "P";
             //      }

                    // MIRO SI ESTOY EN EL MES ACTUAL
                    if (mesactual == mimes)
                    {
                        if (anyactual == miany)

                        {
                            f11 = CalendarioACT.Anyactual + "-" + mimes + "-" + diaactual;
                            ListaCalendarioACT[Int32.Parse(diaactual) + CalendarioACT.EmpiezaDia].Color = "LightGray";
                            ultimonumero = Int32.Parse(diaactual) + CalendarioACT.EmpiezaDia;
                        }
                        else
                        {
                            ListaCalendarioACT[Int32.Parse("01") + CalendarioACT.EmpiezaDia].Color = "LightGray";
                            ultimonumero = Int32.Parse("01") + CalendarioACT.EmpiezaDia;
                        }

                    }
                    else
                    {
                        ListaCalendarioACT[Int32.Parse("01") + CalendarioACT.EmpiezaDia].Color = "LightGray";
                        ultimonumero = Int32.Parse("01") + CalendarioACT.EmpiezaDia;
                    }


                    MainViewModel.GetInstance().GrillaList = ListaCalendarioACT;
                 //   RepintaGrilla();
           //     }




                //busco en los menus
                if (haymenus == 1)
                {
                    var buscomenu = from num in MenusesACT where (num.Fechamenu == ServiciosACT[n].Fecha && num.Codigoservicio == ServiciosACT[n].Codservicio) select num;
                    if (buscomenu.Count() > 0)
                    {

                        ServiciosACT[n].conmenu = true;
                        ServiciosACT[n].sinmenu = false;
                        List<Menuses> mismenus = new List<Menuses>();

                        foreach (var l in buscomenu) mismenus.Add(new Menuses()
                        {
                           Any = l.Any,
                           Codigoservicio = l.Codigoservicio,
                           Dia = l.Dia,
                           Dieta = l.Dieta,
                           Entrante = l.Entrante,
                           Fechamenu = l.Fechamenu,
                           Mes = l.Mes,
                           Nombremenu = l.Nombremenu,
                           Platodefecto = l.Platodefecto,
                           Platos = l.Platos,
                           Postre = l.Postre,
                           Primero = l.Primero,
                           Primerplato = l.Primerplato,
                           Segundo = l.Segundo,

                        });

                        ServiciosACT[n].elmenu = mismenus[0];
                        ServiciosACT[n].nombremenu1 = mismenus[0].Nombremenu;
                        ServiciosACT[n].primerplato1 = mismenus[0].Primero;
                        ServiciosACT[n].segundoplato1 = mismenus[0].Segundo;
                        ServiciosACT[n].entrante1 = mismenus[0].Entrante;
                        ServiciosACT[n].postre1 = mismenus[0].Postre;

                    }
                    else
                    {
                        ServiciosACT[n].sinmenu = true;
                        ServiciosACT[n].conmenu = false;
                    }
                }
                else
                {
                    ServiciosACT[n].sinmenu = true;
                    ServiciosACT[n].conmenu = false;
                }

            }
            RepintaGrilla();

            MainViewModel.GetInstance().ServiciosListMes = ServiciosACT;


            if (modo == 1)
            {

                MainViewModel.GetInstance().Serviciosmes2 = new ObservableCollection<ServicioItemViewModel>(this.ToServicioItemViewModel().Where(l => (l.Fecha == f11) && (l.Nombreservicio != "0")));
            }
        //    this.Serviciosmes = new ObservableCollection<ServicioItemViewModel>(

         //   this.ToServicioItemViewModel());








            if (hayactividades == 1)
            {
                this.Actividades = new ObservableCollection<ActividadItemViewModel>(

                   this.ToActividadItemViewModel());
            }


            //    IEnumerable<Acceso> filteringQuery =
            //      from num in AccesosACT
            //       where num.mes == "04" select num;
            var Mesdebusqueda = $"{CalendarioACT.Mesactual}";
            var Anybusqueda = $"{CalendarioACT.Anyactual}";

            ;
        }

        private void RepintaGrilla()
        {

            var grillaanterior = MainViewModel.GetInstance().GrillaCalendario;
            var mes = grillaanterior.Mesactual;
            var any = grillaanterior.Anyactual;
            var nombremes = grillaanterior.NombreMesactual;
              
           var Listanueva = MainViewModel.GetInstance().GrillaList;

            this.GrillaActual = new Grilla
            {
                Mesactual = mes,
                Anyactual = any,
                NombreMesactual = nombremes,
                Grilla1 = Listanueva[1],
                Grilla2 = Listanueva[2],
                Grilla3 = Listanueva[3],
                Grilla4 = Listanueva[4],
                Grilla5 = Listanueva[5],
                Grilla6 = Listanueva[6],
                Grilla7 = Listanueva[7],
                Grilla8 = Listanueva[8],
                Grilla9 = Listanueva[9],
                Grilla10 = Listanueva[10],
                Grilla11 = Listanueva[11],
                Grilla12 = Listanueva[12],
                Grilla13 = Listanueva[13],
                Grilla14 = Listanueva[14],
                Grilla15 = Listanueva[15],
                Grilla16 = Listanueva[16],
                Grilla17 = Listanueva[17],
                Grilla18 = Listanueva[18],
                Grilla19 = Listanueva[19],
                Grilla20 = Listanueva[20],
                Grilla21 = Listanueva[21],
                Grilla22 = Listanueva[22],
                Grilla23 = Listanueva[23],
                Grilla24 = Listanueva[24],
                Grilla25 = Listanueva[25],
                Grilla26 = Listanueva[26],
                Grilla27 = Listanueva[27],
                Grilla28 = Listanueva[28],
                Grilla29 = Listanueva[29],
                Grilla30 = Listanueva[30],
                Grilla31 = Listanueva[31],
                Grilla32 = Listanueva[32],
                Grilla33 = Listanueva[33],
                Grilla34 = Listanueva[34],
                Grilla35 = Listanueva[35],
                Grilla36 = Listanueva[36],
                Grilla37 = Listanueva[37],
                Grilla38 = Listanueva[38],
                Grilla39 = Listanueva[39],
                Grilla40 = Listanueva[40],
                Grilla41 = Listanueva[41],
                Grilla42 = Listanueva[42]
    };
            MainViewModel.GetInstance().GrillaCalendario = this.GrillaActual;
            this.IsRunning = false;
        }


        private IEnumerable<ServicioItemViewModel> ToServicioItemViewModel()
        {
            return MainViewModel.GetInstance().ServiciosListMes.Select(l => new ServicioItemViewModel
            {
                Codservicio = l.Codservicio,
                Tipoasistencia = l.Tipoasistencia,
                Diasasistencia = l.Diasasistencia,
                Numeroasistencias = l.Numeroasistencias,
                Codmesa = l.Codmesa,
                Codturno = l.Codturno,
                Nombreservicio = l.Nombreservicio.ToUpper(),
                Nombreturno = l.Nombreturno,
                Fecha = l.Fecha,
                conmenu = l.conmenu,
                Tipocomidas = l.Tipocomidas,
                FechaCambio =l.FechaCambio,
                Monitores = l.Monitores,
                Dia = l.Dia,
                Mes = l.Mes,
                Any = l.Any,
                Iconoasistencia = l.Iconoasistencia,
                Iconoausencia =  l.Iconoausencia,
                Avisoasistencia = l.Avisoasistencia,
                Avisodieta = l.Avisodieta,
                Avisoausencia = l.Avisoausencia ,
                entrante1 = l.entrante1,
                nombremenu1 = l.nombremenu1,
                primerplato1 = l.primerplato1,
                segundoplato1 = l.segundoplato1,
                elmenu = l.elmenu,
                postre1 = l.postre1,
                sinmenu = l.sinmenu,
                tieneacesso = l.tieneacesso,
                notieneacesso = l.notieneacesso,
                Coloracceso = l.Coloracceso,
                modelo1 = l.modelo1,
                modelo2 = l.modelo2,
                Pulsato = l.Pulsato,
                Accesotxt =l.Accesotxt,
                Cantidadplato1 = l.Cantidadplato1,
                 Cantidadplato2 = l.Cantidadplato2,
                 Cantidadplato3 = l.Cantidadplato3,
                 Cantidadplato4 = l.Cantidadplato4,
                 Infonutrimenu = l.Infonutrimenu,
                 Infonutriplato1 = l.Infonutriplato1,
                 Infonutriplato2 = l.Infonutriplato2,
                 Infonutriplato3 = l.Infonutriplato3,
                 Infonutriplato4 = l.Infonutriplato4,
                 Mencomidas = l.Mencomidas,
                 Nomgrupomenu =l.Nomgrupomenu,
                 Nommenu = l.Nommenu,
                 Nomplato1 = l.Nomplato1,
                 Nomplato2 = l.Nomplato2,
                 Nomplato3 = l.Nomplato3,
                 Nomplato4 = l.Nomplato4,
                 Numplatos =l.Numplatos,
                 Obscomidas = l.Obscomidas,
                 Codgrupomenu = l.Codgrupomenu,
                 Codigotipoasistencia = l.Codigotipoasistencia,
                 Flag =l.Flag,
                 Sercomidas = l.Sercomidas,
                 Tienemenu = l.Tienemenu,
                 Tipoplato1 = l.Tipoplato1,
                 Tipoplato2 = l.Tipoplato2,
                 Tipoplato3 = l.Tipoplato3,
                 Tipoplato4 = l.Tipoplato4,
                 Iconoestrella1 = l.Iconoestrella1,
                 Iconoestrella2 = l.Iconoestrella2,
                 Iconoestrella3 = l.Iconoestrella3,
                 Iconoestrella4 = l.Iconoestrella4,





                veraccesos = funcionaccesos(l.Dia,l.Mes,l.Any),
                verasistencia = funcionasistencia(l.Dia,l.Mes,l.Any
                )
            });

        }
        private IEnumerable<ActividadItemViewModel> ToActividadItemViewModel()
        {
            return MainViewModel.GetInstance().ActividadesList.Select(l => new ActividadItemViewModel
            {
                Diassemana = l.Diassemana,
                Codigoactividad = l.Codigoactividad,
                DomDesde = l.DomDesde.Substring(0,5),
                DomHasta = l.DomHasta.Substring(0,5),
                LunDesde = l.LunDesde.Substring(0,5),
                LunHasta = l.LunHasta.Substring(0,5),
                MarDesde = l.MarDesde.Substring(0,5),
                MarHasta = l.MarHasta.Substring(0,5),
                MieDesde = l.MieDesde.Substring(0,5),
                MieHasta = l.MieHasta.Substring(0,5),
                JueDesde = l.JueDesde.Substring(0,5),
                JueHasta = l.JueHasta.Substring(0,5),
                VieDesde = l.VieDesde.Substring(0,5),
                VieHasta = l.VieHasta.Substring(0,5),
                SabDesde = l.SabDesde.Substring(0,5),
                SabHasta = l.SabHasta.Substring(0,5),
                Nombreactividad = l.Nombreactividad,
                horasdia = Metohora(l.LunDesde,l.LunHasta,l.MarDesde,l.MarHasta,l.MieDesde,l.MieHasta,l.JueDesde,l.JueHasta,l.VieDesde,l.VieHasta,l.SabDesde,l.SabHasta,l.DomDesde,l.DomHasta)
            });

        }

        private bool parapulsato(string avisado)
        {

            if (avisado == "1")
            {
                return true;

            }
            else
            {
                return false;
            }

        }

        private bool funcionaccesos(String dia, String mes , String Any)
        {
            var diapulsado = new DateTime(Int32.Parse(Any),Int32.Parse(mes),Int32.Parse(dia));
            if (diapulsado > DateTime.Today)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        private bool funcionasistencia(String dia, String mes, String Any)
        {
            var diapulsado = new DateTime(Int32.Parse(Any), Int32.Parse(mes), Int32.Parse(dia));
            if (diapulsado > DateTime.Today)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        private string  Metohora(string LunDesde,string LunHasta, string MarDesde, string MarHasta, string MieDesde, string MieHasta, string JueDesde, string JueHasta, string VieDesde, string VieHasta, string SabDesde, string SabHasta, string DomDesde, string DomHasta)
        {
            switch (this.diapulsado)
            {
                case 1:
                  return "Horario Lunes de " + LunDesde.Substring(0,5) + " a " + LunHasta.Substring(0,5);
                    break;
                case 2:
                    return "Horario Martes de " + MarDesde.Substring(0,5) + " a " + MarHasta.Substring(0,5);
                    break;
                case 3:
                    return "Horario Miércoles de " + MieDesde.Substring(0,5) + " a " + MieHasta.Substring(0,5);
                    break;
                case 4:
                    return "Horario Jueves de " + JueDesde.Substring(0,5) + " a " + JueHasta.Substring(0,5);
                    break;
                case 5:
                    return "Horario Viernes de " + VieDesde.Substring(0,5) + " a " + VieHasta.Substring(0,5); ;
                    break;
                case 6:
                    return "Horario Sabado de " + SabDesde.Substring(0,5) + " a " + SabHasta.Substring(0,5);
                    break;
                case 0:
                    return "Horario Domingo de " + DomDesde.Substring(0,5) + " a " + DomHasta.Substring(0,5);
                    break;

            }
            return "Horario de " + LunDesde.Substring(0,5) + " a " + LunHasta.Substring(0,5);
        }
        #endregion

        #region Commands
        public ICommand SelectServicioCommand
        {
            get
            {
                return new RelayCommand(SelectServicio);
            }
        }

        private async void SelectServicio()
        {
        //    MainViewModel.GetInstance().Aviso = new AvisoViewModel(this);
            await App.Navigator.PushAsync(new DiarioPage());



#endregion
        }
     


      

    }

}