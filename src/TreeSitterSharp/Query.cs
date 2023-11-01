using System.Runtime.CompilerServices;
using TreeSitterSharp.Native;

namespace TreeSitterSharp;
internal unsafe class Query : INativeObject<TsQuery>
{
    private TsQuery* _query;


    private Query()
    {

    }

    TsQuery* INativeObject<TsQuery>.ToUnmanaged() => _query;

    public static Query Create(Language language, string source, ref uint errorOffset, ref TsQueryError error)
    {
        return new Query
        {
            _query = Ts.query_new(language.ToUnmanaged(), source, (uint)source.Length, (uint*)Unsafe.AsPointer(ref errorOffset),
            (TsQueryError*)Unsafe.AsPointer(ref error))
        };
    }
}
