namespace Tel4Net.LanguageUtilities
{
    internal interface ICharacterHandler
    {
        string EnglishName { get; }
        string NativeName { get; }
        string ToNaturalString(string input);
    }
}
