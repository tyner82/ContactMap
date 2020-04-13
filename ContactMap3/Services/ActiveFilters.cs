using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactMap3.Services
{
    public class ActiveFilter
    {
        List<string> activeFilters;

        public ActiveFilter() => activeFilters = new List<string>();

        async public Task<bool> AddFilterAsync(string filter)
        {
            activeFilters.Add(filter);
            return await Task.FromResult(true);
        }

        async public Task<List<string>> GetFiltersAsync()
        {
            return await Task.FromResult(activeFilters);
        }
    }
}
