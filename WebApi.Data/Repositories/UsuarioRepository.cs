using Dapper;
using MySql.Data.MySqlClient;
using WebApi.Model;

namespace WebApi.Data.Repositories;
// Repositorio que implementa las operaciones definidas en la interfaz IUsuarioRepository
public class UsuarioRepository : IUsuarioRepository
{
    //Variable creada para la conexión con MySQL
    private readonly MySqlConfiguration _connectionString;
    // Constructor que recibe la configuración de MySQL
    public UsuarioRepository(MySqlConfiguration connectionString)
    {
        _connectionString = connectionString;
    }
    // Método protegido para obtener una conexión a la base de datos MySQL
    protected MySqlConnection DbConnection()
    {
        return new MySqlConnection(_connectionString.ConnectionString);
    }
    
    // Método para obtener todos los usuarios
    public async Task<IEnumerable<Usuario>> GetAllUsuarios()
    {
        var db = DbConnection(); //Obtener conexión a la db
        var sql = @" SELECT * FROM usuarios"; //Consulta SQL

        return await db.QueryAsync<Usuario>(sql, new { }); //Ejecutar la consulta y obtener el resultado
    }
    
    // Método para obtener los detalles de un usuario por su ID
    public async Task<Usuario?> GetDetails(int id)
    {
        var db = DbConnection(); //Obtener conexión a la db
        var sql = @" SELECT * FROM usuarios WHERE id = @Id "; //Consulta SQL

        return await db.QueryFirstOrDefaultAsync<Usuario>(sql, new { Id = id }); //Ejecutar la consulta y obtener el resultado
    }
    
    // Método para insertar un nuevo usuario
    public async Task<bool> InsertUsuarios(Usuario usuario)
    {
        var db = DbConnection(); //Obtener conexión a la db
        var sql = @" INSERT INTO usuarios(nombre, apellido, email, direccion, pais) 
                    VALUES(@nombre, @apellido, @email, @direccion, @pais) "; //Consulta SQL

        var result = await db.ExecuteAsync(sql,
            new { nombre = usuario.Nombre, apellido = usuario.Apellido, email = usuario.Email, direccion = usuario.Direccion,
                pais = usuario.Pais }); //Ejecutar la consulta y obtener el resultado  si es mayor que 0 (si es 0 o <0 hay un error)

        return result > 0;
    }
    
    // Método para actualizar la información de un usuario existente
    public async Task<bool> UpdateUsuarios(Usuario usuario)
    {
        var db = DbConnection(); //Obtener conexión a la db
        var sql = @" UPDATE usuarios
                     SET nombre = @nombre,
                         apellido = @apellido,
                         email = @email,
                         direccion = @direccion,
                         pais = @pais
                    WHERE id = @Id "; //Consulta SQL

        var result = await db.ExecuteAsync(sql,
            new { usuario.Id, nombre = usuario.Nombre, apellido = usuario.Apellido, email = usuario.Email,
                direccion = usuario.Direccion,
                pais = usuario.Pais }); //Ejecutar la consulta y obtener el resultado  si es mayor que 0 (si es 0 o <0 hay un error)

        return result > 0;
    }

    // Método para eliminar un usuario
    public async Task<bool> DeleteUsuarios(Usuario usuario)
    {
        var db = DbConnection(); //Obtener conexión a la db

        var sql = @"DELETE FROM usuarios WHERE id = @Id"; //Consulta SQL

        var result = await db.ExecuteAsync(sql, new { Id = usuario.Id }); //Ejecutar la consulta y obtener el resultado  si es mayor que 0 (si es 0 o <0 hay un error)

        return result > 0;
    }
}