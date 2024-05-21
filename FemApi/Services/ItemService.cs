using FemApi.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Fem.Shared.Data;


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
    }
}
