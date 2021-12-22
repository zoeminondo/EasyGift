using System;
using System.IO;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace EasyGift.Views
{
    public class CadeauPhotoView
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
        [Display (Name="Photo"), DisplayFormat(NullDisplayText = null)]
        public IFormFile photoTel { get; set; }
         
        [Display (Name="Déjà acheté"), DisplayFormat(NullDisplayText = null)]
        public string dejaAchete { get; set; }
    }
}