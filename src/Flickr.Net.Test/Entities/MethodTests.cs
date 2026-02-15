using System.Text;
using Flickr.Net.Flickrs.Results;
using Flickr.Net.Internals;
using Xunit;

namespace Flickr.Net.Test.Entities;

public class MethodTests
{
    [Fact]
    public void JsonStringToMethodInfo()
    {
        const string json = """
                            {
                              "stat": "ok",
                              "method": {
                                "name": "flickr.fakeMethod",
                                "needslogin": "1",
                                "description": "A fake method",
                                "response": "xml-response-example",
                                "explanation": "explanation of example response",
                                "arguments": [
                                  {
                                    "name": "api_key",
                                    "optional": "0",
                                    "_content": "You API application key."
                                  },
                                  {
                                    "name": "color",
                                    "optional": "1",
                                    "_content": "Your favorite color."
                                  }
                                ],
                                "errors": [
                                  {
                                    "code": "1",
                                    "message": "Photo not found",
                                    "_content": "Full explanation..."
                                  },
                                  {
                                    "code": "100",
                                    "message": "Invalid API Key",
                                    "_content": "Full explanation..."
                                  }
                                ]
                              }
                            }
                            """;

        var result = FlickrConvert.DeserializeObject<FlickrResult<MethodInfo>>(Encoding.UTF8.GetBytes(json));

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<MethodInfo>(items);
        Assert.NotEmpty(items.Arguments);
        Assert.NotEmpty(items.Errors);

        Assert.All(items.Arguments, argument =>
        {
            Assert.IsType<string>(argument.Name);
            Assert.IsType<bool>(argument.Optional);
            Assert.IsType<string>(argument.Content);
        });

        Assert.All(items.Errors, error =>
        {
            Assert.IsType<int>(error.Code);
            Assert.IsType<string>(error.Message);
            Assert.IsType<string>(error.Content);
        });
    }

