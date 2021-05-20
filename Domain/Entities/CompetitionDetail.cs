using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class CompetitionDetail
    {
        public int Id { get; set; }
        public int IdCompetition { get; set; }
        public int IdUser { get; set; }
        public string TypeUser { get; set; }
        public long? NumLicence { get; set; }
        public int IdClub { get; set; }
        public DateTime? DateCreation { get; set; }
        public DateTime? DateModification { get; set; }
        public int? IdOption { get; set; }

        public virtual Club IdClubNavigation { get; set; }
        public virtual Competition IdCompetitionNavigation { get; set; }
        public virtual CompetitionOptions IdOptionNavigation { get; set; }
    }
}
