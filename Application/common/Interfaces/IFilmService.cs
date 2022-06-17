using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
     public interface IFilmService
     {
        Task<Film> Createfilm(Film film);
        Task<int> Deletefilm(Film film);
        Task<int> UpdateFilm(Film film);
        Task<IEnumerable<Film>> GetallFilm();
        Task<Film> GetFilmByid(int id);
    }
}
