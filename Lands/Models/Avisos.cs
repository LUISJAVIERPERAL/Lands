namespace Lands.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class Aviso
    {
        [JsonProperty(PropertyName = "fecha")]
        public string Fecha { get; set; }

        [JsonProperty(PropertyName = "textoAviso")]
        public string Texto { get; set; }

        [JsonProperty(PropertyName = "nexp")]
        public string Nexp { get; set; }

        [JsonProperty(PropertyName = "alumnos")]
        public string ParaAlumnos { get; set; }

        [JsonProperty(PropertyName = "autor")]
        public string Autor { get; set; }

        [JsonProperty(PropertyName = "tipo_not")]
        public string Tipo { get; set; }


        public List<Destinatario> Destinatarios
        { get; set; }

        public bool hayavisos
        {

            get
            {

                if (ParaAlumnos == "ERROR")
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

        }
}