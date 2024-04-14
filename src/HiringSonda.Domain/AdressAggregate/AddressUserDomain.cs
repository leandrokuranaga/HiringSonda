using Abp.Domain.Entities;
using HiringSonda.Domain.UserAggregate;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HiringSonda.Domain.AdressAggregate
{
    public class AddressUserDomain : Entity
    {
        [DisplayName("Id")]
        [Required]
        public int Id { get; set; }
        [ForeignKey("User_FK")]
        public int UserID { get; set; }
        [DisplayName("CEP")]
        [Required(ErrorMessage = "O campo {0} precisa ser preenchido")]
        public string CEP { get; set; }
        [DisplayName("Logradouro")]
        [Required(ErrorMessage = "O campo {0} precisa ser preenchido")]
        public string Street { get; set; }
        [Required(ErrorMessage = "O campo {0} precisa ser preenchido")]
        [DisplayName("Complemento")]
        public string Complement { get; set; }
        [DisplayName("Bairro")]
        [Required(ErrorMessage = "O campo {0} precisa ser preenchido")]
        public string Neighborhood { get; set; }
        [DisplayName("Cidade")]
        [Required(ErrorMessage = "O campo {0} precisa ser preenchido")]
        public string City { get; set; }
        [DisplayName("Estado")]
        [Required(ErrorMessage = "O campo {0} precisa ser preenchido")]
        public string State { get; set; }

        public UserDomain User { get; set; }
    }
}
