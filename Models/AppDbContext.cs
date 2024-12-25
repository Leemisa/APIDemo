using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System;
namespace APIDemoStudent.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Student>().HasData(

                new Student
                {
                    StudentId = 1,
                    FirstName = "Leemisa",
                    LastName = "Moleko",
                    Email = "leemisa@gmail.com",
                    DateOfBirth = new DateTime(2003,3,3),
                    Gender = Gender.Male,
                    DepartmentId = 1,
                    Photopath = "Images/leemisa.png"
                });

            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    StudentId = 2,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john@gmail.com",
                    DateOfBirth = new DateTime(2003, 3, 3),
                    Gender = Gender.Male,
                    DepartmentId = 2,
                    Photopath = "images/john.png"

                });
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    StudentId = 3,
                    FirstName = "Jane",
                    LastName = "Doe",
                    Email = "jane@gmail.com",
                    DateOfBirth = new DateTime(2004, 4, 4),
                    Gender = Gender.Female,
                    DepartmentId = 2,
                    Photopath = "images/john.png"

                });
            modelBuilder.Entity<Student>().HasData(
               new Student
               {
                   StudentId = 4,
                   FirstName = "Natalie",
                   LastName = "Jons",
                   Email = "jons@gmail.com",
                   DateOfBirth = new DateTime(2005, 5, 5),
                   Gender = Gender.Female,
                   DepartmentId = 2,
                   Photopath = "images/john.png"

               });
            modelBuilder.Entity<Student>().HasData(
               new Student
               {
                   StudentId =5,
                   FirstName = "Mike",
                   LastName = "Rose",
                   Email = "mike@gmail.com",
                   DateOfBirth = new DateTime(2003, 3, 3),
                   Gender = Gender.Other,
                   DepartmentId = 2,
                   Photopath = "images/john.png"

               });

        }
    }

    
}
