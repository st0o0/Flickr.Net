namespace Flickr.Net.Internals;

/// <summary>
/// Summary description for SafeNativeMethods.
/// </summary>
[System.Security.SuppressUnmanagedCodeSecurity]
internal class SafeNativeMethods
{
    private SafeNativeMethods()
    {
    }

    internal static int GetErrorCode(IOException ioe)
    {
        return System.Runtime.InteropServices.Marshal.GetHRForException(ioe) & 0xFFFF;
    }
}