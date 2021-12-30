using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace EasyGift.Models
{
    public class Cadeau
    {
        public int Id { get; set; }
        [Display (Name="Cadeau"), Required]
        public string titre { get; set; }
        [Display (Name="Commentaire"), Required]
        public string commentaire { get; set; }

        [Display (Name="Marque"), Required]
        public string marque { get; set; }
        // Le prix devrait être en format int et non decimal
        [Display (Name="Prix"), Required]
        public double prix { get; set; }
        [Display (Name="Lien")]
        public string lien { get; set; }
        [Display (Name="Photo"), DisplayFormat(NullDisplayText = "none")]
        public string photo { get; set; }
         
        [Display (Name="Déjà acheté"), DisplayFormat(NullDisplayText = "0")]
        public string dejaAchete { get; set; }
        public int? listeId{get;set;}
        public Liste listeCadeau {get;set;}
    }
}