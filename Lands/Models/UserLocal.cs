namespace Lands.Models
{
    using SQLite.Net.Attributes;

    public class UserLocal
    {
        [PrimaryKey]
        public int UserId { get; set; }

        public string cod_familiar { get; set; }

        public string nombre_familiar { get; set; }

        public string cod_centro { get; set; }

        public string cod_empresa { get; set; }

        public string nombre_comedor { get; set; }

        public string alias_centro { get; set; }

        public string Password { get; set; }

      
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", this.cod_familiar, this.nombre_familiar);
            }
        }

        public override int GetHashCode()
        {
            return UserId;
        }
    }
}
