using Microsoft.EntityFrameworkCore;
using UnicamProgettoParadigmi.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicamProgettoParadigmi.Models.Context
{
    public class MyDbContext : DbContext
    {
        public DbSet<Utente> Utenti { get; set; }
        public DbSet<ListaDistribuzione> ListeDistribuzione { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<ListaDistribuzioneEmail> ListaDistribuzioneEmail { get; set; }

        public MyDbContext() : base()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> config) : base(config)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
