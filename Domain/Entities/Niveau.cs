using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class Niveau
    {
        public Niveau()
        {
            Stafftechniques = new HashSet<Stafftechniques>();
            Usersassociation = new HashSet<Usersassociation>();
            Usersfederation = new HashSet<Usersfederation>();
        }

        public int Id { get; set; }
        public int? Type { get; set; }
        public string Description { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? DateModification { get; set; }

        public virtual ICollection<Stafftechniques> Stafftechniques { get; set; }
        public virtual ICollection<Usersassociation> Usersassociation { get; set; }
        public virtual ICollection<Usersfederation> Usersfederation { get; set; }
    }
}
