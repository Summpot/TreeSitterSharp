using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TreeSitterSharp.Native;

namespace TreeSitterSharp;

public unsafe class QueryCursor
{
    private TsQueryCursor* _queryCursor;

    public QueryCursor()
    {
        _queryCursor = Ts.query_cursor_new();
    }

    public void Execute(Query query, TreeSitterSyntaxNode node)
    {
        Ts.query_cursor_exec(_queryCursor, (query as INativeObject<TsQuery>).ToUnmanaged(), node.ToUnmanaged());
    }

    public bool NextMatch([MaybeNullWhen(false)] out QueryMatch queryMatch)
    {
        TsQueryMatch match;
        bool succeed = Ts.query_cursor_next_match(_queryCursor, &match);
        queryMatch = succeed ? new QueryMatch(&match) : null;
        return succeed;
    }

    public bool NextCapture([MaybeNullWhen(false)] out QueryMatch queryMatch, out uint captureIndex)
    {
        TsQueryMatch match;
        uint index;
        bool succeed = Ts.query_cursor_next_capture(_queryCursor, &match, &index);
        queryMatch = succeed ? new QueryMatch(&match) : null;
        captureIndex = index;
        return succeed;
    }
}
