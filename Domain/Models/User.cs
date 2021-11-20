using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HiringSonda.Domain.Models
{
    public class User : Entity
    {
        [DisplayName("Nome Completo")]
        [Required]
        public string FullName { get; set; }
        [DisplayName("Data Nascimento")]
        [Required]
        public DateTime BirthDate { get; set; }
        [DisplayName("CPF")]
        [Required]
        public string CPF { get; set; }
        [DisplayName("Email")]
        [Required]
        public string Email { get; set; }
        public AddressUser addressUser { get; set; }
    }
}
