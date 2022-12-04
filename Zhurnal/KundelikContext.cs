using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Zhurnal
{
    public partial class KundelikContext : DbContext
    {
        public KundelikContext()
        {
        }

        public KundelikContext(DbContextOptions<KundelikContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Authorities> Authorities { get; set; }
        public virtual DbSet<Calendar> Calendar { get; set; }
        public virtual DbSet<Calendarpass> Calendarpass { get; set; }
        public virtual DbSet<People> People { get; set; }
        public virtual DbSet<Reference> Reference { get; set; }
        public virtual DbSet<Semesterassessment> Semesterassessment { get; set; }
        public virtual DbSet<Teachers> Teachers { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Kundelik;Username=postgres;Password=mercy07;Search Path=public");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Authorities>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("authorities");

                entity.Property(e => e.Authority)
                    .HasColumnName("authority")
                    .HasMaxLength(25);

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(15);

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Username)
                    .HasConstraintName("authorities_username_fkey");
            });

            modelBuilder.Entity<Calendar>(entity =>
            {
                entity.ToTable("calendar");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Day1)
                    .HasColumnName("day1")
                    .HasMaxLength(5);

                entity.Property(e => e.Day10)
                    .HasColumnName("day10")
                    .HasMaxLength(5);

                entity.Property(e => e.Day11)
                    .HasColumnName("day11")
                    .HasMaxLength(5);

                entity.Property(e => e.Day12)
                    .HasColumnName("day12")
                    .HasMaxLength(5);

                entity.Property(e => e.Day13)
                    .HasColumnName("day13")
                    .HasMaxLength(5);

                entity.Property(e => e.Day14)
                    .HasColumnName("day14")
                    .HasMaxLength(5);

                entity.Property(e => e.Day15)
                    .HasColumnName("day15")
                    .HasMaxLength(5);

                entity.Property(e => e.Day16)
                    .HasColumnName("day16")
                    .HasMaxLength(5);

                entity.Property(e => e.Day17)
                    .HasColumnName("day17")
                    .HasMaxLength(5);

                entity.Property(e => e.Day18)
                    .HasColumnName("day18")
                    .HasMaxLength(5);

                entity.Property(e => e.Day19)
                    .HasColumnName("day19")
                    .HasMaxLength(5);

                entity.Property(e => e.Day2)
                    .HasColumnName("day2")
                    .HasMaxLength(5);

                entity.Property(e => e.Day20)
                    .HasColumnName("day20")
                    .HasMaxLength(5);

                entity.Property(e => e.Day21)
                    .HasColumnName("day21")
                    .HasMaxLength(5);

                entity.Property(e => e.Day22)
                    .HasColumnName("day22")
                    .HasMaxLength(5);

                entity.Property(e => e.Day23)
                    .HasColumnName("day23")
                    .HasMaxLength(5);

                entity.Property(e => e.Day24)
                    .HasColumnName("day24")
                    .HasMaxLength(5);

                entity.Property(e => e.Day25)
                    .HasColumnName("day25")
                    .HasMaxLength(5);

                entity.Property(e => e.Day26)
                    .HasColumnName("day26")
                    .HasMaxLength(5);

                entity.Property(e => e.Day27)
                    .HasColumnName("day27")
                    .HasMaxLength(5);

                entity.Property(e => e.Day28)
                    .HasColumnName("day28")
                    .HasMaxLength(5);

                entity.Property(e => e.Day29)
                    .HasColumnName("day29")
                    .HasMaxLength(5);

                entity.Property(e => e.Day3)
                    .HasColumnName("day3")
                    .HasMaxLength(5);

                entity.Property(e => e.Day30)
                    .HasColumnName("day30")
                    .HasMaxLength(5);

                entity.Property(e => e.Day31)
                    .HasColumnName("day31")
                    .HasMaxLength(5);

                entity.Property(e => e.Day4)
                    .HasColumnName("day4")
                    .HasMaxLength(5);

                entity.Property(e => e.Day5)
                    .HasColumnName("day5")
                    .HasMaxLength(5);

                entity.Property(e => e.Day6)
                    .HasColumnName("day6")
                    .HasMaxLength(5);

                entity.Property(e => e.Day7)
                    .HasColumnName("day7")
                    .HasMaxLength(5);

                entity.Property(e => e.Day8)
                    .HasColumnName("day8")
                    .HasMaxLength(5);

                entity.Property(e => e.Day9)
                    .HasColumnName("day9")
                    .HasMaxLength(5);

                entity.Property(e => e.Days)
                    .IsRequired()
                    .HasColumnName("days")
                    .HasMaxLength(5);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(25);

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasColumnName("group_name")
                    .HasMaxLength(25);

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasColumnName("item_name")
                    .HasMaxLength(25);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(25);

                entity.Property(e => e.MiddleName)
                    .IsRequired()
                    .HasColumnName("middle_name")
                    .HasMaxLength(25);

                entity.Property(e => e.Month)
                    .IsRequired()
                    .HasColumnName("month")
                    .HasMaxLength(25);

                entity.Property(e => e.Result)
                    .HasColumnName("result")
                    .HasMaxLength(5);

                entity.Property(e => e.Student)
                    .IsRequired()
                    .HasColumnName("student")
                    .HasMaxLength(25);

                entity.Property(e => e.Teacher)
                    .IsRequired()
                    .HasColumnName("teacher")
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<Calendarpass>(entity =>
            {
                entity.ToTable("calendarpass");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Day1)
                    .HasColumnName("day1")
                    .HasMaxLength(5);

                entity.Property(e => e.Day10)
                    .HasColumnName("day10")
                    .HasMaxLength(5);

                entity.Property(e => e.Day11)
                    .HasColumnName("day11")
                    .HasMaxLength(5);

                entity.Property(e => e.Day12)
                    .HasColumnName("day12")
                    .HasMaxLength(5);

                entity.Property(e => e.Day13)
                    .HasColumnName("day13")
                    .HasMaxLength(5);

                entity.Property(e => e.Day14)
                    .HasColumnName("day14")
                    .HasMaxLength(5);

                entity.Property(e => e.Day15)
                    .HasColumnName("day15")
                    .HasMaxLength(5);

                entity.Property(e => e.Day16)
                    .HasColumnName("day16")
                    .HasMaxLength(5);

                entity.Property(e => e.Day17)
                    .HasColumnName("day17")
                    .HasMaxLength(5);

                entity.Property(e => e.Day18)
                    .HasColumnName("day18")
                    .HasMaxLength(5);

                entity.Property(e => e.Day19)
                    .HasColumnName("day19")
                    .HasMaxLength(5);

                entity.Property(e => e.Day2)
                    .HasColumnName("day2")
                    .HasMaxLength(5);

                entity.Property(e => e.Day20)
                    .HasColumnName("day20")
                    .HasMaxLength(5);

                entity.Property(e => e.Day21)
                    .HasColumnName("day21")
                    .HasMaxLength(5);

                entity.Property(e => e.Day22)
                    .HasColumnName("day22")
                    .HasMaxLength(5);

                entity.Property(e => e.Day23)
                    .HasColumnName("day23")
                    .HasMaxLength(5);

                entity.Property(e => e.Day24)
                    .HasColumnName("day24")
                    .HasMaxLength(5);

                entity.Property(e => e.Day25)
                    .HasColumnName("day25")
                    .HasMaxLength(5);

                entity.Property(e => e.Day26)
                    .HasColumnName("day26")
                    .HasMaxLength(5);

                entity.Property(e => e.Day27)
                    .HasColumnName("day27")
                    .HasMaxLength(5);

                entity.Property(e => e.Day28)
                    .HasColumnName("day28")
                    .HasMaxLength(5);

                entity.Property(e => e.Day29)
                    .HasColumnName("day29")
                    .HasMaxLength(5);

                entity.Property(e => e.Day3)
                    .HasColumnName("day3")
                    .HasMaxLength(5);

                entity.Property(e => e.Day30)
                    .HasColumnName("day30")
                    .HasMaxLength(5);

                entity.Property(e => e.Day31)
                    .HasColumnName("day31")
                    .HasMaxLength(5);

                entity.Property(e => e.Day4)
                    .HasColumnName("day4")
                    .HasMaxLength(5);

                entity.Property(e => e.Day5)
                    .HasColumnName("day5")
                    .HasMaxLength(5);

                entity.Property(e => e.Day6)
                    .HasColumnName("day6")
                    .HasMaxLength(5);

                entity.Property(e => e.Day7)
                    .HasColumnName("day7")
                    .HasMaxLength(5);

                entity.Property(e => e.Day8)
                    .HasColumnName("day8")
                    .HasMaxLength(5);

                entity.Property(e => e.Day9)
                    .HasColumnName("day9")
                    .HasMaxLength(5);

                entity.Property(e => e.Days)
                    .IsRequired()
                    .HasColumnName("days")
                    .HasMaxLength(5);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(25);

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasColumnName("group_name")
                    .HasMaxLength(25);

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasColumnName("item_name")
                    .HasMaxLength(25);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(25);

                entity.Property(e => e.MiddleName)
                    .IsRequired()
                    .HasColumnName("middle_name")
                    .HasMaxLength(25);

                entity.Property(e => e.Month)
                    .IsRequired()
                    .HasColumnName("month")
                    .HasMaxLength(25);

                entity.Property(e => e.Result)
                    .HasColumnName("result")
                    .HasMaxLength(5);

                entity.Property(e => e.Student)
                    .IsRequired()
                    .HasColumnName("student")
                    .HasMaxLength(25);

                entity.Property(e => e.Teacher)
                    .IsRequired()
                    .HasColumnName("teacher")
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<People>(entity =>
            {
                entity.ToTable("people");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(50);

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Birth)
                    .IsRequired()
                    .HasColumnName("birth")
                    .HasMaxLength(25);

                entity.Property(e => e.Certificates)
                    .HasColumnName("certificates")
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(25);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnName("gender")
                    .HasMaxLength(25);

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasColumnName("group_name")
                    .HasMaxLength(25);

                entity.Property(e => e.Hobby)
                    .HasColumnName("hobby")
                    .HasMaxLength(100);

                entity.Property(e => e.Iin)
                    .IsRequired()
                    .HasColumnName("iin")
                    .HasMaxLength(12);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(25);

                entity.Property(e => e.MiddleName)
                    .HasColumnName("middle_name")
                    .HasMaxLength(25);

                entity.Property(e => e.NameImg)
                    .IsRequired()
                    .HasColumnName("name_img")
                    .HasMaxLength(50);

                entity.Property(e => e.Nationality)
                    .IsRequired()
                    .HasColumnName("nationality")
                    .HasMaxLength(25);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(25);

                entity.Property(e => e.SocialStatus)
                    .HasColumnName("social_status")
                    .HasMaxLength(30);

                entity.Property(e => e.Teacher)
                    .IsRequired()
                    .HasColumnName("teacher")
                    .HasMaxLength(25);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(25);

                entity.Property(e => e.WorkPlace)
                    .HasColumnName("work_place")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Reference>(entity =>
            {
                entity.ToTable("reference");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(25);

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasColumnName("group_name")
                    .HasMaxLength(25);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(25);

                entity.Property(e => e.MiddleName)
                    .IsRequired()
                    .HasColumnName("middle_name")
                    .HasMaxLength(25);

                entity.Property(e => e.NameFile)
                    .IsRequired()
                    .HasColumnName("name_file")
                    .HasMaxLength(60);

                entity.Property(e => e.Student)
                    .IsRequired()
                    .HasColumnName("student")
                    .HasMaxLength(25);

                entity.Property(e => e.Teacher)
                    .IsRequired()
                    .HasColumnName("teacher")
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<Semesterassessment>(entity =>
            {
                entity.ToTable("semesterassessment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreditWork)
                    .HasColumnName("credit_work")
                    .HasMaxLength(5);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(25);

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasColumnName("group_name")
                    .HasMaxLength(25);

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasColumnName("item_name")
                    .HasMaxLength(25);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(25);

                entity.Property(e => e.MiddleName)
                    .IsRequired()
                    .HasColumnName("middle_name")
                    .HasMaxLength(25);

                entity.Property(e => e.MonthlyEstimate)
                    .HasColumnName("monthly_estimate")
                    .HasMaxLength(5);

                entity.Property(e => e.Semester)
                    .IsRequired()
                    .HasColumnName("semester")
                    .HasMaxLength(3);

                entity.Property(e => e.SemesterResult)
                    .HasColumnName("semester_result")
                    .HasMaxLength(5);

                entity.Property(e => e.Student)
                    .IsRequired()
                    .HasColumnName("student")
                    .HasMaxLength(25);

                entity.Property(e => e.Teacher)
                    .IsRequired()
                    .HasColumnName("teacher")
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<Teachers>(entity =>
            {
                entity.ToTable("teachers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Audience)
                    .IsRequired()
                    .HasColumnName("audience")
                    .HasMaxLength(25);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(25);

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasColumnName("item_name")
                    .HasMaxLength(25);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(25);

                entity.Property(e => e.MiddleName)
                    .IsRequired()
                    .HasColumnName("middle_name")
                    .HasMaxLength(25);

                entity.Property(e => e.Teacher)
                    .IsRequired()
                    .HasColumnName("teacher")
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("users_pkey");

                entity.ToTable("users");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(15);

                entity.Property(e => e.Enabled).HasColumnName("enabled");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
