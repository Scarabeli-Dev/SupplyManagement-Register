using System.ComponentModel.DataAnnotations;

namespace Register.Domain
{
    public class Addressing
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [StringLength(50, ErrorMessage = "Máximo de {1} caracteres!")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        public string Name { get; set; }

        [Display(Name = "Depósito")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        public int WarehouseId { get; set; }

        [Display(Name = "Depósito")]
        public Warehouse Warehouse { get; set; }

        [Display(Name = "Itens")]
        public IEnumerable<ItemsAddressing> Item { get; set; }
    }
}