using TreeSitterSharp.Native;

namespace TreeSitterSharp;
public unsafe class Language:INativeObject<TsLanguage>
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
