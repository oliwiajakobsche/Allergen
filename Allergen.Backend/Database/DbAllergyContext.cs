using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using AllergenBackend.Models;
#nullable disable

namespace AllergenBackend.Database
{
    public partial class DbAllergyContext : DbContext
    {
        public DbAllergyContext()
        {
        }

        public DbAllergyContext(DbContextOptions<DbAllergyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Allergen> Allergens { get; set; }
        public virtual DbSet<AllergenCustom> AllergenCustoms { get; set; }
        public virtual DbSet<AllergenType> AllergenTypes { get; set; }
        public virtual DbSet<PollenCalendarArea> PollenCalendarAreas { get; set; }
        public virtual DbSet<PollenCallendar> PollenCallendars { get; set; }
        public virtual DbSet<Survey> Surveys { get; set; }
        public virtual DbSet<SurveyDetailSymptom> SurveyDetailSymptoms { get; set; }
        public virtual DbSet<SurveyDetailTaking> SurveyDetailTakings { get; set; }
        public virtual DbSet<Symptom> Symptoms { get; set; }
        public virtual DbSet<Taking> Takings { get; set; }
        public virtual DbSet<TakingCategory> TakingCategories { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserAllergen> UserAllergens { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Allergen>(entity =>
            {
                entity.ToTable("ALLERGEN");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Allergens)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ALLERGEN_ALLERGEN_TYPE");
            });

            modelBuilder.Entity<AllergenCustom>(entity =>
            {
                entity.ToTable("ALLERGEN_CUSTOM");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.AllergenCustoms)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ALLERGEN_CUSTOM_ALLERGEN_TYPE");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AllergenCustoms)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ALLERGEN_CUSTOM_2_USER");
            });

            modelBuilder.Entity<AllergenType>(entity =>
            {
                entity.ToTable("ALLERGEN_TYPE");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ShortName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PollenCalendarArea>(entity =>
            {
                entity.ToTable("POLLEN_CALENDAR_AREA");

                entity.Property(e => e.GoogleMapsLayer)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PollenCallendar>(entity =>
            {
                entity.ToTable("POLLEN_CALLENDAR");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.Allergen)
                    .WithMany(p => p.PollenCallendars)
                    .HasForeignKey(d => d.AllergenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_POLLEN_CALLENDAR_ALLERGEN");

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.PollenCallendars)
                    .HasForeignKey(d => d.AreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_POLLEN_CALLENDAR_POLLEN_CALENDAR_AREA");
            });

            modelBuilder.Entity<Survey>(entity =>
            {
                entity.ToTable("SURVEY");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Surveys)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SURVEY_USER");
            });

            modelBuilder.Entity<SurveyDetailSymptom>(entity =>
            {
                entity.ToTable("SURVEY_DETAIL_SYMPTOM");

                entity.HasOne(d => d.Survey)
                    .WithMany(p => p.SurveyDetailSymptoms)
                    .HasForeignKey(d => d.SurveyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SURVEY_DETAIL_SURVEY");

                entity.HasOne(d => d.Symptom)
                    .WithMany(p => p.SurveyDetailSymptoms)
                    .HasForeignKey(d => d.SymptomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SURVEY_DETAIL_SYMPTOM");
            });

            modelBuilder.Entity<SurveyDetailTaking>(entity =>
            {
                entity.ToTable("SURVEY_DETAIL_TAKING");

                entity.HasOne(d => d.Survey)
                    .WithMany(p => p.SurveyDetailTakings)
                    .HasForeignKey(d => d.SurveyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SURVEY_DETAIL_TAKING_2_SURVEY");

                entity.HasOne(d => d.Taking)
                    .WithMany(p => p.SurveyDetailTakings)
                    .HasForeignKey(d => d.TakingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SURVEY_DETAIL_TAKING_TAKING");
            });

            modelBuilder.Entity<Symptom>(entity =>
            {
                entity.ToTable("SYMPTOM");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Question)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Taking>(entity =>
            {
                entity.ToTable("TAKING");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Takings)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TAKING_TAKING_CATEGORY");
            });

            modelBuilder.Entity<TakingCategory>(entity =>
            {
                entity.ToTable("TAKING_CATEGORY");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USER");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserAllergen>(entity =>
            {
                entity.ToTable("USER_ALLERGEN");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.HasOne(d => d.Allergen)
                    .WithMany(p => p.UserAllergens)
                    .HasForeignKey(d => d.AllergenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_ALLERGEN_ALLERGEN");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserAllergens)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_ALLERGEN_USER");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
