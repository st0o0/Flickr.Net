# Changelog

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
