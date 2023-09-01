﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Register.Domain
{
    public class PerishableItem
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Data de Fabricação")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? FabricationDate { get; set; }

        [Display(Name = "Data de Validade")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? ExpirationDate { get; set; }

        [Display(Name = "Lote")]
        [StringLength(30, ErrorMessage = "Máximo de {1} caracteres!")]
        public string ItemBatch { get; set; } = string.Empty;

        [Display(Name = "Quantidade do Lote")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Column(TypeName = "decimal(8,2)")]
        public decimal PerishableItemQuantity { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public decimal PerishableItemPreviousQuantity { get; set; } = 0;
        
        [Display(Name = "Contagem")]
        public int ItemId { get; set; }
        [Display(Name = "Contagens")]
        public Item Item { get; set; }
    }
}