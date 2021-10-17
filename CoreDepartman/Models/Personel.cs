using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CoreDepartman.Models
{
    public class Personel
    {
        [Key]
        public int PerId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Sehir { get; set; }
        public int BirimId { get; set; }
        public Birim Birim { get; set; }
    }
}