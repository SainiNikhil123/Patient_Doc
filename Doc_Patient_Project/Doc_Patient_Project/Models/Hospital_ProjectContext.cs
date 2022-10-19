using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Doc_Patient_Project.Models
{
    public partial class Hospital_ProjectContext : IdentityDbContext<ApplicationUser>
    {
        public Hospital_ProjectContext()
        {
        }

        public Hospital_ProjectContext(DbContextOptions<Hospital_ProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AppointmentRegistration> AppointmentRegistrations { get; set; }
        public virtual DbSet<AppointmentTime> AppointmentTimes { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Designation> Designations { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<DoctorDesignation> DoctorDesignations { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<PatientComment> PatientComments { get; set; }
        public virtual DbSet<UserPatient> UserPatients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=con");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AppointmentRegistration>(entity =>
            {
                entity.ToTable("Appointment_Registration");

                entity.Property(e => e.Address).IsRequired();

                entity.Property(e => e.AppointmentDate).HasColumnType("date");

                entity.Property(e => e.PatientName).IsRequired();

                entity.Property(e => e.PhoneNumber).IsRequired();

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.AppointmentTimesNavigation)
                    .WithMany(p => p.AppointmentRegistrations)
                    .HasForeignKey(d => d.AppointmentTimes)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Appointme__Appoi__2B0A656D");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.AppointmentRegistrations)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Appointme__Depar__05D8E0BE");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.AppointmentRegistrations)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Appointme__Docto__160F4887");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AppointmentRegistrations)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Appointme__UserI__339FAB6E");
            });

            modelBuilder.Entity<AppointmentTime>(entity =>
            {
                entity.ToTable("AppointmentTime");

                entity.Property(e => e.Name).IsRequired();
            });
           
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("COMMENTS");

                entity.Property(e => e.Comments).IsRequired();
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.Department1)
                    .IsRequired()
                    .HasColumnName("Department");
            });

            modelBuilder.Entity<Designation>(entity =>
            {
                entity.ToTable("Designation");

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.Property(e => e.Docname)
                    .IsRequired()
                    .HasColumnName("DOCNAME");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Doctors__Departm__19DFD96B");
            });

            modelBuilder.Entity<DoctorDesignation>(entity =>
            {
                entity.HasKey(e => new { e.DoctorId, e.DesignationId })
                    .HasName("PK__DoctorDe__D66BD8B27111E2D9");

                entity.ToTable("DoctorDesignation");

                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.DoctorDesignations)
                    .HasForeignKey(d => d.DesignationId)
                    .HasConstraintName("FK__DoctorDes__Desig__282DF8C2");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.DoctorDesignations)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__DoctorDes__Docto__2739D489");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("Patient");

                entity.Property(e => e.Address).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.PhoneNumber).IsRequired();

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.AppointmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Patient__Appoint__4D5F7D71");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Patient__Departm__02084FDA");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.PatientDoctors)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Patient__DoctorI__17F790F9");

                entity.HasOne(d => d.ReferNavigation)
                    .WithMany(p => p.PatientReferNavigations)
                    .HasForeignKey(d => d.Refer)
                    .HasConstraintName("FK__Patient__Refer__4E53A1AA");
            });

            modelBuilder.Entity<PatientComment>(entity =>
            {
                entity.HasKey(e => new { e.PatientId, e.CommentId })
                    .HasName("PK__PatientC__2B358E9A35B86ABA");

                entity.ToTable("PatientComment");

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.PatientComments)
                    .HasForeignKey(d => d.CommentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PatientCo__Comme__3D2915A8");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.PatientComments)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PatientCo__Patie__3C34F16F");
            });

            modelBuilder.Entity<UserPatient>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.PatientId })
                    .HasName("PK__UserPati__6EF8207A9EBFFC73");

                entity.ToTable("UserPatient");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.UserPatients)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserPatie__Patie__37703C52");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserPatients)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserPatie__UserI__367C1819");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
