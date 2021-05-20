using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class Ville
    {
        public Ville()
        {
            Arbitre = new HashSet<Arbitre>();
            Club = new HashSet<Club>();
            Coach = new HashSet<Coach>();
            Competition = new HashSet<Competition>();
            Competitionafrica = new HashSet<Competitionafrica>();
            Stafftechniques = new HashSet<Stafftechniques>();
            Usersassociation = new HashSet<Usersassociation>();
            Usersfederation = new HashSet<Usersfederation>();
        }

        public int Id { get; set; }
        public string NomVille { get; set; }
        public int? RegionId { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? DateModification { get; set; }

        public virtual Region Region { get; set; }
        public virtual Association Association { get; set; }
        public virtual ICollection<Arbitre> Arbitre { get; set; }
        public virtual ICollection<Club> Club { get; set; }
        public virtual ICollection<Coach> Coach { get; set; }
        public virtual ICollection<Competition> Competition { get; set; }
        public virtual ICollection<Competitionafrica> Competitionafrica { get; set; }
        public virtual ICollection<Stafftechniques> Stafftechniques { get; set; }
        public virtual ICollection<Usersassociation> Usersassociation { get; set; }
        public virtual ICollection<Usersfederation> Usersfederation { get; set; }
    }
}
