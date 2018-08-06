namespace Lands.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class Menuses
    {
        [JsonProperty(PropertyName = "fec_caldia")]
        public string Fechamenu { get; set; }


        [JsonProperty(PropertyName = "nom_menu")]
        public string Nombremenu { get; set; }

        [JsonProperty(PropertyName = "ser_caldia")]
        public string Codigoservicio { get; set; }

        [JsonProperty(PropertyName = "platos")]
        public string Primerplato { get; set; }

        [JsonProperty(PropertyName = "r_defecto_caldia")]
        public string Platodefecto { get; set; }

        [JsonProperty(PropertyName = "r_dieta_caldia")]
        public string Dieta { get; set; }

        public string[] Platos
        {
            get
            {
                return Primerplato.Split('#');
            }
            set
            {
            }
        }

    //    public string Codigoservicio
    //    {
    //        get
    //        {
    //            return "1";

            //        }
            //        set
            //        {

            //        }
            //    }
        public string Dia
        {
            get
            {
                return Fechamenu.Substring(8, 2);
                }
            set
            {
            }
            

        }
        public string Mes
        {
            get
            {
                return Fechamenu.Substring(5, 2);
            }
            set
            {
            }
        }
        public string Any
        {
            get
            {
                return Fechamenu.Substring(0, 4);
            }
            set
            { }
        }
    
    public string Entrante
    {
        get
        {
          
            return Platos[1];
        }
        set
        {
        }


    }
    public string Primero
    {
        get
        {
                return Platos[3];
        }
        set
        {
        }
    }
    public string Segundo
    {
        get
        {
            return Platos[5];
        }
        set
        { }
    }
    public string Postre
    {
        get
        {
            return Platos[7];
        }
        set
        { }
    }
}

}