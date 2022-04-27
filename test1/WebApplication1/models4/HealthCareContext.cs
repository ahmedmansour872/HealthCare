using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebApplication1.models4
{
    public partial class HealthCareContext : DbContext
    {
        public HealthCareContext()
        {
        }

        public HealthCareContext(DbContextOptions<HealthCareContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<BedsNumber> BedsNumbers { get; set; }
        public virtual DbSet<Clinic> Clinics { get; set; }
        public virtual DbSet<DiseasHistory> DiseasHistories { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Drug> Drugs { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<PatientDoctor> PatientDoctors { get; set; }
        public virtual DbSet<Pharmacist> Pharmacists { get; set; }
        public virtual DbSet<Prescription> Prescriptions { get; set; }
        public virtual DbSet<Receptionest> Receptionests { get; set; }
        public virtual DbSet<ReservedPatient> ReservedPatients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-TO18DDI;Database=HealthCare;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.UserName).IsRequired();
            });

            modelBuilder.Entity<BedsNumber>(entity =>
            {
                entity.HasKey(e => e.BedId);

                entity.ToTable("BedsNumber");

                entity.Property(e => e.BedId)
                    .ValueGeneratedNever()
                    .HasColumnName("Bed_ID");

                entity.Property(e => e.NumberBed).HasColumnName("Number_Bed");
            });

            modelBuilder.Entity<Clinic>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<DiseasHistory>(entity =>
            {
                entity.ToTable("DiseasHistory");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClinicsId).HasColumnName("Clinics_ID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.PatientId).HasColumnName("Patient_ID");

                entity.HasOne(d => d.Clinics)
                    .WithMany(p => p.DiseasHistories)
                    .HasForeignKey(d => d.ClinicsId)
                    .HasConstraintName("FK_DiseasHistory_Clinics");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.DiseasHistories)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DiseasHistory_Patient");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.ToTable("Doctor");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Fname).IsRequired();

                entity.Property(e => e.Lname).IsRequired();

                entity.Property(e => e.Mname).IsRequired();

                entity.Property(e => e.Mname2).IsRequired();

                entity.Property(e => e.NationalId).HasColumnName("NationalID");

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.Rank).IsRequired();

                entity.Property(e => e.Specialization).IsRequired();

                entity.Property(e => e.Username).IsRequired();
            });

            modelBuilder.Entity<Drug>(entity =>
            {
                entity.ToTable("drugs");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AddDate).HasColumnType("datetime");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.PharmacistId).HasColumnName("Pharmacist_ID");

                entity.HasOne(d => d.Pharmacist)
                    .WithMany(p => p.Drugs)
                    .HasForeignKey(d => d.PharmacistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_drugs_Pharmacist");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("Patient");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Fname).IsRequired();

                entity.Property(e => e.Lname).IsRequired();

                entity.Property(e => e.Mname).IsRequired();

                entity.Property(e => e.Mname2).IsRequired();

                entity.Property(e => e.NationalId).HasColumnName("NationalID");

                entity.Property(e => e.PharmacistId).HasColumnName("Pharmacist_ID");

                entity.Property(e => e.Rank).IsRequired();

                entity.Property(e => e.ReceptionestId).HasColumnName("Receptionest_ID");

                entity.HasOne(d => d.Pharmacist)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.PharmacistId)
                    .HasConstraintName("FK_Patient_Pharmacist");

                entity.HasOne(d => d.Receptionest)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.ReceptionestId)
                    .HasConstraintName("FK_Patient_Receptionest");
            });

            modelBuilder.Entity<PatientDoctor>(entity =>
            {
                entity.ToTable("PatientDoctor");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Iddoctor).HasColumnName("IDDoctor");

                entity.Property(e => e.Idpatient).HasColumnName("IDPatient");

                entity.HasOne(d => d.IddoctorNavigation)
                    .WithMany(p => p.PatientDoctors)
                    .HasForeignKey(d => d.Iddoctor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientDoctor_Doctor");

                entity.HasOne(d => d.IdpatientNavigation)
                    .WithMany(p => p.PatientDoctors)
                    .HasForeignKey(d => d.Idpatient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientDoctor_Patient");
            });

            modelBuilder.Entity<Pharmacist>(entity =>
            {
                entity.ToTable("Pharmacist");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.NationalId).HasColumnName("NationalID");

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.Rank).IsRequired();

                entity.Property(e => e.Username).IsRequired();
            });

            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.ToTable("Prescription");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClinId).HasColumnName("Clin_ID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.DoctorId).HasColumnName("Doctor_ID");

                entity.Property(e => e.DoneDrug).HasColumnName("Done_Drug");

                entity.Property(e => e.DrugAmountPday).HasColumnName("DrugAmountPDay");

                entity.Property(e => e.DrugName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PatientId).HasColumnName("PatientID");

                entity.HasOne(d => d.Clin)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(d => d.ClinId)
                    .HasConstraintName("FK_Prescription_Clinics");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK_Prescription_Doctor");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK_Prescription_Patient");
            });

            modelBuilder.Entity<Receptionest>(entity =>
            {
                entity.ToTable("Receptionest");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Fname).IsUnicode(false);

                entity.Property(e => e.NationalId).HasColumnName("NationalID");

                entity.Property(e => e.Password).IsUnicode(false);
            });

            modelBuilder.Entity<ReservedPatient>(entity =>
            {
                entity.HasKey(e => e.ReservedId);

                entity.Property(e => e.ReservedId)
                    .ValueGeneratedNever()
                    .HasColumnName("Reserved_ID");

                entity.Property(e => e.BedNumber).HasColumnName("Bed_Number");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.DoctorId).HasColumnName("Doctor_ID");

                entity.Property(e => e.PatientId).HasColumnName("Patient_ID");

                entity.HasOne(d => d.BedNumberNavigation)
                    .WithMany(p => p.ReservedPatients)
                    .HasForeignKey(d => d.BedNumber)
                    .HasConstraintName("FK_ReservedPatients_BedsNumber");

                entity.HasOne(d => d.BedNumber1)
                    .WithMany(p => p.ReservedPatients)
                    .HasForeignKey(d => d.BedNumber)
                    .HasConstraintName("FK_ReservedPatients_Patient");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.ReservedPatients)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK_ReservedPatients_Doctor");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
