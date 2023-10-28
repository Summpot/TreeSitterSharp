using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Unicode;
using System.Threading.Tasks;
using TreeSitterSharp.Native;

namespace TreeSitterSharp;
public unsafe class Parser
{
    private TsParser* _internalParser;
    private Language? _language;

    public Language? Language
    {
        get => _language;
        set
        {
            _language = value;
            if (_language is not null)
            {
                Ts.parser_set_language(_internalParser, _language.ToUnmanaged());
            }
        }
    }

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
            parser.Language = language;
        }
        return parser;
    }
    ~Parser()
    {
        Ts.parser_delete(_internalParser);
    }

    public Tree Parse(string code)
    {
        if (_language is null)
        {
            throw new Exception("Language can't be null");
        }
        return new Tree(Ts.parser_parse_string(_internalParser, null, code, (uint)code.Length), _language);
    }

    public Tree Parse(Span<byte> code, Encoding encoding)
    {
        if (_language is null)
        {
            throw new Exception("Language can't be null");
        }
        byte[] bytes = Encoding.UTF8.GetBytes(encoding.GetString(code));
        return new Tree(Ts.parser_parse_string_encoding(_internalParser, null, bytes, (uint)bytes.Length, TsInputEncoding.TSInputEncodingUTF8), _language);
    }


}
