using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace RPGLibrary
{
    public class Combatant
    {
        #region Attributes
        private string name;
        private int level;
        private int experiencePoints;
        private int hitPoints;
        private int manaPoints;
        // character stats
        private int attack;
        private int defense;
        private int magicResist;
        private int evade;
        private int magicEvade;
        private int strength;
        private int magicPower;
        private int vitality;
        private int speed;
        // status effects
        private List<StatusEffect> statusEffects;
        public const int MaxLevel = 99;
        #endregion

        #region Properties
        /// <summary>This method gets/sets the name attribute.</summary>
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        /// <summary>This method gets/sets the level attribute.</summary>
        public int Level
        {
            get { return this.level; }
            set { this.level = value; }
        }

        /// <summary>This method gets/sets the experiencePoints attribute.</summary>
        public int EXP
        {
            get { return this.experiencePoints; }
            set { this.experiencePoints = value; }
        }

        /// <summary>This method gets/sets the hp attribute.</summary>
        public int HP
        {
            get { return this.hitPoints; }
            set { this.hitPoints = value; }
        }

        /// <summary>This method gets/sets the mp attribute.</summary>
        public int MP
        {
            get { return this.manaPoints; }
            set { this.manaPoints = value; }
        }

        /// <summary>This method gets/sets the attack attribute.</summary>
        public int ATK
        {
            get { return this.attack; }
            set { this.attack = value; }
        }

        /// <summary>This method gets/sets the defense attribute.</summary>
        public int DEF
        {
            get { return this.defense; }
            set { this.defense = value; }
        }

        /// <summary>This method gets/sets the magicResist attribute.</summary>
        public int MRST
        {
            get { return this.magicResist; }
            set { this.magicResist = value; }
        }

        /// <summar>This method gets/sets the evade attribute.</summar>
        public int EVA
        {
            get { return this.evade; }
            set { this.evade = value; }
        }
 
        /// <summary>This method gets/sets the magicEvade attribute.</summary>
        public int MEVA
        {
            get { return this.magicEvade; }
            set { this.magicEvade = value; }
        }

        /// <summary>This method gets/sets the strength attribute.</summary>
        public int STR
        {
            get { return this.strength; }
            set { this.strength = value; }
        }

        /// <summary>This method gets/sets the magicPower attribute.</summary>
        public int MPOW
        {
            get { return this.magicPower; }
            set { this.magicPower = value; }
        }

        /// <summary>This method gets/sets the vitality attribute.</summary>
        public int VIT
        {
            get { return this.vitality; }
            set { this.vitality = value; }
        }

        /// <summary>This method gets/sets the speed attribute.</summary>
        public int SPD
        {
            get { return this.speed; }
            set { this.speed = value; }
        }

        /// <summary>This method gets the statusEffects attribute.</summary>
        public int StatusEffects
        {
            get { return this.statusEffects; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// This is the empty constructor for Combatant.
        /// </summary>
        public Combatant()
        {
            this.statusEffects = new List<StatusEffect>();
        }
        #endregion

        #region Methods
        /// <summary>This method returns the Combatant's name.</summary>
        public override string ToString()
        {
            return this.Name;
        }

        public void LevelUp()
        {
        }

        #region StatusEffect Methods
        /// <summary>
        /// This method checks if the combatant has a certain status effect.
        /// </summary>
        /// <param name="se">the status effect to be checked</param>
        /// <returns>boolean for existence of status effect</returns>
        public bool HasStatusEffect(StatusEffect se)
        {
            bool result = false;
            foreach (StatusEffect statusEffect in this.statusEffects)
            {
                if (statusEffect.Name == se.Name)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// This method gets actual status effect object from the list.
        /// </summary>
        /// <param name="se">the status effect to get</param>
        /// <returns>the status effect from StatusEffects</returns>
        public StatusEffect GetStatusEffect(StatusEffect se)
        {
            StatusEffect result = null;
            foreach (StatusEffect statusEffect in this.statusEffects)
            {
                if (statusEffect.Name == se.Name)
                {
                    result = statusEffect;
                    break;
                }
            }
            return result;
        }

        /// <summary>This method adds a status effect.</summary>
        /// <param name="se">the status effect to be added</param>
        public void AddStatusEffect(StatusEffect se)
        {
            if (!HasStatusEffect(se))
            {
                this.statusEffects.Add(se);
            }
        }

        /// <summary>This method removes a status effect.</summary>
        /// <param name="se">the status effect to be removed</param>
        public void RemoveStatusEffect(StatusEffect se)
        {
            if (HasStatusEffect(se))
            {
                StatusEffect statusEffect = this.GetStatusEffect(se);
                this.statusEffect.Remove(statusEffect);
            }
        }
        #endregion

        public void Draw(GraphicsDevice graphics)
        {
        }
        #endregion
    }
}
