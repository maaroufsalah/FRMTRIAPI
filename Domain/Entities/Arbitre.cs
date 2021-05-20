using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class Arbitre
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Cin { get; set; }
        public DateTime? DateNaissance { get; set; }
        public long? NumLicence { get; set; }
        public int? NiveauId { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Adresse { get; set; }
        public string Observation { get; set; }
        public int? ClubId { get; set; }
        public int? VilleId { get; set; }
        public string ImageUrl { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? DateModification { get; set; }
        public bool? HasAccount { get; set; }
        public int? StatutCreation { get; set; }
        public string Sexe { get; set; }
        public long? NumLicenceInt { get; set; }
        public string TypeArbitre { get; set; }
        public DateTime? DateCreation { get; set; }
        public string UserCreator { get; set; }
        public string UserValidatorFed { get; set; }
        public DateTime? DateValidationFed { get; set; }
        public int? StatutDeletion { get; set; }
        public DateTime? DateDemandeDeletion { get; set; }
        public string UserDeletionFed { get; set; }
        public DateTime? DateDeletionFed { get; set; }

        public virtual Club Club { get; set; }
        public virtual Ville Ville { get; set; }
    }
}
