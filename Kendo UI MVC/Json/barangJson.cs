using Kendo_UI_MVC.Models;
using Kendo_UI_MVC.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kendo_UI_MVC.Json
{
    public class barangJson : Controller
    {
        SQLCommand sql = new SQLCommand();
        [HttpGet]
        public JsonResult get()
        {
            return Json(sql.getbarang());
        }

        [HttpGet]
        public JsonResult create(int id_barang, string nama_barang, int harga, int stok)
        {
            barang brg = new barang { id_barang = id_barang, nama_barang = nama_barang, harga = harga, stok = stok };
            try
            {
                sql.createbarang(brg);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            return Json(brg);
        }
        [HttpGet]
        public JsonResult update(int id_barang, string nama_barang, int harga, int stok)
        {
            barang brg = new barang { id_barang = id_barang, nama_barang = nama_barang, harga = harga, stok = stok };
            string e = string.Empty;
            try
            {
                sql.updatebarang(brg);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            return Json(brg);
        }
        [HttpGet]
        public JsonResult delete(int id_barang)
        {
            try
            {
                sql.deletebarang(new barang { id_barang = id_barang });
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            return Json("ok");
        }
    }
}
