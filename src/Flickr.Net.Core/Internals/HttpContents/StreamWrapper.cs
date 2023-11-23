namespace Flickr.Net.Core.Internals.HttpContents;

internal class StreamWrapper(Stream stream) : Stream
{
    public Stream InnerStream { get; private set; } = stream;

    public override bool CanRead => InnerStream.CanRead;

    public override bool CanSeek => InnerStream.CanSeek;

    public override bool CanWrite => InnerStream.CanWrite;

    public bool TryGetPosition(out long? position)
    {
        if (!InnerStream.CanSeek)
        {
            position = null;
            return false;
        }
        try
        {
            position = InnerStream.Position;
            return true;
        }
        catch
        {
            position = null;
            return false;
        }
    }

    public override long Length => InnerStream.Length;

    public override long Position
    {
        get => InnerStream.Position;
        set => InnerStream.Position = value;
    }

    public override void Flush()
        => InnerStream.Flush();

    public override int Read(byte[] buffer, int offset, int count)
        => InnerStream.Read(buffer, offset, count);

    public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        => await InnerStream.ReadAsync(buffer.AsMemory(offset, count), cancellationToken);

    public override async Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        => await base.WriteAsync(buffer.AsMemory(offset, count), cancellationToken);

    public override async Task FlushAsync(CancellationToken cancellationToken)
        => await InnerStream.FlushAsync(cancellationToken);

    public override async Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken)
        => await InnerStream.CopyToAsync(destination, bufferSize, cancellationToken);

    public override long Seek(long offset, SeekOrigin origin)
        => InnerStream.Seek(offset, origin);

    public override void SetLength(long value)
        => InnerStream.SetLength(value);

    public override void Write(byte[] buffer, int offset, int count)
        => InnerStream.Write(buffer, offset, count);

    protected override void Dispose(bool disposing) 
        => InnerStream.Dispose();
}