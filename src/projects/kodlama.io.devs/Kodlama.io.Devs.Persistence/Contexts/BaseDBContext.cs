using Core.Security.Entities;
using Kodlama.io.Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Kodlama.io.Devs.Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<ProgrammingTechnology> ProgrammingTechnologies { get; set; }
        public DbSet<ProgrammingTechnologyType> ProgrammingTechnologyTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<SocialPlatform> SocialPlatforms { get; set; }
        public DbSet<UserProfileSocialPlatform> UserProfileSocialPlatforms { get; set; }

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguage>(a =>
            {
                a.ToTable("ProgrammingLanguages").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.HasMany(p => p.ProgrammingTechnologies);
            });

            modelBuilder.Entity<ProgrammingTechnologyType>(a =>
            {
                a.ToTable("ProgrammingTechnologyTypes").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.HasMany(p => p.ProgrammingTechnologies);
            });

            modelBuilder.Entity<ProgrammingTechnology>(a =>
            {
                a.ToTable("ProgrammingTechnologies").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.ProgrammingTechnologyTypeId).HasColumnName("ProgrammingTechnologyTypeId");
                a.Property(p => p.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
                a.Property(p => p.Name).HasColumnName("Name");
                a.HasOne(p => p.ProgrammingTechnologyType);
                a.HasOne(p => p.ProgrammingLanguage);
            });

            modelBuilder.Entity<User>(u =>
            {
                u.ToTable("Users").HasKey(u => u.Id);
                u.Property(u => u.Id).HasColumnName("Id");
                u.Property(u => u.Email).HasColumnName("Email");
                u.Property(u => u.PasswordSalt).HasColumnName("PasswordSalt");
                u.Property(u => u.PasswordHash).HasColumnName("PasswordHash");
                u.Property(u => u.Status).HasColumnName("Status");
                u.Property(u => u.AuthenticatorType).HasColumnName("AuthenticatorType");
                u.HasMany(c => c.UserOperationClaims);
                u.HasMany(c => c.RefreshTokens);
            });

            modelBuilder.Entity<OperationClaim>(o =>
            {
                o.ToTable("OperationClaims").HasKey(o => o.Id);
                o.Property(o => o.Id).HasColumnName("Id");
                o.Property(o => o.Name).HasColumnName("Name");
                o.HasMany(o => o.UserOperationClaims);
            });

            modelBuilder.Entity<UserOperationClaim>(u =>
            {
                u.ToTable("UserOperationClaims").HasKey(u => u.Id);
                u.Property(u => u.Id).HasColumnName("Id");
                u.Property(u => u.UserId).HasColumnName("UserId");
                u.Property(u => u.OperationClaimId).HasColumnName("OperationClaimId");
                u.HasOne(u => u.User);
                u.HasOne(u => u.OperationClaim);
            });

            modelBuilder.Entity<Gender>(g =>
            {
                g.ToTable("Genders").HasKey(k => k.Id);
                g.Property(p => p.Name).HasColumnName("Name");
                g.HasMany(up => up.UserProfiles);
            });

            modelBuilder.Entity<UserProfile>(u =>
            {
                u.ToTable("UserProfiles");
                u.Property(p => p.Id).HasColumnName("UserId");
                u.Property(p => p.GenderId).HasColumnName("GenderId");
                u.Property(u => u.FirstName).HasColumnName("FirstName");
                u.Property(u => u.LastName).HasColumnName("LastName");
                u.Property(u => u.DateOfBirth).HasColumnName("DateOfBirth");
                u.Property(u => u.CreatedAt).HasColumnName("CreatedAt");
                u.Property(u => u.LastActiveness).HasColumnName("LastActiveness");
                u.HasOne(g => g.Gender);
                u.HasMany(upsp => upsp.UserProfileSocialPlatforms);
            });

            modelBuilder.Entity<SocialPlatform>(s =>
            {
                s.ToTable("SocialPlatforms").HasKey(k => k.Id);
                s.Property(p => p.Name).HasColumnName("Name");
                s.Property(p => p.Domain).HasColumnName("Domain");
                s.HasMany(upsp => upsp.UserProfileSocialPlatforms);
            });

            modelBuilder.Entity<UserProfileSocialPlatform>(u =>
            {
                u.ToTable("UserProfileSocialPlatforms").HasKey(k => k.Id);
                u.Property(p => p.UserProfileId).HasColumnName("UserProfileId");
                u.Property(p => p.SocialPlatformId).HasColumnName("SocialPlatformId");
                u.Property(p => p.SocialProfileURI).HasColumnName("SocialProfileURI");
                u.HasOne(up => up.UserProfile);
                u.HasOne(sp => sp.SocialPlatform);
            });

            ProgrammingLanguage[] programmingLanguageSeedData = { new(1, "Rust"), new(2, "Go") };
            modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguageSeedData);

            ProgrammingTechnologyType[] programmingTechnologyTypeSeedData = { new(1, "Framework"), new(2, "Library") };
            modelBuilder.Entity<ProgrammingTechnologyType>().HasData(programmingTechnologyTypeSeedData);

            ProgrammingTechnology[] programmingTechnologySeedData = { new(1, 1, 1, "GGEZ"), new(2, 2, 1, "gin") };
            modelBuilder.Entity<ProgrammingTechnology>().HasData(programmingTechnologySeedData);

            OperationClaim[] operationClaimSeedData = { new(1, "Admin"), new(2, "User") };
            modelBuilder.Entity<OperationClaim>().HasData(operationClaimSeedData);

            Gender[] genderSeedData = { new(1, "Male"), new(2, "Female") };
            modelBuilder.Entity<Gender>().HasData(genderSeedData);
        }
    }
}
