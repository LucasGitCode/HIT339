using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicApp.Models;

namespace MusicApp.Data
{
    public class MusicAppContext : DbContext
    {
        public MusicAppContext (DbContextOptions<MusicAppContext> options)
            : base(options)
        {
        }

        public DbSet<MusicApp.Models.Students> Students { get; set; }

        public DbSet<MusicApp.Models.Instruments> Instruments { get; set; }

        public DbSet<MusicApp.Models.Tutors> Tutors { get; set; }

        public DbSet<MusicApp.Models.LessonTY> LessonTY { get; set; }

        public DbSet<MusicApp.Models.LessonDT> LessonDT { get; set; }

        public DbSet<MusicApp.Models.Durations> Durations { get; set; }

        public DbSet<MusicApp.Models.Letters> Letters { get; set; }

        public DbSet<MusicApp.Models.Lessons> Lessons { get; set; }
    }
}
