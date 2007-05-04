using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace XNA_RPG.Character
{
    public class Accessory : Armament
    {
        #region Attributes
        #endregion

        #region Properties
        #endregion

        #region Constructors
        /// <summary>
        /// This is the empty constructor for Accessory.
        /// </summary>
        public Accessory()
        {
        }

        /// <summary>
        /// This constructor takes in a string as the name of the Accessory.
        /// </summary>
        /// <param name="n">the name of the accessory</param>
        public Accessory(string n)
        {
            base.Name = n;
        }
        #endregion

        #region Methods
        #endregion
    }
}
