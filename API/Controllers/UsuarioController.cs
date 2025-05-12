using AutoMapper;
using Dominio.Entidades;
using Aplicacion.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServicio _usuarioServicio;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioServicio usuarioServicio, IMapper mapper)
        {
            this._usuarioServicio = usuarioServicio;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ListaUsuarios()
        {
            try
            {
                var usuarios = await _usuarioServicio.ListaUsuarios();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> UsuarioPorId(int id)
        {
            try
            {
                var usuario = await _usuarioServicio.UsuarioPorId(id);
                if (usuario == null)
                {
                    return NotFound("Usuario no encontrado o no existe");
                }
                return Ok(usuario);
            }
            catch (Exception ex) 
            { 
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarUsuario([FromBody] Usuario nuevoUsuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var usuarioRegistrado = await _usuarioServicio.RegistrarNuevoUsuario(nuevoUsuario);
                    return CreatedAtAction(nameof(RegistrarUsuario), new { id = usuarioRegistrado.Id }, usuarioRegistrado);
                }
                return BadRequest(ModelState);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarUsuario(int id, [FromBody] Usuario data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var usuarioActualizado = await _usuarioServicio.ActualizarUsuario(id, data);
                    return Ok(usuarioActualizado);
                }
                return BadRequest(ModelState);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> CambiarEstado(int id, [FromQuery] bool isActive)
        {
            try
            {
                await _usuarioServicio.ActualizarEstadoUsuario(id, isActive);
                return Ok($"Usuario {(isActive ? "Habilitado" : "Deshabilitado")}");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarUsuario(int id)
        {
            try
            {
                await _usuarioServicio.EliminarUsuario(id);
                return Ok("Usuario eliminado correctamente");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

    }
}
