using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace RPGLibrary
{
    public class Armor : Armament
    {
        #region Attributes
        #endregion

        #region Properties
        #endregion

        #region Constructors
        /// <summary>
        /// This is the empty constructor for Armor.
        /// </summary>
        public Armor()
        {
        }

        /// <summary>
        /// This constructor takes in a string as the name of the Armor.
        /// </summary>
        /// <param name="n">the name of the armor</param>
        public Armor(string n)
        {
            base.Name = n;
        }
        #endregion

        #region Methods
        #endregion
    }
}
