using System.Net;
using Flickr.Net.Core.Internals.Extensions;

namespace Flickr.Net.Core.Internals.HttpContents;

internal class StreamedContent(Stream fileStream, IProgress<double> progress, CancellationToken cancellationToken) : HttpContent
{
    private CancellationToken _cancellationToken = cancellationToken;
    private Stream _fileStream = fileStream;
    private IProgress<double> _progress = progress;

    private class ContentStream(Stream stream, IProgress<double> progress) : StreamWrapper(stream)
    {
        private IProgress<double> _progress = progress;
        private long _position = 0;

        public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            var readBytes = await base.ReadAsync(buffer.AsMemory(offset, count), cancellationToken);
            _position += readBytes;
            _progress?.Report(readBytes / count);
            return readBytes;
        }
    }

    protected override Task<Stream> CreateContentReadStreamAsync()
    {
        return Task.FromResult<Stream>(new ContentStream(_fileStream, _progress));
    }

    protected override async Task SerializeToStreamAsync(Stream stream, TransportContext context)
    {
        await _fileStream.CopyToAsync(stream, _progress, cancellationToken: _cancellationToken);
    }

    protected override bool TryComputeLength(out long length)
    {
        length = _fileStream.Length;
        return true;
    }
}
