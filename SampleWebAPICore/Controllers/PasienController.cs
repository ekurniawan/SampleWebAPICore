using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using SampleWebAPICore.Models;

namespace SampleWebAPICore.Controllers
{
    [Produces("application/json")]
    [Route("api/Pasien")]
    public class PasienController : Controller
    {
        static List<Pasien> lstPasien = new List<Pasien>
        {
            new Pasien{PasienID=1,Nama="Budi",Alamat="Jl Mangga 12",Telpon="667788",Umur=45},
            new Pasien{PasienID=2,Nama="Amir",Alamat="Jl Duren 12",Telpon="889988",Umur=48},
            new Pasien{PasienID=3,Nama="Bambang",Alamat="Jl Sawo 12",Telpon="445566",Umur=24}
        };

        [HttpGet]
        public IEnumerable<Pasien> Get()
        {
            return lstPasien;
        }

        /*[HttpGet]
        [Route("GetPasien")]
        public IEnumerable<Pasien> GetPasien()
        {
            return lstPasien;
        }*/
    }
}