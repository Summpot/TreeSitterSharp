using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeSitterSharp.Native;

namespace TreeSitterSharp;
internal class QueryMatch : INativeObject<TsQueryMatch>
{
    private readonly unsafe TsQueryMatch* _queryMatch;

    public unsafe QueryMatch(TsQueryMatch* queryMatch) => _queryMatch = queryMatch;

    public unsafe TsQueryMatch* ToUnmanaged() => _queryMatch;
}
