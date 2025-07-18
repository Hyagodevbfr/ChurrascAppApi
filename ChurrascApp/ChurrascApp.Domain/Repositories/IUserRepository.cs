using ChurrascApp.Domain.Entities;

namespace ChurrascApp.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User> GetByEmail(string email);
    Task<User> GetByCpf(string cpf);
    Task<User> GetByPhoneNumber(string phoneNumber);
}