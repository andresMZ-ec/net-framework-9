using Aplicacion.Interfaces;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/permisos")]
    public class PermisoController : ControllerBase
    {
        private readonly IPermisoServicio _permisoServicio;

        public PermisoController(IPermisoServicio permisoServicio)
        {
            this._permisoServicio = permisoServicio;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerPermisos([FromQuery] string? identificador)
        {
            try
            {
                var permisos = await _permisoServicio.ListaPermisos(identificador);
                return Ok(permisos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> GuardarPermiso([FromBody] Permiso nuevoPermiso)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var permiso = await _permisoServicio.NuevoPermiso(nuevoPermiso);
                return CreatedAtAction(nameof(GuardarPermiso), new { id = permiso.Id }, permiso);
            }
            catch (InvalidOperationException ex)
            {
                return Forbid(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarPermiso(int id, [FromBody] Permiso nuevoPermiso)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var permiso = await _permisoServicio.ActualizarPermiso(id, nuevoPermiso);
                return Ok(permiso);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            } catch (InvalidOperationException ex)
            {
                return Forbid(ex.Message);
            } catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarPermiso(int id)
        {
            try
            {                
                await _permisoServicio.EliminarPermiso(id);
                return Ok($"El permiso ha sido eliminado sastisfactoriamente");
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
