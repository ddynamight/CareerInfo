using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CareerInfo.Model;

namespace CareerInfo.Model.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170707002141_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CareerInfo.Model.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Address");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Country");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("Firstname");

                    b.Property<string>("Lastname");

                    b.Property<string>("LocalGovtArea");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Middlename");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("Sex");

                    b.Property<string>("State");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("ApplicationUser");
                });

            modelBuilder.Entity("CareerInfo.Model.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Article");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<string>("Image");

                    b.Property<string>("Status");

                    b.Property<string>("Tagname");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("CareerInfo.Model.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Details");

                    b.Property<string>("Image");

                    b.Property<string>("Name");

                    b.Property<string>("Tagname");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("CareerInfo.Model.News", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Article");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<string>("Image");

                    b.Property<string>("Status");

                    b.Property<string>("Tagname");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("News");
                });

            modelBuilder.Entity("CareerInfo.Model.Personality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CourseId");

                    b.Property<string>("Details");

                    b.HasKey("Id");

                    b.HasIndex("CourseId")
                        .IsUnique();

                    b.ToTable("Personalities");
                });

            modelBuilder.Entity("CareerInfo.Model.Profession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CourseId");

                    b.Property<string>("Details");

                    b.HasKey("Id");

                    b.HasIndex("CourseId")
                        .IsUnique();

                    b.ToTable("Professions");
                });

            modelBuilder.Entity("CareerInfo.Model.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("Category");

                    b.Property<string>("Comment");

                    b.Property<DateTime>("Date");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("CareerInfo.Model.Requirement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Alevel");

                    b.Property<int>("CourseId");

                    b.Property<string>("Jamb");

                    b.Property<int>("JambScore");

                    b.Property<string>("Olevel");

                    b.Property<int>("PostUtme");

                    b.HasKey("Id");

                    b.HasIndex("CourseId")
                        .IsUnique();

                    b.ToTable("Requirements");
                });

            modelBuilder.Entity("CareerInfo.Model.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("Comment");

                    b.Property<int>("CourseId");

                    b.Property<DateTime>("Date");

                    b.Property<short>("Rating");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("CourseId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("CareerInfo.Model.School", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Description");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("State");

                    b.Property<string>("Tagname");

                    b.HasKey("Id");

                    b.ToTable("Schools");
                });

            modelBuilder.Entity("CareerInfo.Model.SchoolCourse", b =>
                {
                    b.Property<int>("CourseId");

                    b.Property<int>("SchoolId");

                    b.HasKey("CourseId", "SchoolId");

                    b.HasIndex("SchoolId");

                    b.ToTable("SchoolCourses");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole<string>", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedName");

                    b.HasKey("Id");

                    b.ToTable("AspNetRole");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityRole<string>");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("IdentityRoleId");

                    b.Property<string>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("IdentityRoleId");

                    b.ToTable("AspNetRoleClaim");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("AspNetUserClaim");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("ProviderKey");

                    b.HasKey("UserId");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("AspNetUserLogin");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("RoleId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("IdentityRoleId");

                    b.Property<string>("UserId");

                    b.HasKey("RoleId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("IdentityRoleId");

                    b.ToTable("AspNetUserRole");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId");

                    b.ToTable("AspNetUserToken");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole<string>");


                    b.ToTable("IdentityRole");

                    b.HasDiscriminator().HasValue("IdentityRole");
                });

            modelBuilder.Entity("CareerInfo.Model.Personality", b =>
                {
                    b.HasOne("CareerInfo.Model.Course", "Course")
                        .WithOne("Personality")
                        .HasForeignKey("CareerInfo.Model.Personality", "CourseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CareerInfo.Model.Profession", b =>
                {
                    b.HasOne("CareerInfo.Model.Course", "Course")
                        .WithOne("Profession")
                        .HasForeignKey("CareerInfo.Model.Profession", "CourseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CareerInfo.Model.Request", b =>
                {
                    b.HasOne("CareerInfo.Model.ApplicationUser", "ApplicationUser")
                        .WithMany("Requests")
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("CareerInfo.Model.Requirement", b =>
                {
                    b.HasOne("CareerInfo.Model.Course", "Course")
                        .WithOne("Requirement")
                        .HasForeignKey("CareerInfo.Model.Requirement", "CourseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CareerInfo.Model.Review", b =>
                {
                    b.HasOne("CareerInfo.Model.ApplicationUser", "ApplicationUser")
                        .WithMany("Reviews")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("CareerInfo.Model.Course", "Course")
                        .WithMany("Reviews")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CareerInfo.Model.SchoolCourse", b =>
                {
                    b.HasOne("CareerInfo.Model.Course", "Course")
                        .WithMany("SchoolCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CareerInfo.Model.School", "School")
                        .WithMany("SchoolCourses")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("IdentityRoleId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CareerInfo.Model.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CareerInfo.Model.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("CareerInfo.Model.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("IdentityRoleId");
                });
        }
    }
}
