using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Locally.Models
{
    public partial class _2019SBDContext : DbContext
    {
        public _2019SBDContext()
        {
        }

        public _2019SBDContext(DbContextOptions<_2019SBDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<Photo> Photo { get; set; }
        public virtual DbSet<PhotosReview> PhotosReview { get; set; }
        public virtual DbSet<PhotosService> PhotosService { get; set; }
        public virtual DbSet<Profile> Profile { get; set; }
        public virtual DbSet<ProfileSkills> ProfileSkills { get; set; }
        public virtual DbSet<Review> Review { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<ServiceSkills> ServiceSkills { get; set; }
        public virtual DbSet<Skill> Skill { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data source=db-mssql;Initial Catalog=2019SBD;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "s18734");

            modelBuilder.Entity<Message>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.ServiceId).HasColumnName("Service_ID");

                entity.Property(e => e.UserFrom).HasColumnName("User_From");

                entity.Property(e => e.UserTo).HasColumnName("User_To");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Message)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Message_Service");

                entity.HasOne(d => d.UserFromNavigation)
                    .WithMany(p => p.MessageUserFromNavigation)
                    .HasForeignKey(d => d.UserFrom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Message_User");

                entity.HasOne(d => d.UserToNavigation)
                    .WithMany(p => p.MessageUserToNavigation)
                    .HasForeignKey(d => d.UserTo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Message_User_2");
            });

            modelBuilder.Entity<Photo>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(1);
            });

            modelBuilder.Entity<PhotosReview>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.PhotoId).HasColumnName("Photo_ID");

                entity.Property(e => e.ReviewId).HasColumnName("Review_ID");

                entity.HasOne(d => d.Photo)
                    .WithMany(p => p.PhotosReview)
                    .HasForeignKey(d => d.PhotoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PhotosReview_Photo");

                entity.HasOne(d => d.Review)
                    .WithMany(p => p.PhotosReview)
                    .HasForeignKey(d => d.ReviewId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PhotosReview_Review");
            });

            modelBuilder.Entity<PhotosService>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.PhotoId).HasColumnName("Photo_ID");

                entity.Property(e => e.ServiceId).HasColumnName("Service_ID");

                entity.HasOne(d => d.Photo)
                    .WithMany(p => p.PhotosService)
                    .HasForeignKey(d => d.PhotoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PhotosService_Photo");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.PhotosService)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PhotosService_Service");
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("Profile_pk");

                entity.Property(e => e.UserId)
                    .HasColumnName("User_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.PhotoId).HasColumnName("Photo_ID");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.HasOne(d => d.Photo)
                    .WithMany(p => p.Profile)
                    .HasForeignKey(d => d.PhotoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Profile_Photo");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Profile)
                    .HasForeignKey<Profile>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Profile_User");
            });

            modelBuilder.Entity<ProfileSkills>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.SkillId).HasColumnName("Skill_ID");

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.ProfileSkills)
                    .HasForeignKey(d => d.SkillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ProfileSkills_Skill");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ProfileSkills)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ProfileSkills_Profile");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Comment).HasMaxLength(1);

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Review)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Review_User");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.PreApprovedUserId).HasColumnName("PreApproved_User_ID");

                entity.Property(e => e.ReviewId).HasColumnName("Review_ID");

                entity.Property(e => e.UserContractor).HasColumnName("User_Contractor");

                entity.Property(e => e.UserOwner).HasColumnName("User_Owner");

                entity.HasOne(d => d.PreApprovedUser)
                    .WithMany(p => p.ServicePreApprovedUser)
                    .HasForeignKey(d => d.PreApprovedUserId)
                    .HasConstraintName("Service_User_2");

                entity.HasOne(d => d.Review)
                    .WithMany(p => p.Service)
                    .HasForeignKey(d => d.ReviewId)
                    .HasConstraintName("Service_Review");

                entity.HasOne(d => d.UserContractorNavigation)
                    .WithMany(p => p.ServiceUserContractorNavigation)
                    .HasForeignKey(d => d.UserContractor)
                    .HasConstraintName("Service_User");

                entity.HasOne(d => d.UserOwnerNavigation)
                    .WithMany(p => p.ServiceUserOwnerNavigation)
                    .HasForeignKey(d => d.UserOwner)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Service_User_1");
            });

            modelBuilder.Entity<ServiceSkills>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ServiceId).HasColumnName("Service_ID");

                entity.Property(e => e.SkillId).HasColumnName("Skill_ID");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.ServiceSkills)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ServiceSkills_Service");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.ServiceSkills)
                    .HasForeignKey(d => d.SkillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ServiceSkills_Skill");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(1);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(1);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
