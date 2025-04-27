using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace informatic_asp_mvc.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<ClassRoom> ClassRooms { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Ad> Ads { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Stu_Sub> Stu_Sub { get; set; }
        public DbSet<ObjectionOrder> ObjectionOrders { get; set; }
        public DbSet<RepracOrder> RepracOrders { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<StuPro> StuPros { get; set; }

      
    }
}
