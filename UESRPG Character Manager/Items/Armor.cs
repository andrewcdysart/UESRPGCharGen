﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESRPG_Character_Manager.Items
{
    public class Armor : Item, IComparable, ICloneable
    {
        public double AR { get; set; }
        public string[] Qualities { get; set; }
        public ArmorLocations Location { get; set; }

        public Armor () : base("", "", 0, 0)
        {
            AR = 0.0;
            Qualities = new string[] { };
            Location = ArmorLocations.MAX;
            _isEquippable = true;
        }

        public Armor(string name, double ar, int encumbrance, int price, ArmorLocations location, string[] qualities) :
            base(name, "", encumbrance, price)
        {
            AR = ar;
            Qualities = qualities;
            Location = location;
            _isEquippable = true;
            _equipSlots = new List<string> { location.ToString() };
        }

        /// <todo>
        /// This could use some work. I dispute the notion that an Armor's material should not be a member variable,
        /// calling into question the need for this method.
        /// </todo>
        public static double CalculateAR(ArmorTypes type, ArmorMaterials material, ArmorQualities quality)
        {
            double result = 0;
            result += ArmorTypeData.s_modifiers[(int)type];
            result += ArmorMaterialData.s_modifiers[(int)material];
            result += result * ArmorQualityData.s_modifiers[(int)quality];

            return result;
        }

        public int CompareTo (object obj)
        {
            return ((IComparable)Location).CompareTo (((Armor)obj).Location);
        }

        public object Clone()
        {
            Armor newArmor = new Armor();

            newArmor.Name = Name;
            newArmor.Price = Price;
            newArmor.Encumbrance = Encumbrance;
            newArmor.Description = Description;
            newArmor.AR = AR;
            newArmor.Qualities = (string[])Qualities.Clone();
            newArmor.Location = Location;

            return newArmor;
        }
    }
}
