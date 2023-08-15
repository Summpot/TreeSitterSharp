using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TreeSitterSharp.Native;

namespace TreeSitterSharp.C
{
    public partial class TsC
    {
        [DllImport("libtree-sitter-c", EntryPoint = "tree_sitter_c", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true,SetLastError = true)]
        public static extern unsafe void* tree_sitter_c();
    }
}
