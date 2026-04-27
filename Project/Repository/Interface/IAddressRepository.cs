using Project.Models;
namespace Project.Repository.Interface
{
    public interface IAddressRepository
    {
        Task<List<Address>> GetByUserIdAsync(int userId);
        Task<Address?> GetByIdAsync(int id);
        Task<Address> CreateAsync(Address address);
        Task<Address?> UpdateAsync(int id, Address updated);
        Task<bool> DeleteAsync(int id);
        Task SetDefaultAsync(int userId, int addressId);
    }
}
