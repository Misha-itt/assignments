using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.Repository.Interface;

namespace Project.Repository.Class
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AppDBContext _context;
        public AddressRepository(AppDBContext context) { _context = context; }

        public async Task<List<Address>> GetByUserIdAsync(int userId)
            => await _context.Addresses
                .AsNoTracking()
                .Where(a => a.UserId == userId)
                .ToListAsync();

        public async Task<Address?> GetByIdAsync(int id) => await _context.Addresses.FindAsync(id);

        public async Task<Address> CreateAsync(Address address)
        {
            _context.Addresses.Add(address);
            await _context.SaveChangesAsync();
            return address;
        }

        public async Task<Address?> UpdateAsync(int id, Address updated)
        {
            var existing = await _context.Addresses.FindAsync(id);
            if (existing == null) return null;
            existing.Line1 = updated.Line1;
            existing.Line2 = updated.Line2;
            existing.City = updated.City;
            existing.State = updated.State;
            existing.Pincode = updated.Pincode;
            existing.Country = updated.Country;
            existing.Label = updated.Label;
            existing.IsDefault = updated.IsDefault;
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var address = await _context.Addresses.FindAsync(id);
            if (address == null) return false;
            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();
            return true;
        }

       
        public async Task SetDefaultAsync(int userId, int addressId)
        {
            var addresses = await _context.Addresses
                .Where(a => a.UserId == userId).ToListAsync();
            foreach (var a in addresses)
                a.IsDefault = (a.Id == addressId);
            await _context.SaveChangesAsync();
        }
    }
}