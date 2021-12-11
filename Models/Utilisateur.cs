using System;
using System.ComponentModel.DataAnnotations;

namespace EasyGift.Models
{
    public class Utilisateur
    {
        public int id { get; set; }
        [Display (Name="Nom"), Required]
        public string nom { get; set; }   
        [Display (Name="Prénom"), Required]     
        public string prenom { get; set; }
        [Display (Name="Date de naissance"), DataType(DataType.Date)]
        public DateTime DateNaissance {get;set;}
        
        [Display (Name="Ville"), Required]
        public string ville { get; set; }
        [Display (Name="Code postal"), Required]
        public int cp { get; set; }

        [Display (Name="Nom d'utilisateur"), Required]
        public string nomUtilisateur { get; set; }
        [Display (Name="Mot de passe"), Required]
        public string mdp { get; set; }
        [Display (Name="Adresse mail")]
        public string mail { get; set; }
        [Display (Name="Numéro de téléphone"), StringLength(10, MinimumLength = 10, ErrorMessage = "Numéro de téléphone incorrect.")]
        
        public string numero { get; set; }
    }
}