using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class Region
    {
        public Region()
        {
            Ville = new HashSet<Ville>();
        }

        public int Id { get; set; }
        public string NomRegion { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? DateModification { get; set; }

        public virtual ICollection<Ville> Ville { get; set; }
    }
}
