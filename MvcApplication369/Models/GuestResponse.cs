using System.ComponentModel.DataAnnotations;

namespace PartyInvites.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage = "Укажите первое значение")]
        [Compare("Operand_2", ErrorMessage = "Значения операндов не совпадают")]
        public sbyte Operand_1 { get; set; }

        [Required(ErrorMessage = "Укажите второе значение")]
        public sbyte Operand_2 { get; set; }

        public string Operation { get; set; }

        public decimal Result { get; set; }
    }
}