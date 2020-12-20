using Microsoft.EntityFrameworkCore;
using Students_Announcement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Students_Announcements.Models
{
    public class AnnouncementContext : DbContext
    {

        public AnnouncementContext(DbContextOptions<AnnouncementContext> options) : base(options)
        {
        }

        public DbSet<Announcement> Announcements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Announcement>().HasKey(c => c.id); //klucz
            modelBuilder.Entity<Announcement>().ToTable("announcement");
        }
    }

}
