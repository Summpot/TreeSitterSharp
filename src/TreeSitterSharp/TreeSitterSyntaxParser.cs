using System.Runtime.InteropServices;
using System.Text;
using TreeSitterSharp.Native;

namespace TreeSitterSharp;
public unsafe class TreeSitterSyntaxParser : INativeObject<TsParser>
{
    private TsParser* _parser;
    private Language? _language;



    public TreeSitterSyntaxParser(Language language)
    {
        static void* NewMalloc(nuint byteCount) => NativeMemory.Alloc(byteCount);
        static void* NewCalloc(nuint count, nuint size) => NativeMemory.AllocZeroed(count * size);
        static void* NewRealloc(void* ptr, nuint byteCount) => NativeMemory.Realloc(ptr, byteCount);
        static void NewFree(void* ptr) => NativeMemory.Free(ptr);
        Ts.set_allocator(&NewMalloc, &NewCalloc, &NewRealloc, &NewFree);
        _parser = Ts.parser_new();
        Language = language;
    }

    ~TreeSitterSyntaxParser()
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

    public TreeSitterSyntaxTree Parse(string code)
    {
        if (_language is null)
        {
            throw new Exception("Language can't be null");
        }
        return new TreeSitterSyntaxTree(Ts.parser_parse_string(_parser, null, code, (uint)code.Length));
    }

    public TreeSitterSyntaxTree Parse(Span<byte> code, Encoding encoding)
    {
        if (_language is null)
        {
            throw new Exception("Language can't be null");
        }
        byte[] bytes = Encoding.UTF8.GetBytes(encoding.GetString(code));
        return new TreeSitterSyntaxTree(Ts.parser_parse_string_encoding(_parser, null, bytes, (uint)bytes.Length, TsInputEncoding.TSInputEncodingUTF8));
    }


}
