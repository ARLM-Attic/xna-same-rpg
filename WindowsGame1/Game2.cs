using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using XNA_RPG.Mapping;
using XNA_RPG.Character;
using XNA_RPG.Menu;
using XNA_RPG.XML;
using WindowsGame1.Submenus;

namespace WindowsGame2
{
    public class Game2 : Microsoft.Xna.Framework.Game
    {
        #region Attributes
        GraphicsDeviceManager graphics;
        ContentManager content;
        //Variables for Map testing
        Chipset chipset;
        Chipset systemchipset;
        Map map;
        //Graphics
        private Avatar avatar;
        SpriteBatch spritebatch;
        Vector2 screenSize;
        Vector2 focus;
        Vector2 oldFocus;

        //Party
        Combatant char1;
        Combatant char2;
        Combatant char3;
        Item potion;
        Weapon sword;
        Accessory chain;

        //Menu
        Menu menu;
        Main submain;
        Items itemssub;

        private XMLAgent xmlAgent;
        private GameStates gameState;
        private Party party;
        //Constants/Enums
        public enum GameStates { InStartMenu, ReadyWorld, InWorld, ReadyMenu,
            InMenu, InBattle };
        #endregion

        public Game2()
        {
            graphics = new GraphicsDeviceManager(this);
            content = new ContentManager(Services);
        }

        #region Methods
        #region Initializers
        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            this.gameState = GameStates.InWorld;
            this.xmlAgent = new XMLAgent();
            this.avatar = new Avatar();

            InitializeChipsets();
            InitializeMaps();
            InitializeMenu();
            InitializeParty();

            screenSize.X = 12;
            screenSize.Y = 12;
            graphics.PreferredBackBufferWidth = (int)screenSize.X * ChipsetTile.Width;
            graphics.PreferredBackBufferHeight = (int)screenSize.Y * ChipsetTile.Height;

            spritebatch = new SpriteBatch(graphics.GraphicsDevice);
            focus = new Vector2(0, 0);

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

        // TODO: make map loader
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
        
        public void InitializeMenu()
        {
            menu = new Menu();
            menu.MenuFont = content.Load<SpriteFont>("Content\\Fonts\\Arial17");

            submain = new Main("Party");
            menu.MainSubMenu = submain;

            itemssub = new Items("Items");
            menu.Submenus.Add(itemssub);
            

            submain.SmallFont = content.Load<SpriteFont>("Content\\Fonts\\Arial13");
        }

        public void InitializeParty()
        {
            this.party = new Party();

            //Character1
            char1 = new Combatant();
            char1.ATK = 15;
            char1.DEF = 17;
            char1.HP = 40;
            char1.MP = 12;
            char1.MaxHP = 45;
            char1.MaxMP = 20;
            char1.Name = "Icon";
            char1.FaceImage = "Content\\Characters\\Menu\\daniel";

            //Character2
            char2 = new Combatant();
            char2.ATK = 12;
            char2.DEF = 15;
            char2.HP = 35;
            char2.MP = 11;
            char2.MaxHP = 75;
            char2.MaxMP = 30;
            char2.Name = "Splatilian";
            char2.FaceImage = "Content\\Characters\\Menu\\michael";

            //Character2
            char3 = new Combatant();
            char3.ATK = 16;
            char3.DEF = 11;
            char3.HP = 19;
            char3.MP = 20;
            char3.MaxHP = 60;
            char3.MaxMP = 21;
            char3.Name = "Vegeta";
            char3.FaceImage = "Content\\Characters\\Menu\\vegeta";

         
            party.AddCombatant(char1, Party.Status.Active);
            party.AddCombatant(char2, Party.Status.Active);
            party.AddCombatant(char3, Party.Status.Active);

            potion = new Item("Potion");
            sword = new Weapon("Ragnarok");
            chain = new Accessory("Golden Pendant");

            party.Bag.AddItem(potion);
            party.Bag.AddWeapon(sword);
            party.Bag.AddAccessory(chain);

            
        }
        #endregion

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

                this.avatar.Texture = content.Load<Texture2D>("Content\\Characters\\Walking\\testchar");
                menu.Texture = content.Load<Texture2D>("Content\\Menu\\MenuBackground");
                menu.Hand = content.Load<Texture2D>("Content\\Menu\\menuHand");
                submain.EmptyBar = content.Load<Texture2D>("Content\\Menu\\EmptyBar");
                submain.FullBar = content.Load<Texture2D>("Content\\Menu\\FullBar");
                
