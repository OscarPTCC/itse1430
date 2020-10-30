/*
 * ITSE 1430
 * Oscar Peinado-Rojo
 * Lab 3
*/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CharacterCreator
{
    ///<summary>Represents a character</summary>
    public class Character : IValidatableObject
    {
        private string _name = "";
        private string _description = "";
        private string _profession = "";
        private string _race = "";

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

        public int Id { get; set; }

        /// <summary>The character's Strength stat</summary>
        /// <value>The maximum value is 40</value>
        public int Strength { get; set; } = 6;

        /// <summary>The character's Magic stat</summary>
        ///  <value>The maximum value is 40</value>
        public int Magic { get; set; } = 6;

        /// <summary>The character's Skill stat</summary>
        /// <value>The maximum value is 40</value>
        public int Skill { get; set; } = 6;

        /// <summary>The character's Speed stat</summary>
        /// <value>The maximum value is 40</value>
        public int Speed { get; set; } = 6;

        /// <summary>The character's Luck stat</summary>
        /// <value>The maximum value is 40</value>
        public int Luck { get; set; } = 6;

        /// <summary>The character's Defense stat</summary>
        /// <value>The maximum value is 40</value>
        public int Defense { get; set; } = 6;

        /// <summary>The character's HP or Hit Points stat</summary>
        /// <value>The maximum value is 52</value>
        public int HP { get; set; } = 20;

        public const int MaxStat = 40;
        public const int MinimumStat = 0;
        public const int MaxHP = 52;

        //public string Validate ()
        //{
        //    if (String.IsNullOrEmpty(Name))
        //        return "Name is required";

        //    if (String.IsNullOrEmpty(Profession))
        //        return "Profession is required";

        //    if (String.IsNullOrEmpty(Race))
        //        return "Race is required";

        //    if (Strength < 0 || Strength > 40)
        //        return "Strength value must be between 0 and 40";

        //    if (Magic < 0 || Magic > 40)
        //        return "Magic value must be between 0 and 40";

        //    if (Skill < 0 || Skill > 40)
        //        return "Skill value must be between 0 and 40";

        //    if (Speed < 0 || Speed > 40)
        //        return "Speed value must be between 0 and 40";

        //    if (Luck < 0 || Luck > 40)
        //        return "Luck value must be between 0 and 40";

        //    if (Defense < 0 || Defense > 40)
        //        return "Defense value must be between 0 and 40";

        //    if (HP < 0 || HP > 52)
        //        return "HP value must be between 0 and 52";

        //    return null;
        //}

        public override string ToString ()
        {
            return Name;
        }

        public IEnumerable<ValidationResult> Validate ( ValidationContext validationContext )
        {
            if (String.IsNullOrEmpty(Name))
                yield return new ValidationResult("Name is required", new[] { nameof(Name) });
            if (String.IsNullOrEmpty(Profession))
                yield return new ValidationResult("Profession is required", new[] { nameof(Profession) });
            if (String.IsNullOrEmpty(Race))
                yield return new ValidationResult("Race is required", new[] { nameof(Race) });
            if (HP < MinimumStat || HP > MaxHP)
                yield return new ValidationResult($"HP must be between '{MinimumStat}' and '{MaxHP}'", new[] { nameof(HP) });
            if (!AttributeValidation(Strength))
                yield return new ValidationResult($"Strength must be between '{MinimumStat}' and '{MaxStat}'", new[] { nameof(Strength) });
            if (!AttributeValidation(Magic))
                yield return new ValidationResult($"Magic must be between '{MinimumStat}' and '{MaxStat}'", new[] { nameof(Magic) });
            if (!AttributeValidation(Skill))
                yield return new ValidationResult($"Skill must be between '{MinimumStat}' and '{MaxStat}'", new[] { nameof(Skill) });
            if (!AttributeValidation(Speed))
                yield return new ValidationResult($"Speed must be between '{MinimumStat}' and '{MaxStat}'", new[] { nameof(Speed) });
            if (!AttributeValidation(Luck))
                yield return new ValidationResult($"Luck must be between '{MinimumStat}' and '{MaxStat}'", new[] { nameof(Luck) });
            if (!AttributeValidation(Defense))
                yield return new ValidationResult($"Defense must be between '{MinimumStat}' and '{MaxStat}'", new[] { nameof(Defense) });
        }

        private bool AttributeValidation ( int stat )
        {
            return (stat >= MinimumStat) && (stat <= MaxStat);
        }
    }
}
