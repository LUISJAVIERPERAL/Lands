namespace Lands.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class Actividad
    {
        [JsonProperty(PropertyName = "cod_act")]
        public string Codigoactividad { get; set; }

        [JsonProperty(PropertyName = "nom_act")]
        public string Nombreactividad { get; set; }

        [JsonProperty(PropertyName = "dias_semana")]
        public string Diassemana { get; set; }

        [JsonProperty(PropertyName = "lun_hdes_act")]
        public string LunDesde { get; set; }

        [JsonProperty(PropertyName = "lun_hhas_act")]
        public string LunHasta { get; set; }

        [JsonProperty(PropertyName = "mar_hdes_act")]
        public string MarDesde { get; set; }

        [JsonProperty(PropertyName = "mar_hhas_act")]
        public string MarHasta { get; set; }

        [JsonProperty(PropertyName = "mie_hdes_act")]
        public string MieDesde { get; set; }

        [JsonProperty(PropertyName = "mie_hhas_act")]
        public string MieHasta { get; set; }

        [JsonProperty(PropertyName = "jue_hdes_act")]
        public string JueDesde { get; set; }

        [JsonProperty(PropertyName = "jue_hhas_act")]
        public string JueHasta { get; set; }

        [JsonProperty(PropertyName = "vie_hdes_act")]
        public string VieDesde { get; set; }

        [JsonProperty(PropertyName = "vie_hhas_act")]
        public string VieHasta { get; set; }


        [JsonProperty(PropertyName = "sab_hdes_act")]
        public string SabDesde { get; set; }

        [JsonProperty(PropertyName = "sab_hhas_act")]
        public string SabHasta { get; set; }

        [JsonProperty(PropertyName = "dom_hdes_act")]
        public string DomDesde { get; set; }

        [JsonProperty(PropertyName = "dom_hhas_act")]
        public string DomHasta { get; set; }

        public string Error { get; set; }

        public string horasdia { get; set; }

    }
}