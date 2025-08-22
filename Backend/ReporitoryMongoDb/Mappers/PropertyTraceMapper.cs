using Domain.Models.PropertyTrace;
using ReporitoryMongoDb.Documents;

namespace ReporitoryMongoDb.Mappers
{
    public static class PropertyTraceMapper
    {
        public static PropertyTraceModel ToDomain(this PropertyTraceDocument document) => new PropertyTraceModel
        {
            Id = document.Id,
            Name = document.Name,
            Tax = document.Tax,
            Value = document.Value,
            DateSale = document.DateSale,
            PropertyId = document.PropertyId,
        };

        public static PropertyTraceDocument ToDocument(this PropertyTraceModel modal) => new PropertyTraceDocument
        {
            Id = modal.Id,
            Name = modal.Name,
            Value = modal.Value,
            Tax = modal.Tax,
            DateSale = modal.DateSale,
            PropertyId = modal.PropertyId,
        };
    }
}
