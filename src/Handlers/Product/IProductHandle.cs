namespace BugStore.Handlers.Product;

public interface IProductHandle
{
    Task<IResult> GetAllAsync();
    Task<IResult> GetByIdAsync(Guid id);
    Task<IResult> CreateAsync(BugStore.Requests.Products.Create request); 
    Task<IResult> UpdateAsync(Guid id, BugStore.Requests.Products.Update request);
    Task<IResult> DeleteAsync(Guid id);
}