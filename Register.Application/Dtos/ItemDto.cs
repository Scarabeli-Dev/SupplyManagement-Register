namespace Register.Application.Dtos
{
    public class ItemDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string UnitOfMeasurement { get; set; }
        public IEnumerable<ItemsAddressingDto> Addressings { get; set; }
        public decimal Price { get; set; }
        public string Observation { get; set; }
        public string ImageUrl { get; set; }
        public IEnumerable<InventoryMovementDto> InventoryMovement { get; set; }

    }
}