using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class Competition
    {
        public Competition()
        {
            CompetitionClassement = new HashSet<CompetitionClassement>();
            CompetitionDetail = new HashSet<CompetitionDetail>();
            CompetitionReport = new HashSet<CompetitionReport>();
            CompetitionsOptionsMap = new HashSet<CompetitionsOptionsMap>();
            EngagementEntete = new HashSet<EngagementEntete>();
        }

        public int Id { get; set; }
        public string TypeCompetition { get; set; }
        public DateTime? DateCompetition { get; set; }
        public int? VilleId { get; set; }
        public bool? StatutClassement { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? StatutReportArbitre { get; set; }
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
        public bool? StatutDetails { get; set; }
        public string UserModification { get; set; }

        public virtual Ville Ville { get; set; }
        public virtual ICollection<CompetitionClassement> CompetitionClassement { get; set; }
        public virtual ICollection<CompetitionDetail> CompetitionDetail { get; set; }
        public virtual ICollection<CompetitionReport> CompetitionReport { get; set; }
        public virtual ICollection<CompetitionsOptionsMap> CompetitionsOptionsMap { get; set; }
        public virtual ICollection<EngagementEntete> EngagementEntete { get; set; }
    }
}
