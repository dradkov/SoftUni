namespace P01_HospitalDatabase.Data
{
    using Microsoft.EntityFrameworkCore;
    using P01_HospitalDatabase.Data.Models;


    public class HospitalContext : DbContext
    {
        public HospitalContext()
        {

        }

        public HospitalContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Diagnose> Diagnoses { get; set; }

        public DbSet<Medicament> Medicaments { get; set; }

        public DbSet<Visitation> Visitations { get; set; }

        public DbSet<PatientMedicament> PatientMedicaments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectonString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Patient>(p =>
            {
                p.HasKey(pt => pt.PatientId);
                p.Property(pr => pr.FirstName).HasMaxLength(50).IsUnicode(true);
                p.Property(pr => pr.LastName).HasMaxLength(50).IsUnicode(true);
                p.Property(pr => pr.Address).HasMaxLength(250).IsUnicode(true);
                p.Property(pr => pr.Email).HasMaxLength(80).IsUnicode(false);

            });

            builder.Entity<Patient>()
                .HasMany(pt => pt.Prescriptions)
                .WithOne(pt => pt.Patient)
                .HasForeignKey(pt => pt.PatientId);

            builder.Entity<Patient>()
                .HasMany(p => p.Diagnoses)
                .WithOne(p => p.Patient)
                .HasForeignKey(p => p.PatientId);

            builder.Entity<Patient>()
                .HasMany(p => p.Visitations)
                .WithOne(p => p.Patient)
                .HasForeignKey(p => p.PatientId);


            builder.Entity<Visitation>(v =>
            {
                v.HasKey(vis => vis.VisitationId);
                v.Property(pr => pr.Comments).HasMaxLength(250).IsUnicode(true);

            });



            builder.Entity<Diagnose>(d =>
            {
                d.HasKey(dia => dia.DiagnoseId);
                d.Property(pr => pr.Name).HasMaxLength(50).IsUnicode(true);
                d.Property(pr => pr.Comments).HasMaxLength(250).IsUnicode(true);

            });

            builder.Entity<Medicament>(m =>
            {
                m.HasKey(med => med.MedicamentId);
                m.Property(med => med.Name).HasMaxLength(50).IsUnicode(true);

            });

            builder.Entity<Medicament>()
                .HasMany(m => m.Prescriptions)
                .WithOne(m => m.Medicament)
                .HasForeignKey(m => m.MedicamentId);

            builder.Entity<PatientMedicament>()
                .HasKey(k => new
                {
                    k.MedicamentId,
                    k.PatientId
                });

            builder.Entity<PatientMedicament>()
                .HasOne(p => p.Patient)
                .WithMany(c => c.Prescriptions)
                .HasForeignKey(c => c.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<PatientMedicament>()
                .HasOne(m => m.Medicament)
                .WithMany(p => p.Prescriptions)
                .HasForeignKey(m => m.MedicamentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Doctor>(d =>
            {
                d.HasKey(doc => doc.DoctorId);
                d.Property(doc => doc.Name).HasMaxLength(100).IsUnicode(true);
                d.Property(doc => doc.Specialty).HasMaxLength(100).IsUnicode(true);

            });

            builder.Entity<Doctor>()
                .HasMany(doc => doc.Visitations)
                .WithOne(d => d.Doctor)
                .HasForeignKey(d => d.DoctorId);


        }

    }
}
