using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class CompetitionOptions
    {
        public CompetitionOptions()
        {
            CompetitionDetail = new HashSet<CompetitionDetail>();
            CompetitionsOptionsMap = new HashSet<CompetitionsOptionsMap>();
            EngagementDetail = new HashSet<EngagementDetail>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DateCreation { get; set; }
        public string UserCreator { get; set; }
        public DateTime? DateModification { get; set; }
        public string UserModification { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? DateDeletion { get; set; }
        public string UserDeletion { get; set; }

        public virtual ICollection<CompetitionDetail> CompetitionDetail { get; set; }
        public virtual ICollection<CompetitionsOptionsMap> CompetitionsOptionsMap { get; set; }
        public virtual ICollection<EngagementDetail> EngagementDetail { get; set; }
    }
}
