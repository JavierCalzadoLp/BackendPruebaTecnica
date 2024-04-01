using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Repositories;
using WebApi.Model;

namespace WebApi.Controllers;
// Controlador para manejar las operaciones relacionadas con los usuarios
[Route("api/[controller]")]
[ApiController]
public class UsuarioController : Controller
{
    //Variable que hace referencia al objeto que implementa la interfaz
    private readonly IUsuarioRepository _usuarioRepository;
    
    // Constructor que recibe un repositorio de usuarios
    public UsuarioController(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }
    
    // Método para obtener todos los usuarios
    [HttpGet]
    public async Task<IActionResult> GetAllUsuario()
    {
        return Ok(await _usuarioRepository.GetAllUsuarios()); // Devolver una respuesta HTTP OK con todos los usuarios obtenidos del repositorio
    }
    
    // Método para obtener los detalles de un usuario por su ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUsuarioDetails(int id)
    {
        return Ok(await _usuarioRepository.GetDetails(id)); // Devolver una respuesta HTTP OK con los detalles del usuario obtenidos del repositorio
    }
    
    // Método para dar de alta un usuario
    [HttpPost]
    public async Task<IActionResult> CreateUsuario([FromBody] Usuario usuario)
    {
        // Validar si el objeto de usuario recibido es nulo
        if (usuario == null)
            return BadRequest();
        // Validar si el modelo de usuario es válido según las anotaciones de validación
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        // Insertar el usuario en la base de datos a través del repositorio
        var created = await _usuarioRepository.InsertUsuarios(usuario);
        // Devolver una respuesta HTTP Created con un mensaje de éxito
        return Created("created", $"Usuario {usuario.Nombre} creado correctamente. Se ha enviado un correo electrónico a {usuario.Email}");
    }
    
    // Método para actualizar un usuario
    [HttpPut]
    public async Task<IActionResult> UpdateUsuario([FromBody] Usuario usuario)
    {
        // Validar si el objeto de usuario recibido es nulo
        if (usuario == null)
            return BadRequest();
        // Validar si el modelo de usuario es válido según las anotaciones de validación
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        // Actualizar el usuario en la base de datos a través del repositorio
        await _usuarioRepository.UpdateUsuarios(usuario);
        // Devolver una respuesta HTTP NoContent para indicar que la actualización fue exitosa
        return NoContent();
    }
    
    // Método para eliminar un usuario existente por su ID
    [HttpDelete]
    public async Task<IActionResult> DeleteUsuario(int id)
    {
        // Eliminar el usuario de la base de datos a través del repositorio
        await _usuarioRepository.DeleteUsuarios(new Usuario { Id = id });
        
        // Devolver una respuesta HTTP NoContent para indicar que la eliminación fue exitosa
        return NoContent();
    }
}