using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace RPGLibrary
{
    public class Helm : Armament
    {
        #region Attributes
        #endregion

        #region Properties
        #endregion

        #region Constructors
        /// <summary>
        /// This is the empty constructor for Helm.
        /// </summary>
        public Helm()
        {
        }

        /// <summary>
        /// This constructor takes in a string as the name of the Helm.
        /// </summary>
        /// <param name="n">the name of the helm</param>
        public Helm(string n)
        {
            base.Name = n;
        }
        #endregion

        #region Methods
        #endregion
    }
}
