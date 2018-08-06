namespace Lands.Models
{
    using System;
    using Newtonsoft.Json;
    using SQLite.Net.Attributes;

    public class LoginResponse
    {
        #region Properties
        [PrimaryKey, AutoIncrement]
        public int LoginResponseId { get; set; }

        [JsonProperty(PropertyName = "token")]
        public string AccessToken { get; set; }

        [JsonProperty(PropertyName = "cod_centro")]
        public string Cod_centro { get; set; }

        [JsonProperty(PropertyName = "cod_empresa")]
        public string Cod_empresa { get; set; }

        [JsonProperty(PropertyName = "nom_empresa")]
        public string Nom_empresa { get; set; }

        [JsonProperty(PropertyName = "logo_empresa")]
        public string Logo_empresa { get; set; }


        [JsonProperty(PropertyName = "nom_comedor")]
        public string Nombre_comedor { get; set; }

        [JsonProperty(PropertyName = "cod_alumf")]
        public string Cod_alumf { get; set; }

        [JsonProperty(PropertyName = "nomf_alumf")]
        public string Nomf_alumf { get; set; }

        [JsonProperty(PropertyName = "s_t_idioma")]
        public string S_t_idioma { get; set; }

        [JsonProperty(PropertyName = "r_comedor")]
        public string R_comedor { get; set; }

        [JsonProperty(PropertyName = "r_actividades")]
        public string R_actividades { get; set; }

        [JsonProperty(PropertyName = "r_bus")]
        public string R_bus { get; set; }

        [JsonProperty(PropertyName = "r_campus")]
        public string R_campus { get; set; }

        [JsonProperty(PropertyName = "r_activo")]
        public string R_activo { get; set; }

        [JsonProperty(PropertyName = "r_bloqueo_mantenimiento")]
        public string R_bloqueo_mantenimiento { get; set; }

        [JsonProperty(PropertyName = "r_hora_tope_avisos")]
        public string R_hora_tope_avisos { get; set; }



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

        #region Methods
        public override int GetHashCode()
		{
            return LoginResponseId;
		}
		#endregion
	}
}
