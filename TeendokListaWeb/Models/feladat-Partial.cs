using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeendokListaWeb.Models
{
    [MetadataType(typeof(feladatMetaData))]
    public partial class feladat
    {

    }

    public class feladatMetaData
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "Cím")]
        public string cim { get; set; }
        [Required]
        [Display(Name = "Szöveg")]
        [DataType(DataType.MultilineText)]
        public string szoveg { get; set; }

        [Display(Name = "Dátum")]
        // [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        public DateTime letrehozas_datum { get; set; }

        [Display(Name = "Teljesítve")]
        public bool teljesitve { get; set; }
    }
}