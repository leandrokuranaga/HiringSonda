using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HiringSonda.Domain.Models
{
    public class User : Entity
    {
        [DisplayName("Nome Completo")]
        [Required(ErrorMessage = "O campo {0} precisa ser preenchido")]
        public string FullName { get; set; }
        [DisplayName("Data Nascimento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "O campo {0} precisa ser preenchido")]
        public DateTime BirthDate { get; set; }
        [DisplayName("CPF")]
        [Required(ErrorMessage = "O campo {0} precisa ser preenchido")]
        public string CPF { get; set; }
        [DisplayName("Email")]
        [Required(ErrorMessage = "O campo {0} precisa ser preenchido")]
        public string Email { get; set; }
        public AddressUser addressUser { get; set; }
    }
}
