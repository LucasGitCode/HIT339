using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ass1.Models;

namespace Ass1.Data
{
    public class Ass1Context : DbContext
    {
        public Ass1Context (DbContextOptions<Ass1Context> options)
            : base(options)
        {
        }

        public DbSet<Ass1.Models.Students> Student { get; set; }

        public DbSet<Ass1.Models.Lesson> Lesson { get; set; }

        public DbSet<Ass1.Models.Tutor> Tutor { get; set; }

        public DbSet<Ass1.Models.Instrument> Instrument { get; set; }

        public DbSet<Ass1.Models.DurationCost> DurationCost { get; set; }

        public DbSet<Ass1.Models.Invoice> Invoice { get; set; }
    }
}
