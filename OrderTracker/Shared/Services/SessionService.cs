using Microsoft.AspNetCore.Components.ProtectedBrowserStorage;
using OrderTracker.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTracker.Shared.Services
{
    public class SessionService
    {
        private readonly ProtectedSessionStorage _sessionStorage;

        public SessionService(ProtectedSessionStorage sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }

        public async Task<Order?> GetExistingNewOrderTemplate()
        {
            var result = await _sessionStorage.GetAsync<Order>("NewOrder");
            if (result.Success)
            {
                return result.Value;
            }
            return null;
        }

        public async Task SaveKey<T>(string key, T value)
        {
            await _sessionStorage.SetAsync(key, value);
        }
        public async Task ClearStorageKey(string key)
        {
            await _sessionStorage.DeleteAsync(key);
        }
    }
}
