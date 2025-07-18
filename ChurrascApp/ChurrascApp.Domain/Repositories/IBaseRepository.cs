namespace ChurrascApp.Domain.Repositories;


public interface IBaseRepository<T>
{
    public Task<T> GetById(string id);
    public Task<T> Register(T item);
    public Task<T> Update(T item);
    public Task<IEnumerable<T>> GetAll();
    public Task Delete(string publicId);
}