using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BibliotecaVirtualdeDVDs.Models
{
    [MetadataType(typeof(UserMetadado))]
    public partial class User
    {
        public override bool Equals(object obj)
        {
            User UserObj = obj as User;

            if (UserObj == null)
            {
                return false;
            }

            return (this.email.Equals(UserObj.email) && this.password.Equals(UserObj.password));
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public class UserMetadado
    {
        [Required(ErrorMessage = "O campo Usuário é de preenchimento obrigatório!")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-Mail não é válido")]
        [DisplayName("E-Mail")]
        public string email { get; set; }

        [Required(ErrorMessage = "O campo Senha é de preenchimento obrigatório!")]
        [DataType(DataType.Password, ErrorMessage = "Senha inválida")]
        [DisplayName("Senha")]
        public string password { get; set; }
    }
}