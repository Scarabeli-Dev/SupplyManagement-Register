using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Register.Domain
{
    public class ItemsAddressing
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Endereçamento")]
        public int AddressingId { get; set; }
        [Display(Name = "Endereçamentos")]
        public Addressing Addressing { get; set; }

        [Display(Name = "Item")]
        public string ItemId { get; set; }

        [Display(Name = "Itens")]
        public Item Item { get; set; }

        [Display(Name = "Quantidade de Itens")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Quantity { get; set; }
    }
}