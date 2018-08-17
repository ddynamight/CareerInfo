using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CareerInfo.Model
{
     public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
     {

          public ApplicationDbContext()
          {

          }

          public ApplicationDbContext(DbContextOptions options) : base(options)
          {
               
          }

          public static ApplicationDbContext Create()
          {
               return new ApplicationDbContext();
          }

          public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
          public virtual DbSet<Blog> Blogs { get; set; }
          public virtual DbSet<Course> Courses { get; set; }
          public virtual DbSet<News> News { get; set; }
          public virtual DbSet<Personality> Personalities { get; set; }
          public virtual DbSet<Profession> Professions { get; set; }
          public virtual DbSet<Request> Requests { get; set; }
          public virtual DbSet<Requirement> Requirements { get; set; }
          public virtual DbSet<Review> Reviews { get; set; }
          public virtual DbSet<School> Schools { get; set; }
          public virtual DbSet<SchoolCourse> SchoolCourses { get; set; }


          protected override void OnModelCreating(ModelBuilder modelBuilder)
          {
               // Single Property Configuration
               modelBuilder.Entity<ApplicationUser>().HasKey(e => e.Id);
               modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(e => e.UserId);
               modelBuilder.Entity<IdentityUserRole<string>>().HasKey(e => e.RoleId);
               modelBuilder.Entity<IdentityRole<string>>().HasKey(e => e.Id);
               modelBuilder.Entity<IdentityRoleClaim<string>>().HasKey(e => e.Id);
               modelBuilder.Entity<IdentityUserClaim<string>>().HasKey(e => e.Id);
               modelBuilder.Entity<IdentityUserToken<string>>().HasKey(e => e.UserId);
               modelBuilder.Entity<SchoolCourse>().HasKey(e => new { e.CourseId, e.SchoolId });


               // ToTable Property Configuration
               modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("AspNetUserLogin");
               modelBuilder.Entity<IdentityUserRole<string>>().ToTable("AspNetUserRole");
               modelBuilder.Entity<IdentityRole<string>>().ToTable("AspNetRole");
               modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("AspNetRoleClaim");
               modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("AspNetUserClaim");
               modelBuilder.Entity<IdentityUserToken<string>>().ToTable("AspNetUserToken");

               // One to Many Relationships Configurations
               modelBuilder.Entity<ApplicationUser>()
                    .HasMany(a => a.Reviews)
                    .WithOne(r => r.ApplicationUser)
                    .HasForeignKey(r => r.ApplicationUserId);

               modelBuilder.Entity<ApplicationUser>()
                    .HasMany(a => a.Requests)
                    .WithOne(r => r.ApplicationUser)
                    .HasForeignKey(r => r.ApplicationUserId);

               modelBuilder.Entity<Course>()
                    .HasMany(c => c.Reviews)
                    .WithOne(r => r.Course)
                    .HasForeignKey(r => r.CourseId);

               modelBuilder.Entity<Course>()
                    .HasMany(c => c.SchoolCourses)
                    .WithOne(sc => sc.Course)
                    .HasForeignKey(sc => sc.CourseId);

               modelBuilder.Entity<School>()
                    .HasMany(s => s.SchoolCourses)
                    .WithOne(sc => sc.School)
                    .HasForeignKey(sc => sc.SchoolId);

               // One to Zero or One Relationships Configurations
               modelBuilder.Entity<Course>()
                    .HasOne(c => c.Personality)
                    .WithOne(p => p.Course)
                    .HasForeignKey<Personality>(p => p.CourseId);

               modelBuilder.Entity<Course>()
                    .HasOne(c => c.Profession)
                    .WithOne(p => p.Course)
                    .HasForeignKey<Profession>(p => p.CourseId);

               modelBuilder.Entity<Course>()
                    .HasOne(c => c.Requirement)
                    .WithOne(r => r.Course)
                    .HasForeignKey<Requirement>(r => r.CourseId);


               // Other Configurations Here
               //modelBuilder.Ignore<CustomUserLogin>();

          }

          protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
          {
               optionsBuilder.UseSqlServer("Server=.;Database=CareerInfo;Trusted_Connection=True;MultipleActiveResultSets=true");
          }
     }
}
