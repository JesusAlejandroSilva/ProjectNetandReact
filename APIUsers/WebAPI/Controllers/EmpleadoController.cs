using Application.DTOs;
using Application.ServicesLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/user")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoService _empleadoService;

        public EmpleadoController(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmpleados()
        {
            var empleados = await _empleadoService.GetAllEmpleadosAsync();
            return Ok(empleados);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmpleadoById(int id)
        {
            var empleado = await _empleadoService.GetEmpleadoByIdAsync(id);
            return Ok(empleado);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmpleado(EmpleadoDTO empleadoDto)
        {
            await _empleadoService.AddEmpleadoAsync(empleadoDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmpleado(int id, EmpleadoDTO empleadoDto)
        {
            empleadoDto.IdEmpleado = id;
            await _empleadoService.UpdateEmpleadoAsync(empleadoDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleado(int id)
        {
            await _empleadoService.DeleteEmpleadoAsync(id);
            return Ok();
        }
    }
}

