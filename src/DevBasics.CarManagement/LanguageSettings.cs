using System.Collections.Generic;

namespace DevBasics.CarManagement
{
    public class LanguageSettings
    {
        public IDictionary<string, string> LanguageCodes { get; set; } = new Dictionary<string, string>();

        public LanguageSettings()
        {
            // Define valid language codes (see Leasing API Spec).
            LanguageCodes.Add("Dutch", "nl");
            LanguageCodes.Add("English", "en");
            LanguageCodes.Add("French", "fr");
            LanguageCodes.Add("German", "de");
            LanguageCodes.Add("Spanish", "es");
            LanguageCodes.Add("Italian", "it");
            LanguageCodes.Add("Japanese", "jp");
            LanguageCodes.Add("Traditional Chinese", "zf");
            LanguageCodes.Add("Simple Chinese", "zh");
            LanguageCodes.Add("Swedish", "sv");
            LanguageCodes.Add("Finnish", "fi");
            LanguageCodes.Add("Danish", "dk");
            LanguageCodes.Add("Norwegian", "no");
            LanguageCodes.Add("Thailand", "th");
            LanguageCodes.Add("Brazilian Portugese", "br");
            LanguageCodes.Add("Czech", "cs");
            LanguageCodes.Add("Hungarian", "hu");
            LanguageCodes.Add("Polish", "pl");
            LanguageCodes.Add("Portuguese", "pt");
            LanguageCodes.Add("Korean", "ko");
            LanguageCodes.Add("Malay", "my");
            LanguageCodes.Add("Romanian", "ro");
            LanguageCodes.Add("Slovak", "sk");
            LanguageCodes.Add("Ukrainian", "uk");
            LanguageCodes.Add("Hindi", "hi");
        }
    }
}
