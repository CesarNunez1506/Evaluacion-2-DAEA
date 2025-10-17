using System;
using System.Threading.Tasks;
using Evaluacion_2.Models;
using Evaluacion_2.Repository.Interface;

namespace Evaluacion_2.Repository;
//unitofwork repository implementation
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private IClientRepository? _clientRepository;
    private IProductRepository? _productRepository;
    private IOrderRepository? _orderRepository;
    private bool _disposed;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public IClientRepository ClientRepository
    {
        get { return _clientRepository ??= new ClientRepository(_context); }
    }

    public IProductRepository ProductRepository
    {
        get { return _productRepository ??= new ProductRepository(_context); }
    }

    public IOrderRepository OrderRepository
    {
        get { return _orderRepository ??= new OrderRepository(_context); }
    }

    public async Task<bool> SaveChangesAsync()
    {
        try
        {
            return await _context.SaveChangesAsync() > 0;
        }
        catch
        {
            // Aquí podrías agregar logging
            return false;
        }
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed && disposing)
        {
            _context.Dispose();
        }
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}