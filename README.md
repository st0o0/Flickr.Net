# Flickr.Net

[![NuGet](https://img.shields.io/nuget/v/Flickr.Net.svg?style=flat-square)](https://www.nuget.org/packages/Flickr.Net/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Flickr.Net.svg?style=flat-square)](https://www.nuget.org/packages/Flickr.Net/)
[![License: Apache-2.0](https://img.shields.io/badge/License-Apache--2.0-blue.svg?style=flat-square)](LICENSE)

A modern, fully-featured .NET client library for the Flickr API with dependency injection, `IHttpClientFactory` integration, and optional `HybridCache` support.

## ✨ Features

- 🖼️ **Photo Management** - Upload, download, search, and organize photos
- 📚 **Albums & Collections** - Create and manage photo albums and collections
- 🎨 **Galleries** - Browse and interact with Flickr galleries
- 👥 **User Management** - Access user profiles, contacts, and favorites
- 🔍 **Advanced Search** - Powerful search capabilities with filtering
- 🏷️ **Tags & Metadata** - Full support for tags, EXIF data, and metadata
- 🔐 **OAuth Authentication** - Secure authentication with OAuth 1.0a
- ⚡ **Async/Await** - Modern async API throughout
- 📦 **Strongly Typed** - Type-safe API with comprehensive models
- 💉 **Dependency Injection** - First-class DI support with `IHttpClientFactory`
- 🗄️ **Optional Caching** - Opt-in response caching via `HybridCache`

## 📦 Installation

Install via NuGet Package Manager:

```bash
dotnet add package Flickr.Net
```

Or via Package Manager Console:

```powershell
Install-Package Flickr.Net
```

## 🚀 Quick Start

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

## 🔐 Authentication

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

## 🔍 Search Photos

```csharp
var options = new PhotoSearchOptions
{
    Text = "sunset",
    Tags = "nature,landscape",
    PerPage = 20,
    Extras = PhotoSearchExtras.DateTaken | PhotoSearchExtras.Description
};

var photos = await flickr.Photos.SearchAsync(options);

foreach (var photo in photos)
{
    Console.WriteLine($"{photo.Title} by {photo.OwnerName}");
}
```

## 🖼️ Upload Photos

```csharp
await using var stream = File.OpenRead("photo.jpg");
var photoId = await flickr.Upload.UploadPictureAsync(
    stream,
    "photo.jpg",
    title: "Sunset at the beach",
    tags: "sunset beach vacation",
    isPublic: true);
```

## 📚 Manage Albums

```csharp
// Create an album
var album = await flickr.Photosets.CreateAsync("Vacation 2024", "primary-photo-id");

// Add photos to album
await flickr.Photosets.AddPhotoAsync(album.PhotosetId, "photo-id");

// Get album photos
var albumPhotos = await flickr.Photosets.GetPhotosAsync(album.PhotosetId);
```

## ⭐ Favorites

```csharp
// Add to favorites
await flickr.Favorites.AddAsync("photo-id");

// Get user's favorites
var favorites = await flickr.Favorites.GetListAsync();

// Remove from favorites
await flickr.Favorites.RemoveAsync("photo-id");
```

## 💬 Comments & Notes

```csharp
// Add a comment
var commentId = await flickr.PhotosComments.AddCommentAsync("photo-id", "Great photo!");

// Get all comments
var comments = await flickr.PhotosComments.GetListAsync("photo-id");

// Add a note to a photo
await flickr.PhotosNotes.AddAsync("photo-id", 100, 100, 50, 50, "This is a note");
```

## 📋 API Areas

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
flickr.Places           // Place and location search
flickr.PhotosComments   // Photo comments
flickr.PhotosGeo        // Geolocation data
flickr.PhotosNotes      // Photo annotations
flickr.Interestingness  // Interesting photos
flickr.MachineTags      // Machine tag operations
// ... and more
```

## 🗄️ Caching

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

## 🔧 Configuration

### Default Search Extras

Configure extras that are automatically included in every search:

```csharp
services.AddFlickr(o =>
{
    o.ApiKey = "...";
    o.SharedSecret = "...";
    o.DefaultSearchExtras = PhotoSearchExtras.Description | PhotoSearchExtras.DateTaken;
});
```

## 📖 Migration

Upgrading from an earlier version? See the [Migration Guide](MIGRATION.md) for breaking changes and upgrade steps.

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request. For major changes, please open an issue first to discuss what you would like to change.

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📋 Requirements

- .NET 10.0 or higher
- Flickr API key and secret ([Get yours here](https://www.flickr.com/services/apps/create/))

## 📝 License

This project is licensed under the Apache License 2.0 - see the [LICENSE](LICENSE) file for details.

## 🙏 Acknowledgments

- Original FlickrNet library by Sam Judson
