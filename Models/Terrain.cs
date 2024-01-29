using System;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebGestImmobilier.Models
{ 
    public class Terrain
    {
        [Key]
        public int Idterrain { get; set; }
        [Display(Name = "Description du terrain "), Required(ErrorMessage = "*"), MaxLength(1000, ErrorMessage = " La taille max est de 1000")]
        public string Description { get; set; }
        [Display(Name = "Prix du produit")]
        public int Prix { get; set; }
        [Display(Name = "Superficie du bien"), Required(ErrorMessage = "*")]
        public float? Superficie { get; set; }
        [Display(Name = "Localisation du bien "), Required(ErrorMessage = "*"), MaxLength(300, ErrorMessage = " La taille max est de 1000")]
        public string Localisation { get; set; }
        public int? IdProprio { get; set; }
        [ForeignKey("IdProprio")]
        public virtual Proprietaire Proprietaire { get; set; }





        [Display(Name = "type de terrain "), Required(ErrorMessage = "*")]
        public int typeterrain { get; set; }

     //   public virtual Bien bien { get; set; } 
    }
}
