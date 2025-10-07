namespace Evaluacion_2.Repository.Interface;

public interface IUnitOfWork : IDisposable
{
    //Unitofwork interface
    IClientRepository ClientRepository { get; }
    IProductRepository ProductRepository { get; }
    IOrderRepository OrderRepository { get; }
    
    Task<bool> SaveChangesAsync();
}