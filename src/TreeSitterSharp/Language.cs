using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeSitterSharp.Native;

namespace TreeSitterSharp;
public unsafe class Language
{
    private TsLanguage* _language;

    public Language(TsLanguage* language)
    {
        _language = language;
    }

    public TsLanguage* ToUnmanaged()
    {
        return _language;
    }
}
