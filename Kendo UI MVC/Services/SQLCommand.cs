using Kendo_UI_MVC.Models;
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
            MySqlCommand comm = db.comm("SELECT * FROM barang order by createdate desc");
            db.conn.Open();
            MySqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                brg.Add(new barang
                {
                    id_barang = Convert.ToInt32(reader["id_barang"]),
                    nama_barang = reader["nama_barang"].ToString(),
                    harga = Convert.ToInt32(reader["harga"]),
                    stok = Convert.ToInt32(reader["stok"])
                });
                
            }
            db.conn.Close();
            return brg;
        }

        public void createbarang(barang brg)
        {
            InsUpdDelConQ($"insert into barang (nama_barang, harga, stok) values ('{brg.nama_barang}', {brg.harga}, {brg.stok})");
        }

        public void updatebarang(barang brg)
        {
            InsUpdDelConQ($"update barang set nama_barang = '{brg.nama_barang}', harga = {brg.harga}, stok = {brg.stok} where id_barang = {brg.id_barang}");
        }

        public void deletebarang(barang brg)
        {
            InsUpdDelConQ($"delete from barang where id_barang = {brg.id_barang}");
        }

        private void InsUpdDelConQ(string query)
        {
            MySqlCommand sql = db.comm(query);
            db.conn.Open();
            sql.ExecuteNonQuery();
            db.conn.Close();
        }
    }

    
}
