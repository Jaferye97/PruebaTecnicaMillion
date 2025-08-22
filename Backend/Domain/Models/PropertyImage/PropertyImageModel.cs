namespace Domain.Models.PropertyImage
{
    public class PropertyImageModel
    {
        public Guid Id { get; set; }
        public string File { get; set; } = null!;
        public bool Enabled { get; set; }
        public Guid PropertyId { get; set; }
    }
}
