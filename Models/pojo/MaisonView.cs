using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebGestImmobilier.Models.pojo
{
    public class MaisonView
    {

        [Key]
        public int Idbien { get; set; }
        [Display(Name = "Description du bien "), Required(ErrorMessage = "*"), MaxLength(1000, ErrorMessage = " La taille max est de 1000")]
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

        // les attributs propre au model maison 
        [Display(Name = "Nombre chambre "), Required(ErrorMessage = "*")]
        public int Nbre_chambres { get; set; }
        [Display(Name = "Nombre de douche "), Required(ErrorMessage = "*")]
        public int Nbre_douche { get; set; }
        [Display(Name = "Nombre de cuisine "), Required(ErrorMessage = "*")]

        public int Nbre_cuisine { get; set; }
        [Display(Name = "Nombre de Salle d'eau"), Required(ErrorMessage = "*")]
        public int NbreToilette { get; set; }
      //  public List<Appartement> Appartements { get; set; }


    }
}