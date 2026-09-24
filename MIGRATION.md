# Migration Guide

## v0.5.0

### Newtonsoft.Json removed

The `Newtonsoft.Json` dependency has been completely removed. All JSON handling now uses `System.Text.Json`.

If you were using `Newtonsoft.Json` types that came transitively through Flickr.Net, add the package to your own project:

```xml
<PackageReference Include="Newtonsoft.Json" Version="13.0.4" />
```

The internal XML-to-JSON conversion now uses `_content` for mixed text/attribute elements instead of `#text`. This only affects you if you were parsing raw `FlickrExtendedDataResult.Content` JSON elements directly.

### Entity properties are now init-only

All entity record properties changed from `{ get; set; }` to `{ get; init; }`. This makes entities immutable after deserialization.

```diff
- photo.Title = "new title";  // no longer compiles
+ var updated = photo with { Title = "new title" };  // use with-expression
```

This also applies to `FlickrResult`, `FlickrContextResult`, and related result types.

### FlickrConfiguration properties are now required

`ApiKey` and `SharedSecret` on `FlickrConfiguration` are now `required` properties:

```diff
- var config = new FlickrConfiguration();
- config.ApiKey = "key";
+ var config = new FlickrConfiguration { ApiKey = "key", SharedSecret = "secret" };
```

### Nullable reference type annotations

All public API surface now has proper nullable annotations. Properties that may be `null` (e.g. optional API response fields) are now typed as `string?`, `int?`, etc. This may cause new compiler warnings in your code if you have `<Nullable>enable</Nullable>`.

### Sealed exception and converter classes

All leaf exception classes (e.g. `PhotoNotFoundException`, `UserNotFoundException`) and JSON converter classes are now `sealed`. If you were inheriting from these, use composition instead.

**Sealed exceptions:** `ApiKeyRequiredException`, `AuthenticationRequiredException`, `CacheException`, `FlickrWebException`, `InvalidApiKeyException`, `InvalidSignatureException`, `LoginFailedInvalidTokenException`, `MissingSignatureException`, `OAuthException`, `ParsingException`, `PermissionDeniedException`, `PhotoNotFoundException`, `PhotosetNotFoundException`, `ResponseXmlException`, `ServiceUnavailableException`, `SignatureRequiredException`, `UserNotFoundException`, `UserNotLoggedInInsufficientPermissionsException`.

**Not sealed** (base classes): `FlickrException`, `FlickrApiException`.

### IAsyncDisposable support

`IFlickrClient` now implements `IAsyncDisposable` in addition to `IDisposable`. Use `await using` for async disposal:

```diff
- using var flickr = new FlickrClient("apiKey", "secret");
+ await using var flickr = new FlickrClient("apiKey", "secret");
```

`using` still works — this is additive, not a removal.

### Removed types

- `SafeNativeMethods` — unused internal class, removed entirely.

### New API coverage

New sub-interfaces added to `IFlickrClient`:

```csharp
flickr.Places         // flickr.places.* — 15 methods
flickr.Testimonials   // flickr.testimonials.* — 13 methods
```

New methods on existing interfaces:

- `IFlickrTags.GetListUserRawAsync()` — `flickr.tags.getListUserRaw`
- `IFlickrPhotosLicenses.GetAvailableAsync()` — `flickr.photos.licenses.getAvailable`
- `IFlickrPhotosLicenses.GetLicenseHistoryAsync()` — `flickr.photos.licenses.getLicenseHistory`
- `IFlickrPeople.GetPublicPhotosAsync()` — `flickr.people.getPublicPhotos`
- `IFlickrStats.GetMostPopularPhotoDateRangeAsync()` — `flickr.stats.getMostPopularPhotoDateRange`

### New entity properties

**Photo** — 22 new extras properties: `CountFaves`, `CountComments`, `Media`, `MediaStatus`, `PathAlias`, `OwnerName`, `Views`, `License`, `MachineTags`, `OriginalFormat`, `OriginalSecret`, `Rotation`, `LastUpdate`, `Accuracy`, `Context`, `PlaceId`, `WoeId`, `GeoIsFamily`, `GeoIsFriend`, `GeoIsContact`, `GeoIsPublic`, `IconServer`, `IconFarm`.

**Person** — `PathAlias` type fixed (`object` → `string?`), 6 new relationship fields: `Contact`, `Friend`, `Family`, `RevContact`, `RevFriend`, `RevFamily`.

**Contact** — 3 new fields: `RevContact`, `RevFriend`, `RevFamily`.

**GroupInfo** — 2 new fields: `PoolCount`, `TopicCount`.

**PhotoInfo** — new `Permissions` property (`PhotoPermissions` record).

### Naming consistency fixes

- `PeoplePerson.Iconserver` → `IconServer`, `PeoplePerson.Iconfarm` → `IconFarm`
- `Topic.Iconserver` → `IconServer`, `Topic.Iconfarm` → `IconFarm`

The `[JsonPropertyName]` attributes are unchanged, so API deserialization is not affected.

---

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
