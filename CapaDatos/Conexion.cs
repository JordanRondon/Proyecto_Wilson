using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class Conexion
    {
        private static readonly Conexion instancia = new Conexion();

        public static Conexion GetInstancia => instancia;

        
        //public SqlConnection Conectar => new SqlConnection("Data Source = BDWILSON.mssql.somee.com; Initial Catalog = BDWILSON; Integrated Security=False; User Id= ct; Password=sgb6jh3iyz");
        public SqlConnection Conectar => new SqlConnection("Data Source = .; Initial Catalog = BDWILSON; Integrated Security=true;");
    }
}
