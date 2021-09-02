using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SehirlerAPI.IServices;
using SehirlerAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Diagnostics;

namespace SehirlerAPI.Services
{
    public class SehirlerService : ISehirlerService

    {
        SehirlerContext dbcontext;
        private readonly IConfiguration _configuration;
        public SehirlerService(SehirlerContext _db, IConfiguration configuration)
        {
            dbcontext = _db;
            _configuration = configuration;
        }

        public Sehir AddSehir(Sehir sehir)
        {
            if (sehir != null)
            {
                var temp = dbcontext.Sehirs.FirstOrDefault(x => x.Plaka == sehir.Plaka);
                if (temp == null)
                {
                    dbcontext.Sehirs.Add(sehir);
                    dbcontext.SaveChanges();
                    return sehir;
                }
            }
            return null;
        }
        /*
        public Ilceler AddIlce(Ilceler ilce)
        {
            if(ilce.Plaka == 0)
            {
                dbcontext.Ilcelers.Add(ilce);
                dbcontext.SaveChanges();
                return ilce;

            }
            else
            {
                return null;
            }
        }
        */
        
        public Ilceler AddIlce(Ilceler ilce)
        {
            if (ilce != null)
            {
                    dbcontext.Ilcelers.Add(ilce);
                    dbcontext.SaveChanges();
                    return ilce;
            }
            return null;
        }
        public IEnumerable<Sehir> GetSehir()
        {
            var sehir = dbcontext.Sehirs.ToList();
            return sehir;
        }
        public List<SehirlerViewModel> GetSehirIlce()
        {
            var merged = (from a in dbcontext.Sehirs
                          join b in dbcontext.Ilcelers
                          on a.Plaka equals b.Plaka
                          select new SehirlerViewModel
                          {
                              plaka = a.Plaka,
                              sehir = a.Isim,
                              ilce = b.ilce
                          }).ToList();
            return merged;
        }

        public IEnumerable<Ilceler> GetIlceler()
        {
            var ilceler = dbcontext.Ilcelers.ToList();
            return ilceler;
        }

        public Sehir DeleteSehir(int plaka)
        {
            var sehir = dbcontext.Sehirs.FirstOrDefault(x => x.Plaka == plaka);
            if(sehir != null)
            {
                dbcontext.Entry(sehir).State = EntityState.Deleted;
                dbcontext.SaveChanges();
                return sehir;
            }
            else
            {
                return null;
            }

        }
        public Ilceler DeleteIlce(int ID)
        {
            var ilce = dbcontext.Ilcelers.FirstOrDefault(x => x.id == ID);
            dbcontext.Entry(ilce).State = EntityState.Deleted;
            dbcontext.SaveChanges();
            return ilce;
        }

        public Sehir GetSehirByPlaka(int Plaka)
        {
            var sehir = dbcontext.Sehirs.FirstOrDefault(x => x.Plaka == Plaka);
            return sehir;
        }
        public Ilceler GetIlceById(int ID)
        {
            var ilce = dbcontext.Ilcelers.FirstOrDefault(x => x.id == ID);
            return ilce;
        }
        public List<Ilceler> GetIlcelerByPlaka(int Plaka)
        {
            var ilce = dbcontext.Ilcelers.Where(x => x.Plaka == Plaka).ToList();
            return ilce;
        }

        public Sehir UpdateSehir(Sehir sehir)
        {
            dbcontext.Entry(sehir).State = EntityState.Modified;
            dbcontext.SaveChanges();
            return sehir;
        }
        
        public Ilceler UpdateIlceler(Ilceler ilce)
        {
            dbcontext.Entry(ilce.ilce).State = EntityState.Modified;
            dbcontext.Entry(ilce.Plaka).State = EntityState.Modified;
            dbcontext.SaveChanges();
            return ilce;
        }

      
        public List<Sehir> LoadFromDB()
        {
            List<Sehir> Sehirlere = new List<Sehir>();
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            SqlCommand cmd = new SqlCommand("select * from sehir", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);


            for (int i = 0; i < dt.Rows.Count; i++)
            {

                Sehir obj = new Sehir();
                obj.Plaka = Convert.ToByte(dt.Rows[i]["Plaka"]);
                obj.Isim = dt.Rows[i]["isim"].ToString();
                Sehirlere.Add(obj);
            }
            con.Close();
            return Sehirlere;

        }
        public List<SehirlerViewModel> ADOGetSehirIlce()
        {
            List<SehirlerViewModel> Sehirlere = new List<SehirlerViewModel>();
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            SqlCommand cmd = new SqlCommand("select Sehirler.plaka,Sehirler.sehir,Ilceler.Ilce from Sehirler inner join Ilceler on Sehirler.plaka = Ilceler.Plaka", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SehirlerViewModel obj = new SehirlerViewModel();
                obj.plaka = Convert.ToByte(dt.Rows[i]["Plaka"]);
                obj.sehir = dt.Rows[i]["sehir"].ToString();
                obj.ilce = dt.Rows[i]["Ilce"].ToString();
                Sehirlere.Add(obj);
            }
            con.Close();
            return Sehirlere;

        }
        public Sehir ADOGetSehirByPlaka(int plaka)
        {
            Sehir sehir = new Sehir();
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                SqlCommand cmnd = new SqlCommand("select * from sehir where plaka =" + plaka, connection);
                SqlDataAdapter da = new SqlDataAdapter(cmnd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Sehir obj = new Sehir();
                sehir.Plaka = Convert.ToByte(dt.Rows[0]["Plaka"]);
                sehir.Isim = dt.Rows[0]["isim"].ToString();
            }
            return sehir;
        }
        public Sehir ADOAddSehir(Sehir sehir)
        {
            if (sehir != null)
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    SqlCommand cmd = new SqlCommand("Insert into sehir values ('" + sehir.Plaka + "','" + sehir.Isim + "')", connection);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                return sehir;
            }
            else
            {
                return null;
            }
        }
        public bool ADODeleteSehir(int? plaka)
        {
            if (plaka != null)
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    SqlCommand cmd = new SqlCommand("delete from sehir where plaka =" + plaka, connection);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();

                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public Sehir ADOUpdateSehir(Sehir sehir)
        {
            if (sehir != null)
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    SqlCommand cmd = new SqlCommand("update sehir set plaka='" + sehir.Plaka + "',isim='" + sehir.Isim + "' where plaka=" + sehir.Plaka, connection);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                return sehir;
            }
            else
            {
                return null;
            }
        }

        public Ilceler ADOUpdateIlce(Ilceler ilce)
        {
            if (ilce != null)
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    SqlCommand cmd = new SqlCommand("update Ilceler set plaka='" + ilce.Plaka + "',Ilce='" + ilce.ilce + "' where Ilceler.ID=" + ilce.id, connection);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                return ilce;
            }
            else
            {
                return null;
            }
        }
    }
}


