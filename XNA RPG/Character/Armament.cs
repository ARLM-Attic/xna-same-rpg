using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace RPGLibrary
{
    public class Armament
    {
        #region Attributes
        private string name;
        // stat boosts
        private int attackBoost;
        private int defenseBoost;
        private int magicResistBoost;
        private int evadeBoost;
        private int magicEvadeBoost;
        private int strengthBoost;
        private int magicPowerBoost;
        private int vitalityBoost;
        private int speedBoost;
        #endregion

        #region Properties
        /// <summary>This method gets/sets the name attribute.</summary>
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        /// <summary>This method gets/sets the attack attribute.</summary>
        public int ATKBoost
        {
            get { return this.attackBoost; }
            set { this.attackBoost = value; }
        }

        /// <summary>This method gets/sets the defense attribute.</summary>
        public int DEFBoost
        {
            get { return this.defenseBoost; }
            set { this.defenseBoost = value; }
        }

        /// <summary>This method gets/sets the magicResist attribute.</summary>
        public int MRSTBoost
        {
            get { return this.magicResistBoost; }
            set { this.magicResistBoost = value; }
        }

        /// <summar>This method gets/sets the evade attribute.</summar>
        public int EVABoost
        {
            get { return this.evadeBoost; }
            set { this.evadeBoost = value; }
        }

        /// <summary>This method gets/sets the magicEvade attribute.</summary>
        public int MEVABoost
        {
            get { return this.magicEvadeBoost; }
            set { this.magicEvadeBoost = value; }
        }

        /// <summary>This method gets/sets the strength attribute.</summary>
        public int STRBoost
        {
            get { return this.strengthBoost; }
            set { this.strengthBoost = value; }
        }

        /// <summary>This method gets/sets the magicPower attribute.</summary>
        public int MPOWBoost
        {
            get { return this.magicPowerBoost; }
            set { this.magicPowerBoost = value; }
        }

        /// <summary>This method gets/sets the vitality attribute.</summary>
        public int VITBoost
        {
            get { return this.vitalityBoost; }
            set { this.vitalityBoost = value; }
        }

        /// <summary>This method gets/sets the speed attribute.</summary>
        public int SPDBoost
        {
            get { return this.speedBoost; }
            set { this.speedBoost = value; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// This is the empty constructor for Armament.
        /// </summary>
        public Armament()
        {
        }
        #endregion

        #region Methods
        /// <summary>This method returns the name of the Armament.</summary>
        public override string ToString()
        {
            return this.Name;
        }
        #endregion
    }
}

