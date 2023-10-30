using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeSitterSharp.C;
public class CParser : TsParser
{
    public CParser() : base(CLanguageProvider.GetLanguage())
    {
    }
}
