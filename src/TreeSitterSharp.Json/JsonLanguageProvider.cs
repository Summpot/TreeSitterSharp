using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TreeSitterSharp.Native;

namespace TreeSitterSharp.Json
{
    public unsafe class JsonLanguageProvider : ILanguageProvider
    {
        [DllImport("libtree-sitter-json", EntryPoint = "tree_sitter_json", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        private static extern unsafe TsLanguage* tree_sitter_json();

        public static Language GetLanguage() => Language.FromUnmanaged(tree_sitter_json());
    }
}
