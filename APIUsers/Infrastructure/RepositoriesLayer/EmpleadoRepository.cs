using Domain.EntityLayer;
using Domain.InterfacesLayer;
using Infrastructure.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.RepositoriesLayer
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly ApplicationDbContext _context;

        public EmpleadoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Empleado>> GetEmpleadosAsync()
        {
            return await _context.Empleados.FromSqlRaw("EXEC sp_GetAllEmpleados").ToListAsync();
        }

        public async Task<Empleado> GetEmpleadoByIdAsync(int id)
        {
            return await _context.Empleados.FromSqlRaw("EXEC sp_GetEmpleadoById @IdEmpleado={0}", id).FirstOrDefaultAsync();
        }

        public async Task AddEmpleadoAsync(Empleado empleado)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC sp_AddEmpleado @Nombre={0}, @Posicion={1}, @Descripcion={2}, @Estado={3}",
                empleado.Nombre, empleado.Posicion, empleado.Descripcion, empleado.Estado);
        }

        public async Task UpdateEmpleadoAsync(Empleado empleado)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC sp_UpdateEmpleado @IdEmpleado={0}, @Nombre={1}, @Posicion={2}, @Descripcion={3}, @Estado={4}",
                empleado.IdEmpleado, empleado.Nombre, empleado.Posicion, empleado.Descripcion, empleado.Estado);
        }

        public async Task DeleteEmpleadoAsync(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC sp_DeleteEmpleado @IdEmpleado={0}", id);
        }
    }
}
