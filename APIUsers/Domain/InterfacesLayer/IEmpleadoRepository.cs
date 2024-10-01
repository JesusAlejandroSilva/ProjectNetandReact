using Domain.EntityLayer;

namespace Domain.InterfacesLayer
{
    public interface IEmpleadoRepository
    {
        Task<IEnumerable<Empleado>> GetEmpleadosAsync();
        Task<Empleado> GetEmpleadoByIdAsync(int id);
        Task AddEmpleadoAsync(Empleado empleado);
        Task UpdateEmpleadoAsync(Empleado empleado);
        Task DeleteEmpleadoAsync(int id);
    }
}
