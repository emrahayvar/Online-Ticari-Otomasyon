using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;

namespace MvcOnlineTicari.Models.Siniflar
{
    public class Gider
    {
        [Key]
        public int Giderid { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Aciklama { get; set; }
        public DataSetDateTime Tarih { get; set; }
        public decimal Tutar { get; set; }
    }
}