using System.Runtime.InteropServices;
using TreeSitterSharp.Native;

namespace TreeSitterSharp.Cpp;

[LanguageName("Cpp")]
internal class CppLanguageProvider : ILanguageProvider
{
    [DllImport("tree-sitter-cpp", EntryPoint = "tree_sitter_cpp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    private static extern unsafe TsLanguage* tree_sitter_cpp();
    public static unsafe Language GetLanguage()
    {
        return new Language(tree_sitter_cpp());
    }

}
