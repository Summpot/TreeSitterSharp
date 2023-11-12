using System.Runtime.InteropServices;
using TreeSitterSharp.Native;
using TreeSitterSharp;

namespace TreeSitterSharp.Lua;

[LanguageName("Lua")]
internal class LuaLanguageProvider : ILanguageProvider
{
    [DllImport("tree-sitter-lua", EntryPoint = "tree_sitter_lua", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    private static extern unsafe TsLanguage* tree_sitter_lua();
    public static unsafe Language GetLanguage()
    {
        return new Language(tree_sitter_lua());
    }

}
