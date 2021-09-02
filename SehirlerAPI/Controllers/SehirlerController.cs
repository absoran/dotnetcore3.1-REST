using Microsoft.AspNetCore.Mvc;
using SehirlerAPI.IServices;
using SehirlerAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace SehirlerAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class SehirlerController : ControllerBase
    {
        private readonly ISehirlerService sehirservice;
        public SehirlerController(ISehirlerService sehir)
        {
            sehirservice = sehir;
        }
        

        [HttpGet]
        [Route("[action]")]
        //[Route("//GetSehir")]
        public IEnumerable<Sehir> GetSehir()
        {
            return sehirservice.GetSehir();
        }

        [HttpGet]
        [Route("[action]")]
        //[Route("//GetIlceler")]
        public IEnumerable<Ilceler> GetIlceler()
        {
            return sehirservice.GetIlceler();
        }


        [HttpGet]
        [Route("[action]")]
        //[Route("api/Sehir/GetSehir")]
        public IEnumerable<Sehir> ADOGetSehir()
        {
            return sehirservice.LoadFromDB();
        }
        [HttpGet]
        [Route("[action]")]
        //[Route("api/Sehir/GetSehirByplaka")]
        public Sehir GetSehirByPlaka(int plaka)
        {
            var temp = sehirservice.GetSehirByPlaka(plaka);
            return temp;
        }
        [HttpGet]
        [Route("[action]")]
        //[Route("api/Sehir/GetSehirByplaka")]
        public List<Ilceler> GetIlcelerByPlaka(int plaka)
        {
            var temp = sehirservice.GetIlcelerByPlaka(plaka);
            return temp;
        }

        [HttpGet]
        [Route("[action]")]
        //[Route("api/Sehir/GetSehirByplaka")]
        public Sehir ADOGetSehirByPlaka(int plaka)
        {
            return sehirservice.ADOGetSehirByPlaka(plaka);
        }
        [HttpGet]
        [Route("[action]")]
        //[Route("api/Sehir/GetSehirByplaka")]
        public Ilceler GetIlceById(int ID)
        {
            return sehirservice.GetIlceById(ID);
        }

        [HttpGet]
        [Route("[action]")]
        //[Route("api/Sehir/GetSehirByplaka")]
        public List<SehirlerViewModel> GetSehirIlce()
        {
            return sehirservice.GetSehirIlce();
        }
        [HttpGet]
        [Route("[action]")]
        //[Route("api/Sehir/GetSehirByplaka")]
        public List<SehirlerViewModel> ADOGetSehirIlce()
        {
            return sehirservice.ADOGetSehirIlce();
        }

        [HttpPost]
        [Route("[action]")]
        //[Route("api/Sehir/AddSehir")]
        public Sehir AddSehir(Sehir sehir)
        {
            return sehirservice.AddSehir(sehir);
        }
        [HttpPost]
        [Route("[action]")]
        //[Route("api/Sehir/AddSehir")]
        public Ilceler AddIlce(Ilceler ilce)
        {
            return sehirservice.AddIlce(ilce);
        }

        [HttpPost]
        [Route("[action]")]
        //[Route("api/Sehir/AddSehir")]
        public Sehir ADOAddSehir(Sehir sehir)
        {
            return sehirservice.ADOAddSehir(sehir);
        }

        [HttpPut]
        [Route("[action]")]
        //[Route("api/Sehir/EditSehir")]
        public Sehir UpdateSehir(Sehir sehir)
        {
            return sehirservice.UpdateSehir(sehir);
        }

        [HttpPut]
        [Route("[action]")]
        //[Route("api/Sehir/EditSehir")]
        public Ilceler UpdateIlce(Ilceler ilce)
        {
            return sehirservice.UpdateIlceler(ilce);
        }

        [HttpPut]
        [Route("[action]")]
        //[Route("api/Sehir/EditSehir")]
        public Sehir ADOUpdateSehir(Sehir sehir)
        {
            return sehirservice.ADOUpdateSehir(sehir);
        }
        [HttpPut]
        [Route("[action]")]
        //[Route("api/Sehir/EditSehir")]
        public Ilceler ADOUpdateIlce(Ilceler ilce)
        {
            return sehirservice.ADOUpdateIlce(ilce);
        }

        [HttpDelete]
        [Route("[action]")]
        //[Route("api/Sehir/DeleteSehir")]
        public Sehir DeleteSehir(int plaka)
        {
            return sehirservice.DeleteSehir(plaka);
        }
        [HttpDelete]
        [Route("[action]")]
        //[Route("api/Sehir/DeleteSehir")]
        public Ilceler DeleteIlce(int ID)
        {
            return sehirservice.DeleteIlce(ID);
        }

        [HttpDelete]
        [Route("[action]")]
        //[Route("api/Sehir/DeleteSehir")]
        public bool ADODeleteSehir(int plaka)
        {
            return sehirservice.ADODeleteSehir(plaka);
        }
    }
}