                char1.Face = content.Load<Texture2D>(char1.FaceImage);
                char2.Face = content.Load<Texture2D>(char2.FaceImage);
                char3.Face = content.Load<Texture2D>(char3.FaceImage);
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
            KeyboardState kbState = Keyboard.GetState();
            switch (this.gameState)
            {
                case GameStates.InStartMenu:
                    break;
                case GameStates.ReadyWorld:
                    if (kbState.IsKeyUp(Keys.D))
                    {
                        this.gameState = GameStates.InWorld;
                    }
                    break;
                case GameStates.InWorld:
                    Vector2 pos = this.avatar.Position;
                    Vector2 foc = this.focus;
                    //Vector2 mapPos = this.GetMapPosition(pos);
                    Vector2 mapPos = this.GetAvatarMapPosition(this.avatar);
                    if (pos != null)
                    {
                        this.avatar.LastPosition = pos;
                    }
                    if (foc != null)
                    {
                        this.oldFocus = foc;
                    }
                    if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                    {
                        this.Exit();
                    }

                    // Check for movement
                    if (kbState.IsKeyDown(Keys.Up) || kbState.IsKeyDown(Keys.Down) ||
                        kbState.IsKeyDown(Keys.Left) || kbState.IsKeyDown(Keys.Right))
                    {
                        this.avatar.IsMoving = true;
                    }
                    else
                    {
                        this.avatar.IsMoving = false;
                    }

                    float midViewHeight = (this.graphics.GraphicsDevice.Viewport.Height - ChipsetTile.Height) / 2;
                    float midViewWidth = (this.graphics.GraphicsDevice.Viewport.Width - ChipsetTile.Width) / 2;
                    float focusYBound = this.map.Height - this.screenSize.Y;
                    float focusXBound = this.map.Width - this.screenSize.X;
                    float avatarYBound = this.graphics.GraphicsDevice.Viewport.Height - ChipsetTile.Height;
                    float avatarXBound = this.graphics.GraphicsDevice.Viewport.Width - ChipsetTile.Width;
                    float increment = this.avatar.WalkingSpeed / 100.0f;
                    if (kbState.IsKeyDown(Keys.Up))
                    {
                        this.avatar.Direction = Direction.UP;
                        if (mapPos.Y > 0)
                        {
                            if (mapPos.Y < 1)
                            {
                                mapPos.Y = 1;
                            }
                            int aboveTile = this.map.BottomLayer[(int)mapPos.X, (int)mapPos.Y - 1];
                            if (this.chipset.Tiles[aboveTile].IsWalkable)
                            {
                                float newfocy = foc.Y - increment;
                                if (pos.Y <= (midViewHeight + this.avatar.WalkingSpeed) && newfocy > 0)
                                {
                                    this.focus.Y = newfocy;
                                }
                                else if (this.focus.Y <= increment || this.focus.Y >= (focusYBound - increment))
                                {
                                    this.avatar.Position = new Vector2(pos.X, (pos.Y - this.avatar.WalkingSpeed));
                                }
                            }
                        }
                    }
                    else if (kbState.IsKeyDown(Keys.Down))
                    {
                        this.avatar.Direction = Direction.DOWN;
                        if (mapPos.Y < (map.Height - 1))
                        {
                            int belowTile = this.map.BottomLayer[(int)mapPos.X, (int)mapPos.Y + 1];
                            if (this.chipset.Tiles[belowTile].IsWalkable)
                            {
                                float newfocy = foc.Y + increment;
                                if (pos.Y >= (midViewHeight - this.avatar.WalkingSpeed) &&
                                    newfocy <= focusYBound && newfocy > 0)
                                {
                                    this.focus.Y = newfocy;
                                }
                                else if ((this.focus.Y >= (focusYBound - increment) || this.focus.Y <= increment) &&
                                    pos.Y <= avatarYBound)
                                {
                                    this.avatar.Position = new Vector2(pos.X, pos.Y + this.avatar.WalkingSpeed);
                                }
                            }
                        }
                    }
                    else if (kbState.IsKeyDown(Keys.Left))
                    {
                        this.avatar.Direction = Direction.LEFT;
                        if (mapPos.X > 0)
                        {
                            if (mapPos.X < 1)
                            {
                                mapPos.X = 1;
                            }
                            int leftTile = this.map.BottomLayer[(int)mapPos.X - 1, (int)mapPos.Y];
                            if (this.chipset.Tiles[leftTile].IsWalkable)
                            {
                                float newfocx = foc.X - increment;
                                if (pos.X <= (midViewWidth + this.avatar.WalkingSpeed) &&
                                    newfocx > 0)
                                {
                                    this.focus.X = newfocx;
                                }
                                else if (this.focus.X <= increment || this.focus.X >= (focusXBound - increment))
                                {
                                    this.avatar.Position = new Vector2(pos.X - this.avatar.WalkingSpeed, pos.Y);
                                }
                            }
                        }
                    }
                    else if (kbState.IsKeyDown(Keys.Right))
                    {
                        this.avatar.Direction = Direction.RIGHT;
                        if (mapPos.X < (map.Width - 1))
                        {
                            int rightTile = this.map.BottomLayer[(int)mapPos.X + 1, (int)mapPos.Y];
                            if (this.chipset.Tiles[rightTile].IsWalkable)
                            {
                                float newfocx = foc.X + increment;
                                if (pos.X >= (midViewWidth - this.avatar.WalkingSpeed) &&
                                    newfocx <= focusXBound && newfocx > 0)
                                {
                                    this.focus.X = newfocx;
                                }
                                else if ((this.focus.X >= (focusXBound - increment) || this.focus.X <= increment) &&
                                    pos.X <= avatarXBound)
                                {
                                    this.avatar.Position = new Vector2(pos.X + this.avatar.WalkingSpeed, pos.Y);
                                }
                            }
                        }
                    }
                    else if (kbState.IsKeyDown(Keys.D))
                    {
                        this.gameState = GameStates.ReadyMenu;
                    }
                    break;
                case GameStates.ReadyMenu:
                    if (kbState.IsKeyUp(Keys.D))
                    {
                        this.gameState = GameStates.InMenu;
                    }
                    break;
                case GameStates.InMenu:
                    if (kbState.IsKeyDown(Keys.D) && menu.SubMenuActive == false)
                    {
                        this.gameState = GameStates.ReadyWorld;
                    }
                    else
                    {
                        menu.UpdateMenu(kbState);
                    }
                    break;
                case GameStates.InBattle:
                    break;
                default:
                    break;
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
            RenderAvatar();

            if (this.gameState == GameStates.InMenu)
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
                        spritebatch.Draw(chipset.Tiles[map.BottomLayer[i, j]].Texture,
                            new Vector2((i - focus.X) * ChipsetTile.Width, (j - focus.Y) *
                            ChipsetTile.Height), Color.White);
                    }
                    else
                    {
                        spritebatch.Draw(systemchipset.Tiles[0].Texture,
                            new Vector2((i - focus.X) * ChipsetTile.Width, (j - focus.Y) *
                            ChipsetTile.Height), Color.White);
                    }
                }
            }
        }

        public void RenderAvatar()
        {
            this.spritebatch.Draw(this.avatar.Texture, this.avatar.Position,
                this.avatar.GetCurrentFrame(), Color.White);
        }

        public void RenderMenu()
        {
            spritebatch.Draw(menu.Texture,
                new Rectangle(0, 0, graphics.GraphicsDevice.Viewport.Width,
                graphics.GraphicsDevice.Viewport.Height), Color.White);

            menu.Draw(spritebatch, TargetElapsedTime, party);
        }

        public Vector2 GetMapPosition(Vector2 screenPosition)
        {
            Vector2 mapPosition = new Vector2();

            mapPosition.X = focus.X + (screenPosition.X / ChipsetTile.Width);
            mapPosition.Y = focus.Y + (screenPosition.Y / ChipsetTile.Height);

            return mapPosition;
        }

        public Vector2 GetAvatarMapPosition(Avatar av)
        {
            Vector2 pos = av.Position;
            float row = this.focus.Y + (pos.Y / ChipsetTile.Height);
            float clmn = this.focus.X + (pos.X / ChipsetTile.Width);
            Vector2 mapPos = new Vector2(clmn, row);
            return mapPos;
        }
        #endregion
    }
}
