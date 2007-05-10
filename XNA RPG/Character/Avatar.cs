using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using XNA_RPG.Mapping;
using XNA_RPG.Menu;

namespace XNA_RPG.Character
{
    public class Avatar
    {
        #region Attributes
        private string image;
        private Texture2D texture;
        private Vector2 position;
        private Vector2 lastPosition;
        private Direction direction;
        private int frameCount;
        private bool isMoving;
        private float walkingSpeed;
        private float runningSpeed;
        #endregion

        #region Properties
        public string Image
        {
            get { return this.image; }
            set { this.image = value; }
        }

        public Texture2D Texture
        {
            get { return this.texture; }
            set { this.texture = value; }
        }

        public Vector2 Position
        {
            get { return this.position; }
            set { this.position = value; }
        }

        public Vector2 LastPosition
        {
            get { return this.lastPosition; }
            set { this.lastPosition = value; }
        }

        public Direction Direction
        {
            get { return this.direction; }
            set { this.direction = value; }
        }

        public int FrameCount
        {
            get { return this.frameCount; }
            set { this.frameCount = value; }
        }

        public bool IsMoving
        {
            get { return this.isMoving; }
            set { this.isMoving = value; }
        }

        public float WalkingSpeed
        {
            get { return this.walkingSpeed; }
            set { this.walkingSpeed = value; }
        }

        public float RunningSpeed
        {
            get { return this.runningSpeed; }
            set { this.runningSpeed = value; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// This is the empty constructor for Avatar. A default image is set.
        /// </summary>
        public Avatar()
        {
            this.position = new Vector2(0, 0);
            this.direction = Direction.DOWN;
            this.frameCount = 0;
            this.isMoving = false;
            this.walkingSpeed = 5.0f;
            this.runningSpeed = 10.0f;
        }

        /// <summary>
        /// This is the preferred constructor for Avatar.
        /// </summary>
        /// <param name="img">the Avatar image</param>
        public Avatar(string img)
        {
            this.image = img;
            this.position = new Vector2(0, 0);
            this.frameCount = 0;
            this.isMoving = false;
            this.walkingSpeed = 5.0f;
            this.runningSpeed = 10.0f;
        }
        #endregion

        #region Methods
        public Rectangle GetCurrentFrame()
        {
            if (this.isMoving == true)
            {
                this.frameCount++;
            }

            int x = ChipsetTile.Width * ((this.frameCount / 10) % 3);
            int y = 0;
            int width = ChipsetTile.Width;
            int height = ChipsetTile.Height;
            switch (this.direction)
            {
                case Direction.UP:
                    y = 0;
                    break;
                case Direction.RIGHT:
                    y = ChipsetTile.Width;
                    break;
                case Direction.DOWN:
                    y = 2 * ChipsetTile.Height;
                    break;
                case Direction.LEFT:
                    y = 3 * ChipsetTile.Width;
                    break;
                default:
                    y = 0;
                    break;
            }
            Rectangle rect = new Rectangle(x, y, width, height);
            return rect;
        }
        #endregion
    }
}
