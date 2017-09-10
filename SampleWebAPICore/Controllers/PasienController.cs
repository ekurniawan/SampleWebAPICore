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
       

        [HttpGet]
        public IEnumerable<Pasien> Get()
        {
            //return lstPasien;
        }

        /*[HttpGet]
        [Route("GetPasien")]
        public IEnumerable<Pasien> GetPasien()
        {
            return lstPasien;
        }*/
    }
}