using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class EngagementEntete
    {
        public EngagementEntete()
        {
            EngagementDetail = new HashSet<EngagementDetail>();
        }

        public int Id { get; set; }
        public int? IdCompetition { get; set; }
        public int? IdClub { get; set; }
        public string Type { get; set; }
        public string UserCreation { get; set; }
        public DateTime? DateCreation { get; set; }
        public string UserValidatorSec { get; set; }
        public DateTime? DateValidationSec { get; set; }
        public string UserValidatorFed { get; set; }
        public DateTime? DateValidationFed { get; set; }
        public string UserModification { get; set; }
        public DateTime? DateModification { get; set; }
        public int? StatutDeletion { get; set; }
        public bool? IsDeleted { get; set; }
        public string UserDeletion { get; set; }
        public DateTime? DateDeletion { get; set; }
        public int? StatutValidation { get; set; }
        public DateTime? DateValidationClub { get; set; }

        public virtual Club IdClubNavigation { get; set; }
        public virtual Competition IdCompetitionNavigation { get; set; }
        public virtual AspNetUsers UserCreationNavigation { get; set; }
        public virtual AspNetUsers UserDeletionNavigation { get; set; }
        public virtual AspNetUsers UserModificationNavigation { get; set; }
        public virtual AspNetUsers UserValidatorFedNavigation { get; set; }
        public virtual AspNetUsers UserValidatorSecNavigation { get; set; }
        public virtual ICollection<EngagementDetail> EngagementDetail { get; set; }
    }
}
