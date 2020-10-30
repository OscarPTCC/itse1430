/*
 * ITSE 1430
 * Oscar Peinado-Rojo
 * Lab 3
*/
using System;
using System.Collections.Generic;
using System.Text;

namespace CharacterCreator.Memory
{
    public class MemoryCharacterRoster : CharacterRoster
    {
        protected override Character AddCore ( Character character )
        {
            var item = CloneCharacter(character);

            item.Id = _id++;

            _character.Add(item);

            character.Id = item.Id;

            return character;
        }

        protected override void DeleteCore ( int id )
        {
            var character = FindById(id);

            if (character != null)
            {
                _character.Remove(character);
            };
        }

        protected override IEnumerable<Character> GetAllCore ()
        {
            foreach (var character in _character)
                yield return CloneCharacter(character);
        }

        protected override Character GetByIdCore ( int id )
        {
            var character = FindById(id);

            return (character != null) ? CloneCharacter(character) : null;
        }

        private Character FindById ( int id )
        {
            foreach (var character in _character)
            {
                if (character?.Id == id)
                    return character;
            };

            return null;
        }

        protected override void UpdateCore ( int id, Character character )
        {
            var existing = FindById(id);

            CopyCharacter(existing, character);
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
