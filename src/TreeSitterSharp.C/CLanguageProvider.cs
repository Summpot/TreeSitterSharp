using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TreeSitterSharp.Native;

namespace TreeSitterSharp.C;
internal class CLanguageProvider : ILanguageProvider
{
    [DllImport("libtree-sitter-c", EntryPoint = "tree_sitter_c", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    private static extern unsafe TsLanguage* tree_sitter_c();

    public static unsafe Language GetLanguage()
    {
        return new Language(tree_sitter_c());
    }

}
