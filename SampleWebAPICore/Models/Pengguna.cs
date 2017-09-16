using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace SampleWebAPICore.Models
{
    public class Pengguna
    {
        //menambahkan primary key
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
