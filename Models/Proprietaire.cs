using System;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebGestImmobilier.Models
{
    public class Proprietaire 
    {
        [Key]
        public int Idproprietarie { get; set; }
        // pour une chaine de caractere ne pas oublier de donner le maxlenght
        [Display(Name = "Addresse du proprietaire"), Required(ErrorMessage = "*"), MaxLength(100, ErrorMessage = "La taille maximale est de 100")]
        public string NomPropri { get; set; }
        public int? IdUsers { get; set; }

        public virtual Utilisateurs Utilisateures {get; set;}
        public virtual ICollection<Studio> Studio { get; set;  }
        public virtual ICollection<Maison> Maison { get; set; } 
        public virtual ICollection<Terrain> Terrains { get; set; } 
       // public  virtual ICollection<>
    }
}