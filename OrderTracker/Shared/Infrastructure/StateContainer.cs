using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTracker.Shared.Infrastructure
{
    public class StateContainer
    {
        private Dictionary<string, object> States { get; set; } = new Dictionary<string, object>();

        public T? GetState<T>(string keyName) where T : class
        {
            States.TryGetValue(keyName, out object? state);

            if (state != null)
            {
                var result = state as T;
                return result;
            }

            return null;
        }

        public void SetState(string keyName, object state)
        {
            States.TryAdd(keyName, state);
        }

        public void ClearState(string keyName)
        {
            States.Remove(keyName);
        }
    }
}
