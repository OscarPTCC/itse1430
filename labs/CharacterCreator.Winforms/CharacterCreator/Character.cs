using System;

namespace CharacterCreator
{
    ///<summary>Represents a character</summary>
    public class Character
    {
        private string _name;
        private string _description;
        private string _profession;
        private string _race;

        /// <summary>The name of the character</summary>
        public string Name
        {
            get { return _name ?? ""; }
            set { _name = value; }
        }

        /// <summary>Gets or sets the character description</summary>
        public string Description
        {
            get { return _description ?? ""; }
            set { _description = value; }
        }

        /// <summary>Gets or sets the character profession</summary>
        public string Profession
        {
            get { return _profession ?? ""; }
            set { _profession = value; }
        }

        /// <summary>Gets or sets the character race</summary>
        public string Race
        {
            get { return _race ?? ""; }
            set { _race = value; }
        }

        /// <summary>The character's Strength stat</summary>
        /// <value>The maximum value is 40</value>
        public int Strength { get; set; }

        /// <summary>The character's Magic stat</summary>
        ///  <value>The maximum value is 40</value>
        public int Magic { get; set; }

        /// <summary>The character's Skill stat</summary>
        /// <value>The maximum value is 40</value>
        public int Skill { get; set; }

        /// <summary>The character's Speed stat</summary>
        /// <value>The maximum value is 40</value>
        public int Speed { get; set; }

        /// <summary>The character's Luck stat</summary>
        /// <value>The maximum value is 40</value>
        public int Luck { get; set; }

        /// <summary>The character's Defense stat</summary>
        /// <value>The maximum value is 40</value>
        public int Defense { get; set; }

        /// <summary>The character's HP or Hit Points stat</summary>
        /// <value>The maximum value is 52</value>
        public int HP { get; set; }


    }
}
