using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace RPGLibrary
{
    public class StatusEffect
    {
        #region Attributes
        private string name;
        private int counter;
        private bool positive;
        #endregion

        #region Properties
        /// <summary>This method gets/sets the name attribute.</summary>
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        /// <summary>This method gets/sets the counter attribute.</summary>
        public int Counter
        {
            get { return this.counter; }
            set { this.counter = value; }
        }

        /// <summary>This method sets the positive attribute.</summary>
        public bool Positive
        {
            set { this.positive = value; }
        }   
        #endregion

        #region Costructors
        /// <summary>This is the empty constructor for StatusEffect.</summary>
        public StatusEffect()
        {
            this.positive = true;
        }
        #endregion

        #region Methods
        /// <summary>This method returns the name attribute.</summary>
        public override string ToString()
        {
            return this.name;
        }

        /// <summary>This method returns the positive attribute.</summary>
        /// <returns>positive attribute</returns>
        public bool IsPositive()
        {
            return this.positive;
        }

        /// <summary>
        /// This method is meant to be overridden.
        /// It is used to determine whether or not a status effect
        /// may be removed.
        /// </summary>
        /// <returns></returns>
        public virtual bool IsDone()
        {
            bool result = false;
            return result;
        }

        /// <summary>
        /// This method is meant to be overridden.
        /// It is used to affect the combatant in some way.
        /// </summary>
        public virtual void Affect(Combatant c)
        {
        }
        #endregion
    }
}
