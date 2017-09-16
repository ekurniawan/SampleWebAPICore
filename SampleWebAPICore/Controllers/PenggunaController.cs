using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using SampleWebAPICore.Models;
using SampleWebAPICore.Data;
using Microsoft.EntityFrameworkCore;

namespace SampleWebAPICore.Controllers
{
    [Produces("application/json")]
    [Route("api/Pengguna")]
    public class PenggunaController : Controller
    {
        private readonly PasienDataContext context;

        public PenggunaController(PasienDataContext context)
        {
            this.context = context;
        }

        [Route("Login")]
        [HttpPost]
        public async Task<bool> Login(Pengguna pengguna)
        {
            var result = await (from p in context.Pengguna
                          where p.Username == pengguna.Username
                          select p).AsNoTracking().SingleOrDefaultAsync();

            if (result != null)
            {
                var isValid = BCrypt.Net.BCrypt.Verify(pengguna.Password, result.Password);
                return isValid;
            }
            return false;
        }

        // GET: api/Pengguna
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

       

        // GET: api/Pengguna/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Pengguna
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Pengguna/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
