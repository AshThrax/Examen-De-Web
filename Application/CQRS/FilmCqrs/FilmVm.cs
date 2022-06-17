using Film_api.CQRS.FilmCqrs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.FilmCqrs
{
    public class FilmVm
    {
        public IList<FilmDto> Lists { get; set; }
    }
}
