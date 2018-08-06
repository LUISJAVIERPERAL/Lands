namespace Lands.Models
{
    using Newtonsoft.Json;

    public class Destinatario
    {
        [JsonProperty(PropertyName = "expediente")]
        public string Expediente { get; set; }

        [JsonProperty(PropertyName = "nombre")]
        public string Nombre { get; set; }

        
    }
}