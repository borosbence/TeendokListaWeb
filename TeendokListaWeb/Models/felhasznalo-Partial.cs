using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeendokListaWeb.Models
{
    [MetadataType(typeof(felhasznaloMetaData))]
    public partial class felhasznalo
    {

    }

    public class felhasznaloMetaData
    {
        [Required]
        [StringLength(20)]
        [Display(Name = "Felhasználónév")]
        public string felhasznalonev { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name = "Jelszó")]
        [DataType(DataType.Password)]
        public string jelszo { get; set; }
    }
}