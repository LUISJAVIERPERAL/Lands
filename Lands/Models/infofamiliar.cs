namespace Lands.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class infofamiliar
    {
        [JsonProperty(PropertyName = "fam")]
        public Familia Fam { get; set; }

        [JsonProperty(PropertyName = "hijos")]
        public List<Hijo> Hijos { get; set; }


    }
}