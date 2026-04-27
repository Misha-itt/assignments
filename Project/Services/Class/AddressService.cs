using AutoMapper;
using Project.Models;
using Project.Repository.Interface;
using Project.Services.Interface;

namespace Project.Services.Class
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _repo;
        private readonly IMapper _mapper;

        public AddressService(IAddressRepository repo, IMapper mapper)
        { 
            _repo = repo;
            _mapper = mapper; 
        }

        public async Task<List<AddressResponseDTO>> GetAllAsync(int userId)
        {
            var list = await _repo.GetByUserIdAsync(userId);
            return _mapper.Map<List<AddressResponseDTO>>(list);
        }

        public async Task<AddressResponseDTO?> GetByIdAsync(int id, int userId)
        {
            var address = await _repo.GetByIdAsync(id);

            if (address == null || address.UserId != userId)
                return null;

            return _mapper.Map<AddressResponseDTO>(address);
        }

        public async Task<AddressResponseDTO> CreateAsync(int userId, AddressDTO dto)
        {
            var address = _mapper.Map<Address>(dto);
            address.UserId = userId;

            
            var existing = await _repo.GetByUserIdAsync(userId);
            if (!existing.Any()) address.IsDefault = true;

            var created = await _repo.CreateAsync(address);
            return _mapper.Map<AddressResponseDTO>(created);
        }

        public async Task<AddressResponseDTO?> UpdateAsync(int id, int userId, AddressDTO dto)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null || existing.UserId != userId)
                return null;

            var updated = await _repo.UpdateAsync(id, _mapper.Map<Address>(dto));
            return updated == null ? null : _mapper.Map<AddressResponseDTO>(updated);
        }

        public async Task<bool> DeleteAsync(int id, int userId)
        {
            var address = await _repo.GetByIdAsync(id);
            if (address == null || address.UserId != userId) 
                return false;

            return await _repo.DeleteAsync(id);
        }

        public async Task<bool> SetDefaultAsync(int id, int userId)
        {
            var address = await _repo.GetByIdAsync(id);
            if (address == null || address.UserId != userId) 
                return false;

            await _repo.SetDefaultAsync(userId, id);
            return true;
        }
    }
}