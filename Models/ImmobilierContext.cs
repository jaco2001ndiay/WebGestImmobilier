using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Web;


namespace WebGestImmobilier.Models
{
    public class ImmobilierContext:DbContext
    {
        public ImmobilierContext() : base("WebGestImmobilier")
        { 
        }
        public DbSet<Appartement> Appartements { get; set;}
        //public DbSet<Bien> Biens { get; set;}
        public DbSet<Maison> Maisons { get; set;}
        public DbSet <Studio> Studios { get; set;}
        
        public DbSet<Utilisateurs> Utilisateurs { get; set; } 
       public DbSet <Terrain> Terrains { get; set;}
        
        public DbSet<Proprietaire> Proprietaires { get; set;  }

     //   public System.Data.Entity.DbSet<WebGestImmobilier.Models.pojo.MaisonView> MaisonViews { get; set; }

        ///protected override void OnModelCreating(DbModelBuilder modelBuilder)
        // {
        //    modelBuilder.Entity<Appartement>()
        //        .HasRequired(b => b.maisons)
        //       .WithMany(a => a.Appartements);
        // Si vous avez une clé étrangère
        // .HasForeignKey(b => b.maisons.idbien
        //  modelBuilder.Entity<Bien>().ToTable("biens");

        // Autres configurations et relations...

        // base.OnModelCreating(modelBuilder);
        // }
    }
}