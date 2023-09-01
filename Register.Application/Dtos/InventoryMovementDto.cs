namespace Register.Application.Dtos
{
    public class InventoryMovementDto
    {
        public int Id { get; set; }
        public string ItemId { get; set; }
        public ItemDto Item { get; set; }
        public string MovementeType { get; set; }
        public int WarehouseId { get; set; }
        public WarehouseDto Warehouse { get; set; }
        public decimal Amount { get; set; }
        public DateTime MovementDate { get; set; }
        public DateTime ImportDate { get; set; }
        public int InventoryId { get; set; }
    }
}