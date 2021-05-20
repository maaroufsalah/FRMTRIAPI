using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class EngagementDetail
    {
        public int Id { get; set; }
        public int IdEngagementEntete { get; set; }
        public int? IdJoueur { get; set; }
        public int? IdCoach { get; set; }
        public long? NumLicence { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? DateCreation { get; set; }
        public DateTime? DateModification { get; set; }
        public int? StatutValidationFed { get; set; }
        public DateTime? DateValidationFed { get; set; }
        public string UserValidatorFed { get; set; }
        public string MotifRefus { get; set; }
        public int? IdOption { get; set; }

        public virtual Coach IdCoachNavigation { get; set; }
        public virtual EngagementEntete IdEngagementEnteteNavigation { get; set; }
        public virtual Joueur IdJoueurNavigation { get; set; }
        public virtual CompetitionOptions IdOptionNavigation { get; set; }
    }
}
