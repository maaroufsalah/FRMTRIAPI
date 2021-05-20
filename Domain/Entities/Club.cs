using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class Club
    {
        public Club()
        {
            Arbitre = new HashSet<Arbitre>();
            Coach = new HashSet<Coach>();
            CompetitionClassement = new HashSet<CompetitionClassement>();
            CompetitionDetail = new HashSet<CompetitionDetail>();
            CompetitionafricaDetail = new HashSet<CompetitionafricaDetail>();
            EngagementEntete = new HashSet<EngagementEntete>();
            Joueur = new HashSet<Joueur>();
            Stafftechniques = new HashSet<Stafftechniques>();
            Usersassociation = new HashSet<Usersassociation>();
            Usersfederation = new HashSet<Usersfederation>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Nom { get; set; }
        public int? VilleId { get; set; }
        public string Adresse { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public int? Membre { get; set; }
        public DateTime? DateCreation { get; set; }
        public string ImageUrl { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? DateModification { get; set; }
        public bool? HasAccount { get; set; }
        public int? StatutCreation { get; set; }
        public DateTime? DateCreationFed { get; set; }
        public string UserCreator { get; set; }
        public string UserDeletionFed { get; set; }
        public DateTime? DateDeletionFed { get; set; }
        public string UserModification { get; set; }
        public string Medecin { get; set; }
        public string Kinesitherapie { get; set; }

        public virtual Ville Ville { get; set; }
        public virtual Association Association { get; set; }
        public virtual ICollection<Arbitre> Arbitre { get; set; }
        public virtual ICollection<Coach> Coach { get; set; }
        public virtual ICollection<CompetitionClassement> CompetitionClassement { get; set; }
        public virtual ICollection<CompetitionDetail> CompetitionDetail { get; set; }
        public virtual ICollection<CompetitionafricaDetail> CompetitionafricaDetail { get; set; }
        public virtual ICollection<EngagementEntete> EngagementEntete { get; set; }
        public virtual ICollection<Joueur> Joueur { get; set; }
        public virtual ICollection<Stafftechniques> Stafftechniques { get; set; }
        public virtual ICollection<Usersassociation> Usersassociation { get; set; }
        public virtual ICollection<Usersfederation> Usersfederation { get; set; }
    }
}
