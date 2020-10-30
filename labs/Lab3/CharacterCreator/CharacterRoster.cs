/*
 * ITSE 1430
 * Oscar Peinado-Rojo
 * Lab 3
*/
using System;
using System.Collections.Generic;
using System.Text;

namespace CharacterCreator
{
    public class CharacterRoster : ICharacterRoster
    {
        public CharacterRoster ()
        {
           
        }

        public Character Add ( Character character, out string error )
        {
            error = "";

            Character item = CloneCharacter(character);

            item.Id = _id++;

            _character.Add(item);

            character.Id = item.Id;

            return character;
        }

        public void Delete ( int id )
        {
            var character = GetById(id);

            if (character != null)
            {
                _character.Remove(character);
            };
        }

        public IEnumerable<Character> GetAll ()
        {
            foreach (var character in _character)
                yield return CloneCharacter(character);
        }

        public Character Get ( int id )
        {
            var character = GetById(id);

            return (character != null) ? CloneCharacter(character) : null;
        }

        private Character GetById ( int id )
        {
            foreach (var character in _character)
            {
                if (character?.Id == id)
                    return character;
            };

            return null;
        }

        public string Update ( int id, Character character )
        {
            var existing = GetById(id);

            if (existing == null)
                return "Character not found";

            CopyCharacter(existing, character);

            return "";
        }

        private Character CloneCharacter ( Character character )
        {
            var item = new Character();

            item.Id = character.Id;

            CopyCharacter(item, character);

            return item;
        }

        private void CopyCharacter ( Character target, Character source )
        {
            target.Id = source.Id;
            target.Name = source.Name;
            target.Profession = source.Profession;
            target.Race = source.Race;
            target.Description = source.Description;
            target.HP = source.HP;
            target.Strength = source.Strength;
            target.Magic = source.Magic;
            target.Skill = source.Skill;
            target.Speed = source.Speed;
            target.Luck = source.Luck;
            target.Defense = source.Defense;
        }

        private List<Character> _character = new List<Character>();
        private int _id = 1;
    }
}
