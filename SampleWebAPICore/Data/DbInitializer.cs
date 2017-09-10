using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleWebAPICore.Models;

namespace SampleWebAPICore.Data
{
    public static class DbInitializer
    {
        public static void Initialize(PasienDataContext context)
        {
            context.Database.EnsureCreated();

            if (context.Pasien.Any())
            {
                return;
            }

            var lstPasien = new Pasien[]
            {
                new Pasien{Nama="Budi",Alamat="Jl Mangga 12",Telpon="667788",Umur=45},
                new Pasien{Nama="Amir",Alamat="Jl Duren 12",Telpon="889988",Umur=48},
                new Pasien{Nama="Bambang",Alamat="Jl Sawo 12",Telpon="445566",Umur=24},
                new Pasien{Nama="Joko",Alamat="Jl Belimbing 99",Telpon="115566",Umur=28},
                new Pasien{Nama="Ani",Alamat="Jl Belimbing 23",Telpon="455566",Umur=22}
            };

            foreach(var pasien in lstPasien)
            {
                context.Pasien.Add(pasien);
            }
            context.SaveChanges();
        }
    }
}
