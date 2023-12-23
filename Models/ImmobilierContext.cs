using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebImmobilier.Models
{
    public class ImmobilierContext : DbContext
    {
        public ImmobilierContext() : base("name=immobilier")
        { 
        }
        public DbSet<Appartement> appartement { get; set;}
        public DbSet<Bien> biens { get; set;}
        public DbSet<Maison> maisons { get; set;}
        public DbSet <Studio> studios { get; set;}
        public DbSet <Terrain> terrains { get; set;}
    }
}