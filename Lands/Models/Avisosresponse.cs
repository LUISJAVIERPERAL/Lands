namespace Lands.Models
{
    using System;
    using Newtonsoft.Json;
    using SQLite.Net.Attributes;

    public class AvisosResponse
    {
        #region Properties
       
        [JsonProperty(PropertyName = "token")]
        public string AccessToken { get; set; }

        [JsonProperty(PropertyName = "cod_centro")]
        public string Cod_centro { get; set; }

        [JsonProperty(PropertyName = "cod_empresa")]
        public string Cod_empresa { get; set; }
        
        [JsonProperty(PropertyName = "nom_comedor")]
        public string Nombre_comedor { get; set; }

        [JsonProperty(PropertyName = "cod_alumf")]
        public string Cod_alumf { get; set; }

        [JsonProperty(PropertyName = "nomf_alumf")]
        public string Nomf_alumf { get; set; }

        [JsonProperty(PropertyName = "s_t_idioma")]
        public string S_t_idioma { get; set; }
        #endregion

        public string Cultura
        {
            get
            {
                int i = Int32.Parse(S_t_idioma);
                string idioma = string.Empty;
                switch (i)
                {
                    case 1:
                        idioma = "es-ES";
                        break;
                    case 2:
                         idioma = "ca";
                        break;
                    case 3:
                         idioma = "pt-Pt";
                        break;

                }
                return idioma;
            }
            set
            {
            }

        }

     
	}
}
