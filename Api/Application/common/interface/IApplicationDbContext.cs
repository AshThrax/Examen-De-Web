using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
using Application.Common.Models;

namespace Application.Common.Interfaces
{
    

    namespace Application.Common.Interfaces
    {
        public interface IApplicationDbContext
        {
            DbSet<Film> Film { get; set; }
            DbSet<Acteur> Acteur { get; set; }

            Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        }
    }

}
