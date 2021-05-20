using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class Association
    {
        public int Id { get; set; }
        public string CodeAssociation { get; set; }
        public string NomAssociation { get; set; }
        public int? VilleId { get; set; }
        public string AdresseAssociation { get; set; }
        public string TelephoneAssociation { get; set; }
        public string EmailAssociation { get; set; }
        public int? MembreAssociation { get; set; }
        public DateTime? DateCreation { get; set; }
        public int? IdClub { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Ville Id1 { get; set; }
        public virtual Club IdNavigation { get; set; }
    }
}
