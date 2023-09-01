namespace Register.Application.Dtos
{
    public class AddressingDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int WarehouseId { get; set; }
        public WarehouseDto Warehouse { get; set; }
        public IEnumerable<ItemsAddressingDto> Item { get; set; }

    }
}
