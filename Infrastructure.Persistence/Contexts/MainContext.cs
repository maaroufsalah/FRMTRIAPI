using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Domain.Entities;

#nullable disable

namespace Infrastructure.Persistence.Contexts
{
    public partial class MainContext : DbContext
    {
        public MainContext()
        {
        }

        public MainContext(DbContextOptions<MainContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Activite> Activite { get; set; }
        public virtual DbSet<Arbitre> Arbitre { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Association> Association { get; set; }
        public virtual DbSet<Club> Club { get; set; }
        public virtual DbSet<Coach> Coach { get; set; }
        public virtual DbSet<Competition> Competition { get; set; }
        public virtual DbSet<CompetitionClassement> CompetitionClassement { get; set; }
        public virtual DbSet<CompetitionDetail> CompetitionDetail { get; set; }
        public virtual DbSet<CompetitionOptions> CompetitionOptions { get; set; }
        public virtual DbSet<CompetitionReport> CompetitionReport { get; set; }
        public virtual DbSet<Competitionafrica> Competitionafrica { get; set; }
        public virtual DbSet<CompetitionafricaClassement> CompetitionafricaClassement { get; set; }
        public virtual DbSet<CompetitionafricaDetail> CompetitionafricaDetail { get; set; }
        public virtual DbSet<CompetitionafricaReport> CompetitionafricaReport { get; set; }
        public virtual DbSet<CompetitionsOptionsMap> CompetitionsOptionsMap { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Ecran> Ecran { get; set; }
        public virtual DbSet<EcranRole> EcranRole { get; set; }
        public virtual DbSet<EngagementDetail> EngagementDetail { get; set; }
        public virtual DbSet<EngagementEntete> EngagementEntete { get; set; }
        public virtual DbSet<Joueur> Joueur { get; set; }
        public virtual DbSet<Joueuretranger> Joueuretranger { get; set; }
        public virtual DbSet<Module> Module { get; set; }
        public virtual DbSet<ModuleActivite> ModuleActivite { get; set; }
        public virtual DbSet<Niveau> Niveau { get; set; }
        public virtual DbSet<NomcompetitionAfrica> NomcompetitionAfrica { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<Stafftechniques> Stafftechniques { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserTypes> UserTypes { get; set; }
        public virtual DbSet<UsersRoles> UsersRoles { get; set; }
        public virtual DbSet<Usersassociation> Usersassociation { get; set; }
        public virtual DbSet<Usersfederation> Usersfederation { get; set; }
        public virtual DbSet<Ville> Ville { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "French_CI_AS");

            modelBuilder.Entity<Activite>(entity =>
            {
                entity.ToTable("ACTIVITE");

                entity.Property(e => e.ActiviteId).HasColumnName("Activite_Id");

                entity.Property(e => e.ActiviteCode)
                    .HasMaxLength(50)
                    .HasColumnName("Activite_Code");

                entity.Property(e => e.ActiviteDateCreation)
                    .HasColumnType("datetime")
                    .HasColumnName("Activite_DateCreation");

                entity.Property(e => e.ActiviteIcon)
                    .HasMaxLength(50)
                    .HasColumnName("Activite_Icon");

                entity.Property(e => e.ActiviteIsActif).HasColumnName("Activite_IsActif");

                entity.Property(e => e.ActiviteLibelle)
                    .HasMaxLength(125)
                    .HasColumnName("Activite_Libelle");

                entity.Property(e => e.ActiviteOrder).HasColumnName("Activite_Order");

                entity.Property(e => e.ActiviteUserCreation)
                    .HasMaxLength(125)
                    .HasColumnName("Activite_UserCreation");
            });

            modelBuilder.Entity<Arbitre>(entity =>
            {
                entity.ToTable("ARBITRE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cin).HasMaxLength(125);

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.DateDeletionFed).HasColumnType("datetime");

                entity.Property(e => e.DateDemandeDeletion).HasColumnType("datetime");

                entity.Property(e => e.DateModification).HasColumnType("datetime");

                entity.Property(e => e.DateNaissance).HasColumnType("datetime");

                entity.Property(e => e.DateValidationFed).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(225);

                entity.Property(e => e.HasAccount).HasColumnName("hasAccount");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Nom).HasMaxLength(225);

                entity.Property(e => e.Prenom).HasMaxLength(225);

                entity.Property(e => e.Sexe).HasMaxLength(1);

                entity.Property(e => e.Telephone).HasMaxLength(30);

                entity.Property(e => e.TypeArbitre).HasMaxLength(1);

                entity.Property(e => e.UserCreator).HasMaxLength(256);

                entity.Property(e => e.UserDeletionFed).HasMaxLength(256);

                entity.Property(e => e.UserValidatorFed).HasMaxLength(256);

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.Arbitre)
                    .HasForeignKey(d => d.ClubId)
                    .HasConstraintName("FK__ARBITRE__ClubId__7C4F7684");

                entity.HasOne(d => d.Ville)
                    .WithMany(p => p.Arbitre)
                    .HasForeignKey(d => d.VilleId)
                    .HasConstraintName("FK__ARBITRE__VilleId__7D439ABD");
            });

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Id).HasMaxLength(256);

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(256);

                entity.Property(e => e.ProviderKey).HasMaxLength(256);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId, "IX_AspNetUserRoles_RoleId");

                entity.Property(e => e.UserId).HasMaxLength(256);

                entity.Property(e => e.RoleId).HasMaxLength(256);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.UserId).HasMaxLength(256);

