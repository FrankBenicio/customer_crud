using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Customer_Web.Models
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "O {0} é item obrigatório.")]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O {0} é item obrigatório.")]
        [DisplayName("CPF")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O {0} é item obrigatório.")]
        [DisplayName("Data de nascimento")]
        public string DateOfBirth { get; set; }

        [Required(ErrorMessage = "O {0} é item obrigatório.")]
        [DisplayName("Genêro")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "O {0} é item obrigatório.")]
        [DisplayName("CEP")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "O {0} é item obrigatório.")]
        [DisplayName("Endereço")]
        public string Address { get; set; }

        [Required(ErrorMessage = "O {0} é item obrigatório.")]
        [DisplayName("Estado")]
        public string State { get; set; }

        [Required(ErrorMessage = "O {0} é item obrigatório.")]
        [DisplayName("Cidade")]
        public string City { get; set; }
    }
}
