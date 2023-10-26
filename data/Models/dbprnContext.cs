using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace data.Models
{
    public partial class dbprnContext : DbContext
    {
        public dbprnContext()
        {
        }

        public dbprnContext(DbContextOptions<dbprnContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<QuestionTest> QuestionTests { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserCourse> UserCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=Admin;uid=sa;pwd=12345;database=db-prn;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("Question");

                entity.Property(e => e.A).IsRequired();

                entity.Property(e => e.B).IsRequired();

                entity.Property(e => e.C).IsRequired();

                entity.Property(e => e.CorrectAnswer)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.CourseId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.D).IsRequired();

                entity.Property(e => e.Title).IsRequired();

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.CourseId);
            });

            modelBuilder.Entity<QuestionTest>(entity =>
            {
                entity.HasKey(e => new { e.QuestionId, e.TestId });

                entity.ToTable("QuestionTest");

                entity.Property(e => e.UserId).HasMaxLength(450);

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.QuestionTests)
                    .HasForeignKey(d => d.QuestionId);

                entity.HasOne(d => d.Test)
                    .WithMany(p => p.QuestionTests)
                    .HasForeignKey(d => d.TestId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.QuestionTests)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("Task");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Title).IsRequired();

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.ToTable("Test");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.UserName).IsRequired();
            });

            modelBuilder.Entity<UserCourse>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.CourseId });

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.UserCourses)
                    .HasForeignKey(d => d.CourseId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserCourses)
                    .HasForeignKey(d => d.UserId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
