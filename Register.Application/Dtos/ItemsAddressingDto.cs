namespace Register.Application.Dtos
{
    public class ItemsAddressingDto
    {
        public int Id { get; set; }
        public int AddressingId { get; set; }
        public AddressingDto Addressing { get; set; }
        public string ItemId { get; set; }
        public ItemDto Item { get; set; }
        public decimal Quantity { get; set; }

    }
}