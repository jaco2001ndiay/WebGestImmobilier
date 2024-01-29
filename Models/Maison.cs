using System;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebGestImmobilier.Models
{
       public class Maison
    {
        [Key]
        public int Idmaison { get; set; }
        [Display(Name = "Description de la maison "), Required(ErrorMessage = "*"), MaxLength(1000, ErrorMessage = " La taille max est de 1000")]
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




        [Display(Name = "Nombre chambre "), Required(ErrorMessage ="*")]
        public int Nbre_chambres { get; set; }
        [Display(Name = "Nombre de douche "), Required(ErrorMessage ="*")]
        public int Nbre_douche { get; set; }
        [Display(Name = "Nombre de cuisine "), Required(ErrorMessage = "*")]

        public int Nbre_cuisine { get; set; }
        [Display(Name = "Nombre de Salle d'eau"), Required(ErrorMessage = "*")]
        public int NbreToilette { get; set;  }
        public virtual List<Appartement> Appartements { get; set; }

       

        ///on indique que dans une maison se trouve plusieurs apparements 

        //  public virtual Bien bien { get; set; }
    }
}