                entity.Property(e => e.LoginProvider).HasMaxLength(256);

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).HasMaxLength(256);

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.DateModification).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.ImageUrl).HasMaxLength(225);

                entity.Property(e => e.IsBlocked).HasColumnName("isBlocked");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.Nom).HasMaxLength(125);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.Prenom).HasMaxLength(125);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Association>(entity =>
            {
                entity.ToTable("ASSOCIATION");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.AdresseAssociation).HasMaxLength(125);

                entity.Property(e => e.CodeAssociation).HasMaxLength(20);

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.EmailAssociation).HasMaxLength(125);

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NomAssociation).HasMaxLength(125);

                entity.Property(e => e.TelephoneAssociation).HasMaxLength(30);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Association)
                    .HasForeignKey<Association>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ASSOCIATION__Id__03F0984C");

                entity.HasOne(d => d.Id1)
                    .WithOne(p => p.Association)
                    .HasForeignKey<Association>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ASSOCIATION__Id__04E4BC85");
            });

            modelBuilder.Entity<Club>(entity =>
            {
                entity.ToTable("CLUB");

                entity.Property(e => e.Adresse).HasMaxLength(125);

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.DateCreationFed).HasColumnType("datetime");

                entity.Property(e => e.DateDeletionFed).HasColumnType("datetime");

                entity.Property(e => e.DateModification).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(125);

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.Kinesitherapie).HasMaxLength(125);

                entity.Property(e => e.Medecin).HasMaxLength(125);

                entity.Property(e => e.Nom).HasMaxLength(125);

                entity.Property(e => e.Telephone).HasMaxLength(30);

                entity.Property(e => e.UserCreator).HasMaxLength(256);

                entity.Property(e => e.UserDeletionFed).HasMaxLength(256);

                entity.Property(e => e.UserModification).HasMaxLength(256);

                entity.HasOne(d => d.Ville)
                    .WithMany(p => p.Club)
                    .HasForeignKey(d => d.VilleId)
                    .HasConstraintName("FK__CLUB__VilleId__05D8E0BE");
            });

            modelBuilder.Entity<Coach>(entity =>
            {
                entity.ToTable("COACH");

                entity.Property(e => e.Cin).HasMaxLength(125);

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.DateDeletionFed).HasColumnType("datetime");

                entity.Property(e => e.DateDemandeDeletion).HasColumnType("datetime");

                entity.Property(e => e.DateModification).HasColumnType("datetime");

                entity.Property(e => e.DateNaissance).HasColumnType("datetime");

                entity.Property(e => e.DateValidationFed).HasColumnType("datetime");

                entity.Property(e => e.DateValidationSec).HasColumnType("datetime");

                entity.Property(e => e.Diplome).HasMaxLength(225);

                entity.Property(e => e.Email).HasMaxLength(225);

                entity.Property(e => e.HasAccount).HasColumnName("hasAccount");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Nom).HasMaxLength(225);

                entity.Property(e => e.PdfUrl).HasMaxLength(225);

                entity.Property(e => e.Prenom).HasMaxLength(225);

                entity.Property(e => e.Sexe).HasMaxLength(1);

                entity.Property(e => e.Telephone).HasMaxLength(30);

                entity.Property(e => e.UserCreator).HasMaxLength(256);

                entity.Property(e => e.UserDeletionFed).HasMaxLength(256);

                entity.Property(e => e.UserValidatorFed).HasMaxLength(256);

                entity.Property(e => e.UserValidatorSec).HasMaxLength(256);

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.Coach)
                    .HasForeignKey(d => d.ClubId)
                    .HasConstraintName("FK__COACH__ClubId__06CD04F7");

                entity.HasOne(d => d.Ville)
                    .WithMany(p => p.Coach)
                    .HasForeignKey(d => d.VilleId)
                    .HasConstraintName("FK__COACH__VilleId__07C12930");
            });

            modelBuilder.Entity<Competition>(entity =>
            {
                entity.ToTable("COMPETITION");

                entity.Property(e => e.DateCompetition).HasColumnType("datetime");

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.DateDeletionFed).HasColumnType("datetime");

                entity.Property(e => e.DateModification).HasColumnType("datetime");

                entity.Property(e => e.DateValidationFed).HasColumnType("datetime");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TypeCompetition).HasMaxLength(125);

                entity.Property(e => e.UserCreator).HasMaxLength(256);

                entity.Property(e => e.UserDeletionFed).HasMaxLength(256);

                entity.Property(e => e.UserModification).HasMaxLength(256);

                entity.Property(e => e.UserValidatorFed).HasMaxLength(256);

                entity.HasOne(d => d.Ville)
                    .WithMany(p => p.Competition)
                    .HasForeignKey(d => d.VilleId)
                    .HasConstraintName("FK__COMPETITI__Ville__08B54D69");
            });

            modelBuilder.Entity<CompetitionClassement>(entity =>
            {
                entity.ToTable("COMPETITION_CLASSEMENT");

                entity.Property(e => e.Bike).HasColumnName("BIKE");

                entity.Property(e => e.Run).HasColumnName("RUN");

                entity.Property(e => e.Swim).HasColumnName("SWIM");

                entity.HasOne(d => d.IdClubNavigation)
                    .WithMany(p => p.CompetitionClassement)
                    .HasForeignKey(d => d.IdClub)
                    .HasConstraintName("FK__COMPETITI__IdClu__09A971A2");

                entity.HasOne(d => d.IdCompetitionNavigation)
                    .WithMany(p => p.CompetitionClassement)
                    .HasForeignKey(d => d.IdCompetition)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__COMPETITI__IdCom__0A9D95DB");

                entity.HasOne(d => d.IdJoueurNavigation)
                    .WithMany(p => p.CompetitionClassement)
                    .HasForeignKey(d => d.IdJoueur)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__COMPETITI__IdJou__0B91BA14");
            });

            modelBuilder.Entity<CompetitionDetail>(entity =>
            {
                entity.ToTable("COMPETITION_DETAIL");

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.DateModification).HasColumnType("datetime");

                entity.Property(e => e.TypeUser)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.HasOne(d => d.IdClubNavigation)
                    .WithMany(p => p.CompetitionDetail)
                    .HasForeignKey(d => d.IdClub)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__COMPETITI__IdClu__0C85DE4D");

                entity.HasOne(d => d.IdCompetitionNavigation)
                    .WithMany(p => p.CompetitionDetail)
                    .HasForeignKey(d => d.IdCompetition)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__COMPETITI__IdCom__0D7A0286");

                entity.HasOne(d => d.IdOptionNavigation)
                    .WithMany(p => p.CompetitionDetail)
                    .HasForeignKey(d => d.IdOption)
                    .HasConstraintName("FK__COMPETITI__IdOpt__0E6E26BF");
            });

            modelBuilder.Entity<CompetitionOptions>(entity =>
            {
                entity.ToTable("Competition_Options");

                entity.Property(e => e.Code).HasMaxLength(15);

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.DateDeletion).HasColumnType("datetime");

                entity.Property(e => e.DateModification).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(550);

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.Name).HasMaxLength(125);

                entity.Property(e => e.UserCreator).HasMaxLength(256);

                entity.Property(e => e.UserDeletion).HasMaxLength(256);

                entity.Property(e => e.UserModification)
                    .HasMaxLength(256)
                    .HasColumnName("userModification");
            });

            modelBuilder.Entity<CompetitionReport>(entity =>
            {
                entity.ToTable("COMPETITION_REPORT");

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.DateCreationArbitre).HasColumnType("datetime");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.UserCreatorArbitre).HasMaxLength(256);

                entity.Property(e => e.UserCreatorFed).HasMaxLength(256);

                entity.HasOne(d => d.IdCompetitionNavigation)
                    .WithMany(p => p.CompetitionReport)
                    .HasForeignKey(d => d.IdCompetition)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__COMPETITI__IdCom__0F624AF8");
            });

            modelBuilder.Entity<Competitionafrica>(entity =>
            {
                entity.ToTable("COMPETITIONAFRICA");

                entity.Property(e => e.DateCompetition).HasColumnType("datetime");

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.DateDeletionFed).HasColumnType("datetime");

                entity.Property(e => e.DateModification).HasColumnType("datetime");

                entity.Property(e => e.DateValidationFed).HasColumnType("datetime");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.UserCreator).HasMaxLength(256);

                entity.Property(e => e.UserDeletionFed).HasMaxLength(256);

                entity.Property(e => e.UserModification).HasMaxLength(256);

                entity.Property(e => e.UserValidatorFed).HasMaxLength(256);

                entity.HasOne(d => d.IdCompetitionNomNavigation)
                    .WithMany(p => p.Competitionafrica)
                    .HasForeignKey(d => d.IdCompetitionNom)
                    .HasConstraintName("FK__COMPETITI__IdCom__10566F31");

                entity.HasOne(d => d.Ville)
                    .WithMany(p => p.Competitionafrica)
                    .HasForeignKey(d => d.VilleId)
                    .HasConstraintName("FK__COMPETITI__Ville__114A936A");
            });

            modelBuilder.Entity<CompetitionafricaClassement>(entity =>
            {
                entity.ToTable("COMPETITIONAFRICA_CLASSEMENT");

                entity.Property(e => e.Bike).HasColumnName("BIKE");

                entity.Property(e => e.Run).HasColumnName("RUN");

                entity.Property(e => e.Swim).HasColumnName("SWIM");

                entity.HasOne(d => d.IdCompetitionNavigation)
                    .WithMany(p => p.CompetitionafricaClassement)
                    .HasForeignKey(d => d.IdCompetition)
                    .HasConstraintName("FK__COMPETITI__IdCom__123EB7A3");

                entity.HasOne(d => d.IdJoueurNavigation)
                    .WithMany(p => p.CompetitionafricaClassement)
                    .HasForeignKey(d => d.IdJoueur)
                    .HasConstraintName("FK__COMPETITI__IdJou__1332DBDC");
            });

            modelBuilder.Entity<CompetitionafricaDetail>(entity =>
            {
                entity.ToTable("COMPETITIONAFRICA_DETAIL");

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.DateModification).HasColumnType("datetime");

                entity.Property(e => e.TypeUser)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.HasOne(d => d.IdClubNavigation)
                    .WithMany(p => p.CompetitionafricaDetail)
                    .HasForeignKey(d => d.IdClub)
                    .HasConstraintName("FK__COMPETITI__IdClu__14270015");

                entity.HasOne(d => d.IdCompetitionNavigation)
                    .WithMany(p => p.CompetitionafricaDetail)
                    .HasForeignKey(d => d.IdCompetition)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__COMPETITI__IdCom__151B244E");
            });

            modelBuilder.Entity<CompetitionafricaReport>(entity =>
            {
                entity.ToTable("COMPETITIONAFRICA_REPORT");

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.DateCreationArbitre).HasColumnType("datetime");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.UserCreatorArbitre).HasMaxLength(256);

                entity.Property(e => e.UserCreatorFed).HasMaxLength(256);

                entity.HasOne(d => d.IdCompetitionNavigation)
                    .WithMany(p => p.CompetitionafricaReport)
                    .HasForeignKey(d => d.IdCompetition)
                    .HasConstraintName("FK__COMPETITI__IdCom__160F4887");
            });

            modelBuilder.Entity<CompetitionsOptionsMap>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateDetailInserted).HasColumnType("datetime");

                entity.HasOne(d => d.IdCompetitionNavigation)
                    .WithMany(p => p.CompetitionsOptionsMap)
                    .HasForeignKey(d => d.IdCompetition)
                    .HasConstraintName("FK__Competiti__IdCom__17036CC0");

                entity.HasOne(d => d.IdOptionsNavigation)
                    .WithMany(p => p.CompetitionsOptionsMap)
                    .HasForeignKey(d => d.IdOptions)
                    .HasConstraintName("FK__Competiti__IdOpt__17F790F9");
            });

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Name)
                    .HasMaxLength(125)
                    .IsUnicode(false);

                entity.Property(e => e.ThreeCharCountryCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TwoCharCountryCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Ecran>(entity =>
            {
                entity.ToTable("ECRAN");

                entity.Property(e => e.EcranId).HasColumnName("Ecran_id");

                entity.Property(e => e.EcranDateModification)
                    .HasColumnType("datetime")
                    .HasColumnName("Ecran_DateModification");

                entity.Property(e => e.EcranDescription)
                    .HasMaxLength(250)
                    .HasColumnName("Ecran_Description");

                entity.Property(e => e.EcranLibelle)
                    .HasMaxLength(125)
                    .HasColumnName("Ecran_Libelle");

                entity.Property(e => e.EcranLien)
                    .HasMaxLength(255)
                    .HasColumnName("Ecran_Lien");

                entity.Property(e => e.EcranModuleId).HasColumnName("Ecran_Module_id");

                entity.Property(e => e.EcranNom)
                    .HasMaxLength(255)
                    .HasColumnName("Ecran_Nom");

                entity.Property(e => e.EcranOrdre).HasColumnName("Ecran_Ordre");

                entity.HasOne(d => d.EcranModule)
                    .WithMany(p => p.Ecran)
                    .HasForeignKey(d => d.EcranModuleId)
                    .HasConstraintName("FK__ECRAN__Ecran_Mod__18EBB532");
            });

            modelBuilder.Entity<EcranRole>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ECRAN_ROLE");

                entity.Property(e => e.EcranId).HasColumnName("Ecran_Id");

                entity.Property(e => e.EcranRoleAdd).HasColumnName("ECRAN_ROLE_Add");

                entity.Property(e => e.EcranRoleConsult).HasColumnName("ECRAN_ROLE_Consult");

                entity.Property(e => e.EcranRoleDateModification)
                    .HasColumnType("datetime")
                    .HasColumnName("ECRAN_ROLE_DateModification");

                entity.Property(e => e.EcranRoleDelete).HasColumnName("ECRAN_ROLE_Delete");

                entity.Property(e => e.EcranRoleId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ECRAN_ROLE_Id");

                entity.Property(e => e.EcranRoleUpdate).HasColumnName("ECRAN_ROLE_Update");

                entity.Property(e => e.RoleId)
                    .HasMaxLength(256)
                    .HasColumnName("Role_Id");

                entity.HasOne(d => d.Ecran)
                    .WithMany()
                    .HasForeignKey(d => d.EcranId)
                    .HasConstraintName("FK__ECRAN_ROL__Ecran__19DFD96B");

                entity.HasOne(d => d.Role)
                    .WithMany()
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__ECRAN_ROL__Role___1AD3FDA4");
            });

            modelBuilder.Entity<EngagementDetail>(entity =>
            {
                entity.ToTable("Engagement_Detail");

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.DateModification).HasColumnType("datetime");

                entity.Property(e => e.DateValidationFed).HasColumnType("datetime");

                entity.Property(e => e.IdEngagementEntete).HasColumnName("Id_EngagementEntete");

                entity.Property(e => e.ImageUrl).HasMaxLength(225);

                entity.Property(e => e.UserValidatorFed).HasMaxLength(256);

                entity.HasOne(d => d.IdCoachNavigation)
                    .WithMany(p => p.EngagementDetail)
                    .HasForeignKey(d => d.IdCoach)
                    .HasConstraintName("FK__Engagemen__IdCoa__1CBC4616");

                entity.HasOne(d => d.IdEngagementEnteteNavigation)
                    .WithMany(p => p.EngagementDetail)
                    .HasForeignKey(d => d.IdEngagementEntete)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Engagemen__Id_En__1BC821DD");

                entity.HasOne(d => d.IdJoueurNavigation)
                    .WithMany(p => p.EngagementDetail)
                    .HasForeignKey(d => d.IdJoueur)
                    .HasConstraintName("FK__Engagemen__IdJou__1DB06A4F");

                entity.HasOne(d => d.IdOptionNavigation)
                    .WithMany(p => p.EngagementDetail)
                    .HasForeignKey(d => d.IdOption)
                    .HasConstraintName("FK__Engagemen__IdOpt__1EA48E88");
            });

            modelBuilder.Entity<EngagementEntete>(entity =>
            {
                entity.ToTable("Engagement_Entete");

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.DateDeletion).HasColumnType("datetime");

                entity.Property(e => e.DateModification).HasColumnType("datetime");

                entity.Property(e => e.DateValidationClub).HasColumnType("datetime");

                entity.Property(e => e.DateValidationFed).HasColumnType("datetime");

                entity.Property(e => e.DateValidationSec).HasColumnType("datetime");

                entity.Property(e => e.Type).HasMaxLength(1);

                entity.Property(e => e.UserCreation).HasMaxLength(256);

                entity.Property(e => e.UserDeletion).HasMaxLength(256);

                entity.Property(e => e.UserModification).HasMaxLength(256);

                entity.Property(e => e.UserValidatorFed).HasMaxLength(256);

                entity.Property(e => e.UserValidatorSec).HasMaxLength(256);

                entity.HasOne(d => d.IdClubNavigation)
                    .WithMany(p => p.EngagementEntete)
                    .HasForeignKey(d => d.IdClub)
                    .HasConstraintName("FK__Engagemen__IdClu__1F98B2C1");

                entity.HasOne(d => d.IdCompetitionNavigation)
                    .WithMany(p => p.EngagementEntete)
                    .HasForeignKey(d => d.IdCompetition)
                    .HasConstraintName("FK__Engagemen__IdCom__208CD6FA");

                entity.HasOne(d => d.UserCreationNavigation)
                    .WithMany(p => p.EngagementEnteteUserCreationNavigation)
                    .HasForeignKey(d => d.UserCreation)
                    .HasConstraintName("FK__Engagemen__UserC__2180FB33");

                entity.HasOne(d => d.UserDeletionNavigation)
                    .WithMany(p => p.EngagementEnteteUserDeletionNavigation)
                    .HasForeignKey(d => d.UserDeletion)
                    .HasConstraintName("FK__Engagemen__UserD__22751F6C");

                entity.HasOne(d => d.UserModificationNavigation)
                    .WithMany(p => p.EngagementEnteteUserModificationNavigation)
                    .HasForeignKey(d => d.UserModification)
                    .HasConstraintName("FK__Engagemen__UserM__236943A5");

                entity.HasOne(d => d.UserValidatorFedNavigation)
                    .WithMany(p => p.EngagementEnteteUserValidatorFedNavigation)
                    .HasForeignKey(d => d.UserValidatorFed)
                    .HasConstraintName("FK__Engagemen__UserV__25518C17");

                entity.HasOne(d => d.UserValidatorSecNavigation)
                    .WithMany(p => p.EngagementEnteteUserValidatorSecNavigation)
                    .HasForeignKey(d => d.UserValidatorSec)
                    .HasConstraintName("FK__Engagemen__UserV__245D67DE");
            });

            modelBuilder.Entity<Joueur>(entity =>
            {
                entity.ToTable("JOUEUR");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cin).HasMaxLength(125);

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.DateDeletionFed).HasColumnType("datetime");

                entity.Property(e => e.DateDemandeDeletion).HasColumnType("datetime");

                entity.Property(e => e.DateModification).HasColumnType("datetime");

                entity.Property(e => e.DateNaissance).HasColumnType("datetime");

                entity.Property(e => e.DateValidationFed).HasColumnType("datetime");

                entity.Property(e => e.DateValidationSec).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(225)
                    .HasColumnName("email");

                entity.Property(e => e.FatherName).HasMaxLength(125);

                entity.Property(e => e.HasAccount).HasColumnName("hasAccount");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MotherName).HasMaxLength(125);

                entity.Property(e => e.Nom).HasMaxLength(225);

                entity.Property(e => e.PdfUrl)
                    .IsRequired()
                    .HasMaxLength(225);

                entity.Property(e => e.Prenom).HasMaxLength(225);

                entity.Property(e => e.Sexe).HasMaxLength(1);

                entity.Property(e => e.UserCreator).HasMaxLength(256);

                entity.Property(e => e.UserDeletionFed).HasMaxLength(256);

                entity.Property(e => e.UserValidatorFed).HasMaxLength(256);

                entity.Property(e => e.UserValidatorSec).HasMaxLength(256);

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.Joueur)
                    .HasForeignKey(d => d.ClubId)
                    .HasConstraintName("FK__JOUEUR__ClubId__2645B050");
            });

            modelBuilder.Entity<Joueuretranger>(entity =>
            {
                entity.ToTable("JOUEURETRANGER");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Country).HasMaxLength(125);

                entity.Property(e => e.DateModification).HasColumnType("datetime");

                entity.Property(e => e.DateNaissance).HasColumnType("datetime");

                entity.Property(e => e.HasAccount).HasColumnName("hasAccount");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.Nom).HasMaxLength(225);

                entity.Property(e => e.Passeport).HasMaxLength(125);

                entity.Property(e => e.Prenom).HasMaxLength(225);

                entity.Property(e => e.Sexe).HasMaxLength(1);
            });

            modelBuilder.Entity<Module>(entity =>
            {
                entity.ToTable("MODULE");

                entity.Property(e => e.ModuleId).HasColumnName("Module_Id");

                entity.Property(e => e.ModuleCode)
                    .HasMaxLength(50)
                    .HasColumnName("Module_Code");

                entity.Property(e => e.ModuleDateCreation)
                    .HasColumnType("datetime")
                    .HasColumnName("Module_DateCreation");

                entity.Property(e => e.ModuleIcon)
                    .HasMaxLength(50)
                    .HasColumnName("Module_Icon");

                entity.Property(e => e.ModuleIsActif).HasColumnName("Module_IsActif");

                entity.Property(e => e.ModuleLibelle)
                    .HasMaxLength(120)
                    .HasColumnName("Module_Libelle");

                entity.Property(e => e.ModuleLien)
                    .HasMaxLength(50)
                    .HasColumnName("Module_Lien");

                entity.Property(e => e.ModuleUserCreation)
                    .HasMaxLength(256)
                    .HasColumnName("Module_UserCreation");
            });

            modelBuilder.Entity<ModuleActivite>(entity =>
            {
                entity.HasKey(e => e.MaId)
                    .HasName("PK__MODULE_A__53E132458AA20F6A");

                entity.ToTable("MODULE_ACTIVITE");

                entity.Property(e => e.MaId).HasColumnName("MA_Id");

                entity.Property(e => e.MaActiviteId).HasColumnName("MA_Activite_id");

                entity.Property(e => e.MaDateModification)
                    .HasColumnType("datetime")
                    .HasColumnName("MA_DateModification");

                entity.Property(e => e.MaIsactive).HasColumnName("MA_Isactive");

                entity.Property(e => e.MaIsgroup).HasColumnName("MA_Isgroup");

                entity.Property(e => e.MaModuleId).HasColumnName("MA_Module_Id");

                entity.HasOne(d => d.MaActivite)
                    .WithMany(p => p.ModuleActivite)
                    .HasForeignKey(d => d.MaActiviteId)
                    .HasConstraintName("FK__MODULE_AC__MA_Ac__2739D489");

                entity.HasOne(d => d.MaModule)
                    .WithMany(p => p.ModuleActivite)
                    .HasForeignKey(d => d.MaModuleId)
                    .HasConstraintName("FK__MODULE_AC__MA_Mo__282DF8C2");
            });

            modelBuilder.Entity<Niveau>(entity =>
            {
                entity.ToTable("NIVEAU");

                entity.Property(e => e.DateModification).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(225);

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<NomcompetitionAfrica>(entity =>
            {
                entity.ToTable("NOMCOMPETITION_AFRICA");

                entity.Property(e => e.DateModification).HasColumnType("datetime");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.Nom).HasMaxLength(125);
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.Icon).HasMaxLength(50);

                entity.Property(e => e.TextHeader).HasMaxLength(125);

                entity.Property(e => e.TypeNotification).HasMaxLength(125);

                entity.Property(e => e.Url).HasMaxLength(50);
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.ToTable("REGION");

                entity.Property(e => e.DateModification).HasColumnType("datetime");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NomRegion)
                    .IsRequired()
                    .HasMaxLength(125);
            });

            modelBuilder.Entity<Stafftechniques>(entity =>
            {
                entity.ToTable("STAFFTECHNIQUES");

                entity.Property(e => e.Cin).HasMaxLength(125);

                entity.Property(e => e.DateModification).HasColumnType("datetime");

                entity.Property(e => e.DateNaissance).HasColumnType("datetime");

                entity.Property(e => e.Diplome).HasMaxLength(225);

                entity.Property(e => e.Email).HasMaxLength(225);

                entity.Property(e => e.HasAccount).HasColumnName("hasAccount");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Nom).HasMaxLength(225);

                entity.Property(e => e.Prenom).HasMaxLength(225);

                entity.Property(e => e.Sexe).HasMaxLength(1);

                entity.Property(e => e.Telephone).HasMaxLength(30);

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.Stafftechniques)
                    .HasForeignKey(d => d.ClubId)
                    .HasConstraintName("FK__STAFFTECH__ClubI__29221CFB");

                entity.HasOne(d => d.Niveau)
                    .WithMany(p => p.Stafftechniques)
                    .HasForeignKey(d => d.NiveauId)
                    .HasConstraintName("FK__STAFFTECH__Nivea__2A164134");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Stafftechniques)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__STAFFTECH__RoleI__2B0A656D");

                entity.HasOne(d => d.Ville)
                    .WithMany(p => p.Stafftechniques)
                    .HasForeignKey(d => d.VilleId)
                    .HasConstraintName("FK__STAFFTECH__Ville__2BFE89A6");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FirstName).HasMaxLength(30);

                entity.Property(e => e.LastName).HasMaxLength(30);

                entity.Property(e => e.Login).HasMaxLength(30);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<UserTypes>(entity =>
            {
                entity.Property(e => e.UserTypeLibelle).HasMaxLength(50);
            });

            modelBuilder.Entity<UsersRoles>(entity =>
            {
                entity.ToTable("USERS_ROLES");

                entity.Property(e => e.DateModification).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(225);

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Usersassociation>(entity =>
            {
                entity.ToTable("USERSASSOCIATION");

                entity.Property(e => e.Cin).HasMaxLength(125);

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.DateDeletionFed).HasColumnType("datetime");

                entity.Property(e => e.DateDemandeDeletion).HasColumnType("datetime");

                entity.Property(e => e.DateModification).HasColumnType("datetime");

                entity.Property(e => e.DateNaissance).HasColumnType("datetime");

                entity.Property(e => e.DateValidationFed).HasColumnType("datetime");

                entity.Property(e => e.DateValidationSec).HasColumnType("datetime");

                entity.Property(e => e.Diplome).HasMaxLength(225);

                entity.Property(e => e.Email).HasMaxLength(225);

                entity.Property(e => e.HasAccount).HasColumnName("hasAccount");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Nom).HasMaxLength(225);

                entity.Property(e => e.Prenom).HasMaxLength(225);

                entity.Property(e => e.Sexe).HasMaxLength(1);

                entity.Property(e => e.Telephone).HasMaxLength(30);

                entity.Property(e => e.UserCreator).HasMaxLength(256);

                entity.Property(e => e.UserDeletionFed).HasMaxLength(256);

                entity.Property(e => e.UserModification).HasMaxLength(256);

                entity.Property(e => e.UserValidatorFed).HasMaxLength(256);

                entity.Property(e => e.UserValidatorSec).HasMaxLength(256);

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.Usersassociation)
                    .HasForeignKey(d => d.ClubId)
                    .HasConstraintName("FK__USERSASSO__ClubI__2CF2ADDF");

                entity.HasOne(d => d.Niveau)
                    .WithMany(p => p.Usersassociation)
                    .HasForeignKey(d => d.NiveauId)
                    .HasConstraintName("FK__USERSASSO__Nivea__2DE6D218");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Usersassociation)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__USERSASSO__RoleI__2EDAF651");

                entity.HasOne(d => d.Ville)
                    .WithMany(p => p.Usersassociation)
                    .HasForeignKey(d => d.VilleId)
                    .HasConstraintName("FK__USERSASSO__Ville__2FCF1A8A");
            });

            modelBuilder.Entity<Usersfederation>(entity =>
            {
                entity.ToTable("USERSFEDERATION");

                entity.Property(e => e.Cin).HasMaxLength(125);

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.DateDeletionFed).HasColumnType("datetime");

                entity.Property(e => e.DateModification).HasColumnType("datetime");

                entity.Property(e => e.DateNaissance).HasColumnType("datetime");

                entity.Property(e => e.Diplome).HasMaxLength(225);

                entity.Property(e => e.Email).HasMaxLength(225);

                entity.Property(e => e.HasAccount).HasColumnName("hasAccount");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Nom).HasMaxLength(225);

                entity.Property(e => e.Prenom).HasMaxLength(225);

                entity.Property(e => e.Sexe).HasMaxLength(1);

                entity.Property(e => e.Telephone).HasMaxLength(30);

                entity.Property(e => e.UserCreator).HasMaxLength(256);

                entity.Property(e => e.UserDeletionFed).HasMaxLength(256);

                entity.Property(e => e.UserModification).HasMaxLength(256);

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.Usersfederation)
                    .HasForeignKey(d => d.ClubId)
                    .HasConstraintName("FK__USERSFEDE__ClubI__30C33EC3");

                entity.HasOne(d => d.Niveau)
                    .WithMany(p => p.Usersfederation)
                    .HasForeignKey(d => d.NiveauId)
                    .HasConstraintName("FK__USERSFEDE__Nivea__31B762FC");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Usersfederation)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__USERSFEDE__RoleI__32AB8735");

                entity.HasOne(d => d.Ville)
                    .WithMany(p => p.Usersfederation)
                    .HasForeignKey(d => d.VilleId)
                    .HasConstraintName("FK__USERSFEDE__Ville__339FAB6E");
            });

            modelBuilder.Entity<Ville>(entity =>
            {
                entity.ToTable("VILLE");

                entity.Property(e => e.DateModification).HasColumnType("datetime");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NomVille).HasMaxLength(125);

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Ville)
                    .HasForeignKey(d => d.RegionId)
                    .HasConstraintName("FK__VILLE__RegionId__3493CFA7");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
