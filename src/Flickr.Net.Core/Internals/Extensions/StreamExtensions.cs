namespace Flickr.Net.Core.Internals.Extensions;

internal static class StreamExtensions
{
    internal static async Task CopyToAsync(this Stream source, Stream destination, IProgress<double> progress, int bufferSize = 81920, CancellationToken cancellationToken = default)
    {
        if (source != null)
        {
            if (!source.CanRead)
            {
                throw new ArgumentException("Has to be readable", nameof(source));
            }

            if (destination != null)
            {
                if (!destination.CanWrite)
                {
                    throw new ArgumentException("Has to be writable", nameof(destination));
                }

                if (bufferSize >= 0)
                {
                    var buffer = new byte[bufferSize];
                    double totalBytesRead = 0;
                    int bytesRead;
                    while ((bytesRead = source.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        await destination.WriteAsync(buffer.AsMemory(0, bytesRead), cancellationToken);
                        totalBytesRead += bytesRead;
                        progress?.Report(totalBytesRead);
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(bufferSize));
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(destination));
            }
        }
        else
        {
            throw new ArgumentNullException(nameof(source));
        }
    }
}