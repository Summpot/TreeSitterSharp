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
    [DllImport("tree-sitter-c", EntryPoint = "tree_sitter_c", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    private static extern unsafe Native.TsLanguage* tree_sitter_c();

    public static unsafe TsLanguage GetLanguage()
    {
        return new TsLanguage(tree_sitter_c());
    }

}
