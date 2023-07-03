using Microsoft.EntityFrameworkCore;
using PeaBuxTest.Data.Entities;
using System.Collections.Generic;

namespace PeaBuxTest.Data.Conf
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
    }



}
