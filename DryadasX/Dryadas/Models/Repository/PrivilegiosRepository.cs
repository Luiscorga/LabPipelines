using Microsoft.EntityFrameworkCore;
using Dryadas.Models.Data;
namespace Dryadas.Models.Repository

{
    public class PrivilegiosRepository : IPrivilegiosRepository
    {
        protected readonly Context _context;
        public PrivilegiosRepository(Context context) => _context = context;

        public IEnumerable<Privilegios> GetPrivilegioss()
        {
            return _context.Privilegios.ToList();
        }

        public Privilegios GetPrivilegiosByid(int id)
        {
            return _context.Privilegios.Find(id);
        }

        public async Task<Privilegios> CreatePrivilegiosAsync(Privilegios privilegios)
        {
            await _context.Set<Privilegios>().AddAsync(privilegios);
            await _context.SaveChangesAsync();
            return privilegios;
        }

        public async Task<bool> UpdatePrivilegiosAsync(Privilegios privilegios)
        {
            _context.Entry(privilegios).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePrivilegiosAsync(Privilegios privilegios)
        {
            //var entity = await GetByIdAsync(id);
            if (privilegios is null)
            {
                return false;
            }
            _context.Set<Privilegios>().Remove(privilegios);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}




