using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Studentes.Evaluation.Domain.OigaContext.Entities;
using System.Linq;

namespace Studentes.Evaluation.Infra.SqlContext
{
    public class Oiga_DBContext : DbContext
    {
        private readonly IConfiguration _config;
        public Oiga_DBContext()
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }
        public Oiga_DBContext(DbContextOptions<Oiga_DBContext> options,
            IConfiguration config)
          : base(options)
        {
            _config = config;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
            }
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseStudent> CourseStudents { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Studentes.Evaluation.Domain.OigaContext.Entities.Evaluation> Evaluations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Oiga_DBContext).Assembly);
            //modelBuilder.Ignore<Notifiable>();
            //modelBuilder.Ignore<Notification>();
            EntityMapping(modelBuilder);
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Oiga_DBContext).Assembly);
        }

        private void EntityMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Courses").HasKey(e => e.Id);

                entity.Property(e => e.name)
                    .HasColumnName("name");

                entity.Property(e => e.creation_date)
                    .HasColumnName("creation_date");

                entity.Property(e => e.active)
                    .HasColumnName("active");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Students").HasKey(e => e.Id);

                entity.Property(e => e.name)
                    .HasColumnName("name");

                entity.Property(e => e.last_name)
                    .HasColumnName("last_name");

                entity.Property(e => e.creation_date)
                 .HasColumnName("creation_date");

                entity.Property(e => e.active)
                    .HasColumnName("active");
            });

            modelBuilder.Entity<CourseStudent>(entity =>
            {
                entity.ToTable("CourseStudents").HasKey(e => e.Id);

                entity.HasOne(p => p.course)
                .WithMany(c => c.CourseStudents)
                .HasForeignKey(fk => fk.course_id);

                entity.HasOne(p => p.student)
                    .WithMany(c => c.CourseStudents)
                    .HasForeignKey(fk => fk.student_id);

                entity.Property(e => e.grade)
                 .HasColumnName("grade");
            });



            modelBuilder.Entity<Studentes.Evaluation.Domain.OigaContext.Entities.Evaluation>(entity =>
            {
                entity.ToTable("Evaluations").HasKey(e => e.Id);

                entity.HasOne(p => p.courseStudent)
                    .WithMany(c => c.Evaluations)
                    .HasForeignKey(fk => fk.course_student_id);

                entity.Property(e => e.stars)
                    .HasColumnName("stars");
                entity.Property(e => e.description)
                    .HasColumnName("description");
                entity.Property(e => e.creation_date)
                    .HasColumnName("creation_date");
            });
        }

    }
}
