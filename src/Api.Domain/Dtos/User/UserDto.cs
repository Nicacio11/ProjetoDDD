using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.User
{
    public class UserDto
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O Campo é obrigatório")]
        [StringLength(60, ErrorMessage = "Deve ter no máximo {1} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "E-mail é campo obrigatório para Login")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido")]
        [StringLength(100, ErrorMessage = "E-mail deve ter máximo {1} caracteres")]
        public string Email { get; set; }
    }
}
