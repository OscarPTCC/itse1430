/*
 * ITSE 1430
 * Oscar Peinado-Rojo
 * Lab 3
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CharacterCreator
{
    public abstract class CharacterRoster : ICharacterRoster
    {
        public Character Add ( Character character, out string error )
        {
            var results = new ObjectValidator().TryValidateFullObject(character);
            if (results.Count() > 0)
            {
                foreach (var result in results)
                {
                    error = result.ErrorMessage;
                    return null;
                };
            };

            var existing = GetByName(character.Name);
            if (existing != null)
            {
                error = "Character name must be unique";
                return null;
            };

            error = null;
            return AddCore(character);
        }

        public void Delete ( int id )
        {
            DeleteCore(id);
        }

        public IEnumerable<Character> GetAll ()
        {
            return GetAllCore();
        }

        public Character Get ( int id )
        {
            return GetByIdCore(id);
        }

        public string Update ( int id, Character character )
        {
            var results = new ObjectValidator().TryValidateFullObject(character);
            if (results.Count() > 0)
            {
                foreach (var result in results)
                {
                    return result.ErrorMessage;
                };
            };

            var existing = GetByName(character.Name);
            if (existing != null && existing.Id != id)
                return "Character must be unique";

            UpdateCore(id, character);

            return "";
        }

        protected virtual Character GetByName ( string name )
        {
            foreach (var character in GetAll())
            {
                if (String.Compare(character.Name, name, true) == 0)
                    return character;
            };

            return null;
        }

        protected abstract Character AddCore ( Character character );

        protected abstract void DeleteCore ( int id );

        protected abstract IEnumerable<Character> GetAllCore ();

        protected abstract Character GetByIdCore ( int id );

        protected abstract void UpdateCore ( int id, Character character );
    }
}
