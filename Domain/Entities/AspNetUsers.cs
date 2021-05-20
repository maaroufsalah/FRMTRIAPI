using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class AspNetUsers
    {
        public AspNetUsers()
        {
            AspNetUserClaims = new HashSet<AspNetUserClaims>();
            AspNetUserLogins = new HashSet<AspNetUserLogins>();
            AspNetUserRoles = new HashSet<AspNetUserRoles>();
            AspNetUserTokens = new HashSet<AspNetUserTokens>();
            EngagementEnteteUserCreationNavigation = new HashSet<EngagementEntete>();
            EngagementEnteteUserDeletionNavigation = new HashSet<EngagementEntete>();
            EngagementEnteteUserModificationNavigation = new HashSet<EngagementEntete>();
            EngagementEnteteUserValidatorFedNavigation = new HashSet<EngagementEntete>();
            EngagementEnteteUserValidatorSecNavigation = new HashSet<EngagementEntete>();
        }

        public string Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int? TypeUser { get; set; }
        public int? UserId { get; set; }
        public int? ClubId { get; set; }
        public DateTime? DateCreation { get; set; }
        public string ImageUrl { get; set; }
        public bool? IsBlocked { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? DateModification { get; set; }

        public virtual ICollection<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual ICollection<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual ICollection<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual ICollection<EngagementEntete> EngagementEnteteUserCreationNavigation { get; set; }
        public virtual ICollection<EngagementEntete> EngagementEnteteUserDeletionNavigation { get; set; }
        public virtual ICollection<EngagementEntete> EngagementEnteteUserModificationNavigation { get; set; }
        public virtual ICollection<EngagementEntete> EngagementEnteteUserValidatorFedNavigation { get; set; }
        public virtual ICollection<EngagementEntete> EngagementEnteteUserValidatorSecNavigation { get; set; }
    }
}
