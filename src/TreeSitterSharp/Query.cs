using System.Runtime.CompilerServices;
using TreeSitterSharp.Native;

namespace TreeSitterSharp;
public unsafe class Query : INativeObject<TsQuery>
{
    private TsQuery* _query;


    private Query()
    {

    }

    TsQuery* INativeObject<TsQuery>.ToUnmanaged() => _query;

    public static Query Create(Language language, string source, out uint errorOffset, out TsQueryError error)
    {
        errorOffset = default;
        error = default;
        return new Query
        {
            _query = Ts.query_new(language.ToUnmanaged(), source, (uint)source.Length, (uint*)Unsafe.AsPointer(ref errorOffset),
            (TsQueryError*)Unsafe.AsPointer(ref error))
        };
    }
}
