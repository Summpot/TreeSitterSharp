
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeSitterSharp.Json;
public class JsonParser : TsParser
{
    public JsonParser() : base(JsonLanguageProvider.GetLanguage())
    {
    }
}
