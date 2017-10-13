using Interns2.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interns2.Domain.Domains
{
    class Film
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<FilmType> Types { get; set; }
    }
}
