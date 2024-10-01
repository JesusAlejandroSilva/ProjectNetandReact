using Application.DTOs;
using Domain.EntityLayer;
using Domain.InterfacesLayer;

namespace Application.ServicesLayer
{
    public class EmpleadoService: IEmpleadoService
    {
        private readonly IEmpleadoRepository _empleadoRepository;

        public EmpleadoService(IEmpleadoRepository empleadoRepository)
        {
            _empleadoRepository = empleadoRepository;
        }

        public async Task<IEnumerable<EmpleadoDTO>> GetAllEmpleadosAsync()
        {
            var empleados = await _empleadoRepository.GetEmpleadosAsync();
            return empleados.Select(e => new EmpleadoDTO
            {
                IdEmpleado = e.IdEmpleado,
                Nombre = e.Nombre,
                Posicion = e.Posicion,
                Descripcion = e.Descripcion,
                Estado = e.Estado
            });
        }

        public async Task<EmpleadoDTO> GetEmpleadoByIdAsync(int id)
        {
            var empleado = await _empleadoRepository.GetEmpleadoByIdAsync(id);
            return new EmpleadoDTO
            {
                IdEmpleado = empleado.IdEmpleado,
                Nombre = empleado.Nombre,
                Posicion = empleado.Posicion,
                Descripcion = empleado.Descripcion,
                Estado = empleado.Estado
            };
        }

        public async Task AddEmpleadoAsync(EmpleadoDTO empleadoDto)
        {
            var empleado = new Empleado
            {
                Nombre = empleadoDto.Nombre,
                Posicion = empleadoDto.Posicion,
                Descripcion = empleadoDto.Descripcion,
                Estado = empleadoDto.Estado,
                FechaCreacion = DateTime.UtcNow
            };

            await _empleadoRepository.AddEmpleadoAsync(empleado);
        }

        public async Task UpdateEmpleadoAsync(EmpleadoDTO empleadoDto)
        {
            var empleado = new Empleado
            {
                IdEmpleado = empleadoDto.IdEmpleado,
                Nombre = empleadoDto.Nombre,
                Posicion = empleadoDto.Posicion,
                Descripcion = empleadoDto.Descripcion,
                Estado = empleadoDto.Estado,
                FechaModificacion = DateTime.UtcNow
            };

            await _empleadoRepository.UpdateEmpleadoAsync(empleado);
        }

        public async Task DeleteEmpleadoAsync(int id)
        {
            await _empleadoRepository.DeleteEmpleadoAsync(id);
        }
    
    }
}
