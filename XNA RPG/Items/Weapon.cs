using System;
using System.Collections.Generic;
using System.Text;

namespace XNA_RPG.Items
{
    public class Weapon : EquipableItem
    {
        #region Attributes
        #endregion

        #region Properties
        #endregion

        #region Constructors
        /// <summary>
        /// This is the empty constructor for Weapon.
        /// </summary>
        public Weapon()
            : base()
        {
        }

        /// <summary>
        /// This is the preferred constructor for Weapon.
        /// </summary>
        /// <param name="n">the name of the weapon</param>
        public Weapon(string n)
            : base(n)
        {
        }
        #endregion

        #region Methods
        #endregion
    }
}
