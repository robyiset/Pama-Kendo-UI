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
        private Context cxt = new Context();

        [HttpGet]
        public JsonResult get(string[] opr, string[] val, string[] fld)
        {
            if (opr.Length == 0 && val.Length == 0  && fld.Length == 0 )
            {
                return Json(cxt.GetBarang());
            }
            else
            {
                return Json(cxt.FilterBarang(opr, val, fld));
            }
        }

        [HttpGet]
        public JsonResult create(int id_barang, string nama_barang, int harga, int stok)
        {
            Barang brg = new Barang { id_barang = id_barang, nama_barang = nama_barang, harga = harga, stok = stok };
            try
            {
                cxt.CreateBarang(brg);
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
            Barang brg = new Barang { id_barang = id_barang, nama_barang = nama_barang, harga = harga, stok = stok };
            try
            {
                cxt.UpdateBarang(brg);
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
                cxt.DeleteBarang(id_barang);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            return Json("ok");
        }
    }
}
