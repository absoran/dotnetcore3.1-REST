using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace SehirlerAPI.Models
{
    public partial class Sehir
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public byte Plaka { get; set; }
        public string Isim { get; set; }

    }
}
