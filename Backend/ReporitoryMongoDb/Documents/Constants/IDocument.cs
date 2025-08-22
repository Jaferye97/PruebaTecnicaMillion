namespace ReporitoryMongoDb.Entities.Constants
{
    public interface IDocument<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
    }
}
