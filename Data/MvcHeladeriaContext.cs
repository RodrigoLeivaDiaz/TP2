using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TP2.Models;

namespace TP2.Data
{
    public class MvcHeladeriaContext : DbContext
    {
        public MvcHeladeriaContext (DbContextOptions<MvcHeladeriaContext> options)
            : base(options)
        {
        }

        public DbSet<TP2.Models.Heladeria> Heladeria { get; set; } = default!;

        public DbSet<TP2.Models.Marca> Marca { get; set; } = default!;

        public DbSet<TP2.Models.Helado> Helado { get; set; } = default!;

        public DbSet<TP2.Models.Direccion> Direccion { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        modelBuilder.Entity<Direccion>()
        .HasOne(p => p.Heladeria)
        .WithOne(p => p.Direccion )
        .HasForeignKey(p => p.DireccionId);

        }
    }
}
