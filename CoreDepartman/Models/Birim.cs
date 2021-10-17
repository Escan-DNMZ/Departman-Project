using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CoreDepartman.Models
{
    public class Birim
    {
        [Key]
        public int BirimID { get; set; }
        public string BirimAd { get; set; }
        public IList<Personel> Personels { get; set; }
    }
}