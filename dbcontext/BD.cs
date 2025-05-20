using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EkzamenWPF.models;
using EkzamenWPF.Models;

namespace EkzamenWPF.dbcontext
{
    public class BD : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductMaterial> ProductMaterials { get; set; }
        public DbSet<MaterialHistory> MaterialHistory { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<MaterialType> MaterialTypes { get; set; }


        private const string ConnectionString = @"Data Source=DESKTOP-703LNUO;Database=Test4;Integrated Security=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
