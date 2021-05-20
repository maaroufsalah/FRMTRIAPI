using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class CompetitionafricaReport
    {
        public int Id { get; set; }
        public int? IdCompetition { get; set; }
        public string ReportArbitre { get; set; }
        public string ReportDeleGue { get; set; }
        public string ReportFederation { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? DateCreation { get; set; }
        public string UserCreatorFed { get; set; }
        public string UserCreatorArbitre { get; set; }
        public DateTime? DateCreationArbitre { get; set; }

        public virtual Competitionafrica IdCompetitionNavigation { get; set; }
    }
}
