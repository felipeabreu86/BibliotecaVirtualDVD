using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BibliotecaVirtualdeDVDs.Models
{
    [MetadataType(typeof(DVDMetadado))]
    public partial class DVD
    {
        public override bool Equals(object obj)
        {
            DVD DvdObj = obj as DVD;

            if (DvdObj == null)
            {
                return false;
            }

            return (this.Titulo.Equals(DvdObj.Titulo) && this.Ano.Equals(DvdObj.Ano) && this.Genero.Equals(DvdObj.Genero));
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public class DVDMetadado
    {
        [Required(ErrorMessage = "O campo Título é de preenchimento obrigatório!")]
        [DataType(DataType.Text, ErrorMessage = "Título inválido")]
        [DisplayName("Título")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo Ano é de preenchimento obrigatório!")]
        [AnoEmFormatoValido]
        [DisplayName("Ano")]
        public string Ano { get; set; }

        [Required(ErrorMessage = "O campo Gênero é de preenchimento obrigatório!")]
        [DataType(DataType.Text, ErrorMessage = "Gênero inválido")]
        [DisplayName("Gênero")]
        public string Genero { get; set; }
    }

    public class AnoEmFormatoValido : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int? year = null;

            // Tenta converter a String Ano para Integer
            try
            {
                year = Int32.Parse(value.ToString());
            }
            catch
            {
                ErrorMessage = "Ano de versão inválido.";
                return false;
            }
            
            // Conversão realizada com sucesso
            return true;
        }
    }

}