using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kendo_UI_MVC.Services
{
    public class SQLCommand
    {
        DBConnection db = new DBConnection();
        public List<barang> getbarang()
        {
            List<barang> brg = new List<barang>();
            MySqlCommand comm = db.comm("SELECT * FROM barang");
            db.conn.Open();
            MySqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                brg.Add(new barang
                {
                    id_barang = Convert.ToInt32(reader["id_barang"]),
                    nama_barang = reader["nama_barang"].ToString(),
                    harga = Convert.ToInt32(reader["harga"]),
                    stok = Convert.ToInt32(reader["stok"]),
                    id_supplier = Convert.ToInt32(reader["id_supplier"])
                });
                
            }
            db.conn.Close();
            return brg;
        }
    }

    public class barang
    {
        public int id_barang { get; set; }
        public string nama_barang { get; set; }
        public int harga { get; set; }
        public int stok { get; set; }
        public int id_supplier { get; set; }
    }
}
