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
        
        [Display (Name="Prix"), Required]
        public decimal prix { get; set; }
        [Display (Name="Lien")]
        public string lien { get; set; }
        [Display (Name="Photo"), DisplayFormat(NullDisplayText = "none")]
        public string photo { get; set; }
         
        [Display (Name="Déjà acheté"), DisplayFormat(NullDisplayText = "0")]
        public string dejaAchete { get; set; }
    }
}