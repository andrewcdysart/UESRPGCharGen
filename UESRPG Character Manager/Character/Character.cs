﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;
using System.Xml.Serialization;

namespace UESRPG_Character_Manager
{
    public class Skill
    {
        [XmlAttribute ()]
        public string Name { get; set; }
        [XmlAttribute ()]
        public int Rank { get; set; }
        public string Description { get; set; }
        public int[] Characteristics { get; set; }

        public override string ToString ()
        {
            return Name;
        }
    }

    public class Spell
    {
        [XmlAttribute ()]
        public string Name { get; set; }
        [XmlAttribute ()]
        public int Level { get; set; }
        public int Cost { get; set; }
        public int Difficulty { get; set; }
        public string AssociatedSkill { get; set; }
        public string Description { get; set; }
        public bool DoesDamage { get; set; }
        public int NumberOfDice { get; set; }
        public int DiceSides { get; set; }
        public int Penetration { get; set; }
    }

    //[XmlRoot("Character", IsNullable = false)]
    public class Character// : ICloneable
    {
        private int[] _characteristics;
        private int[] _modifiers;
        private List<Armor> _armorPieces;
        private List<Weapon> _weapons;
        private List<Spell> _spells;
        private List<Skill> _skills;

        private string _name = "Player";

        public Character ()
        {
            _characteristics = new int[Characteristics.NumberOfCharacteristics];
            _armorPieces = new List<Armor>();
            _weapons = new List<Weapon> ();
            _spells = new List<Spell> ();
            _skills = new List<Skill> ();
            _modifiers = new int[Modifiers.NumberOfModifiers];
        }

        public int GetBonus (int attribute)
        {
            return attribute / 10;
        }

        public int GetCharacteristic (int index)
        {
            return _characteristics[index];
        }

        [XmlAttribute()]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

/******************
 * CHARACTERISTICS
 *****************/
        public int Strength
        {
            get { return _characteristics[Characteristics.Strength]; }
            set { _characteristics[Characteristics.Strength] = value; }
        }
        public int Endurance
        {
            get { return _characteristics[Characteristics.Endurance]; }
            set { _characteristics[Characteristics.Endurance] = value; }
        }
        public int Agility
        {
            get { return _characteristics[Characteristics.Agility]; }
            set { _characteristics[Characteristics.Agility] = value; }
        }
        public int Intelligence
        {
            get { return _characteristics[Characteristics.Intelligence]; }
            set { _characteristics[Characteristics.Intelligence] = value; }
        }
        public int Willpower
        {
            get { return _characteristics[Characteristics.Willpower]; }
            set { _characteristics[Characteristics.Willpower] = value; }
        }
        public int Perception
        {
            get { return _characteristics[Characteristics.Perception]; }
            set { _characteristics[Characteristics.Perception] = value; }
        }
        public int Personality
        {
            get { return _characteristics[Characteristics.Personality]; }
            set { _characteristics[Characteristics.Personality] = value; }
        }
        public int Luck
        {
            get { return _characteristics[Characteristics.Luck]; }
            set { _characteristics[Characteristics.Luck] = value; }
        }
/************
 * EQUIPMENT
 ***********/
        public List<Armor> ArmorPieces
        {
            get { return  _armorPieces; }
            set { _armorPieces = value; }
        }

        //
        // Add a piece of armor.  Replacing any existing piece that
        // belongs to the same body part
        //
        public void AddArmorPiece(Armor piece)
        {
            bool addNew = true;

            for (int i = 0; i < _armorPieces.Count; i++)
            {
                if (_armorPieces[i].Location == piece.Location)
                {
                    _armorPieces[i] = piece;
                    addNew = false;
                    break;
                }
            }

            if (addNew)
            {
                _armorPieces.Add (piece);
                _armorPieces.Sort ();
            }
        }

        public Armor GetArmorPiece (ArmorLocations location)
        {
            Armor result = new Armor();
            for (int i = 0; i < _armorPieces.Count; i++)
            {
                if (_armorPieces[i].Location == location)
                {
                    result = _armorPieces[i];
                    break;
                }
            }
            return result;
        }

        /*object ICloneable.Clone ()
        {
            Character c = new Character ();

            c.Name = Name;
            c._characteristics = (int[])_characteristics.Clone ();
            c._modifiers = (int[])_modifiers.Clone ();
            c._armorPieces = new List<Armor> ();
            foreach (Armor piece in _armorPieces)
            {
                Armor newPiece = piece;
                c._armorPieces
            }

            return c;
        }*/

