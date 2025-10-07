namespace Evaluacion_2.Repository.Interface;

public interface IUnitOfWork : IDisposable
{
    IClientRepository ClientRepository { get; }
    IProductRepository ProductRepository { get; }
    IOrderRepository OrderRepository { get; }
    
    Task<bool> SaveChangesAsync();
}