    [Fact]
    public void JsonStringToMethods()
    {
        const string json = """
                            {
                                "methods": {
                                    "method": [
                                        {
                                            "_content": "flickr.activity.userComments"
                                        },
                                        {
                                            "_content": "flickr.activity.userPhotos"
                                        },
                                        {
                                            "_content": "flickr.auth.checkToken"
                                        },
                                        {
                                            "_content": "flickr.auth.getFrob"
                                        },
                                        {
                                            "_content": "flickr.auth.getFullToken"
                                        },
                                        {
                                            "_content": "flickr.auth.getToken"
                                        },
                                        {
                                            "_content": "flickr.auth.oauth.checkToken"
                                        },
                                        {
                                            "_content": "flickr.auth.oauth.getAccessToken"
                                        },
                                        {
                                            "_content": "flickr.blogs.getList"
                                        },
                                        {
                                            "_content": "flickr.blogs.getServices"
                                        },
                                        {
                                            "_content": "flickr.blogs.postPhoto"
                                        },
                                        {
                                            "_content": "flickr.cameras.getBrandModels"
                                        },
                                        {
                                            "_content": "flickr.cameras.getBrands"
                                        },
                                        {
                                            "_content": "flickr.collections.getInfo"
                                        },
                                        {
                                            "_content": "flickr.collections.getTree"
                                        },
                                        {
                                            "_content": "flickr.commons.getInstitutions"
                                        },
                                        {
                                            "_content": "flickr.contacts.getList"
                                        },
                                        {
                                            "_content": "flickr.contacts.getListRecentlyUploaded"
                                        },
                                        {
                                            "_content": "flickr.contacts.getPublicList"
                                        },
                                        {
                                            "_content": "flickr.contacts.getTaggingSuggestions"
                                        },
                                        {
                                            "_content": "flickr.favorites.add"
                                        },
                                        {
                                            "_content": "flickr.favorites.getContext"
                                        },
                                        {
                                            "_content": "flickr.favorites.getList"
                                        },
                                        {
                                            "_content": "flickr.favorites.getPublicList"
                                        },
                                        {
                                            "_content": "flickr.favorites.remove"
                                        },
                                        {
                                            "_content": "flickr.galleries.addPhoto"
                                        },
                                        {
                                            "_content": "flickr.galleries.create"
                                        },
                                        {
                                            "_content": "flickr.galleries.editMeta"
                                        },
                                        {
                                            "_content": "flickr.galleries.editPhoto"
                                        },
                                        {
                                            "_content": "flickr.galleries.editPhotos"
                                        },
                                        {
                                            "_content": "flickr.galleries.getInfo"
                                        },
                                        {
                                            "_content": "flickr.galleries.getList"
                                        },
                                        {
                                            "_content": "flickr.galleries.getListForPhoto"
                                        },
                                        {
                                            "_content": "flickr.galleries.getPhotos"
                                        },
                                        {
                                            "_content": "flickr.galleries.removePhoto"
                                        },
                                        {
                                            "_content": "flickr.groups.discuss.replies.add"
                                        },
                                        {
                                            "_content": "flickr.groups.discuss.replies.delete"
                                        },
                                        {
                                            "_content": "flickr.groups.discuss.replies.edit"
                                        },
                                        {
                                            "_content": "flickr.groups.discuss.replies.getInfo"
                                        },
                                        {
                                            "_content": "flickr.groups.discuss.replies.getList"
                                        },
                                        {
                                            "_content": "flickr.groups.discuss.topics.add"
                                        },
                                        {
                                            "_content": "flickr.groups.discuss.topics.getInfo"
                                        },
                                        {
                                            "_content": "flickr.groups.discuss.topics.getList"
                                        },
                                        {
                                            "_content": "flickr.groups.getInfo"
                                        },
                                        {
                                            "_content": "flickr.groups.join"
                                        },
                                        {
                                            "_content": "flickr.groups.joinRequest"
                                        },
                                        {
                                            "_content": "flickr.groups.leave"
                                        },
                                        {
                                            "_content": "flickr.groups.members.getList"
                                        },
                                        {
                                            "_content": "flickr.groups.pools.add"
                                        },
                                        {
                                            "_content": "flickr.groups.pools.getContext"
                                        },
                                        {
                                            "_content": "flickr.groups.pools.getGroups"
                                        },
                                        {
                                            "_content": "flickr.groups.pools.getPhotos"
                                        },
                                        {
                                            "_content": "flickr.groups.pools.remove"
                                        },
                                        {
                                            "_content": "flickr.groups.search"
                                        },
                                        {
                                            "_content": "flickr.interestingness.getList"
                                        },
                                        {
                                            "_content": "flickr.machinetags.getNamespaces"
                                        },
                                        {
                                            "_content": "flickr.machinetags.getPairs"
                                        },
                                        {
                                            "_content": "flickr.machinetags.getPredicates"
                                        },
                                        {
                                            "_content": "flickr.machinetags.getRecentValues"
                                        },
                                        {
                                            "_content": "flickr.machinetags.getValues"
                                        },
                                        {
                                            "_content": "flickr.panda.getList"
                                        },
                                        {
                                            "_content": "flickr.panda.getPhotos"
                                        },
                                        {
                                            "_content": "flickr.people.findByEmail"
                                        },
                                        {
                                            "_content": "flickr.people.findByUsername"
                                        },
                                        {
                                            "_content": "flickr.people.getGroups"
                                        },
                                        {
                                            "_content": "flickr.people.getInfo"
                                        },
                                        {
                                            "_content": "flickr.people.getLimits"
                                        },
                                        {
                                            "_content": "flickr.people.getPhotos"
                                        },
                                        {
                                            "_content": "flickr.people.getPhotosOf"
                                        },
                                        {
                                            "_content": "flickr.people.getPublicGroups"
                                        },
                                        {
                                            "_content": "flickr.people.getPublicPhotos"
                                        },
                                        {
                                            "_content": "flickr.people.getUploadStatus"
                                        },
                                        {
                                            "_content": "flickr.photos.addTags"
                                        },
                                        {
                                            "_content": "flickr.photos.comments.addComment"
                                        },
                                        {
                                            "_content": "flickr.photos.comments.deleteComment"
                                        },
                                        {
                                            "_content": "flickr.photos.comments.editComment"
                                        },
                                        {
                                            "_content": "flickr.photos.comments.getList"
                                        },
                                        {
                                            "_content": "flickr.photos.comments.getRecentForContacts"
                                        },
                                        {
                                            "_content": "flickr.photos.delete"
                                        },
                                        {
                                            "_content": "flickr.photos.geo.batchCorrectLocation"
                                        },
                                        {
                                            "_content": "flickr.photos.geo.correctLocation"
                                        },
                                        {
                                            "_content": "flickr.photos.geo.getLocation"
                                        },
                                        {
                                            "_content": "flickr.photos.geo.getPerms"
                                        },
                                        {
                                            "_content": "flickr.photos.geo.photosForLocation"
                                        },
                                        {
                                            "_content": "flickr.photos.geo.removeLocation"
                                        },
                                        {
                                            "_content": "flickr.photos.geo.setContext"
                                        },
                                        {
                                            "_content": "flickr.photos.geo.setLocation"
                                        },
                                        {
                                            "_content": "flickr.photos.geo.setPerms"
                                        },
                                        {
                                            "_content": "flickr.photos.getAllContexts"
                                        },
                                        {
                                            "_content": "flickr.photos.getContactsPhotos"
                                        },
                                        {
                                            "_content": "flickr.photos.getContactsPublicPhotos"
                                        },
                                        {
                                            "_content": "flickr.photos.getContext"
                                        },
                                        {
                                            "_content": "flickr.photos.getCounts"
                                        },
                                        {
                                            "_content": "flickr.photos.getExif"
                                        },
                                        {
                                            "_content": "flickr.photos.getFavorites"
                                        },
                                        {
                                            "_content": "flickr.photos.getInfo"
                                        },
                                        {
                                            "_content": "flickr.photos.getNotInSet"
                                        },
                                        {
                                            "_content": "flickr.photos.getPerms"
                                        },
                                        {
                                            "_content": "flickr.photos.getPopular"
                                        },
                                        {
                                            "_content": "flickr.photos.getRecent"
                                        },
                                        {
                                            "_content": "flickr.photos.getSizes"
                                        },
                                        {
                                            "_content": "flickr.photos.getUntagged"
                                        },
                                        {
                                            "_content": "flickr.photos.getWithGeoData"
                                        },
                                        {
                                            "_content": "flickr.photos.getWithoutGeoData"
                                        },
                                        {
                                            "_content": "flickr.photos.licenses.getInfo"
                                        },
                                        {
                                            "_content": "flickr.photos.licenses.setLicense"
                                        },
                                        {
                                            "_content": "flickr.photos.licenses.getLicenseHistory"
                                        },
                                        {
                                            "_content": "flickr.photos.notes.add"
                                        },
                                        {
                                            "_content": "flickr.photos.notes.delete"
                                        },
                                        {
                                            "_content": "flickr.photos.notes.edit"
                                        },
                                        {
                                            "_content": "flickr.photos.people.add"
                                        },
                                        {
                                            "_content": "flickr.photos.people.delete"
                                        },
                                        {
                                            "_content": "flickr.photos.people.deleteCoords"
                                        },
                                        {
                                            "_content": "flickr.photos.people.editCoords"
                                        },
                                        {
                                            "_content": "flickr.photos.people.getList"
                                        },
                                        {
                                            "_content": "flickr.photos.recentlyUpdated"
                                        },
                                        {
                                            "_content": "flickr.photos.removeTag"
                                        },
                                        {
                                            "_content": "flickr.photos.search"
                                        },
                                        {
                                            "_content": "flickr.photos.setContentType"
                                        },
                                        {
                                            "_content": "flickr.photos.setDates"
                                        },
                                        {
                                            "_content": "flickr.photos.setMeta"
                                        },
                                        {
                                            "_content": "flickr.photos.setPerms"
                                        },
                                        {
                                            "_content": "flickr.photos.setSafetyLevel"
                                        },
                                        {
                                            "_content": "flickr.photos.setTags"
                                        },
                                        {
                                            "_content": "flickr.photos.suggestions.approveSuggestion"
                                        },
                                        {
                                            "_content": "flickr.photos.suggestions.getList"
                                        },
                                        {
                                            "_content": "flickr.photos.suggestions.rejectSuggestion"
                                        },
                                        {
                                            "_content": "flickr.photos.suggestions.removeSuggestion"
                                        },
                                        {
                                            "_content": "flickr.photos.suggestions.suggestLocation"
                                        },
                                        {
                                            "_content": "flickr.photos.transform.rotate"
                                        },
                                        {
                                            "_content": "flickr.photos.upload.checkTickets"
                                        },
                                        {
                                            "_content": "flickr.photosets.addPhoto"
                                        },
                                        {
                                            "_content": "flickr.photosets.comments.addComment"
                                        },
                                        {
                                            "_content": "flickr.photosets.comments.deleteComment"
                                        },
                                        {
                                            "_content": "flickr.photosets.comments.editComment"
                                        },
                                        {
                                            "_content": "flickr.photosets.comments.getList"
                                        },
                                        {
                                            "_content": "flickr.photosets.create"
                                        },
                                        {
                                            "_content": "flickr.photosets.delete"
                                        },
                                        {
                                            "_content": "flickr.photosets.editMeta"
                                        },
                                        {
                                            "_content": "flickr.photosets.editPhotos"
                                        },
                                        {
                                            "_content": "flickr.photosets.getContext"
                                        },
                                        {
                                            "_content": "flickr.photosets.getInfo"
                                        },
                                        {
                                            "_content": "flickr.photosets.getList"
                                        },
                                        {
                                            "_content": "flickr.photosets.getPhotos"
                                        },
                                        {
                                            "_content": "flickr.photosets.orderSets"
                                        },
                                        {
                                            "_content": "flickr.photosets.removePhoto"
                                        },
                                        {
                                            "_content": "flickr.photosets.removePhotos"
                                        },
                                        {
                                            "_content": "flickr.photosets.reorderPhotos"
                                        },
                                        {
                                            "_content": "flickr.photosets.setPrimaryPhoto"
                                        },
                                        {
                                            "_content": "flickr.places.find"
                                        },
                                        {
                                            "_content": "flickr.places.findByLatLon"
                                        },
                                        {
                                            "_content": "flickr.places.getChildrenWithPhotosPublic"
                                        },
                                        {
                                            "_content": "flickr.places.getInfo"
                                        },
                                        {
                                            "_content": "flickr.places.getInfoByUrl"
                                        },
                                        {
                                            "_content": "flickr.places.getPlaceTypes"
                                        },
                                        {
                                            "_content": "flickr.places.getShapeHistory"
                                        },
                                        {
                                            "_content": "flickr.places.getTopPlacesList"
                                        },
                                        {
                                            "_content": "flickr.places.placesForBoundingBox"
                                        },
                                        {
                                            "_content": "flickr.places.placesForContacts"
                                        },
                                        {
                                            "_content": "flickr.places.placesForTags"
                                        },
                                        {
                                            "_content": "flickr.places.placesForUser"
                                        },
                                        {
                                            "_content": "flickr.places.resolvePlaceId"
                                        },
                                        {
                                            "_content": "flickr.places.resolvePlaceURL"
                                        },
                                        {
                                            "_content": "flickr.places.tagsForPlace"
                                        },
                                        {
                                            "_content": "flickr.prefs.getContentType"
                                        },
                                        {
                                            "_content": "flickr.prefs.getGeoPerms"
                                        },
                                        {
                                            "_content": "flickr.prefs.getHidden"
                                        },
                                        {
                                            "_content": "flickr.prefs.getPrivacy"
                                        },
                                        {
                                            "_content": "flickr.prefs.getSafetyLevel"
                                        },
                                        {
                                            "_content": "flickr.profile.getProfile"
                                        },
                                        {
                                            "_content": "flickr.push.getSubscriptions"
                                        },
                                        {
                                            "_content": "flickr.push.getTopics"
                                        },
                                        {
                                            "_content": "flickr.push.subscribe"
                                        },
                                        {
                                            "_content": "flickr.push.unsubscribe"
                                        },
                                        {
                                            "_content": "flickr.reflection.getMethodInfo"
                                        },
                                        {
                                            "_content": "flickr.reflection.getMethods"
                                        },
                                        {
                                            "_content": "flickr.stats.getCollectionDomains"
                                        },
                                        {
                                            "_content": "flickr.stats.getCollectionReferrers"
                                        },
                                        {
                                            "_content": "flickr.stats.getCollectionStats"
                                        },
                                        {
                                            "_content": "flickr.stats.getCSVFiles"
                                        },
                                        {
                                            "_content": "flickr.stats.getMostPopularPhotoDateRange"
                                        },
                                        {
                                            "_content": "flickr.stats.getPhotoDomains"
                                        },
                                        {
                                            "_content": "flickr.stats.getPhotoReferrers"
                                        },
                                        {
                                            "_content": "flickr.stats.getPhotosetDomains"
                                        },
                                        {
                                            "_content": "flickr.stats.getPhotosetReferrers"
                                        },
                                        {
                                            "_content": "flickr.stats.getPhotosetStats"
                                        },
                                        {
                                            "_content": "flickr.stats.getPhotoStats"
                                        },
                                        {
                                            "_content": "flickr.stats.getPhotostreamDomains"
                                        },
                                        {
                                            "_content": "flickr.stats.getPhotostreamReferrers"
                                        },
                                        {
                                            "_content": "flickr.stats.getPhotostreamStats"
                                        },
                                        {
                                            "_content": "flickr.stats.getPopularPhotos"
                                        },
                                        {
                                            "_content": "flickr.stats.getTotalViews"
                                        },
                                        {
                                            "_content": "flickr.tags.getClusterPhotos"
                                        },
                                        {
                                            "_content": "flickr.tags.getClusters"
                                        },
                                        {
                                            "_content": "flickr.tags.getHotList"
                                        },
                                        {
                                            "_content": "flickr.tags.getListPhoto"
                                        },
                                        {
                                            "_content": "flickr.tags.getListUser"
                                        },
                                        {
                                            "_content": "flickr.tags.getListUserPopular"
                                        },
                                        {
                                            "_content": "flickr.tags.getListUserRaw"
                                        },
                                        {
                                            "_content": "flickr.tags.getMostFrequentlyUsed"
                                        },
                                        {
                                            "_content": "flickr.tags.getRelated"
                                        },
                                        {
                                            "_content": "flickr.test.echo"
                                        },
                                        {
                                            "_content": "flickr.test.login"
                                        },
                                        {
                                            "_content": "flickr.test.null"
                                        },
                                        {
                                            "_content": "flickr.testimonials.addTestimonial"
                                        },
                                        {
                                            "_content": "flickr.testimonials.approveTestimonial"
                                        },
                                        {
                                            "_content": "flickr.testimonials.deleteTestimonial"
                                        },
                                        {
                                            "_content": "flickr.testimonials.editTestimonial"
                                        },
                                        {
                                            "_content": "flickr.testimonials.getAllTestimonialsAbout"
                                        },
                                        {
                                            "_content": "flickr.testimonials.getAllTestimonialsAboutBy"
                                        },
                                        {
                                            "_content": "flickr.testimonials.getAllTestimonialsBy"
                                        },
                                        {
                                            "_content": "flickr.testimonials.getPendingTestimonialsAbout"
                                        },
                                        {
                                            "_content": "flickr.testimonials.getPendingTestimonialsAboutBy"
                                        },
                                        {
                                            "_content": "flickr.testimonials.getPendingTestimonialsBy"
                                        },
                                        {
                                            "_content": "flickr.testimonials.getTestimonialsAbout"
                                        },
                                        {
                                            "_content": "flickr.testimonials.getTestimonialsAboutBy"
                                        },
                                        {
                                            "_content": "flickr.testimonials.getTestimonialsBy"
                                        },
                                        {
                                            "_content": "flickr.urls.getGroup"
                                        },
                                        {
                                            "_content": "flickr.urls.getUserPhotos"
                                        },
                                        {
                                            "_content": "flickr.urls.getUserProfile"
                                        },
                                        {
                                            "_content": "flickr.urls.lookupGallery"
                                        },
                                        {
                                            "_content": "flickr.urls.lookupGroup"
                                        },
                                        {
                                            "_content": "flickr.urls.lookupUser"
                                        }
                                    ]
                                },
                                "stat": "ok"
                            }
                            """;

        var result = FlickrConvert.DeserializeObject<FlickrResult<Methods>>(Encoding.UTF8.GetBytes(json));

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<Methods>(items);
        Assert.NotEmpty(items.Values);

        Assert.All(items.Values, value =>
        {
            Assert.IsType<Method>(value);
            Assert.Contains("flickr.", value);
        });
    }
}