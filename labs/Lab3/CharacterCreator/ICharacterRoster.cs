/*
 * ITSE 1430
 * Oscar Peinado-Rojo
 * Lab 3
*/
using System;
using System.Collections.Generic;

namespace CharacterCreator
{
    public interface ICharacterRoster
    {
        /// <summary>
        /// Adds a character to the database.</summary>
        /// <param name="character">The character to add.</param>
        /// <param name="error">The error message.</param>
        /// <returns>The new character.</returns>
        Character Add ( Character character, out string error );

        /// <summary>Deletes a character from the database.</summary>
        /// <param name="id">The character to delete.</param>
        void Delete ( int id );

        /// <summary>Gets the character from the database.</summary>
        /// <param name="id">The character to retrieve.</param>
        Character Get ( int id );

        /// <summary>Gets all character from the database.</summary>
        /// <returns>The characters.</returns>
        IEnumerable<Character> GetAll ();

        /// <summary>Updates existing character in the database.</summary>
        /// <param name="id">The character to update.</param>
        /// <param name="character">The character details.</param>   
        string Update ( int id, Character character );
    }
}