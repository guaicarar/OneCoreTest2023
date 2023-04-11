using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using OneCoreTest2023.Models.ViewModels;

namespace OneCoreTest2023.Models.ViewModels
{
    public class ClienteViewModel
    {

        public int ID { get; set; }
        //[Required]
        [Required(ErrorMessage = "Name is Required")]
        [Display(Name = "Nombre")]
        [StringLength(100)]
        public string NOMBRE{ get; set; }
        //[Required]
        [Required(ErrorMessage = "Name is Required")]
        [Display(Name = "RFC")]
        [StringLength(15)]
        public string RFC { get; set; }
        //[Required]
        [Required(ErrorMessage = "Name is Required")]
        [Display(Name = "Direccion")]
        [StringLength(100)]
        public string DIRECCION{ get; set; }
        //[Required]
        [Required(ErrorMessage = "Name is Required")]
        [Display(Name = "CP")]
        [StringLength(100)]
        public string CP { get; set; }
        //[Required]
        [Required(ErrorMessage = "Name is Required")]
        [Display(Name = "Correo")]
        [StringLength(50)]
        public string CORREO{ get; set; }
    }
}