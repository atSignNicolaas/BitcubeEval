using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Trainingfacility_Bitcube.Models;

    public class MvcDataContext : DbContext
    {
        public MvcDataContext (DbContextOptions<MvcDataContext> options)
            : base(options)
        {
        }

        public DbSet<Trainingfacility_Bitcube.Models.Student> Student { get; set; }

        public DbSet<Trainingfacility_Bitcube.Models.Degree> Degree { get; set; }

        public DbSet<Trainingfacility_Bitcube.Models.Lecturer> Lecturer { get; set; }

        public DbSet<Trainingfacility_Bitcube.Models.Courses> Courses { get; set; }
    }
