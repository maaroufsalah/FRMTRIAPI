using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class NomcompetitionAfrica
    {
        public NomcompetitionAfrica()
        {
            Competitionafrica = new HashSet<Competitionafrica>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? DateModification { get; set; }

        public virtual ICollection<Competitionafrica> Competitionafrica { get; set; }
    }
}
