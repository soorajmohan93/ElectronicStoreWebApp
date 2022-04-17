using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ElectronicStoreModels.Models;

    public class ElectronicStoreContext : DbContext
    {
        public ElectronicStoreContext (DbContextOptions<ElectronicStoreContext> options)
            : base(options)
        {
        }

        public DbSet<ElectronicStoreModels.Models.ProductCategory> ProductCategory { get; set; }

        public DbSet<ElectronicStoreModels.Models.Product> Product { get; set; }

        public DbSet<ElectronicStoreModels.Models.Customer> Customer { get; set; }

        public DbSet<ElectronicStoreModels.Models.Cart> Cart { get; set; }
    }
