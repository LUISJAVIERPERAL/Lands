namespace Lands.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class Servicio
    {
        [JsonProperty(PropertyName = "cod_servicio")]
        public string Codservicio { get; set; }

        [JsonProperty(PropertyName = "nom_servicio")]
        public string Nombreservicio { get; set; }

       

        [JsonProperty(PropertyName = "cod_turno")]
        public string Codturno { get; set; }

        [JsonProperty(PropertyName = "nom_turno")]
        public string Nombreturno { get; set; }

        [JsonProperty(PropertyName = "cod_tipo_asistencia")]
        public string Codigotipoasistencia { get; set; }


        [JsonProperty(PropertyName = "nom_tipo_asistencia")]
        public string Tipoasistencia { get; set; }

        [JsonProperty(PropertyName = "dias_semana")]
        public string Diasasistencia { get; set; }

        [JsonProperty(PropertyName = "num_dias")]
        public string Numeroasistencias { get; set; }

        [JsonProperty(PropertyName = "fecha_cambio")]
        public string FechaCambio { get; set; }

        [JsonProperty(PropertyName = "mesa")]
        public string Codmesa { get; set; }


        [JsonProperty(PropertyName = "monitores")]
        public string Monitores { get; set; }

        [JsonProperty(PropertyName = "fecha")]
        public string Fecha { get; set; }

   
        [JsonProperty(PropertyName = "aviso_ausencia")]
        public string Avisoausencia { get; set; }

        [JsonProperty(PropertyName = "aviso_asistencia")]
        public string Avisoasistencia { get; set; }

        [JsonProperty(PropertyName = "aviso_dieta")]
        public string Avisodieta { get; set; }


        [JsonProperty(PropertyName = "tiene_menu")]
        public string Tienemenu { get; set; }

        [JsonProperty(PropertyName = "cod_grupo_menu")]
        public string Codgrupomenu { get; set; }

        [JsonProperty(PropertyName = "nom_grupo_menu")]
        public string Nomgrupomenu { get; set; }

        [JsonProperty(PropertyName = "men_comidas")]
        public string Mencomidas { get; set; }

        [JsonProperty(PropertyName = "tipo_comidas")]
        public string Tipocomidas { get; set; }

        [JsonProperty(PropertyName = "flag")]
        public string Flag { get; set; }


        [JsonProperty(PropertyName = "obs_comidas")]
        public string Obscomidas { get; set; }

        [JsonProperty(PropertyName = "ser_comidas")]
        public string Sercomidas { get; set; }

        [JsonProperty(PropertyName = "acceso_txt")]
        public string Accesotxt { get; set; }



        [JsonProperty(PropertyName = "nom_menu")]
        public string Nommenu { get; set; }

        [JsonProperty(PropertyName = "info_nutri_menu")]
        public string Infonutrimenu { get; set; }

        [JsonProperty(PropertyName = "num_platos")]
        public string Numplatos { get; set; }


        [JsonProperty(PropertyName = "tipo_plato_1")]
        public string Tipoplato1 { get; set; }

        [JsonProperty(PropertyName = "nom_plato_1")]
        public string Nomplato1 { get; set; }

        [JsonProperty(PropertyName = "cantidad_plato_1")]
        public string Cantidadplato1 { get; set; }

        [JsonProperty(PropertyName = "info_nutri_plato_1")]
        public string Infonutriplato1 { get; set; }

        [JsonProperty(PropertyName = "tipo_plato_2")]
        public string Tipoplato2 { get; set; }

        [JsonProperty(PropertyName = "nom_plato_2")]
        public string Nomplato2 { get; set; }

        [JsonProperty(PropertyName = "cantidad_plato_2")]
        public string Cantidadplato2 { get; set; }

        [JsonProperty(PropertyName = "info_nutri_plato_2")]
        public string Infonutriplato2 { get; set; }


        [JsonProperty(PropertyName = "tipo_plato_3")]
        public string Tipoplato3 { get; set; }

        [JsonProperty(PropertyName = "nom_plato_3")]
        public string Nomplato3 { get; set; }

        [JsonProperty(PropertyName = "cantidad_plato_3")]
        public string Cantidadplato3 { get; set; }

        [JsonProperty(PropertyName = "info_nutri_plato_3")]
        public string Infonutriplato3 { get; set; }

        [JsonProperty(PropertyName = "tipo_plato_4")]
        public string Tipoplato4 { get; set; }

        [JsonProperty(PropertyName = "nom_plato_4")]
        public string Nomplato4 { get; set; }

        [JsonProperty(PropertyName = "cantidad_plato_4")]
        public string Cantidadplato4 { get; set; }

        [JsonProperty(PropertyName = "info_nutri_plato_4")]
        public string Infonutriplato4 { get; set; }



      //  public string Acceso { get; set; }
        public string Fechaacceso { get; set; }
       // public bool conmenu { get; set; }
      //  public bool sinmenu { get; set; }
        public bool veraccesos { get; set; }
        public bool verasistencia { get; set; }
        public Menuses elmenu { get; set; }

        public string nombremenu1 { get; set; }
        public string primerplato1 { get; set; }
        public string segundoplato1 { get; set; }
        public string postre1 { get; set; }
        public string entrante1 { get; set; }

        public string Iconoestrella1

        {

            get
            {
                   return "estrella"+Cantidadplato1;
            }
            set
            { }

        }

        public string Iconoestrella2

        {

            get
            {
                return "estrella" + Cantidadplato2;
            }
            set
            { }

        }
        public string Iconoestrella3

        {

            get
            {
                return "estrella" + Cantidadplato3;
            }
            set
            { }

        }
        public string Iconoestrella4

        {

            get
            {
                return "estrella" + Cantidadplato4;
            }
            set
            { }

        }
        public string Iconoestrellapeque1

        {

            get
            {
                return "estrellapeque" + Cantidadplato1;
            }
            set
            { }

        }

        public string Iconoestrellapeque2

        {

            get
            {
                return "estrellapeque" + Cantidadplato2;
            }
            set
            { }

        }
        public string Iconoestrellapeque3

        {

            get
            {
                return "estrellapeque" + Cantidadplato3;
            }
            set
            { }

        }
        public string Iconoestrellapeque4

        {

            get
            {
                return "estrellapeque" + Cantidadplato4;
            }
            set
            { }

        }
        public string Coloracceso

        {

            get
            {

                if (Tipocomidas == "A" | Tipocomidas == "H" | Tipocomidas == "M")
                {
                    return "Green";

                }
                if (Tipocomidas == "J")
                {
                    return "Blue";


                }
                if (Tipocomidas == "X")
                {
                    return "Red";


                }
                else
                {
                    return "Blue";
                }

            }
            set
            { }

        }





        public string Iconoacceso

        {

            get
            {

                if (Tipocomidas == "A" | Tipocomidas == "H" | Tipocomidas == "M")
                {
                    return "ico_enverde";

                }
                if (Tipocomidas == "J")
                {
                    return "carasosa";


                }
                if (Tipocomidas == "X")
                {
                    return "ico_enrojo";


                }
                else
                {
                    return "carasosa";
                }

            }
            set
            { }

        }


        public string botondieta

 

        {

            get
            {

                if (Avisodieta== "1")
                {
                
                    return "botonencendido";

                }
                else
                {
                  
                        
                    return "botapagado";
                }


            }
            set
            { }

        }
        public string botonausencia



        {

            get
            {

                if (Avisoausencia == "1")
                {
                
                    return "botonencendido";

                }
                else
                {
                    
                    return "botapagado";
                }


            }
            set
            { }

        }

        public string botonasistencia



        {

            get
            {

                if (Avisoasistencia == "1")
                {
           
                    return "botonencendido";

                }
                else
                {
             
                    return "botapagado";
                }


            }
            set
            { }

        }

        public string colorausencia

        {

            get
            {

                if (Avisoausencia == "1")
                {
                    return "Red";

                }
                else
                {
                    return "Green";
                }


            }
            set
            { }

        }

        public string colordieta

        {

            get
            {

                if (Avisodieta == "1")
                {
                    return "Red";

                }
                else
                {
                    return "Green";
                }


            }
            set
            { }

        }


        public string colorasistencia

        {

            get
            {

                if (Avisoasistencia == "1")
                {
                    return "Green";

                }
                else
                {
                    return "Red";
                }


            }
            set
            { }

        }





        public string Iconoausencia

        {

            get
            {

                if (Avisoausencia == "1")
                {
                    return "AUSENCIA CONFIRMADA";

                }
                else
                {
                    return "CONFIRMAR AUSENCIA";
                }
            

            }
            set
            { }

        }
        public string Iconodieta

        {

            get
            {

                if (Avisodieta == "1")
                {
                    return "DIETA CONFIRMADA";

                }
                else
                {
                    return "CONFIRMAR DIETA";
                }


            }
            set
            { }

        }
        public bool Pulsato

        {

            get
            {

                if (Avisoasistencia == "1")
                {
                    return false;

                }
                else
                {
                    return true;


                }


            }
            set
            { }

        }

        public string Iconoasistencia

        {

            get
            {

                if (Avisoasistencia == "1")
                {
                    return "ASISTENCIA CONFIRMADA";

                }
                else
                {
                    return "CONFIRMAR ASISTENCIA";


                }


            }
            set
            { }

        }

        public bool conmenu



        {

            get
            {

                if (Tienemenu == "1")
                {

                    return true;

                }
                else
                {


                    return false;
                }


            }
            set
            { }

        }
        public bool sinmenu



        {

            get
            {

                if (Tienemenu == "0")
                {

                    return true;

                }
                else
                {


                    return false;
                }


            }
            set
            { }

        }




        public bool notieneacesso
        {
            get
            {

                if (Tipocomidas == "A" | Tipocomidas == "H" | Tipocomidas == "M")
                {
                    return false;

                }
                if (Tipocomidas == "J")
                {
                    return true;


                }
                if (Tipocomidas == "X")
                {
                    return true;


                }
                else
                {
                    return true;
                }

            }
            set
            { }


        }

        public bool tieneacesso
        {
            get
            {

                if (Tipocomidas == "A" | Tipocomidas == "H" | Tipocomidas == "M") 
                {
                    return true;

                }
                if (Tipocomidas == "J")
                {
                    return false;


                }
                if (Tipocomidas == "X")
                {
                    return false;


                }
                else
                {
                    return false;
                }

            }
            set
            { }


        }
        public string Descriacceso

        {

            get
            {

                if (Tipocomidas == "A" | Tipocomidas == "H" | Tipocomidas == "M")
                {
                    return "ASISTENCIA";

                }
                if (Tipocomidas == "J")
                {
                    return "AUSENCIA JUSTIFICADA";


                }
                if (Tipocomidas == "X")
                {
                    return "AUSENCIA NO JUSTIFICADA";


                }
                else
                {
                    return "SIN DATOS DEL ACCESO";
                }

            }
            set
            { }

        }

        public bool modelo1

        {

            get
            {

                if (Tipoasistencia == "TODOS LOS DIAS ")
                {
                    return true;

                }
                if (Tipoasistencia == "DIAS FIJO")
                {

                    var diapulsado = new System.DateTime(System.Int32.Parse(Any), Int32.Parse(Mes), Int32.Parse(Dia));
                    int numdia = (int)(diapulsado.DayOfWeek);
                    var nomdia = "D";
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
                    if (Diasasistencia.Contains(nomdia))
                    {
                        return true;
                    }
                    else
                    {
                        return false;

                    }


                }
                else
                {
                    return false;
                }

            }
            set
            { }

        }

    






        public bool modelo2

        {

            get
            {

                if (Tipoasistencia == "TODOS LOS DIAS ")
                {
                    return false;

                }
                if (Tipoasistencia == "DIAS FIJO")
                {

                    var diapulsado = new System.DateTime(System.Int32.Parse(Any), Int32.Parse(Mes), Int32.Parse(Dia));
                    int numdia = (int)(diapulsado.DayOfWeek);
                    var nomdia = "D";
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
                    if (Diasasistencia.Contains(nomdia))
                    {
                        return false;
                    }
                    else
                    {
                        return true;

                    }


                }
                else
                {
                    return true;
                }

            }
            set
            { }

        }

        public string Dia
        {
            get
            {
                return Fecha.Substring(8, 2);
            }
            set
            {
            }


        }
        public string Mes
        {
            get
            {
                return Fecha.Substring(5, 2);
            }
            set
            {
            }
        }
        public string Any
        {
            get
            {
                return Fecha.Substring(0, 4);
            }
            set
            { }
        }
    }

    }
    
