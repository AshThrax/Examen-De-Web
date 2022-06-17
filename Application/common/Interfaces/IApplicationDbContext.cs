using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
        {
            DbSet<Film> Films { get; set; }
            DbSet<Acteur> Acteurs { get; set; }

            Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        }
    

}
