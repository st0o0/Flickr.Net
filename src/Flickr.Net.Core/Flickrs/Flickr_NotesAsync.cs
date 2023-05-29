namespace FlickrNet.Core;

public partial class Flickr
{
    /// <summary>
    /// Add a note to a picture.
    /// </summary>
    /// <param name="photoId">The photo id to add the note to.</param>
    /// <param name="noteX">The X co-ordinate of the upper left corner of the note.</param>
    /// <param name="noteY">The Y co-ordinate of the upper left corner of the note.</param>
    /// <param name="noteWidth">The width of the note.</param>
    /// <param name="noteHeight">The height of the note.</param>
    /// <param name="noteText">The text in the note.</param>
    public async Task<string> PhotosNotesAddAsync(string photoId, int noteX, int noteY, int noteWidth, int noteHeight, string noteText, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.notes.add" },
            { "photo_id", photoId },
            { "note_x", noteX.ToString(System.Globalization.NumberFormatInfo.InvariantInfo) },
            { "note_y", noteY.ToString(System.Globalization.NumberFormatInfo.InvariantInfo) },
            { "note_w", noteWidth.ToString(System.Globalization.NumberFormatInfo.InvariantInfo) },
            { "note_h", noteHeight.ToString(System.Globalization.NumberFormatInfo.InvariantInfo) },
            { "note_text", noteText }
        };

        var result = await GetResponseAsync<UnknownResponse>(parameters, cancellationToken);

        return result.GetAttributeValue("*", "id");
    }

    /// <summary>
    /// Edit and update a note.
    /// </summary>
    /// <param name="noteId">The ID of the note to update.</param>
    /// <param name="noteX">The X co-ordinate of the upper left corner of the note.</param>
    /// <param name="noteY">The Y co-ordinate of the upper left corner of the note.</param>
    /// <param name="noteWidth">The width of the note.</param>
    /// <param name="noteHeight">The height of the note.</param>
    /// <param name="noteText">The new text in the note.</param>
    public async Task PhotosNotesEditAsync(string noteId, int noteX, int noteY, int noteWidth, int noteHeight, string noteText, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.notes.edit" },
            { "note_id", noteId },
            { "note_x", noteX.ToString(System.Globalization.NumberFormatInfo.InvariantInfo) },
            { "note_y", noteY.ToString(System.Globalization.NumberFormatInfo.InvariantInfo) },
            { "note_w", noteWidth.ToString(System.Globalization.NumberFormatInfo.InvariantInfo) },
            { "note_h", noteHeight.ToString(System.Globalization.NumberFormatInfo.InvariantInfo) },
            { "note_text", noteText }
        };

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    /// <summary>
    /// Delete an existing note.
    /// </summary>
    /// <param name="noteId">The ID of the note.</param>
    public async Task PhotosNotesDeleteAsync(string noteId, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.notes.delete" },
            { "note_id", noteId }
        };

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }
}