        public List<Weapon> Weapons
        {
            get { return _weapons; }
            set { _weapons = value; }
        }

/*********
 * SKILLS
 ********/

        public List<Spell> Spells
        {
            get { return _spells; }
            set { _spells = value; }
        }

        public List<Skill> Skills
        {
            get { return _skills; }
            set { _skills = value; }
        }

/************
 * MODIFIERS
 ***********/
        public int HealthMod
        {
            get { return _modifiers[Modifiers.Health]; }
            set { _modifiers[Modifiers.Health] = value; }
        }
        public int WoundThresholdMod
        {
            get { return _modifiers[Modifiers.WoundThreshold]; }
            set { _modifiers[Modifiers.WoundThreshold] = value; }
        }
        public int StaminaMod
        {
            get { return _modifiers[Modifiers.Stamina]; }
            set { _modifiers[Modifiers.Stamina] = value; }
        }
        public int MagickaMod
        {
            get { return _modifiers[Modifiers.Magicka]; }
            set { _modifiers[Modifiers.Magicka] = value; }
        }
        public int ActionPointsMod
        {
            get { return _modifiers[Modifiers.ActionPoints]; }
            set { _modifiers[Modifiers.ActionPoints] = value; }
        }
        public int MovementRatingMod
        {
            get { return _modifiers[Modifiers.MovementRating]; }
            set { _modifiers[Modifiers.MovementRating] = value; }
        }
        public int CarryRatingMod
        {
            get { return _modifiers[Modifiers.CarryRating]; }
            set { _modifiers[Modifiers.CarryRating] = value; }
        }
        public int InitiativeRatingMod
        {
            get { return _modifiers[Modifiers.InitiativeRating]; }
            set { _modifiers[Modifiers.InitiativeRating] = value; }
        }
        public int DamageBonusMod
        {
            get { return _modifiers[Modifiers.DamageBonus]; }
            set { _modifiers[Modifiers.DamageBonus] = value; }
        }
        public int LuckPointsMod
        {
            get { return _modifiers[Modifiers.LuckPoints]; }
            set { _modifiers[Modifiers.LuckPoints] = value; }
        }

        public int CurrentHealth
        {
            get; set;
        }

        public int MaxHealth
        {
            get
            {
                return Endurance + HealthMod;
            }
        }

        public int WoundThreshold
        {
            get
            {
                return (GetBonus (Endurance) + GetBonus (Strength)) + WoundThresholdMod;
            }
        }

        public int CurrentStamina
        {
            get; set;
        }

        public int Stamina
        {
            get
            {
                float halfWillpowerBonus = (float)GetBonus (Willpower) / 2;
                halfWillpowerBonus += 0.5f; // round up
                return (GetBonus (Endurance) + (int)halfWillpowerBonus) + StaminaMod;
            }
        }

        public int CurrentMagicka
        {
            get; set;
        }

        public int MagickaPool
        {
            get
            {
                return Intelligence + MagickaMod;
            }
        }

        public int MovementRating
        {
            get
            {
                return GetBonus (Agility) + MovementRatingMod;
            }
        }

        public int CarryRating
        {
            get
            {
                return ((2 * GetBonus (Strength)) + GetBonus (Endurance)) + CarryRatingMod;
            }
        }

        public int InitiativeRating
        {
            get
            {
                return (GetBonus (Agility) + GetBonus (Perception)) + InitiativeRatingMod;
            }
        }

        public int CurrentAp
        {
            get; set;
        }

        public int MaximumAp
        {
            get
            {
                int value = GetBonus (Agility) + GetBonus (Intelligence) + GetBonus (Perception);
                int ap = 0;
                if (value <= 6)
                {
                    ap = 1;
                }
                else if (value >= 7 && value <= 10)
                {
                    ap = 2;
                }
                else if (value >= 11 && value <= 14)
                {
                    ap = 3;
                }
                else if (value >= 15 && value <= 18)
                {

                    ap = 4;
                }
                else // 19+
                {
                    ap = 5;
                }

                return ap + ActionPointsMod;
            }
        }

        public int DamageBonus
        {
            get
            {
                return GetBonus (Strength) + DamageBonusMod;
            }
        }

        public int CurrentLuckPoints
        {
            get; set;
        }

        public int MaximumLuckPoints
        {
            get
            {
                return GetBonus (Luck) + LuckPointsMod;
            }
        }
    }
}