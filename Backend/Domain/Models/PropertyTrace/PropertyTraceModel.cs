namespace Domain.Models.PropertyTrace
{
    public class PropertyTraceModel
    {
        public Guid Id { get; set; }
        public DateTime DateSale { get; set; }
        public string Name { get; set; } = null!;
        public decimal Value { get; set; }
        public decimal Tax { get; set; }
        public Guid PropertyId { get; set; }
    }
}
