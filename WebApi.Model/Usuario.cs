namespace WebApi.Model;
// Clase que representa un usuario en el sistema
public class Usuario
{
    // Constructor que inicializa un usuario con todos sus atributos
    public Usuario(int id, string nombre, string apellido, string email, string direccion, string pais)
    {
        Id = id;
        this.Nombre = nombre;
        this.Apellido = apellido;
        this.Email = email;
        this.Direccion = direccion;
        this.Pais = pais;
    }
    // Constructor por defecto necesario para serialización/deserialización
    public Usuario()
    {
        
    }
    // Identificador único del usuario
    public int Id { get; set; }
    // Nombre del usuario
    public string Nombre { get; set; }
    // Apellido del usuario
    public string Apellido { get; set; }
    // Email del usuario
    public string Email { get; set; }
    //Dirección del usuario
    public string Direccion { get; set; }
    // Pais del usuario
    public string Pais { get; set; }
}