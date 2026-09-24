using System.Globalization;
using Flickr.Net.Internals.Extensions;

namespace Flickr.Net;

/// <summary>
/// Implementation of the flickr.testimonials.* API methods.
/// </summary>
public sealed partial class FlickrClient : IFlickrTestimonials
{
    async Task IFlickrTestimonials.AddTestimonialAsync(string userId, string text, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.testimonials.addTestimonial" },
            { "user_id", userId },
            { "testimonial_text", text }
        };

        await GetResponseAsync(parameters, cancellationToken).ConfigureAwait(false);
    }

    async Task IFlickrTestimonials.ApproveTestimonialAsync(string testimonialId, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.testimonials.approveTestimonial" },
            { "testimonial_id", testimonialId }
        };

        await GetResponseAsync(parameters, cancellationToken).ConfigureAwait(false);
    }

    async Task IFlickrTestimonials.DeleteTestimonialAsync(string testimonialId, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.testimonials.deleteTestimonial" },
            { "testimonial_id", testimonialId }
        };

        await GetResponseAsync(parameters, cancellationToken).ConfigureAwait(false);
    }

    async Task IFlickrTestimonials.EditTestimonialAsync(string userId, string testimonialId, string text, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.testimonials.editTestimonial" },
            { "user_id", userId },
            { "testimonial_id", testimonialId },
            { "testimonial_text", text }
        };

        await GetResponseAsync(parameters, cancellationToken).ConfigureAwait(false);
    }

    async Task<Testimonials> IFlickrTestimonials.GetAllTestimonialsAboutAsync(string userId, int? page, int? perPage, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.testimonials.getAllTestimonialsAbout" },
            { "user_id", userId }
        };

        parameters.AppendIf("page", page, x => x is > 0, x => x!.Value.ToString(NumberFormatInfo.InvariantInfo));
        parameters.AppendIf("per_page", perPage, x => x is > 0, x => x!.Value.ToString(NumberFormatInfo.InvariantInfo));

        return await GetResponseAsync<Testimonials>(parameters, cancellationToken).ConfigureAwait(false);
    }

    async Task<Testimonials> IFlickrTestimonials.GetAllTestimonialsAboutByAsync(string userId, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.testimonials.getAllTestimonialsAboutBy" },
            { "user_id", userId }
        };

        return await GetResponseAsync<Testimonials>(parameters, cancellationToken).ConfigureAwait(false);
    }

    async Task<Testimonials> IFlickrTestimonials.GetAllTestimonialsByAsync(string userId, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.testimonials.getAllTestimonialsBy" },
            { "user_id", userId }
        };

        return await GetResponseAsync<Testimonials>(parameters, cancellationToken).ConfigureAwait(false);
    }

    async Task<Testimonials> IFlickrTestimonials.GetPendingTestimonialsAboutAsync(int? page, int? perPage, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.testimonials.getPendingTestimonialsAbout" }
        };

        parameters.AppendIf("page", page, x => x is > 0, x => x!.Value.ToString(NumberFormatInfo.InvariantInfo));
        parameters.AppendIf("per_page", perPage, x => x is > 0, x => x!.Value.ToString(NumberFormatInfo.InvariantInfo));

        return await GetResponseAsync<Testimonials>(parameters, cancellationToken).ConfigureAwait(false);
    }

    async Task<Testimonials> IFlickrTestimonials.GetPendingTestimonialsAboutByAsync(string userId, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.testimonials.getPendingTestimonialsAboutBy" },
            { "user_id", userId }
        };

        return await GetResponseAsync<Testimonials>(parameters, cancellationToken).ConfigureAwait(false);
    }

    async Task<Testimonials> IFlickrTestimonials.GetPendingTestimonialsByAsync(int? page, int? perPage, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.testimonials.getPendingTestimonialsBy" }
        };

        parameters.AppendIf("page", page, x => x is > 0, x => x!.Value.ToString(NumberFormatInfo.InvariantInfo));
        parameters.AppendIf("per_page", perPage, x => x is > 0, x => x!.Value.ToString(NumberFormatInfo.InvariantInfo));

        return await GetResponseAsync<Testimonials>(parameters, cancellationToken).ConfigureAwait(false);
    }

    async Task<Testimonials> IFlickrTestimonials.GetTestimonialsAboutAsync(string userId, int? page, int? perPage, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.testimonials.getTestimonialsAbout" },
            { "user_id", userId }
        };

        parameters.AppendIf("page", page, x => x is > 0, x => x!.Value.ToString(NumberFormatInfo.InvariantInfo));
        parameters.AppendIf("per_page", perPage, x => x is > 0, x => x!.Value.ToString(NumberFormatInfo.InvariantInfo));

        return await GetResponseAsync<Testimonials>(parameters, cancellationToken).ConfigureAwait(false);
    }

    async Task<Testimonials> IFlickrTestimonials.GetTestimonialsAboutByAsync(string userId, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.testimonials.getTestimonialsAboutBy" },
            { "user_id", userId }
        };

        return await GetResponseAsync<Testimonials>(parameters, cancellationToken).ConfigureAwait(false);
    }

    async Task<Testimonials> IFlickrTestimonials.GetTestimonialsByAsync(string userId, int? page, int? perPage, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.testimonials.getTestimonialsBy" },
            { "user_id", userId }
        };

        parameters.AppendIf("page", page, x => x is > 0, x => x!.Value.ToString(NumberFormatInfo.InvariantInfo));
        parameters.AppendIf("per_page", perPage, x => x is > 0, x => x!.Value.ToString(NumberFormatInfo.InvariantInfo));

        return await GetResponseAsync<Testimonials>(parameters, cancellationToken).ConfigureAwait(false);
    }
}

