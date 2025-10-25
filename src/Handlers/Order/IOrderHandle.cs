using BugStore.Requests.Orders; 


namespace BugStore.Handlers.Order;

public interface IOrderHandle
{
    Task<IResult> GetAllAsync();
    Task<IResult> GetByIdAsync(Guid id);
    Task<IResult> CreateAsync(Create request); 
    Task<IResult> DeleteAsync(Guid id);
}