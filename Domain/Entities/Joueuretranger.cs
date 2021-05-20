using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class Joueuretranger
    {
        public Joueuretranger()
        {
            CompetitionafricaClassement = new HashSet<CompetitionafricaClassement>();
        }

        public int Id { get; set; }
        public string Passeport { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime? DateNaissance { get; set; }
        public long? NumLicence { get; set; }
        public int? NiveauId { get; set; }
        public int? Classement { get; set; }
        public string Observation { get; set; }
        public string Country { get; set; }
        public int? PayId { get; set; }
        public string ImageUrl { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? DateModification { get; set; }
        public bool? HasAccount { get; set; }
        public int? StatutCreation { get; set; }
        public string Sexe { get; set; }

        public virtual ICollection<CompetitionafricaClassement> CompetitionafricaClassement { get; set; }
    }
}
