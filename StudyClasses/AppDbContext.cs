using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace StudyClasses
{
    public class AppDbContext : DbContext
    {
        // runtime constructor
        private readonly string _connectionString;

        public AppDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        // Parameterless constructor for design-time services
        public AppDbContext() : this("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StudyDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False")
        {
        }
        public DbSet<Teacher> Teachers { get; set; }
        //public DbSet<Student> Students { get; set; }
        //public DbSet<Course> Courses { get; set; }
        //public DbSet<Assignment> Assignments { get; set; }
        //public DbSet<Submission> Submissions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }
        

        // seed database with initial data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //    //seed students
            //    modelBuilder.Entity<Student>().HasData(
            //        new Student
            //        {
            //            Name = "Jenny",
            //            Surname = "Doe",
            //            PersonGender = Gender.Female,
            //            StudentIdNumber = "jd241001"
            //        },
            //        new Student
            //        {
            //            Name = "John",
            //            Surname = "Doe",
            //            PersonGender = Gender.Male,
            //            StudentIdNumber = "jd220510"
            //        },
            //        new Student
            //        {
            //            Name = "Anna",
            //            Surname = "Wayhat",
            //            PersonGender = Gender.Female,
            //            StudentIdNumber = "aw230909"
            //        },
            //        new Student
            //        {
            //            Name = "Peter",
            //            Surname = "Walker",
            //            PersonGender = Gender.Male,
            //            StudentIdNumber = "pw200101"
            //        },
            //        new Student
            //        {
            //            Name = "Sasha",
            //            Surname = "Wool",
            //            PersonGender = Gender.Other,
            //            StudentIdNumber = "sw210303"
            //        }
            //    );
            //seed teachers
            modelBuilder.Entity<Teacher>().HasData(
                new Teacher
                {
                    Id = -1,
                    Name = "Albert",
                    Surname = "Loop",
                    PersonGender = Gender.Male,
                    ContractDate = new DateOnly(2021, 10, 10)
                },
                new Teacher
                {
                    Id = -2,
                    Name = "Linda",
                    Surname = "Palinda",
                    PersonGender = Gender.Female,
                    ContractDate = new DateOnly(2015, 08, 08)
                },
                new Teacher
                {
                    Id = -3,
                    Name = "John",
                    Surname = "Doe",
                    PersonGender = Gender.Male,
                    ContractDate = new DateOnly(2019, 05, 06)
                },
                new Teacher
                {
                    Id = -4,
                    Name = "Jane",
                    Surname = "Done",
                    PersonGender = Gender.Other,
                    ContractDate = new DateOnly(2023, 03, 04)
                },
                new Teacher
                {
                    Id = -5,
                    Name = "Hanter",
                    Surname = "Banter",
                    PersonGender = Gender.Male,
                    ContractDate = new DateOnly(2020, 02, 01)
                }
            );
            //seed courses
            //seed assignments
            //seed submissions
        }
    }
}
