using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EasyGift.Models;

    public class EasyGiftContext : DbContext
    {
        public EasyGiftContext (DbContextOptions<EasyGiftContext> options)
            : base(options)
        {
        }

        public DbSet<EasyGift.Models.Utilisateur> Utilisateur { get; set; }

        public DbSet<EasyGift.Models.Cadeau> Cadeau { get; set; }
    }
