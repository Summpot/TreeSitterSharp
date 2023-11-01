using System.Runtime.InteropServices;
using TreeSitterSharp.Native;

namespace TreeSitterSharp.C;
internal class CLanguageProvider : ILanguageProvider
{
    [DllImport("tree-sitter-c", EntryPoint = "tree_sitter_c", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    private static extern unsafe TsLanguage* tree_sitter_c();

    public static unsafe Language GetLanguage()
    {
        return new Language(tree_sitter_c());
    }

}
