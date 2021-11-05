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
            optionsBuilder.UseMySQL("Server={host};Port=3306;Database=penjualan;Uid={username};Pwd={password};");
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
        public List<Barang> FilterBarang(string[] opr, string[] val, string[] fld)
        {
            List<Barang> lst = new List<Barang>();
            if (opr.Count() > 0 && val.Count() > 0 && fld.Count() > 0 && opr.Count() == val.Count() && val.Count() == fld.Count())
            {
                int i = 0;
                foreach (var item in fld)
                {
                    if (i == 0)
                    {
                        switch (opr[i])
                        {
                            case "gte":
                                switch (item)
                                {
                                    case "harga":
                                        lst = context.barang.Where(p => p.harga >= Convert.ToInt32(val[i])).OrderByDescending(i => i.createdate).ToList();
                                        break;
                                    case "stok":
                                        lst = context.barang.Where(p => p.stok >= Convert.ToInt32(val[i])).OrderByDescending(i => i.createdate).ToList();
                                        break;
                                    default:
                                        // code block
                                        break;
                                }
                                break;
                            case "gt":
                                switch (item)
                                {
                                    case "harga":
                                        lst = context.barang.Where(p => p.harga > Convert.ToInt32(val[i])).OrderByDescending(i => i.createdate).ToList();
                                        break;
                                    case "stok":
                                        lst = context.barang.Where(p => p.stok > Convert.ToInt32(val[i])).OrderByDescending(i => i.createdate).ToList();
                                        break;
                                    default:
                                        // code block
                                        break;
                                }
                                break;
                            case "lte":
                                switch (item)
                                {
                                    case "harga":
                                        lst = context.barang.Where(p => p.harga <= Convert.ToInt32(val[i])).OrderByDescending(i => i.createdate).ToList();
                                        break;
                                    case "stok":
                                        lst = context.barang.Where(p => p.stok <= Convert.ToInt32(val[i])).OrderByDescending(i => i.createdate).ToList();
                                        break;
                                    default:
                                        // code block
                                        break;
                                }
                                break;
                            case "lt":
                                switch (item)
                                {
                                    case "harga":
                                        lst = context.barang.Where(p => p.harga < Convert.ToInt32(val[i])).OrderByDescending(i => i.createdate).ToList();
                                        break;
                                    case "stok":
                                        lst = context.barang.Where(p => p.stok < Convert.ToInt32(val[i])).OrderByDescending(i => i.createdate).ToList();
                                        break;
                                    default:
                                        // code block
                                        break;
                                }
                                break;
                            case "eq":
                                switch (item)
                                {
                                    case "nama_barang":
                                        lst = context.barang.Where(p => p.nama_barang.ToLower() == val[i].ToLower()).OrderByDescending(i => i.createdate).ToList();
                                        break;
                                    case "harga":
                                        lst = context.barang.Where(p => p.harga == Convert.ToInt32(val[i])).OrderByDescending(i => i.createdate).ToList();
                                        break;
                                    case "stok":
                                        lst = context.barang.Where(p => p.stok == Convert.ToInt32(val[i])).OrderByDescending(i => i.createdate).ToList();
                                        break;
                                    default:
                                        // code block
                                        break;
                                }
                                break;
                            case "contains":
                                switch (item)
                                {
                                    case "nama_barang":
                                        lst = context.barang.Where(p => p.nama_barang.ToLower().Contains(val[i].ToLower())).OrderByDescending(i => i.createdate).ToList();
                                        break;
                                    default:
                                        // code block
                                        break;
                                }
                                break;
                            case "neq":
                                switch (item)
                                {
                                    case "nama_barang":
                                        lst = context.barang.Where(p => p.nama_barang.ToLower() != val[i].ToLower()).OrderByDescending(i => i.createdate).ToList();
                                        break;
                                    default:
                                        // code block
                                        break;
                                }
                                break;
                            case "doesnotcontains":
                                switch (item)
                                {
                                    case "nama_barang":
                                        lst = context.barang.Where(p => !p.nama_barang.ToLower().Contains(val[i].ToLower())).OrderByDescending(i => i.createdate).ToList();
                                        break;
                                    default:
                                        // code block
                                        break;
                                }
                                break;
                            default:
                                // code block
                                break;
                        }
                    }
                    else
                    {
                        switch (opr[i])
                    {
                        case "gte":
                            switch (item)
                            {
                                case "harga":
                                    lst = lst.Where(p => p.harga >= Convert.ToInt32(val[i])).OrderByDescending(i => i.createdate).ToList();
                                    break;
                                case "stok":
                                    lst = lst.Where(p => p.stok >= Convert.ToInt32(val[i])).OrderByDescending(i => i.createdate).ToList();
                                    break;
                                default:
                                    // code block
                                    break;
                            }
                            break;
                        case "gt":
                            switch (item)
                            {
                                case "harga":
                                    lst = lst.Where(p => p.harga > Convert.ToInt32(val[i])).OrderByDescending(i => i.createdate).ToList();
                                    break;
                                case "stok":
                                    lst = lst.Where(p => p.stok > Convert.ToInt32(val[i])).OrderByDescending(i => i.createdate).ToList();
                                    break;
                                default:
                                    // code block
                                    break;
                            }
                            break;
                        case "lte":
                            switch (item)
                            {
                                case "harga":
                                    lst = lst.Where(p => p.harga <= Convert.ToInt32(val[i])).OrderByDescending(i => i.createdate).ToList();
                                    break;
                                case "stok":
                                    lst = lst.Where(p => p.stok <= Convert.ToInt32(val[i])).OrderByDescending(i => i.createdate).ToList();
                                    break;
                                default:
                                    // code block
                                    break;
                            }
                            break;
                        case "lt":
                            switch (item)
                            {
                                case "harga":
                                    lst = lst.Where(p => p.harga < Convert.ToInt32(val[i])).OrderByDescending(i => i.createdate).ToList();
                                    break;
                                case "stok":
                                    lst = lst.Where(p => p.stok < Convert.ToInt32(val[i])).OrderByDescending(i => i.createdate).ToList();
                                    break;
                                default:
                                    // code block
                                    break;
                            }
                            break;
                        case "eq":
                            switch (item)
                            {
                                case "nama_barang":
                                    lst = lst.Where(p => p.nama_barang.ToLower() == val[i].ToLower()).OrderByDescending(i => i.createdate).ToList();
                                    break;
                                case "harga":
                                    lst = lst.Where(p => p.harga == Convert.ToInt32(val[i])).OrderByDescending(i => i.createdate).ToList();
                                    break;
                                case "stok":
                                    lst = lst.Where(p => p.stok == Convert.ToInt32(val[i])).OrderByDescending(i => i.createdate).ToList();
                                    break;
                                default:
                                    // code block
                                    break;
                            }
                            break;
                        case "contains":
                            switch (item)
                            {
                                case "nama_barang":
                                    lst = lst.Where(p => p.nama_barang.ToLower().Contains(val[i].ToLower())).OrderByDescending(i => i.createdate).ToList();
                                    break;
                                default:
                                    // code block
                                    break;
                            }
                            break;
                        case "neq":
                            switch (item)
                            {
                                case "nama_barang":
                                    lst = lst.Where(p => p.nama_barang.ToLower() != val[i].ToLower()).OrderByDescending(i => i.createdate).ToList();
                                    break;
                                default:
                                    // code block
                                    break;
                            }
                            break;
                        case "doesnotcontains":
                            switch (item)
                            {
                                case "nama_barang":
                                    lst = lst.Where(p => !p.nama_barang.ToLower().Contains(val[i].ToLower())).OrderByDescending(i => i.createdate).ToList();
                                    break;
                                default:
                                    // code block
                                    break;
                            }
                            break;
                        default:
                            // code block
                            break;
                        }
                    }
                    i++;
                }
            }
            return lst;
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
