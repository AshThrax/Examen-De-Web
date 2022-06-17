using Application.Common.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructure.Service
{
    public class ActeurService:IActeurService
    {
        private readonly ApplicationDbContext _context;

        public ServiceActeur(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Acteur> CreateActeur(Acteur acteur)
        {
            _context.Acteurs.Add(acteur);
            await _context.SaveChangesAsync();
            return acteur;
        }

        public async Task<int> DeleteActeur(Acteur acteur)
        {
            _context.Acteurs.Remove(acteur);
            return await _context.SaveChangesAsync();
        }

        public async Task<Acteur> GetActeurById(int id)
        {
            return await _context.Acteurs.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Acteur>> GetAllActeur()
        {
            return await _context.Acteurs.ToListAsync();
        }

        public async Task<int> UpdateActeur(Acteur acteur)
        {
            _context.Acteurs.Update(acteur);
            return await _context.SaveChangesAsync();
        }
    }
}
