namespace WebApi.Data
{
    // Clase que representa la configuración de MySQL
    public class MySqlConfiguration
    {
        // Constructor que recibe la cadena de conexión a MySQL
        public MySqlConfiguration(string connectionString)
        {
            ConnectionString = connectionString;
        }

        // Propiedad para almacenar la cadena de conexión a MySQL
        public string ConnectionString { get; set; }
    }
}