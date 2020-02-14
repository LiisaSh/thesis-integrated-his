using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DHISWEBAPI.Models
{
    public partial class ehealthContext : DbContext
    {
        public ehealthContext()
        {
        }

        public ehealthContext(DbContextOptions<ehealthContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<Doctor> Doctor { get; set; }
        public virtual DbSet<Hospital> Hospital { get; set; }
        public virtual DbSet<Medicine> Medicine { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<Pharmacy> Pharmacy { get; set; }
        public virtual DbSet<Prescription> Prescription { get; set; }

 //       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
 //       {
 //           if (!optionsBuilder.IsConfigured)
 //           {
 //To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
 //               optionsBuilder.UseSqlServer("Server=DESKTOP-ABTEQ9T;Initial Catalog=ehealth;Integrated Security=True");
 //           }
 //       }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Ipaddress).HasColumnName("IPAddress");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasIndex(e => e.HosptalDoctorId);

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.HosptalDoctorId).HasColumnName("HosptalDoctorID");

                entity.Property(e => e.Idnumber)
                    .IsRequired()
                    .HasColumnName("IDNumber")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nationality)
                    .IsRequired()
                    .HasColumnType("text");

                entity.HasOne(d => d.HosptalDoctor)
                    .WithMany(p => p.Doctor)
                    .HasForeignKey(d => d.HosptalDoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Hospital>(entity =>
            {
                entity.Property(e => e.HospitalId).HasColumnName("HospitalID");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("Created_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnName("Created_on");

                entity.Property(e => e.HospitalName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("Modified_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnName("Modified_on");
            });

            modelBuilder.Entity<Medicine>(entity =>
            {
                entity.HasIndex(e => e.MedicineCode)
                    .IsUnique();

                entity.HasIndex(e => e.PharmacyMedicId);

                entity.Property(e => e.MedicineId).HasColumnName("MedicineID");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("Created_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnName("Created_on");

                entity.Property(e => e.DiseaseCured)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.MedicineCode)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MedicineName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("Modified_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnName("Modified_on");

                entity.Property(e => e.PharmacyMedicId).HasColumnName("PharmacyMedicID");

                entity.HasOne(d => d.PharmacyMedic)
                    .WithMany(p => p.Medicine)
                    .HasForeignKey(d => d.PharmacyMedicId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasIndex(e => e.Idnumber)
                    .IsUnique();

                entity.Property(e => e.PatientId).HasColumnName("PatientID");

                entity.Property(e => e.CellphoneNumber)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("Created_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnName("Created_on");

                entity.Property(e => e.Dob)
                    .IsRequired()
                    .HasColumnName("DOB")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Idnumber)
                    .IsRequired()
                    .HasColumnName("IDNumber")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ImagePath).HasColumnType("text");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("Modified_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnName("Modified_on");

                entity.Property(e => e.Nationality)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.NextOfKin)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NextOfKinCell)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PostalAddress)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.ResidentialAddress)
                    .IsRequired()
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Pharmacy>(entity =>
            {
                entity.Property(e => e.PharmacyId).HasColumnName("PharmacyID");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("Created_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnName("Created_on");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("Modified_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnName("Modified_on");

                entity.Property(e => e.PharmancyName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.HasIndex(e => e.PrescriptionPatientId);

                entity.Property(e => e.PrescriptionId).HasColumnName("PrescriptionID");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("Created_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnName("Created_on");

                entity.Property(e => e.Diagonosis)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.DiagonosisBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("Modified_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnName("Modified_on");

                entity.Property(e => e.PrescriptionNotes)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.PrescriptionPatientId).HasColumnName("PrescriptionPatientID");

                entity.HasOne(d => d.PrescriptionPatient)
                    .WithMany(p => p.Prescription)
                    .HasForeignKey(d => d.PrescriptionPatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }
    }
}
