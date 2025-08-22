namespace Domain.Models.Owner
{
    public class OwnerModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Photo { get; set; } = null!;
        public DateTime Birthday { get; set; }
    }
}
