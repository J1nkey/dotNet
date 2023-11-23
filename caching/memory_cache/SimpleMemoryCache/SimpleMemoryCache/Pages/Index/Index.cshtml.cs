using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using SimpleMemoryCache.Consts;

namespace SimpleMemoryCache.Pages.Index
{
    public class IndexModel : PageModel
    {
        private readonly IMemoryCache _memoryCache;

        public DateTime CacheCurrentDateTime { get; set; }
        public DateTime CurrentDateTime { get; set; }
        public IndexModel(IMemoryCache memoryCache)     // get an object of In-Memory Cache in DI container
        {
            _memoryCache = memoryCache;
        }

        public void OnGet()
        {
            CurrentDateTime = DateTime.Now;
            
            if(!_memoryCache.TryGetValue(CacheKeys.Entry, out DateTime cacheValue)) {
                cacheValue = CurrentDateTime;

                // The cache entry is configured with a sliding expiration of five seconds
                // If the cache entry isn't accessed for more than five seconds, it gets evicted from the cache
                var cacheEntryOptions = new MemoryCacheEntryOptions()   
                    .SetSlidingExpiration(TimeSpan.FromSeconds(5));

                _memoryCache.Set(CacheKeys.Entry, cacheValue, cacheEntryOptions);
            }

            CacheCurrentDateTime = cacheValue;
        }
    }
}
