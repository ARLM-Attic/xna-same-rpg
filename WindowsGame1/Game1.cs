#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using XNA_RPG.Map;
using XNA_RPG.Character;
using XNA_RPG.Menu;
#endregion

namespace WindowsGame1
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        #region Variables

        GraphicsDeviceManager graphics;
        ContentManager content;

        //Variables for Map testing
        Chipset chipset;
        Chipset systemchipset;
        Map map;
        Combatant mainCharacter;

        //Graphics
        SpriteBatch spritebatch;
        Vector2 screenSize;
        Vector2 focus;
        Vector2 characterPosition;
        float walkingSpeed;
        Direction direction;
        Vector2 oldCharPos;
        Vector2 oldFocus;

        //menu
        bool menuActive;
        bool menuPressed;
        Menu menu;

        

        #endregion


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            content = new ContentManager(Services);

        }


        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {

            InitializeChipsets();
            InitializeMaps();
            InitializeCharacter();
            InitializeMenu();

            screenSize.X = 12;
            screenSize.Y = 12;
            graphics.PreferredBackBufferWidth = (int)screenSize.X * ChipsetTile.WIDTH;
            graphics.PreferredBackBufferHeight = (int)screenSize.Y * ChipsetTile.HEIGHT;

            spritebatch = new SpriteBatch(graphics.GraphicsDevice);
            focus = new Vector2(0, 0);
            characterPosition = new Vector2(0, 0);
            walkingSpeed = 5.0f;

            menuActive = false;
            menuPressed = false;



            base.Initialize();
        }

        public void InitializeChipsets()
        {

            //Create Chipsets
            chipset = new Chipset(36, 36);
            chipset.AddTile("Content\\Map\\Chipsets\\Grass1", true);
            chipset.AddTile("Content\\Map\\Chipsets\\dirt", false);

            systemchipset = new Chipset(36, 36);
            systemchipset.AddTile("Content\\System\\blank", false);



        }

        public void InitializeMaps()
        {
            //Create Map
            map = new Map(chipset, 50, 50);
            map.InsertIntoBottomLayer(new int[]{
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            });
        }

        public void InitializeCharacter()
        {
            mainCharacter = new Combatant();
            direction = Direction.DOWN;
        }

        public void InitializeMenu()
        {
            menu = new Menu();
            menu.MenuFont = content.Load<SpriteFont>("Content\\Fonts\\Arial17");
        }

        /// <summary>
        /// Load your graphics content.  If loadAllContent is true, you should
        /// load content from both ResourceManagementMode pools.  Otherwise, just
        /// load ResourceManagementMode.Manual content.
        /// </summary>
        /// <param name="loadAllContent">Which type of content to load.</param>
        protected override void LoadGraphicsContent(bool loadAllContent)
        {
            if (loadAllContent)
            {
                foreach (ChipsetTile tile in chipset.Tiles)
                {
                    tile.Texture = content.Load<Texture2D>(tile.AssetName);
                }

                foreach (ChipsetTile tile in systemchipset.Tiles)
                {
                    tile.Texture = content.Load<Texture2D>(tile.AssetName);
                }

                mainCharacter.Texture = content.Load<Texture2D>("Content\\Characters\\Walking\\testchar");
                menu.Texture = content.Load<Texture2D>("Content\\Menu\\MenuBackground");
            }

            // TODO: Load any ResourceManagementMode.Manual content
        }


        /// <summary>
        /// Unload your graphics content.  If unloadAllContent is true, you should
        /// unload content from both ResourceManagementMode pools.  Otherwise, just
        /// unload ResourceManagementMode.Manual content.  Manual content will get
        /// Disposed by the GraphicsDevice during a Reset.
        /// </summary>
        /// <param name="unloadAllContent">Which type of content to unload.</param>
        protected override void UnloadGraphicsContent(bool unloadAllContent)
        {
            if (unloadAllContent)
            {
                // TODO: Unload any ResourceManagementMode.Automatic content
                content.Unload();
            }

            // TODO: Unload any ResourceManagementMode.Manual content
        }


        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            #region Menu Logic
            if (Keyboard.GetState().IsKeyDown(Keys.D) == true)
            {

                if (menuPressed == false)
                {
                    if (menuActive == true)
                        menuActive = false;
                    else
                        menuActive = true;
                }

                menuPressed = true;
            }
            else
            {
                menuPressed = false;
            }
            #endregion

            if (menuActive == false)
            {
                #region If Menu Isnt Pressed, most Game Logic

                if (characterPosition != null)
                    oldCharPos = characterPosition;
                if (focus != null)
                    oldFocus = focus;

                // Allows the game to exit
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                    this.Exit();

                #region Basic Map Movement

                if (Keyboard.GetState().IsKeyDown(Keys.Up) == true
                    && characterPosition.Y == graphics.GraphicsDevice.Viewport.Height / 2)
                {
                    focus.Y -= walkingSpeed / 100.0f;
                    direction = Direction.UP;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Down) == true
                    && characterPosition.Y == graphics.GraphicsDevice.Viewport.Height / 2)
                {
                    focus.Y += walkingSpeed / 100.0f;
                    direction = Direction.DOWN;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Right) == true
                    && characterPosition.X == graphics.GraphicsDevice.Viewport.Width / 2)
                {
                    focus.X += walkingSpeed / 100.0f;
                    direction = Direction.RIGHT;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Left) == true
                    && characterPosition.X == graphics.GraphicsDevice.Viewport.Width / 2)
                {
                    focus.X -= walkingSpeed / 100.0f;
                    direction = Direction.LEFT;
                }
                #endregion

                #region Map Boundary Checks
                if (focus.X >= map.Width - screenSize.X)
                    focus.X = map.Width - screenSize.X;

                if (focus.X < 0)
                    focus.X = 0;

                if (focus.Y >= map.Height - screenSize.Y)
                    focus.Y = map.Height - screenSize.Y;

                if (focus.Y < 0)
                    focus.Y = 0;
                #endregion

                #region Character Movement Checks

                if (focus.X <= 0 || focus.X >= map.Width - screenSize.X || focus.Y <= 0 || focus.Y >= map.Height - screenSize.Y)
                {

                    #region Map and character at top left of map
                    if (focus.X <= 0)
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.Right) == true)
                        {
                            characterPosition.X += walkingSpeed;
                            direction = Direction.RIGHT;
                        }
                        if (Keyboard.GetState().IsKeyDown(Keys.Left) == true)
                        {
                            characterPosition.X -= walkingSpeed;
                            direction = Direction.LEFT;
                        }
                        if (characterPosition.X <= 0)
                        {
                            characterPosition.X = 0;
                        }
                        if (characterPosition.X >= graphics.GraphicsDevice.Viewport.Width / 2)
                        {
                            characterPosition.X = graphics.GraphicsDevice.Viewport.Width / 2;
                        }

                    }

                    if (focus.Y <= 0)
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.Down) == true)
                        {
                            characterPosition.Y += walkingSpeed;
                            direction = Direction.DOWN;
                        }
                        if (Keyboard.GetState().IsKeyDown(Keys.Up) == true)
                        {
                            characterPosition.Y -= walkingSpeed;
                            direction = Direction.UP;
                        }
                        if (characterPosition.Y <= 0)
                        {
                            characterPosition.Y = 0;
                        }
                        if (characterPosition.Y >= graphics.GraphicsDevice.Viewport.Height / 2)
                        {
                            characterPosition.Y = graphics.GraphicsDevice.Viewport.Height / 2;
                        }
                    }
                    #endregion

                    #region Map and character at bottom right of map
                    if (focus.X >= map.Width - screenSize.X)
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.Right) == true)
                        {
                            characterPosition.X += walkingSpeed;
                            direction = Direction.RIGHT;
                        }
                        if (Keyboard.GetState().IsKeyDown(Keys.Left) == true)
                        {
                            characterPosition.X -= walkingSpeed;
                            direction = Direction.LEFT;
                        }
                        if (characterPosition.X <= graphics.GraphicsDevice.Viewport.Width / 2)
                        {
                            characterPosition.X = graphics.GraphicsDevice.Viewport.Width / 2;
                        }
                        if (characterPosition.X >= graphics.GraphicsDevice.Viewport.Width)
                        {
                            characterPosition.X = graphics.GraphicsDevice.Viewport.Width;
                        }
                    }

                    if (focus.Y >= map.Height - screenSize.Y)
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.Down) == true)
                        {
                            characterPosition.Y += walkingSpeed;
                            direction = Direction.DOWN;
                        }
                        if (Keyboard.GetState().IsKeyDown(Keys.Up) == true)
                        {
                            characterPosition.Y -= walkingSpeed;
                            direction = Direction.UP;
                        }
                        if (characterPosition.Y <= graphics.GraphicsDevice.Viewport.Height / 2)
                        {
                            characterPosition.Y = graphics.GraphicsDevice.Viewport.Height / 2;
                        }
                        if (characterPosition.Y >= graphics.GraphicsDevice.Viewport.Height)
                        {
                            characterPosition.Y = graphics.GraphicsDevice.Viewport.Height;
                        }
                    }
                    #endregion

                    #region Making sure character stays on the screen

                    if (characterPosition.X >= (graphics.GraphicsDevice.Viewport.Width) - ChipsetTile.WIDTH)
                    {
                        characterPosition.X = (graphics.GraphicsDevice.Viewport.Width) - ChipsetTile.WIDTH;
                    }
                    if (characterPosition.Y >= (graphics.GraphicsDevice.Viewport.Height) - ChipsetTile.HEIGHT)
                    {
                        characterPosition.Y = (graphics.GraphicsDevice.Viewport.Height) - ChipsetTile.HEIGHT;
                    }
                    #endregion

                }

                else
                {
                    characterPosition.X = graphics.GraphicsDevice.Viewport.Width / 2;
                    characterPosition.Y = graphics.GraphicsDevice.Viewport.Height / 2;
                }
                #endregion

                #region CollisionChecking

                bool collision;

                //4 tile checks
                Vector2 charac = GetMapPosition(characterPosition);

                Vector2 tile1 = new Vector2((int)charac.X, (int)charac.Y);
                Vector2 tile2 = new Vector2(tile1.X + 1, tile1.Y);
                Vector2 tile3 = new Vector2(tile1.X, tile1.Y + 1);
                Vector2 tile4 = new Vector2(tile1.X + 1, tile1.Y + 1);

                try
                {
                    if (chipset.Tiles[map.BottomLayer[(int)tile1.X, (int)tile1.Y]].IsWalkable == true
                        && chipset.Tiles[map.BottomLayer[(int)tile2.X, (int)tile2.Y]].IsWalkable == true
                        && chipset.Tiles[map.BottomLayer[(int)tile3.X, (int)tile3.Y]].IsWalkable == true
                        && chipset.Tiles[map.BottomLayer[(int)tile4.X, (int)tile4.Y]].IsWalkable == true)
                    {
                        collision = false;
                    }
                    else
                    {
                        collision = true;
                    }
                }
                catch (Exception e)
                {
                    collision = true;
                    Console.WriteLine("caught exception");
                }

                if (collision == true)
                {
                    characterPosition = oldCharPos;
                    focus = oldFocus;
                }
                #endregion

                #region Moving Check

                if (Keyboard.GetState().IsKeyDown(Keys.Up) == true ||
                   Keyboard.GetState().IsKeyDown(Keys.Down) == true ||
                   Keyboard.GetState().IsKeyDown(Keys.Left) == true ||
                   Keyboard.GetState().IsKeyDown(Keys.Right) == true)
                {
                    mainCharacter.IsMoving = true;
                }
                else
                {
                    mainCharacter.IsMoving = false;
                }

                #endregion
                #endregion
            }
            base.Update(gameTime);
        }


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {


            spritebatch.Begin();

            RenderMap();
            RenderCharacter();

            if (menuActive == true)
            {
                RenderMenu();
            }

            spritebatch.End();

           


            base.Draw(gameTime);
        }

        public void RenderMap()
        {

            for (int i = (int)focus.X; i < focus.X + screenSize.X + 1; i++)
            {
                for (int j = (int)focus.Y; j < focus.Y + screenSize.Y + 1; j++)
                {
                    if (i >= 0 && i < map.Width && j >= 0 && j < map.Height)
                    {
                        spritebatch.Draw(chipset.Tiles[map.BottomLayer[i, j]].Texture, new Vector2((i - focus.X) * ChipsetTile.WIDTH, (j - focus.Y) * ChipsetTile.HEIGHT), Color.White);
                    }
                    else
                    {
                        spritebatch.Draw(systemchipset.Tiles[0].Texture, new Vector2((i - focus.X) * ChipsetTile.WIDTH, (j - focus.Y) * ChipsetTile.HEIGHT), Color.White);
                    }
                }
            }
        }

        public void RenderCharacter()
        {

            spritebatch.Draw(mainCharacter.Texture, new Vector2(characterPosition.X, characterPosition.Y),
                mainCharacter.GetCurrentFrame(direction), Color.White);
        }

        public void RenderMenu()
        {
            spritebatch.Draw(menu.Texture, 
                new Rectangle(0, 0, graphics.GraphicsDevice.Viewport.Width, 
                graphics.GraphicsDevice.Viewport.Height), Color.White);            

            menu.Draw(spritebatch, TargetElapsedTime);
        }

        public Vector2 GetMapPosition(Vector2 screenPosition)
        {
            Vector2 mapPosition = new Vector2();

            mapPosition.X = focus.X + (screenPosition.X / ChipsetTile.WIDTH);
            mapPosition.Y = focus.Y + (screenPosition.Y / ChipsetTile.HEIGHT);

            return mapPosition;
        }
    }
}
