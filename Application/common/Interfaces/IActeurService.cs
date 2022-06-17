using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{ 
    public interface IActeurService
    {

        Task<IEnumerable<Acteur>> GetAllActeur();
        Task<Acteur> GetActeurById(int id);
        Task<int> UpdateActeur(Acteur acteur);
        Task<int> DeleteActeur(Acteur acteur);

        Task<Acteur> CreateActeur(Acteur acteur);
    }
}
