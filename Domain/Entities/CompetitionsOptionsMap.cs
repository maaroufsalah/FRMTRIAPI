using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class CompetitionsOptionsMap
    {
        public int Id { get; set; }
        public int? IdCompetition { get; set; }
        public int? IdOptions { get; set; }
        public bool? DetailInserted { get; set; }
        public DateTime? DateDetailInserted { get; set; }

        public virtual Competition IdCompetitionNavigation { get; set; }
        public virtual CompetitionOptions IdOptionsNavigation { get; set; }
    }
}
