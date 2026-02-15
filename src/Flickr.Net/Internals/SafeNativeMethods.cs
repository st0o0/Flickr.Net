using System.Runtime.InteropServices;
using System.Security;

namespace Flickr.Net.Internals;

/// <summary>
/// Summary description for SafeNativeMethods.
/// </summary>
[SuppressUnmanagedCodeSecurity]
internal class SafeNativeMethods
{
    private SafeNativeMethods()
    {
    }

    internal static int GetErrorCode(IOException ioe)
    {
        return Marshal.GetHRForException(ioe) & 0xFFFF;
    }
}