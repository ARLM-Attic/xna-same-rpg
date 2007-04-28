using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace RPGLibrary
{
    public class Weapon : Armament
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
        {
        }

        /// <summary>
        /// This constructor takes in a string as the name of the Weapon.
        /// </summary>
        /// <param name="n">the name of the weapon</param>
        public Weapon(string n)
        {
            base.Name = n;
        }
        #endregion

        #region Methods
        #endregion
    }
}