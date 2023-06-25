namespace Flickr.Net.Core.Internals.Extensions;

/// <summary>
/// </summary>
public static class MachineTagModeExtensions
{
    /// <summary>
    /// Convert a <see cref="MachineTagMode"/> to a string used when passing to Flickr.
    /// </summary>
    /// <param name="machineTagMode">The machine tag mode to convert.</param>
    /// <returns>The string to pass to Flickr.</returns>
    [Obsolete]
    public static string ToKEKWFlickrString(this MachineTagMode machineTagMode) => machineTagMode switch
    {
        MachineTagMode.None => string.Empty,
        MachineTagMode.AllTags => "all",
        MachineTagMode.AnyTag => "any",
        _ => string.Empty,
    };
}