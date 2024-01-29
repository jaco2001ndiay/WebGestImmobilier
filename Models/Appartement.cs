using System;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebGestImmobilier.Models;
namespace WebGestImmobilier.Models
{ 
    public class Appartement
    {
        [Key]
        public int idAppartement { get; set; }
        //   public int idbien { get; set; }  
        [Display(Name = "libelle de L'appartement  "), Required(ErrorMessage = "*"), MaxLength(100)]
        public String lib_Appartement { get; set;}

        [Display(Name = "Nombre de Salle"), Required(ErrorMessage = "*")]
        public int nbre_Salle{ get; set;  } 
        public int Idmaison { get; set; }
        public virtual Maison maisons { get; set; }
        /// la propriete maison représente la composition faible 
        /// elle indique qu'un appartement est associe a une maison mais il n'ya pas de clef etrangere


        //   public virtual Bien bien { get; set; }
    }
}
