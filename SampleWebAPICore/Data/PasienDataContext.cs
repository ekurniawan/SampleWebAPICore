using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleWebAPICore.Models;

namespace SampleWebAPICore.Data
{
    public class PasienDataContext : DbContext
    {
        public PasienDataContext(DbContextOptions<PasienDataContext> options) : base(options)
        {
        }

        public DbSet<Pasien> Pasien { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pasien>().ToTable("Pasien");
        }

    }
}
