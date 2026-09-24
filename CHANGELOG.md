# Changelog

## [0.5.0](https://github.com/st0o0/Flickr.Net/compare/v0.4.0...v0.5.0) (2026-09-24)


### ⚠ BREAKING CHANGES

* nullable annotations, XML docs, and init properties across service layer
* seal converters/exceptions, fix JsonException types, modernize SafeNativeMethods removal
* use init-only properties, XML docs, nullable annotations, and sealed types on entities
* replace Newtonsoft.Json with native System.Text.Json XML-to-JSON conversion

### Features

* add missing API methods (getListUserRaw, getAvailable, getPublicPhotos, getLicenseHistory, getMostPopularPhotoDateRange) ([e220fd3](https://github.com/st0o0/Flickr.Net/commit/e220fd37821ff98656bf4e200ea572f29f6665f0))
* implement flickr.places namespace with 15 API methods ([9196469](https://github.com/st0o0/Flickr.Net/commit/91964694bb934c42c2fe4c4889155b2e3f80c997))
* implement flickr.testimonials namespace with 13 API methods ([62a4574](https://github.com/st0o0/Flickr.Net/commit/62a4574192c022257d0a2861480783a9a1036725))
* implement IAsyncDisposable on FlickrClient ([38d442e](https://github.com/st0o0/Flickr.Net/commit/38d442e129895ec9d398db5b9a34f70118690ba7))


### Bug Fixes

* use correct JSON property name _content in ReplacePictureAsync ([71c3c77](https://github.com/st0o0/Flickr.Net/commit/71c3c77b33ee10ef60c5cc6208c15211c4fca66e))
* use softprops/action-gh-release for nupkg upload ([f6ca677](https://github.com/st0o0/Flickr.Net/commit/f6ca6776f5e9a3c3dc1e14da3fc7a7012df4e898))


### Documentation

* add IAsyncDisposable to migration guide ([0de5222](https://github.com/st0o0/Flickr.Net/commit/0de522283ee2900ece01c7d044e8f4b7ca19748d))
* add v0.5.0 migration guide for breaking changes ([cac862a](https://github.com/st0o0/Flickr.Net/commit/cac862ae5f2b87a06b053e442f6e24d6f2dc85b5))
* revamp README with structured sections and more examples ([80a9168](https://github.com/st0o0/Flickr.Net/commit/80a91688149d2c9bf3996cc4f642e4f9ad7efce3))


### Refactoring

* improve internals (stream deserialization, StreamedContent, ConfigureAwait) ([de0e797](https://github.com/st0o0/Flickr.Net/commit/de0e797ddd38e8044f9be5b9a1d2eabf759f242b))
* make FlickrClient URL properties internal for testability ([23d7bab](https://github.com/st0o0/Flickr.Net/commit/23d7babf1f0b7ade8354146647390e91671588c4))
* nullable annotations, XML docs, and init properties across service layer ([0cfc176](https://github.com/st0o0/Flickr.Net/commit/0cfc17645b6fb80897ae70f712c43386fefb4acb))
* replace Newtonsoft.Json with native System.Text.Json XML-to-JSON conversion ([c1f70ac](https://github.com/st0o0/Flickr.Net/commit/c1f70ac838ff645744eb8e458c029c5e54483aae))
* seal converters/exceptions, fix JsonException types, modernize SafeNativeMethods removal ([70fac42](https://github.com/st0o0/Flickr.Net/commit/70fac421ccf50f1d57b20db395a66c9474e3ef62))
* use init-only properties, XML docs, nullable annotations, and sealed types on entities ([1b2894c](https://github.com/st0o0/Flickr.Net/commit/1b2894ce8e5ed043c015152e72ace4089c6fb1ca))

## [0.4.0](https://github.com/st0o0/Flickr.Net/compare/v0.3.6...v0.4.0) (2026-09-23)


### ⚠ BREAKING CHANGES

* modernize DI, HttpClient, caching and rename Flickr to FlickrClient

### Features

* add global.json with SDK roll-forward and MTP runner ([33c8063](https://github.com/st0o0/Flickr.Net/commit/33c80632c966561668c13d49509276f1bf309d32))
* decouple release-please from build workflow ([940126d](https://github.com/st0o0/Flickr.Net/commit/940126d34a9e82dcc5d81165cbcfa40d2d3c3350))
* modernize DI, HttpClient, caching and rename Flickr to FlickrClient ([962378e](https://github.com/st0o0/Flickr.Net/commit/962378ed33293686276ac4acff8049f95d903b0d))


### Bug Fixes

* remove pull_request trigger from CodeQL ([9ba5b40](https://github.com/st0o0/Flickr.Net/commit/9ba5b40dab467122c64af2e9a86beb6cef4ed1db))
* remove top-level permissions restriction breaking release-please ([b6845d2](https://github.com/st0o0/Flickr.Net/commit/b6845d28aecaab2b91b5fdd4cd072b6270878674))


### Documentation

* align README badges ([5017b06](https://github.com/st0o0/Flickr.Net/commit/5017b065b03300e2c3d470a8224343885767f95f))
* fix migration version to v0.4.0 (pre-1.0 semver) ([6449f12](https://github.com/st0o0/Flickr.Net/commit/6449f12fb0f478f0ef01f1d84c2bb52f2afab1b5))
* update README for v2.0 API with DI, FlickrClient and HybridCache ([e38e18f](https://github.com/st0o0/Flickr.Net/commit/e38e18fd9ea81a1d54e30bde2cfc22f4ed2e11fb))


### Refactoring

* Adjust JSON parsing for number formats ([daf3723](https://github.com/st0o0/Flickr.Net/commit/daf3723d230b08440bbdba398f55ed33d06e0ee6))
* migrate to shared reusable workflows ([8794735](https://github.com/st0o0/Flickr.Net/commit/8794735440bd8f9e7692ea0cca2ff7f6f12d68e3))
* rename CI jobs for cleaner GitHub check names ([ed1a291](https://github.com/st0o0/Flickr.Net/commit/ed1a2914ebc8827e6929fcfd1a390db14458282a))
* replace CodeQL with Trivy filesystem scan ([2821fc7](https://github.com/st0o0/Flickr.Net/commit/2821fc7e107aac38288df23e604fc618c0b2112f))
