using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class Joueur
    {
        public Joueur()
        {
            CompetitionClassement = new HashSet<CompetitionClassement>();
            EngagementDetail = new HashSet<EngagementDetail>();
        }

        public int Id { get; set; }
        public string Cin { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime? DateNaissance { get; set; }
        public long? NumLicence { get; set; }
        public int? NiveauId { get; set; }
        public int? Classement { get; set; }
        public string Observation { get; set; }
        public int? ClubId { get; set; }
        public string ImageUrl { get; set; }
        public bool? IsDeleted { get; set; }
        public string Sexe { get; set; }
        public bool? HasAccount { get; set; }
        public DateTime? DateModification { get; set; }
        public string Email { get; set; }
        public int? StatutCreation { get; set; }
        public DateTime? DateCreation { get; set; }
        public string UserCreator { get; set; }
        public string UserValidatorSec { get; set; }
        public DateTime? DateValidationSec { get; set; }
        public string UserValidatorFed { get; set; }
        public DateTime? DateValidationFed { get; set; }
        public int? StatutDeletion { get; set; }
        public string UserDeletionFed { get; set; }
        public DateTime? DateDeletionFed { get; set; }
        public DateTime? DateDemandeDeletion { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string PdfUrl { get; set; }

        public virtual Club Club { get; set; }
        public virtual ICollection<CompetitionClassement> CompetitionClassement { get; set; }
        public virtual ICollection<EngagementDetail> EngagementDetail { get; set; }
    }
}
