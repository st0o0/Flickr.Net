# Migration Guide

## v0.4.0

### `Flickr` → `FlickrClient`

The main class has been renamed and sealed.

```diff
- var flickr = new Flickr("apiKey", "secret");
+ var flickr = new FlickrClient("apiKey", "secret");
```

```diff
- var flickr = new Flickr(new FlickrConfiguration { ApiKey = "..." });
+ var flickr = new FlickrClient(new FlickrConfiguration { ApiKey = "..." });
```

### DI Integration (new)

The recommended way to use Flickr.Net is now via dependency injection:

```csharp
// Program.cs / Startup
services.AddFlickr(o =>
{
    o.ApiKey = "your-api-key";
    o.SharedSecret = "your-shared-secret";
});

// Inject IFlickrClient anywhere
public class PhotoService(IFlickrClient flickr)
{
    public async Task<Photo> GetPhotoAsync(string id)
    {
        return await flickr.Photos.GetInfoAsync(id);
    }
}
```

This gives you `IHttpClientFactory`-managed HTTP connections, proper lifecycle management, and testability via `IFlickrClient`.

Direct instantiation still works for simple scripts:

```csharp
using var flickr = new FlickrClient("apiKey", "secret");
```

Note: `FlickrClient` now implements `IDisposable` when constructed directly. Use `using` or dispose manually.

### Cache System

The custom file-based cache (`PersistentCache`, `LockFile`, `.dat` files) has been replaced with optional `HybridCache` integration.

```diff
- var config = new FlickrConfiguration
- {
-     ApiKey = "...",
-     CacheDisabled = false,
-     CacheTimeout = TimeSpan.FromMinutes(5),
-     CacheLocation = "/tmp/flickr-cache",
-     CacheSize = 52428800
- };
- var flickr = new Flickr(config);
+ services.AddFlickr(o =>
+ {
+     o.ApiKey = "...";
+ });
+ services.AddFlickrCaching(o =>
+ {
+     o.DefaultEntryOptions = new() { Expiration = TimeSpan.FromMinutes(5) };
+ });
```

**Removed properties** from `FlickrConfiguration`:
- `CacheDisabled` — caching is now opt-in, not opt-out
- `CacheTimeout` — use `HybridCacheEntryOptions.Expiration` instead
- `CacheLocation` — no longer file-based
- `CacheSize` — managed automatically by `HybridCache`

**Removed types:**
- `FlickrCachingSettings`
- `Cache`, `PersistentCache`, `LockFile`, `ICacheItem`, `ResponseCacheItem`

**No caching by default.** Call `AddFlickrCaching()` to enable it. Without DI, there is no caching — this matches the old behavior where `CacheTimeout` defaulted to `TimeSpan.MinValue` (effectively always expired).

### New Sub-Interface Properties

`IFlickrClient` now exposes all 38 API sub-interfaces including nested ones that were previously only accessible via casting:

```csharp
// These are new on IFlickrClient:
flickr.GroupsDiscuss
flickr.GroupsDiscussReplies
flickr.GroupsDiscussTopics
flickr.GroupsMembers
flickr.GroupsPools
flickr.PhotosComments
flickr.PhotosGeo
flickr.PhotosLicenses
flickr.PhotosMisc
flickr.PhotosNotes
flickr.PhotosPeople
flickr.PhotosSuggestions
flickr.PhotosetsComments
```

### FlickrResponder

`FlickrResponder` is now `internal`. If you were referencing it directly, use `IFlickrClient` methods instead.
