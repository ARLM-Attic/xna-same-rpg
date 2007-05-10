using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;

namespace XNA_RPG.Character
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
        private string moveImage;
        private string faceImage;
        private Texture2D texture;
        private Texture2D face;
        // status effects
        private List<StatusEffect> statusEffects;
        public const int MaxLevel = 99;
        // graphics
        private int frameCount;
        private bool isMoving;
        // max values
        private int maxHP;
        private int maxMP;
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
        public List<StatusEffect> StatusEffects
        {
            get { return this.statusEffects; }
        }

        public string MoveImage
        {
            get
            {
                return moveImage;
            }
            set
            {
                moveImage = value;
            }
        }

        public string FaceImage
        {
            get
            {
                return faceImage;
            }
            set
            {
                faceImage = value;
            }
        }

        public Texture2D Texture
        {
            get
            {
                return texture;
            }
            set
            {
                texture = value;
            }
        }

        public Texture2D Face
        {
            get
            {
                return face;
            }
            set
            {
                face = value;
            }
        }

        public int FrameCount
        {
            get
            {
                return frameCount;
            }
            set
            {
                frameCount = value;
            }
        }

        public bool IsMoving
        {
            get
            {
                return isMoving;
            }
            set
            {
                isMoving = value;
            }
        }

        public int MaxHP
        {
            get { return this.maxHP; }
            set { this.maxHP = value; }
        }

        public int MaxMP
        {
            get { return this.maxMP; }
            set { this.maxMP = value; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// This is the empty constructor for Combatant.
        /// </summary>
        public Combatant()
        {
            this.statusEffects = new List<StatusEffect>();
            frameCount = 0;
            isMoving = false;
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
                this.statusEffects.Remove(statusEffect);
            }
        }
        #endregion

        public void Draw(GraphicsDevice graphics)
        {
        }
        #endregion

        /*
         * Not implemented yet, for now just returns first frame
         */
        public Rectangle GetCurrentFrame(Direction direction)
        {
            if (isMoving == true)
            {
                frameCount++;
            }

            if (frameCount > 29)
            {
                frameCount = 0;
            }
            switch (direction)
            {
                case Direction.UP:
                    return (new Rectangle(64 * (frameCount / 10), 0, 64, 64));

                case Direction.RIGHT:
                    return (new Rectangle(64 * (frameCount / 10), 64, 64, 64));

                case Direction.DOWN:
                    return (new Rectangle(64 * (frameCount / 10), 128, 64, 64));

                case Direction.LEFT:
                    return (new Rectangle(64 * (frameCount / 10), 192, 64, 64));
                
                default:
                    return (new Rectangle(64 * (frameCount / 10), 0, 64, 64));

            }

          
        }
    }
}

