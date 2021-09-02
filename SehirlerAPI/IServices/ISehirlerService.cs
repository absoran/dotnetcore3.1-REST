using SehirlerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SehirlerAPI.IServices
{
    public interface ISehirlerService
    {
        IEnumerable<Sehir> GetSehir();
        Sehir GetSehirByPlaka(int Plaka);
        Sehir AddSehir(Sehir sehir);
        Sehir UpdateSehir(Sehir sehir);
        Sehir DeleteSehir(int plaka);
        List<Sehir> LoadFromDB();
        Sehir ADOGetSehirByPlaka(int plaka);
        Sehir ADOAddSehir(Sehir sehir);
        bool ADODeleteSehir(int? plaka);
        Sehir ADOUpdateSehir(Sehir sehir);
        Ilceler ADOUpdateIlce(Ilceler ilce);
        IEnumerable<Ilceler> GetIlceler();
        List<Ilceler> GetIlcelerByPlaka(int plaka);
        Ilceler UpdateIlceler(Ilceler ilce);
        Ilceler DeleteIlce(int ID);
        Ilceler AddIlce(Ilceler ilce);
        List<SehirlerViewModel> GetSehirIlce();
        List<SehirlerViewModel> ADOGetSehirIlce();

        Ilceler GetIlceById(int ID);


    }
}
