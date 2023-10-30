using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeSitterSharp.Native;

namespace TreeSitterSharp;
public unsafe class TsLanguage
{
    private Native.TsLanguage* _language;

    public TsLanguage(Native.TsLanguage* language)
    {
        _language = language;
    }

    public Native.TsLanguage* ToUnmanaged()
    {
        return _language;
    }
}
