using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace RPGLibrary
{
    public class Shield : Armament
    {
        #region Attributes
        #endregion

        #region Properties
        #endregion

        #region Constructors
        /// <summary>
        /// This is the empty constructor for Shield.
        /// </summary>
        public Shield()
        {
        }

        /// <summary>
        /// This constructor takes in a string as the name of the shield.
        /// </summary>
        /// <param name="n">the name of the shield</param>
        public Shield(string n)
        {
            base.Name = n;
        }
        #endregion

        #region Methods
        #endregion
    }
}
