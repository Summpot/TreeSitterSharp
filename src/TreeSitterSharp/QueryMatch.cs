using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeSitterSharp.Native;

namespace TreeSitterSharp;
public unsafe class QueryMatch : INativeObject<TsQueryMatch>
{
    private readonly TsQueryMatch* _queryMatch;

    public QueryMatch(TsQueryMatch* queryMatch) => _queryMatch = queryMatch;

    public ImmutableArray<TsQueryCapture> Captures => new Span<TsQueryCapture>(_queryMatch->Captures, _queryMatch->CaptureCount).ToImmutableArray();

    public TsQueryMatch* ToUnmanaged() => _queryMatch;
}
