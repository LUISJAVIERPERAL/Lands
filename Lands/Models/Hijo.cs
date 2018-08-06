namespace Lands.Models
{
    using Newtonsoft.Json;

    public class Hijo
    {
        [JsonProperty(PropertyName = "num_expediente")]
        public string Num_expediente { get; set; }

        [JsonProperty(PropertyName = "cod_alum")]
        public string Cod_alum { get; set; }

        [JsonProperty(PropertyName = "nom_alum")]
        public string Nom_alum { get; set; }

        [JsonProperty(PropertyName = "apellido1")]
        public string Apellido1 { get; set; }

        [JsonProperty(PropertyName = "apellido2")]
        public string Apellido2 { get; set; }

        [JsonProperty(PropertyName = "r_baja")]
        public string R_baja { get; set; }

        [JsonProperty(PropertyName = "fec_baja")]
        public string Fec_baja { get; set; }

        [JsonProperty(PropertyName = "grupo_menu")]
        public string Grupo_menu { get; set; }
    }
}