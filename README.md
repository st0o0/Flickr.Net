# Flickr.Net

[![CI](https://img.shields.io/github/actions/workflow/status/st0o0/Flickr.Net/ci.yml?style=flat-square&label=CI)](https://github.com/st0o0/Flickr.Net/actions/workflows/ci.yml)
[![NuGet](https://img.shields.io/nuget/v/Flickr.Net.svg?style=flat-square)](https://www.nuget.org/packages/Flickr.Net/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Flickr.Net.svg?style=flat-square)](https://www.nuget.org/packages/Flickr.Net/)
[![License: Apache-2.0](https://img.shields.io/badge/License-Apache--2.0-blue.svg?style=flat-square)](LICENSE)

A modern .NET 10 client library for the Flickr API with dependency injection, `IHttpClientFactory` integration, and optional `HybridCache` support.

## Installation

```bash
dotnet add package Flickr.Net
```

## Quick Start

### With Dependency Injection (recommended)

```csharp
// Program.cs
services.AddFlickr(o =>
{
    o.ApiKey = "your-api-key";
    o.SharedSecret = "your-shared-secret";
});

// Optional: enable response caching
services.AddFlickrCaching();
```

```csharp
// Inject IFlickrClient anywhere
public class PhotoService(IFlickrClient flickr)
{
    public async Task<Photo> GetPhotoAsync(string id, CancellationToken ct)
    {
        return await flickr.Photos.GetInfoAsync(id, ct);
    }
}
```

### Without DI

```csharp
using var flickr = new FlickrClient("your-api-key", "your-shared-secret");
```

## API Areas

`IFlickrClient` organizes the Flickr API into sub-clients:

```csharp
flickr.Photos          // Search, get info, manage photos
flickr.Photosets        // Albums / photosets
flickr.People           // User profiles, find by email/username
flickr.Favorites        // Add, remove, list favorites
flickr.Groups           // Browse and manage groups
flickr.GroupsPools       // Group photo pools
flickr.Tags             // Tag management and search
flickr.Galleries        // Gallery operations
flickr.Contacts         // Contact management
flickr.Upload           // Upload and replace photos
flickr.OAuth            // OAuth 1.0a authentication flow
flickr.Stats            // View counts and referrers
flickr.PhotosComments   // Photo comments
flickr.PhotosGeo        // Geolocation data
flickr.PhotosNotes      // Photo annotations
flickr.Interestingness  // Interesting photos
flickr.MachineTags      // Machine tag operations
// ... and 20+ more
```

## Authentication

```csharp
// 1. Get a request token
var requestToken = await flickr.OAuth.GetRequestTokenAsync("https://your-callback-url");

// 2. Send user to Flickr authorization page
var authUrl = $"https://www.flickr.com/services/oauth/authorize?oauth_token={requestToken.Token}";

// 3. After user authorizes, exchange for access token
var accessToken = await flickr.OAuth.GetAccessTokenAsync(requestToken, "verifier-code");

// 4. Store and set the tokens for future requests
flickr.FlickrSettings.OAuthAccessToken = accessToken.Token;
flickr.FlickrSettings.OAuthAccessTokenSecret = accessToken.TokenSecret;
```

## Search Photos

```csharp
var options = new PhotoSearchOptions
{
    Text = "sunset",
    Tags = "nature,landscape",
    PerPage = 20,
    Extras = PhotoSearchExtras.DateTaken | PhotoSearchExtras.Description
};

var photos = await flickr.Photos.SearchAsync(options);
```

## Upload Photos

```csharp
await using var stream = File.OpenRead("photo.jpg");
var photoId = await flickr.Upload.UploadPictureAsync(
    stream,
    "photo.jpg",
    title: "Sunset at the beach",
    tags: "sunset beach vacation",
    isPublic: true);
```

## Caching

Response caching is opt-in via `HybridCache`:

```csharp
// Basic in-memory caching
services.AddFlickrCaching();

// With custom expiration
services.AddFlickrCaching(o =>
{
    o.DefaultEntryOptions = new() { Expiration = TimeSpan.FromMinutes(10) };
});

// With distributed L2 cache (e.g. Redis)
services.AddFlickrCaching();
services.AddStackExchangeRedisCache(o => o.Configuration = "localhost:6379");
```

Without `AddFlickrCaching()`, every API call goes directly to Flickr — no caching overhead.

## Default Search Extras

Configure extras that are automatically included in every search:

```csharp
services.AddFlickr(o =>
{
    o.ApiKey = "...";
    o.DefaultSearchExtras = PhotoSearchExtras.Description | PhotoSearchExtras.DateTaken;
});
```

## Migration

Upgrading from v1.x? See the [Migration Guide](MIGRATION.md).

## Requirements

- .NET 10.0 or higher
- Flickr API key and secret ([Get yours here](https://www.flickr.com/services/apps/create/))

## License

This project is licensed under the Apache License 2.0 - see the [LICENSE](LICENSE) file for details.

## Acknowledgments

- Original FlickrNet library by Sam Judson