/// <summary>
/// Provides methods for managing user testimonials on Flickr.
/// </summary>
public interface IFlickrTestimonials
{
    /// <summary>
    /// Writes a testimonial for the specified user. Requires authentication.
    /// </summary>
    /// <param name="userId">The NSID of the user to write a testimonial for.</param>
    /// <param name="text">The text of the testimonial.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    Task AddTestimonialAsync(string userId, string text, CancellationToken cancellationToken = default);

    /// <summary>
    /// Approves a pending testimonial written about the authenticated user. Requires authentication.
    /// </summary>
    /// <param name="testimonialId">The ID of the testimonial to approve.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    Task ApproveTestimonialAsync(string testimonialId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a testimonial. The authenticated user must be the author or subject. Requires authentication.
    /// </summary>
    /// <param name="testimonialId">The ID of the testimonial to delete.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    Task DeleteTestimonialAsync(string testimonialId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Edits an existing testimonial written by the authenticated user. Requires authentication.
    /// </summary>
    /// <param name="userId">The NSID of the user the testimonial is about.</param>
    /// <param name="testimonialId">The ID of the testimonial to edit.</param>
    /// <param name="text">The new text of the testimonial.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    Task EditTestimonialAsync(string userId, string testimonialId, string text, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns all testimonials (approved and pending) about the specified user.
    /// </summary>
    /// <param name="userId">The NSID of the user to get testimonials about.</param>
    /// <param name="page">The page of results to return.</param>
    /// <param name="perPage">Number of testimonials per page.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    Task<Testimonials> GetAllTestimonialsAboutAsync(string userId, int? page = null, int? perPage = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns all testimonials about the authenticated user written by the specified user.
    /// </summary>
    /// <param name="userId">The NSID of the user who wrote the testimonials.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    Task<Testimonials> GetAllTestimonialsAboutByAsync(string userId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns all testimonials written by the specified user.
    /// </summary>
    /// <param name="userId">The NSID of the user who wrote the testimonials.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    Task<Testimonials> GetAllTestimonialsByAsync(string userId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns pending testimonials about the authenticated user. Requires authentication.
    /// </summary>
    /// <param name="page">The page of results to return.</param>
    /// <param name="perPage">Number of testimonials per page.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    Task<Testimonials> GetPendingTestimonialsAboutAsync(int? page = null, int? perPage = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns pending testimonials about the authenticated user written by a specific user. Requires authentication.
    /// </summary>
    /// <param name="userId">The NSID of the user who wrote the pending testimonials.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    Task<Testimonials> GetPendingTestimonialsAboutByAsync(string userId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns pending testimonials written by the authenticated user. Requires authentication.
    /// </summary>
    /// <param name="page">The page of results to return.</param>
    /// <param name="perPage">Number of testimonials per page.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    Task<Testimonials> GetPendingTestimonialsByAsync(int? page = null, int? perPage = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns approved testimonials about the specified user.
    /// </summary>
    /// <param name="userId">The NSID of the user to get testimonials about.</param>
    /// <param name="page">The page of results to return.</param>
    /// <param name="perPage">Number of testimonials per page.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    Task<Testimonials> GetTestimonialsAboutAsync(string userId, int? page = null, int? perPage = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns approved testimonials about the specified user written by another specific user.
    /// </summary>
    /// <param name="userId">The NSID of the user who wrote the testimonials.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    Task<Testimonials> GetTestimonialsAboutByAsync(string userId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns approved testimonials written by the specified user.
    /// </summary>
    /// <param name="userId">The NSID of the user who wrote the testimonials.</param>
    /// <param name="page">The page of results to return.</param>
    /// <param name="perPage">Number of testimonials per page.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    Task<Testimonials> GetTestimonialsByAsync(string userId, int? page = null, int? perPage = null, CancellationToken cancellationToken = default);
}
