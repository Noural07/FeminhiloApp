using FemApi.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Fem.Shared.Data;
using FemApi.Models;


namespace FemApi.Services
{
    public class ItemService
    {
        private readonly DataContext _context;

        public ItemService(DataContext context)
        {
            _context = context;
        }

        public async Task<ItemD[]> GetItemsAsync()
        {
            try
            {
                return await _context.Items.AsNoTracking()
                    .Select(i => new ItemD(i.Id, i.Name, i.Price, i.Image))
                    .ToArrayAsync();
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error in GetItemsAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<ItemD> PostItemAsync(ItemD newItem)
        {
            try
            {
                var entity = new Item
                {
                    Name = newItem.Name,
                    Price = newItem.Price,
                    Image = newItem.Image
                };

                _context.Items.Add(entity);
                await _context.SaveChangesAsync();

                // Map back the newly created entity to the ItemD
                return new ItemD(entity.Id, entity.Name, entity.Price, entity.Image);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error in PostItemAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> DeleteItemAsync(int itemId)
        {
            try
            {
                var entity = await _context.Items.FindAsync(itemId);
                if (entity == null)
                {
                    return false; // Item not found
                }

                _context.Items.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error in DeleteItemAsync: {ex.Message}");
                throw;
            }
        }
    }
}
