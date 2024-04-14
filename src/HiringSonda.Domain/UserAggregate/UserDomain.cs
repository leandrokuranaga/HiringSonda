using Abp.Domain.Entities;
using HiringSonda.Domain.AdressAggregate;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HiringSonda.Domain.UserAggregate
{
    public class UserDomain : Entity
    {
        [DisplayName("Id")]
        [Required]
        public int Id { get; set; }
        [DisplayName("Nome Completo")]
        [Required(ErrorMessage = "O campo {0} precisa ser preenchido")]
        public string FullName { get; set; }
        [DisplayName("Data Nascimento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "O campo {0} precisa ser preenchido")]
        public DateOnly BirthDate { get; set; }
        [DisplayName("CPF")]
        [Required(ErrorMessage = "O campo {0} precisa ser preenchido")]
        public string CPF { get; set; }
        [DisplayName("Email")]
        [Required(ErrorMessage = "O campo {0} precisa ser preenchido")]
        public string Email { get; set; }
        public AddressUserDomain AddressUser { get; set; }
    }

    public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
    {
        public DateOnlyConverter()
            : base(dateOnly =>
                    dateOnly.ToDateTime(TimeOnly.MinValue),
                dateTime => DateOnly.FromDateTime(dateTime))
        { }
    }
}
