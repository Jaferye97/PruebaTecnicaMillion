using Domain.Models.Owner;
using ReporitoryMongoDb.Documents;

namespace ReporitoryMongoDb.Mappers
{
    public static class OwnerMapper
    {
        public static OwnerModel ToDomain(this OwnerDocument document) => new OwnerModel
        {
            Id = document.Id,
            Name = document.Name,
            Address = document.Address,
            Birthday = document.Birthday,
            Photo = document.Photo,
        };

        public static OwnerDocument ToDocument(this OwnerModel modal) => new OwnerDocument
        {
            Id = modal.Id,
            Name = modal.Name,
            Address = modal.Address,
            Birthday = modal.Birthday,
            Photo = modal.Photo,
        };
    }
}
