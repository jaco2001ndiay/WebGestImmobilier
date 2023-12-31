//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebImmobilier.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bien
    {
        public int idbien { get; set; }
        public string description { get; set; }
        public Nullable<decimal> prix { get; set; }
        public Nullable<double> superficie { get; set; }
        public string localisation { get; set; }
    
        public virtual Appartement appartement { get; set; }
        public virtual Maison maison { get; set; }
        public virtual Studio studio { get; set; }
        public virtual Terrain terrain { get; set; }
    }
}
