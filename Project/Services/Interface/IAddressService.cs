namespace Project.Services.Interface
{
    public interface IAddressService
    {
        Task<List<AddressResponseDTO>> GetAllAsync(int userId);
        Task<AddressResponseDTO?> GetByIdAsync(int id, int userId);
        Task<AddressResponseDTO> CreateAsync(int userId, AddressDTO dto);
        Task<AddressResponseDTO?> UpdateAsync(int id, int userId, AddressDTO dto);
        Task<bool> DeleteAsync(int id, int userId);
        Task<bool> SetDefaultAsync(int id, int userId);
    }
}