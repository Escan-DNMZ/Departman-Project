using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoreDepartman.Models
{
    public class Admin 
    {
        [Key]
        public int AdminID { get; set; }
        public string Kullanici { get; set; }
        public string Sifre { get; set; }
        
    }
}