using Application.DTOs;

namespace Application.ServicesLayer
{
    public interface IEmpleadoService
    {
        Task<IEnumerable<EmpleadoDTO>> GetAllEmpleadosAsync();
        Task<EmpleadoDTO> GetEmpleadoByIdAsync(int id);
        Task AddEmpleadoAsync(EmpleadoDTO empleadoDto);
        Task UpdateEmpleadoAsync(EmpleadoDTO empleadoDto);
        Task DeleteEmpleadoAsync(int id);
    }
}
