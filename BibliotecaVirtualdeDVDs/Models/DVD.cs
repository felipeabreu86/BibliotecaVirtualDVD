using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BibliotecaVirtualdeDVDs.Models
{
    public partial class DVD
    {
        public string Titulo { get; set; }
        public string Ano { get; set; }
        public string Genero { get; set; }
    }
}