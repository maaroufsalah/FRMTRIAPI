using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class Competitionafrica
    {
        public Competitionafrica()
        {
            CompetitionafricaClassement = new HashSet<CompetitionafricaClassement>();
            CompetitionafricaDetail = new HashSet<CompetitionafricaDetail>();
            CompetitionafricaReport = new HashSet<CompetitionafricaReport>();
        }

        public int Id { get; set; }
        public int? IdCompetitionNom { get; set; }
        public DateTime? DateCompetition { get; set; }
        public int? VilleId { get; set; }
        public bool? StatutClassement { get; set; }
        public bool? StatutReportArbitre { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? DateModification { get; set; }
        public bool? StatutValidation { get; set; }
        public DateTime? DateCreation { get; set; }
        public string UserCreator { get; set; }
        public string UserValidatorFed { get; set; }
        public DateTime? DateValidationFed { get; set; }
        public string UserDeletionFed { get; set; }
        public DateTime? DateDeletionFed { get; set; }
        public bool? StatutReportFederation { get; set; }
        public bool? StatutReportDelegue { get; set; }
        public bool? StatutEngagement { get; set; }
        public string UserModification { get; set; }
        public bool? StatutDetails { get; set; }

        public virtual NomcompetitionAfrica IdCompetitionNomNavigation { get; set; }
        public virtual Ville Ville { get; set; }
        public virtual ICollection<CompetitionafricaClassement> CompetitionafricaClassement { get; set; }
        public virtual ICollection<CompetitionafricaDetail> CompetitionafricaDetail { get; set; }
        public virtual ICollection<CompetitionafricaReport> CompetitionafricaReport { get; set; }
    }
}
