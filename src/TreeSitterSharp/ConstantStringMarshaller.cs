using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace TreeSitterSharp;

[CustomMarshaller(typeof(string), MarshalMode.ManagedToUnmanagedOut, typeof(ConstantStringMarshaller))]
internal static unsafe class ConstantStringMarshaller
{
    /// <summary>
    /// Converts an unmanaged string to a managed version.
    /// </summary>
    /// <param name="unmanaged">The unmanaged string to convert.</param>
    /// <returns>A managed string.</returns>
    public static string? ConvertToManaged(byte* unmanaged)
        => Marshal.PtrToStringUTF8((IntPtr)unmanaged);

    /// <summary>
    /// Free the memory for a specified unmanaged string.
    /// </summary>
    /// <param name="unmanaged">The memory allocated for the unmanaged string.</param>
    public static void Free(byte* unmanaged)
    {
        // We shouldn't free constant string.
    }
}
