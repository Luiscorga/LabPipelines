using Microsoft.EntityFrameworkCore;
using Dryadas.Models.Data;
namespace Dryadas.Models.Repository

{
    public class FamiliaRepository : IFamiliaRepository
    {
        protected readonly Context _context;
        public FamiliaRepository(Context context) => _context = context;

        public IEnumerable<Familia> GetFamilias()
        {
            return _context.Familias.ToList();
        }

        public Familia GetFamiliaByid(int id)
        {
            return _context.Familias.Find(id);
        }

        public async Task<Familia> CreateFamiliaAsync(Familia familia)
        {
            await _context.Set<Familia>().AddAsync(familia);
            await _context.SaveChangesAsync();
            return familia;
        }

        public async Task<bool> UpdateFamiliaAsync(Familia familia)
        {
            _context.Entry(familia).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteFamiliaAsync(Familia familia)
        {
            //var entity = await GetByIdAsync(id);
            if (familia is null)
            {
                return false;
            }
            _context.Set<Familia>().Remove(familia);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}




