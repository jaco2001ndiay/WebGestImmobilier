using System;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
namespace WebGestImmobilier.Models
{
    public class Utilisateurs
    {
        [Key] 
        public int IdUsers { get; set; }

        [Display(Name = "Nom"), Required(ErrorMessage = "required *"), MaxLength(100, ErrorMessage = "La taille maximale  est de 100 caraecteres")]
        public string nomUsers { get; set; }
        [Display(Name = "Prenom"),Required(ErrorMessage ="required *"), MaxLength(200, ErrorMessage =" le nombre de caractere maximale autorise est de 200")]
        public string prenom { get; set; }
        [Display(Name ="Login"), Required(ErrorMessage ="required *"), MaxLength(100, ErrorMessage ="Le login ne peut depasser 100 caracteres")]
        public string login { get; set; }
        [EmailAddress]
        [Display(Name = "Adresse Email"), Required(ErrorMessage ="required *"), MaxLength(100,ErrorMessage ="l'addresse email ne peut depasser 100 caractere")]
        public string email { get; set; }
        [Display(Name ="Numeros de telephone"),Required(ErrorMessage ="required *"),MaxLength(12,ErrorMessage ="le numeros de telephone doit etre de 12 caracteres"),MinLength(2,ErrorMessage ="Le numeros de telephone doit etre de 12 caracteres ")]
        // protected string addPhoneNumber { get; set; } 
        public string addPhoneNumber2 { get; set; }

        public virtual List<Proprietaire> Proprietaires { get; set; }

       
       // public virtual Proprietaire Proprietaire { get; set; }

    }

} 