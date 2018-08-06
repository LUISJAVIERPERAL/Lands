namespace Lands.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class Acceso
    {
        [JsonProperty(PropertyName = "fechora_comidas")]
        public string Fechaacceso { get; set; }

        [JsonProperty(PropertyName = "ser_comidas")]
        public string Codigoservicio { get; set; }

        [JsonProperty(PropertyName = "tur_comidas")]
        public string Turnoservicio { get; set; }

        [JsonProperty(PropertyName = "gme_comidas")]
        public string Grupomenuservicio { get; set; }

        [JsonProperty(PropertyName = "men_comidas")]
        public string Menuservicio { get; set; }

        [JsonProperty(PropertyName = "tipo_comidas")]
        public string Tipoacceso { get; set; }

        [JsonProperty(PropertyName = "obs_comidas")]
        public string Observaciones { get; set; }

      
        public string Iconor { get; set; }

   
        public string Nombreacceso { get; set; }

        public string Fechacorta
        {
            get
            {
                return Fechaacceso.Substring(0, 10);
            }
            set
            {

            }
        }
        public string Dia
        {
            get
            {
                return Fechaacceso.Substring(8, 2);
            }
            set
            {
            }


        }
        public string Mes
        {
            get
            {
                return Fechaacceso.Substring(5, 2);
            }
            set
            {
            }
        }
        public string Any
        {
            get
            {
                return Fechaacceso.Substring(0, 4);
            }
            set
            { }
        }
        public string hora
        {
            get
            {
                return Fechaacceso.Substring(10, 8);
            }
            set
            { }
        }
    }
}