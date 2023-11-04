using System.Runtime.InteropServices;
using System.Text;
using TreeSitterSharp.Native;

namespace TreeSitterSharp;
public unsafe class Parser: INativeObject<TsParser>
{
    protected TsParser* _parser;
    private Language? _language;

    public Parser(Language language)
    {
        static void* NewMalloc(nuint byteCount) => NativeMemory.Alloc(byteCount);
        static void* NewCalloc(nuint count, nuint size) => NativeMemory.AllocZeroed(count * size);
        static void* NewRealloc(void* ptr, nuint byteCount) => NativeMemory.Realloc(ptr, byteCount);
        static void NewFree(void* ptr) => NativeMemory.Free(ptr);
        Ts.set_allocator(&NewMalloc, &NewCalloc, &NewRealloc, &NewFree);
        _parser = Ts.parser_new();
        Language = language;
    }

    ~Parser()
    {
        Ts.parser_delete(_parser);
    }

    public TsParser* ToUnmanaged() => _parser;

    public Language? Language
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

    public virtual SyntaxTree Parse(string code)
    {
        return new SyntaxTree(Ts.parser_parse_string(_parser, null, code, (uint)code.Length));
    }

    public virtual SyntaxTree Parse(Span<byte> code, Encoding encoding)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(encoding.GetString(code));
        return new SyntaxTree(Ts.parser_parse_string_encoding(_parser, null, bytes, (uint)bytes.Length, TsInputEncoding.TSInputEncodingUTF8));
    }
}
