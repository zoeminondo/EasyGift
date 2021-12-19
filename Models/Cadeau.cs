using System;
using System.ComponentModel.DataAnnotations;

namespace EasyGift.Models
{
    public class Cadeau
    {
        public int Id { get; set; }
        [Display (Name="Cadeau"), Required]
        public string cadeau { get; set; }
        [Display (Name="Commentaire"), Required]
        public string commentaire { get; set; }

        [Display (Name="Marque"), Required]
        public string marque { get; set; }
        
        [Display (Name="Prix"), Required]
        public decimal prix { get; set; }
        [Display (Name="Lien")]
        public decimal lien { get; set; }
        [Display (Name="Photo"), Required]
        public string photo { get; set; } // pour le moment on enregistre le nom de l'image
         [Display (Name="Déjà acheté"), Required]
        public string dejaAchete { get; set; }
    }
}