using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TreeSitterSharp.Native;

namespace TreeSitterSharp;
public unsafe class Parser
{
    private TsParser* _internalParser;
    public static Parser Create(Language? language = null)
    {
        static void* NewMalloc(nuint byteCount) => NativeMemory.Alloc(byteCount);
        static void* NewCalloc(nuint count, nuint size) => NativeMemory.AllocZeroed(count * size);
        static void* NewRealloc(void* ptr, nuint byteCount) => NativeMemory.Realloc(ptr, byteCount);
        static void NewFree(void* ptr) => NativeMemory.Free(ptr);
        Ts.set_allocator(&NewMalloc, &NewCalloc, &NewRealloc, &NewFree);
        var parser = new Parser() { _internalParser = Ts.parser_new() };
        if (language is not null)
        {
            parser.SetLanguage(language);
        }
        return parser;
    }
    ~Parser()
    {
        Ts.parser_delete(_internalParser);
    }

    public void SetLanguage(Language language)
    {
        Ts.parser_set_language(_internalParser, language.ToUnmanaged());
    }

    public Tree Parse(string code)
    {
        return Tree.FromNative(Ts.parser_parse_string(_internalParser, null, code, (uint)code.Length));
    }


}
