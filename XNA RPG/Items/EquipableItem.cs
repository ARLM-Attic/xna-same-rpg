using System;
using System.Collections.Generic;
using System.Text;
using XNA_RPG.Character;

namespace XNA_RPG.Items
{
    public class EquipableItem : Item
    {
        #region Attributes
        private int attackUp;
        private int defenseUp;
        private int magicDefenseUp;
        private int evadeUp;
        private int magicEvadeUp;
        private int strengthUp;
        private int magicPowerUp;
        private int vitalityUp;
        private int speedUp;
        #endregion

        #region Properties
        public int ATKUP
        {
            get { return this.attackUp; }
            set { this.attackUp = value; }
        }

        public int DEFUP
        {
            get { return this.defenseUp; }
            set { this.defenseUp = value; }
        }

        public int MDEFUP
        {
            get { return this.magicDefenseUp; }
            set { this.magicDefenseUp = value; }
        }

        public int EVAUP
        {
            get { return this.evadeUp; }
            set { this.evadeUp = value; }
        }

        public int MEVAUP
        {
            get { return this.magicEvadeUp; }
            set { this.magicEvadeUp = value; }
        }

        public int STRUP
        {
            get { return this.strengthUp; }
            set { this.strengthUp = value; }
        }

        public int MPOWUP
        {
            get { return this.magicPowerUp; }
            set { this.magicPowerUp = value; }
        }

        public int VITUP
        {
            get { return this.vitalityUp; }
            set { this.vitalityUp = value; }
        }

        public int SPDUP
        {
            get { return this.speedUp; }
            set { this.speedUp = value; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// This is the empty constructor for EquipableItem.
        /// </summary>
        public EquipableItem()
            : base()
        {
        }

        /// <summary>
        /// This is the preferred constructor for EquipableItem.
        /// </summary>
        /// <param name="n">the name of the item</param>
        public EquipableItem(string n)
            : base(n)
        {
        }
        #endregion

        #region Methods
        public virtual void Equip(Combatant comb)
        {
        }

        public virtual void Unequip(Combatant comb)
        {
        }
        #endregion
    }
}
