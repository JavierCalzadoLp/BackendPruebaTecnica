using WebApi.Model;

namespace WebApi.Data.Repositories;
// Interfaz que define las operaciones que debe proporcionar un repositorio de usuarios
public interface IUsuarioRepository
{
    // Método para obtener todos los usuarios
    Task<IEnumerable<Usuario>> GetAllUsuarios();
    // Método para obtener los detalles de un usuario por su ID
    Task<Usuario?> GetDetails(int id);
    // Método para insertar un nuevo usuario
    Task<bool> InsertUsuarios(Usuario usuario);
    // Método para actualizar la información de un usuario existente
    Task<bool> UpdateUsuarios(Usuario usuario);
    // Método para eliminar un usuario
    Task<bool> DeleteUsuarios(Usuario usuario);
     
}