using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SVTextGenerator
{
    public class SVCardReduced
    {
        public string Name;
        public string FlairNormal;
        public string FlairEvo;
        public string EffectNormal;
        public string EffectEvo;

        public SVCardReduced(string name, string flairNormal, string flairEvo, string effectNormal, string effectEvo)
        {
            Name = name;
            FlairNormal = ReplaceAll(flairNormal);
            FlairEvo = ReplaceAll(flairEvo);
            EffectNormal = ReplaceAll(effectNormal);
            EffectEvo = ReplaceAll(effectEvo);
        }

        public string ReplaceAll(string input)
        {
            return StripHTML(ReplaceBr(input));
        }

        public static string ReplaceBr(string input)
        {
            return Regex.Replace(input, "<br>", " ");
        }

        public static string StripHTML(string input)
        {
            return Regex.Replace(input, "<.*?>", String.Empty);
        }
    }
}
