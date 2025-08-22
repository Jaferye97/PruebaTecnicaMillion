using Domain.Models.Property;
using ReporitoryMongoDb.Documents;

namespace ReporitoryMongoDb.Mappers
{
    public static class PropertyMapper
    {
        public static PropertyModel ToDomain(this PropertyDocument document) => new PropertyModel
        {
            Id = document.Id,
            Name = document.Name,
            Address = document.Address,
            CodeInternal = document.CodeInternal,
            OwnerId = document.OwnerId,
            Price = document.Price,
            Year = document.Year,
        };

        public static PropertyDocument ToDocument(this PropertyModel modal) => new PropertyDocument
        {
            Id = modal.Id,
            Name = modal.Name,
            Address = modal.Address,
            CodeInternal = modal.CodeInternal,
            OwnerId = modal.OwnerId,
            Price = modal.Price,
            Year = modal.Year,
        };
    }
}
