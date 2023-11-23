# Caching in .NET
Caching can significantly improve the performance and scalability of an app by reducing the work required to generate content.
Caching works best with data that changes infrequently and is expensive to generate.
Caching makes a copy of data that can be returned much faster than from the source.
Apps should be written and tested to never depend on cached data.

ASP.NET Core supports several different caches. But the simplest cache is based on the IMemoryCache (in-memory cache).

# IMemoryCache
this represents a cache stored in the memory of the web server.
Apps running on a server farm (multiple servers) should ensure sessions are "sticky" when using the in-memory cache.
Sticky sessions ensure that requests from a client all go to the same server.
For example, Azure Web apps use Application Request Routing (ARR) to route all requests to the same server.

If does not config the sticky sessions, so in the web farm require "distributed cache" to avoid cache consistency problems.
For some apps, a distributed cache can support higher scale-out than an in-memory cache.
Using a distributed cache offloads the cache memory to an external process.

The in-memory cache can store any object. The distributed cache interface is limited to byte[].
The in-memory and distributed cache store cache items as key-value pairs.

### vocabulary
significant(adj): Nhiều, đáng kể
infrequent(adj): Không thường xuyên, ít khi
consistency: tính nhất quán
offload: giảm tải