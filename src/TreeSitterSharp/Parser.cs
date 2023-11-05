using System.Runtime.InteropServices;
using System.Text;
using TreeSitterSharp.Native;

namespace TreeSitterSharp;

public abstract unsafe class Parser<TSyntaxTree, TSyntaxNode, TSelf> : INativeConvertible<TsParser>,
    IParser<TSyntaxTree, TSyntaxNode, TSelf>
    where TSelf : Parser<TSyntaxTree, TSyntaxNode, TSelf>
    where TSyntaxNode : ISyntaxNode<TSyntaxTree, TSyntaxNode>
    where TSyntaxTree : SyntaxTree<TSyntaxNode, TSyntaxTree>
{
    protected TsParser* _parser;
    private Language? _language;

    protected Parser(Language language)
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

    public TSyntaxTree Parse(string code) => Parse(Encoding.UTF8.GetBytes(code));

    public abstract TSyntaxTree Parse(Span<byte> code);

    protected TsTree* ParseCore(Span<byte> code) =>
        Ts.parser_parse_string_encoding(_parser, null, code.ToArray(), (uint)code.Length,
            TsInputEncoding.TSInputEncodingUTF8);
}
