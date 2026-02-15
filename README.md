# Flickr.Net

[![NuGet](https://img.shields.io/nuget/v/Flickr.Net.svg)](https://www.nuget.org/packages/Flickr.Net/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Flickr.Net.svg)](https://www.nuget.org/packages/Flickr.Net/)
[![License](https://img.shields.io/github/license/st0o0/Flickr.Net.svg)](LICENSE)

A modern, fully-featured .NET client library for the Flickr API with comprehensive support for photos, albums, galleries, and user management.

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
- 🔄 **Rate Limiting** - Built-in rate limit handling

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

### Authentication

```csharp
using Flickr.Net;

// Initialize with API key
var flickr = new FlickrNet("your-api-key", "your-api-secret");

// OAuth authentication
var requestToken = await flickr.OAuthGetRequestTokenAsync("oob");
var authUrl = flickr.OAuthCalculateAuthorizationUrl(requestToken.Token, AuthLevel.Read);

// Open authUrl in browser, get verification code
var accessToken = await flickr.OAuthGetAccessTokenAsync(requestToken, "verification-code");

// Now you're authenticated!
```

### Search Photos

```csharp
var options = new PhotoSearchOptions
{
    Text = "sunset",
    Tags = "nature,landscape",
    PerPage = 20,
    Page = 1,
    Extras = PhotoSearchExtras.All
};

var photos = await flickr.PhotosSearchAsync(options);

foreach (var photo in photos.Photos)
{
    Console.WriteLine($"{photo.Title} by {photo.OwnerName}");
    Console.WriteLine($"URL: {photo.LargeUrl}");
}
```

### Upload Photos

```csharp
var uploadOptions = new UploadOptions
{
    Title = "My Vacation Photo",
    Description = "Beautiful sunset at the beach",
    Tags = new[] { "vacation", "sunset", "beach" },
    IsPublic = true,
    IsFamily = false,
    IsFriend = false
};

var photoId = await flickr.UploadPictureAsync("path/to/photo.jpg", uploadOptions);
Console.WriteLine($"Photo uploaded with ID: {photoId}");
```

### Get User Photos

```csharp
var userId = "123456789@N00"; // Flickr user ID
var photos = await flickr.PeopleGetPhotosAsync(userId, SafetyLevel.Safe, 1, 50);

foreach (var photo in photos.Photos)
{
    Console.WriteLine($"{photo.Title} - {photo.DateTaken}");
}
```

### Manage Albums

```csharp
// Create an album
var albumId = await flickr.PhotosetsCreateAsync("Vacation 2024", "Summer vacation photos", "primary-photo-id");

// Add photos to album
await flickr.PhotosetsAddPhotoAsync(albumId, "photo-id-1");
await flickr.PhotosetsAddPhotoAsync(albumId, "photo-id-2");

// Get album photos
var albumPhotos = await flickr.PhotosetsGetPhotosAsync(albumId);
```

## 📚 Advanced Usage

### Custom Photo Search with Filters

```csharp
var searchOptions = new PhotoSearchOptions
{
    UserId = "user-id",
    MinUploadDate = DateTime.Now.AddMonths(-1),
    MaxUploadDate = DateTime.Now,
    MediaType = MediaType.Photos,
    ContentType = ContentType.Photo,
    SafetyLevel = SafetyLevel.Safe,
    SortOrder = PhotoSearchSortOrder.DatePostedDesc,
    PerPage = 100,
    Extras = PhotoSearchExtras.DateUploaded | 
             PhotoSearchExtras.DateTaken | 
             PhotoSearchExtras.Url_O
};

var results = await flickr.PhotosSearchAsync(searchOptions);
```

### Favorites Management

```csharp
// Add to favorites
await flickr.FavoritesAddAsync("photo-id");

// Get user's favorites
var favorites = await flickr.FavoritesGetListAsync("user-id", perPage: 50);

// Remove from favorites
await flickr.FavoritesRemoveAsync("photo-id");
```

### Comments and Notes

```csharp
// Add a comment
var commentId = await flickr.PhotosCommentsAddCommentAsync("photo-id", "Great photo!");

// Get all comments
var comments = await flickr.PhotosCommentsGetListAsync("photo-id");

// Add a note to a photo
await flickr.PhotosNotesAddAsync("photo-id", 100, 100, 50, 50, "This is a note");
```

## 🔧 Configuration

### Rate Limiting

```csharp
var flickr = new FlickrNet("api-key", "api-secret")
{
    HttpTimeout = TimeSpan.FromSeconds(30),
    InstanceCacheDisabled = false
};
```

### Proxy Support

```csharp
var proxy = new WebProxy("proxy-server:port");
flickr.Proxy = proxy;
```

## 📖 Documentation

For detailed API documentation, visit:

- [Flickr API Documentation](https://www.flickr.com/services/api/)
- [Full API Reference](https://github.com/st0o0/Flickr.Net/wiki)

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request. For major changes, please open an issue first to discuss what you would like to change.

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📋 Requirements

- .NET 8.0 or higher
- Flickr API key and secret ([Get yours here](https://www.flickr.com/services/apps/create/))

## 📝 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🙏 Acknowledgments

- Original FlickrNet library by Sam Judson

---

**Built with ❤️ for the .NET
