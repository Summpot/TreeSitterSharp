using System.Runtime.InteropServices;
using TreeSitterSharp.Native;
using TreeSitterSharp;

namespace TreeSitterSharp.Json
{
    internal unsafe class JsonLanguageProvider : ILanguageProvider
    {
        [DllImport("tree-sitter-json", EntryPoint = "tree_sitter_json", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        private static extern TsLanguage* tree_sitter_json();
        
        public static Language GetLanguage() => new(tree_sitter_json());
    }
}
