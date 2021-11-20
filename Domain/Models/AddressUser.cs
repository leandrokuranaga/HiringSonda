using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HiringSonda.Domain.Models
{
    public class AddressUser : Entity
    {
        [DisplayName("CEP")]
        [Required]
        public string CEP { get; set; }
        [DisplayName("Logradouro")]
        [Required]
        public string Street { get; set; }
        [Required]
        [DisplayName("Complemento")]
        public string Complement { get; set; }
        [DisplayName("Bairro")]
        [Required]
        public string Neighborhood { get; set; }
        [DisplayName("Cidade")]
        [Required]
        public string City { get; set; }
        [DisplayName("Estado")]
        [Required]
        public string State { get; set; }

        public User user { get; set; }
    }
}
