using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel;

namespace Trainingfacility_Bitcube.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string Forename { get; set; } 
        public string Surname { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Date Of Birth")]
        public DateTime Dateofbirth { get; set; }
        public string Email { get; set; }
        [DisplayName("First Name")]
        public string Firstname { get; set; }
        [DisplayName("Full Name")]
        public string Fullname { get; set; }
        //Foreign key for degree
        public int DegreeId { get; set; }
        public Degree Degree { get; set; }
    }

    public class Degree 
    {
        [Key]
        public int DegreeId { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }
        //Foreign key for lecturer
        public int LecturerId { get; set; }
        public Lecturer Lecturer { get; set; }

        public ICollection<Student> Students { get; set; }
        public ICollection<Courses> Courses { get; set; }
        
    }

    public class Lecturer
    {
        [Key]
        [DisplayName("Lecturer ID")]
        public int LecturerId { get; set;}
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Date Of Birth")]
        public DateTime Dateofbirth { get; set; }
        [DisplayName("First Name")]
        public string Firstname { get; set; }
        [DisplayName("Full Name")]
        public string Fullname { get; set; }

        public ICollection<Degree> Degree { get; set; }
        public ICollection<Account> Account { get; set; }
    }

    public class Courses
    {
        [Key]
        public int CoursesId { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }
        //Foreign key for degree
        public int DegreeId { get; set; }
        public Degree Degree { get; set; }

    }

    public class Account
    {
        [Key]
        public int Id { get; set; }
        public string  Username { get; set; }
        public string Password { get; set; }
        //Foreign key for lecturer
        public int LecturerId { get; set; }
        public Lecturer Lecturer { get; set; }
    }

    public class ViewModel
    {
        public IEnumerable<Degree> Degree { get; set; }
        public IEnumerable<Student> Student { get; set; }
        public IEnumerable<Lecturer> Lecturer { get; set; }
        public IEnumerable<Courses> Courses { get; set; }
    }
}