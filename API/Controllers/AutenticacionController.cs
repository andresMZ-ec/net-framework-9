using API.Servicios;
using Aplicacion.DTOs.Usuario;
using Aplicacion.Interfaces;
using Aplicacion.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/auth")]
    public class AutenticacionController : ControllerBase
    {
        private readonly IAutenticacionServicio _autenticacionServicio;
        private readonly TokenServicio _tokenServicio;

        public AutenticacionController(TokenServicio tokenServicio, IAutenticacionServicio autenticacionServicio)
        {
            this._tokenServicio = tokenServicio;
            this._autenticacionServicio = autenticacionServicio;            
        }

        [HttpPost("login")]
        public async Task<IActionResult> InicioSesion([FromBody] UsuarioCredencialesDto credenciales){
            try
            {
                if (!ModelState.IsValid || (
                    string.IsNullOrEmpty(credenciales.nombreUsuario) &&
                    string.IsNullOrEmpty(credenciales.correoElectronico)
                ))
                {
                    throw new InvalidDataException("Campos no válidos o faltantes");
                }
                var usuarioAutenticado = await _autenticacionServicio.AutenticarUsuario(credenciales);

                var token = _tokenServicio.GenerarToken(usuarioAutenticado);

                Response.Headers.Add("Authorization", "Bearer " + token);
                return Ok(new
                {
                    allowed = true,
                    mensaje = "Inicio de sesión exitoso",
                    token
                });
            }
            catch (InvalidDataException e)
            {
                return BadRequest(e.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }


    }
}
