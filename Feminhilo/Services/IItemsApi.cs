using Fem.Shared.Data;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feminhilo.Services
{
    public interface IItemsApi
    {
        [Get("/api/items")]
        Task<ItemD[]> GetItemsAsync();
    }
}
