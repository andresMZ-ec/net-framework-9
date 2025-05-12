using System;
using Aplicacion.Interfaces;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/roles")]
    public class RolController : ControllerBase
    {
        private readonly IRolServicio _rolServicio;
        private readonly ILogger<RolController> _logger;

        public RolController(IRolServicio rolServicio, ILogger<RolController> logger)
        {
            this._rolServicio = rolServicio;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> ListaRoles([FromQuery] bool? activo, [FromQuery] string? nombre)
        {
            var roles = await _rolServicio.ListaRoles(activo, nombre);
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> DetalleRol(int id)
        {
            try
            {
                var rol = await _rolServicio.DetalleRol(id);
                return Ok(rol);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> NuevoRol([FromBody] Rol nuevoRol)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var rol = await _rolServicio.NuevoRol(nuevoRol);
                return CreatedAtAction(nameof(NuevoRol), new { id = rol.Id }, rol);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarRol(int id, [FromBody] Rol rol)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var rolActualizado = await _rolServicio.ActualizarRol(id, rol);
                return Ok(rolActualizado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{rol_id}")]
        public async Task<IActionResult> ActualizarEstadoRol(int rol_id, [FromQuery] bool activo)
        {
            try
            {
                await _rolServicio.CambiarEstadoRol(rol_id, activo);
                return Ok($"El rol ha sido {(activo ? "Habilitado" : "Deshabilitado")}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarRol(int id)
        {
            try
            {
                await _rolServicio.EliminarRol(id);
                return Ok($"El rol ha sido eliminado sastisfactoriamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
