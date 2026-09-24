using System.Net;

namespace Flickr.Net.Internals.HttpContents;

internal sealed class StreamedContent(Stream fileStream, IProgress<double>? progress, CancellationToken cancellationToken) : HttpContent
{
    protected override async Task SerializeToStreamAsync(Stream stream, TransportContext? context)
    {
        var buffer = new byte[81920];
        long totalBytesRead = 0;
        var length = fileStream.CanSeek ? fileStream.Length : -1L;
        int bytesRead;

        while ((bytesRead = await fileStream.ReadAsync(buffer, cancellationToken).ConfigureAwait(false)) > 0)
        {
            await stream.WriteAsync(buffer.AsMemory(0, bytesRead), cancellationToken).ConfigureAwait(false);
            totalBytesRead += bytesRead;

            if (progress is not null && length > 0)
            {
                progress.Report((double)totalBytesRead / length);
            }
        }
    }

    protected override bool TryComputeLength(out long length)
    {
        if (fileStream.CanSeek)
        {
            length = fileStream.Length;
            return true;
        }

        length = 0;
        return false;
    }
}
