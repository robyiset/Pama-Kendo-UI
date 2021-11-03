
using System;

namespace Kendo_UI_MVC.Models
{
    public class Barang
    {
        public int id_barang { get; set; }
        public string nama_barang { get; set; }
        public int harga { get; set; }
        public int stok { get; set; }
        public int id_supplier { get; set; }
        public DateTime? createdate { get; set; }
    }
}
