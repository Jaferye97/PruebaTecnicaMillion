using Domain.Models.PropertyImage;
using ReporitoryMongoDb.Documents;

namespace ReporitoryMongoDb.Mappers
{
    public static class PropertyImageMapper
    {
        public static PropertyImageModel ToDomain(this PropertyImageDocument document) => new PropertyImageModel
        {
            Id = document.Id,
            Enabled = document.Enabled,
            File = document.File,
            PropertyId = document.PropertyId,
        };

        public static PropertyImageDocument ToDocument(this PropertyImageModel modal) => new PropertyImageDocument
        {
            Id = modal.Id,
            Enabled = modal.Enabled,
            File = modal.File,
            PropertyId = modal.PropertyId,
        };
    }
}
