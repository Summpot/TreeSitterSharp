using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TreeSitterSharp.Native;

namespace TreeSitterSharp;
public unsafe class Parser
{
    private TsParser* _internalParser;
    public static Parser Create(Language? language = null)
    {
        var parser = new Parser() { _internalParser = Ts.parser_new() };
        if (language is not null)
        {
            parser.SetLanguage(language);
        }
        return parser;
    }

    public void SetLanguage(Language language)
    {
        Ts.parser_set_language(_internalParser, language.ToNative());
    }

    public Tree Parse(string code)
    {
        return Tree.FromNative(Ts.parser_parse_string(_internalParser, null, code, (uint)code.Length));
    }
}
