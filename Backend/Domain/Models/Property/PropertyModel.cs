namespace Domain.Models.Property
{
    public class PropertyModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public decimal Price { get; set; }
        public string CodeInternal { get; set; } = null!;
        public int Year { get; set; }
        public Guid OwnerId { get; set; }
    }
}
