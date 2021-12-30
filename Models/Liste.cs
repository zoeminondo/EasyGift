using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace EasyGift.Models
{
    public class Liste
    {
        public int Id { get; set; }
        [Display (Name="Liste"), Required]
        public string nomListe { get; set; }
        [Display (Name="Propriétaire")]
        public Utilisateur createur{get;set;}     
        public int? createurId{get;set;}
        public ICollection<Cadeau> cad {get;set;}    
    }
}