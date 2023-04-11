using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneCoreTest2023.Models.ViewModels
{
    public class ListClienteViewModel
    {
        public int ID { get; set; }
        public string NOMBRE { get; set; }
        public string RFC { get; set; }
        public string DIRECCION { get; set; }
        public string CP { get; set; }
        public string CORREO { get; set; }
    }
}