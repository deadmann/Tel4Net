using System.Collections.Generic;
using System.Linq;
using Tel4Net.LanguageUtilities;
using Tel4Net.LanguageUtilities.Handlers;

namespace Tel4Net
{
    internal static class TelephoneUtility
    {
        internal static readonly IList<ICharacterHandler> LanguageHandlers = new List<ICharacterHandler>();
        static TelephoneUtility()
        {
            LanguageHandlers.Add(new PersianHandler());
        }

        internal static bool CheckOpenCloseCharacter(string input, List<OpenClose> openCloseCharacters)
        {
            Stack<char> charStack = new Stack<char>();
            char? top = null;

            OpenClose search;
            foreach (var @char in input)
            {
                if (openCloseCharacters.Any(w => w.Opening == @char))
                {
                    charStack.Push(@char);

                    top = @char;
                }
                else if ((search = openCloseCharacters.FirstOrDefault(w => w.Closing == @char)) != null && top != null && top.Value == search.Opening)
                {
                    charStack.Pop();
                    top = (charStack.Count == 0) ? (char?)null : charStack.Peek();
                }
                else if (search != null)
                {
                    return false;
                }
            }

            if (charStack.Count > 0) return false;
            return true;
        }
        
        internal static string PreProcessingHandling(string input, TelephoneOptions options)
        {
            if (options == null)
            {
                options = TelephoneOptions.Default;
            }

            if (!options.ProcessNaturalCharacterOnly)
            {
                input = ToNaturalCharset(input);
                // Stop this process from occured again on nested validations
                options.ProcessNaturalCharacterOnly = true;
            }

            return input;
        }

        private static string ToNaturalCharset(string input)
        {
            foreach (var lh in LanguageHandlers)
            {
                input = lh.ToNaturalString(input);
            }

            return input;
        }
    }
}
