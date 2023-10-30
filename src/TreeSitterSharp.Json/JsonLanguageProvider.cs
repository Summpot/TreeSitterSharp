using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TreeSitterSharp.Native;

namespace TreeSitterSharp.Json
{
    internal unsafe class JsonLanguageProvider : ILanguageProvider
    {
        [DllImport("tree-sitter-json", EntryPoint = "tree_sitter_json", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        private static extern unsafe Native.TsLanguage* tree_sitter_json();

        public static TsLanguage GetLanguage() => new(tree_sitter_json());
    }
}
