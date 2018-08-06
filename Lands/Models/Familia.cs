namespace Lands.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class Familia
    {
        [JsonProperty(PropertyName = "cod_alumf")]
        public string Cod_alumf { get; set; }

        [JsonProperty(PropertyName = "nif")]
        public string Nif  { get; set; }

        [JsonProperty(PropertyName = "nombre")]
        public string Nombre { get; set; }

        [JsonProperty(PropertyName = "idioma")]
        public string Idioma { get; set; }

        [JsonProperty(PropertyName = "hijos")]
        public List<Hijo> Hijos { get; set; }
  
    }
}