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
    [Route("api/Pasien")]
    public class PasienController : Controller
    {
        private readonly PasienDataContext context;

        public PasienController(PasienDataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Pasien>> Get()
        {
            var results = from p in context.Pasien
                          orderby p.Nama
                          select p;

            return await results.AsNoTracking().ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<Pasien> Get(int id)
        {
            var result = await (from p in context.Pasien
                                where p.PasienID == id
                                select p).AsNoTracking().SingleOrDefaultAsync();
            return result;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Pasien pasien)
        {
            try
            {
                context.Pasien.Add(pasien);
                await context.SaveChangesAsync();
                return Ok("Data berhasil ditambah");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Pasien pasien)
        {
            var result = await (from p in context.Pasien
                         where p.PasienID == id
                         select p).SingleOrDefaultAsync();

            if (result != null)
            {
                try
                {
                    result.Nama = pasien.Nama;
                    result.Alamat = pasien.Alamat;
                    result.Umur = pasien.Umur;
                    result.Telpon = pasien.Telpon;

                    context.Pasien.Update(result);
                    await context.SaveChangesAsync();
                    return Ok("Berhasil mengupdate data");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest("Data tidak ditemukan");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await (from p in context.Pasien
                         where p.PasienID == id
                         select p).SingleOrDefaultAsync();

            if (result != null)
            {
                try
                {
                    context.Pasien.Remove(result);
                    await context.SaveChangesAsync();
                    return Ok("Berhasil mendelete data");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            return BadRequest("Data tidak ditemukan");
        }

        /*[HttpGet]
        [Route("GetPasien")]
        public IEnumerable<Pasien> GetPasien()
        {
            return lstPasien;
        }*/
    }
}