using System.Runtime.InteropServices;
using TreeSitterSharp.Native;
using TreeSitterSharp;

namespace TreeSitterSharp.C;

[LanguageName("C")]
internal class CLanguageProvider : ILanguageProvider
{
    [DllImport("tree-sitter-c", EntryPoint = "tree_sitter_c", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    private static extern unsafe TsLanguage* tree_sitter_c();
    public static unsafe Language GetLanguage()
    {
        return new Language(tree_sitter_c());
    }

}
