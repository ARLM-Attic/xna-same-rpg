using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace XNA_RPG.Character
{
    public class Inventory
    {
        #region Attributes
        private Hashtable items;
        private Hashtable weapons;
        private Hashtable shields;
        private Hashtable helms;
        private Hashtable armors;
        private Hashtable accessories;
        public const int MaxItems = 99;
        public const int MaxWeapons = 99;
        public const int MaxShields = 99;
        public const int MaxHelms = 99;
        public const int MaxArmors = 99;
        public const int MaxAccessories = 99;
        #endregion

        #region Properties
        /// <summary>This method gets the items attribute.</summary>
        public Hashtable Items
        {
            get { return this.items; }
        }

        /// <summary>This method gets the weapons attribute.</summary>
        public Hashtable Weapons
        {
            get { return this.weapons; }
        }

        /// <summary>This method gets the shields attribute.</summary>
        public Hashtable Shields
        {
            get { return this.shields; }
        }

        /// <summary>This method gets the helms attribute.</summary>
        public Hashtable Helms
        {
            get { return this.helms; }
        }

        /// <summary>This method gets the armor attribute.</summary>
        public Hashtable Armors
        {
            get { return this.armors; }
        }

        /// <summary>This method gets the accessories attribute.</summary>
        public Hashtable Accessories
        {
            get { return this.accessories; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// This is the empty constructor for Inventory.
        /// It initializes all Lists 
        /// </summary>
        public Inventory()
        {
            this.items = new Hashtable();
            this.weapons = new Hashtable();
            this.shields = new Hashtable();
            this.helms = new Hashtable();
            this.armors = new Hashtable();
            this.accessories = new Hashtable();
        }
        #endregion

        #region Methods
        public bool KeyExists(string s, Hashtable ht)
        {
            bool result = false;
            if (ht.Contains(s))
            {
                result = true;
            }
            return result;
        }

        #region Item Methods
        public void AddItem(Item i)
        {
            Hashtable ht = this.items;
            string key = i.Name;
            if (KeyExists(key, ht) && (int)ht[key] < MaxItems)
            {
                this.items[key] = (int)ht[key] + 1;
            }
            else
            {
                ht.Add(key, 1);
            }
       }

        public void RemoveItem(Item i)
        {
            Hashtable ht = this.items;
            string key = i.Name;
            if (KeyExists(key, ht))
            {
                if ((int)ht[key] > 1)
                {
                    this.items[key] = (int)this.items[key] - 1;
                }
                else
                {
                    ht.Remove(key);
                }
            }
        }

        public void ClearItems()
        {
            this.items.Clear();
        }
        #endregion

        #region Weapon Methods
        public void AddWeapon(Weapon w)
        {
            Hashtable ht = this.weapons;
            string key = w.Name;
            if (KeyExists(key, ht) && (int)ht[key] < MaxWeapons)
            {
                this.weapons[key] = (int)ht[key] + 1;
            }
            else
            {
                ht.Add(key, 1);
            }
        }

        public void RemoveWeapon(Weapon w)
        {
            Hashtable ht = this.weapons;
            string key = w.Name;
            if (KeyExists(key, ht))
            {
                if ((int)ht[key] > 1)
                {
                    this.weapons[key] = (int)ht[key] - 1;
                }
                else
                {
                    ht.Remove(key);
                }
            }
        }

        public void ClearWeapons()
        {
            this.weapons.Clear();
        }
        #endregion

        #region Shield Methods
        public void AddShield(Shield s)
        {
            Hashtable ht = this.shields;
            string key = s.Name;
            if (KeyExists(key, ht) && (int)ht[key] < MaxShields)
            {
                this.shields[key] = (int)ht[key] + 1;
            }
            else
            {
                ht.Add(key, 1);
            }
        }

        public void RemoveShield(Shield s)
        {
            Hashtable ht = this.shields;
            string key = s.Name;
            if (KeyExists(key, ht))
            {
                if ((int)ht[key] > 1)
                {
                    this.shields[key] = (int)ht[key] - 1;
                }
                else
                {
                    ht.Remove(key);
                }
            }
        }

        public void ClearShield()
        {
            this.shields.Clear();
        }
        #endregion

        #region Helm Methods
        public void AddHelm(Helm h)
        {
            Hashtable ht = this.helms;
            string key = h.Name;
            if (KeyExists(key, ht) && (int)ht[key] < MaxHelms)
            {
                this.helms[key] = (int)ht[key] + 1;
            }
            else
            {
                ht.Add(key, 1);
            }
        }

        public void RemoveHelm(Helm h)
        {
            Hashtable ht = this.helms;
            string key = h.Name;
            if (KeyExists(key, ht))
            {
                if ((int)ht[key] > 1)
                {
                    this.helms[key] = (int)ht[key] - 1;
                }
                else
                {
                    ht.Remove(key);
                }
            }
        }

        public void ClearHelms()
        {
            this.helms.Clear();
        }
        #endregion

        #region Armor Methods
        public void AddArmor(Armor a)
        {
            Hashtable ht = this.armors;
            string key = a.Name;
            if (KeyExists(key, ht) && (int)ht[key] < MaxArmors)
            {
                this.armors[key] = (int)ht[key] + 1;
            }
            else
            {
                ht.Add(key, 1);
            }
        }

        public void RemoveArmor(Armor a)
        {
            Hashtable ht = this.armors;
            string key = a.Name;
            if (KeyExists(key, ht))
            {
                if ((int)ht[key] > 1)
                {
                    this.armors[key] = (int)ht[key] - 1;
                }
                else
                {
                    ht.Remove(key);
                }
            }
        }

        public void ClearArmor()
        {
            this.armors.Clear();
        }
        #endregion

        #region Accessory Methods
        public void AddAccessory(Accessory a)
        {
            Hashtable ht = this.accessories;
            string key = a.Name;
            if (KeyExists(key, ht) && (int)ht[key] < MaxAccessories)
            {
                this.accessories[key] = (int)ht[key] + 1;
            }
            else
            {
                ht.Add(key, 1);
            }
        }

        public void RemoveAccessory(Accessory a)
        {
            Hashtable ht = this.accessories;
            string key = a.Name;
            if (KeyExists(key, ht))
            {
                if ((int)ht[key] > 1)
                {
                    this.accessories[key] = (int)ht[key] - 1;
                }
                else
                {
                    ht.Remove(key);
                }
            }
        }

        public void ClearAccessories()
        {
            this.accessories.Clear();
        }
        #endregion
        #endregion
    }
}
