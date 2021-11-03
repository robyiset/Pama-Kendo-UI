using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;
using Kendo_UI_MVC.Models;
using System.Text;

namespace Kendo_UI_MVC.Services
{
    public class EntityFramework : DbContext
    {
        public DbSet<Barang> barang { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=192.168.1.12;Port=3306;Database=penjualan;Uid=root;Pwd=r0131_g4nt3nG;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Barang>(entity =>
            {
                entity.HasKey(e => e.id_barang);
                entity.Property(e => e.nama_barang).IsRequired();
                entity.Property(e => e.harga).IsRequired();
                entity.Property(e => e.stok).IsRequired();
            });
        }
    }


    public class Context
    {
        private EntityFramework context = new EntityFramework();
        public List<Barang> GetBarang()
        {
            return context.barang.OrderByDescending(i => i.createdate).ToList();
        }
        public void CreateBarang(Barang brg)
        {
            context.Database.EnsureCreated();
            context.barang.Add(brg);
            context.SaveChanges();
        }
        public void UpdateBarang(Barang brg)
        {
            var row = context.barang.FirstOrDefault(i => i.id_barang == brg.id_barang);
            if (row != null)
            {
                row.nama_barang = brg.nama_barang;
                row.harga = brg.harga;
                row.stok = brg.stok;
                context.SaveChanges();
            }
        }
        public void DeleteBarang(int id)
        {
            context.Remove(new Barang { id_barang = id });
            context.SaveChanges();
        }
    }
}
