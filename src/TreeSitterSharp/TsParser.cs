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
public unsafe class TsParser
{
    private Native.TsParser* _parser;
    private TsLanguage? _language;



    public TsParser(TsLanguage language)
    {
        static void* NewMalloc(nuint byteCount) => NativeMemory.Alloc(byteCount);
        static void* NewCalloc(nuint count, nuint size) => NativeMemory.AllocZeroed(count * size);
        static void* NewRealloc(void* ptr, nuint byteCount) => NativeMemory.Realloc(ptr, byteCount);
        static void NewFree(void* ptr) => NativeMemory.Free(ptr);
        Ts.set_allocator(&NewMalloc, &NewCalloc, &NewRealloc, &NewFree);
        _parser = Ts.parser_new();
        Language = language;
    }
    ~TsParser()
    {
        Ts.parser_delete(_parser);
    }

    public TsLanguage? Language
    {
        get => _language;
        set
        {
            _language = value;
            if (_language is not null)
            {
                Ts.parser_set_language(_parser, _language.ToUnmanaged());
            }
        }
    }

    public TsTree Parse(string code)
    {
        if (_language is null)
        {
            throw new Exception("Language can't be null");
        }
        return new TsTree(Ts.parser_parse_string(_parser, null, code, (uint)code.Length));
    }

    public TsTree Parse(Span<byte> code, Encoding encoding)
    {
        if (_language is null)
        {
            throw new Exception("Language can't be null");
        }
        byte[] bytes = Encoding.UTF8.GetBytes(encoding.GetString(code));
        return new TsTree(Ts.parser_parse_string_encoding(_parser, null, bytes, (uint)bytes.Length, TsInputEncoding.TSInputEncodingUTF8));
    }


}
