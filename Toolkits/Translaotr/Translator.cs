using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toolkits.Translaotr.API;
using Toolkits.Translaotr.Core;

namespace Toolkits.Translaotr;

public static class Translator
{
    private readonly static Dictionary<string, Type> TranslatorAPIDict = new()
    {
        ["bing"] = typeof(BingTranslaotr),
    };

    public static BaseTranslator? GetAPI(string engine)
    {
        engine = engine.ToLower();
        if (TranslatorAPIDict.TryGetValue(engine, out Type? APIType))
        {
            return Activator.CreateInstance(APIType) as BaseTranslator;
        }
        return null;
    }
}