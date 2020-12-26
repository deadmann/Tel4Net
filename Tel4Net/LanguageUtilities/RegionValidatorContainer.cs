using System.Collections.Generic;
using System.Linq;

namespace Tel4Net.LanguageUtilities
{
    /// <summary>
    /// Provide functionality to register or fetch specific region
    /// </summary>
    internal class CharacterHandlerContainer
    {
        private readonly List<ICharacterHandler> _characterHandlers;

        public CharacterHandlerContainer()
        {
            _characterHandlers = new List<ICharacterHandler>();
            CharacterHandlerRegistrar.RegisterCharacterHandlers(this);
        }

        public void RegisterRegions(ICharacterHandler handler)
        {
            _characterHandlers.Add(handler);
        }

        public List<ICharacterHandler> GetAllCharacterHandlers()
        {
            return _characterHandlers.ToList();
        }

        // in case collection is Dictionary, get by key
        //public ICharacterHandler GetCharacterHandler(X x) => _characterHandlers[x]; 
    }
}
