using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class CompetitionClassement
    {
        public int Id { get; set; }
        public int IdCompetition { get; set; }
        public int IdJoueur { get; set; }
        public long? NumLicence { get; set; }
        public int? IdClub { get; set; }
        public int? StartNumber { get; set; }
        public TimeSpan? Swim { get; set; }
        public TimeSpan? T1 { get; set; }
        public TimeSpan? Bike { get; set; }
        public TimeSpan? T2 { get; set; }
        public TimeSpan? Run { get; set; }
        public int? Classement { get; set; }
        public TimeSpan? TotalTime { get; set; }

        public virtual Club IdClubNavigation { get; set; }
        public virtual Competition IdCompetitionNavigation { get; set; }
        public virtual Joueur IdJoueurNavigation { get; set; }
    }
}
