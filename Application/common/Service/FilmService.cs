using Api.Infrastructure.Persistence;
using Application.Common.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class FilmService : IFilmService
    {
        public readonly IApplicationDbContext _context;
        public FilmService(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Film> Createfilm(Film film)
        {
            _context.Films.Add(film);
            await _context.SaveChangesAsync();
            return film;
        }

        public async Task<int> Deletefilm(Film film)
        {
            _context.Films.Remove(film);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Film>> GetallFilm()
        {
            return await _context.Films
                .ToListAsync();
        }

        public async Task<Film> GetFilmByid(int id)
        {
            return await _context.Films.Include(x => x.Acteurs)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> UpdateFilm(Film film)
        {
            _context.Films.Update(film);
            return await _context.SaveChangesAsync();
        }
    }
}
