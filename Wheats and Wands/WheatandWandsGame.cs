using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;
using Wheats_and_Wands.Entities;
using Wheats_and_Wands.Graphics;
using Wheats_and_Wands.Levels;
using Wheats_and_Wands.System;

namespace Wheats_and_Wands
{
    public class WheatandWandsGame : Game
    {

        public const int WINDOW_WIDTH = 960;
        public const int WINDOW_HEIGHT = 540;

        public static Game _game;

        // 6836f5d3a13ac8096d49dfd4fbe474f0f274e674
        //level systems
        GameState _gameState;
        Level _level;
        TitleScreen _titleScreen;
        CreditScreen _creditScreen;
        OptionScreen _optionScreen;
        TutorialFarm _tutorial;
        Cave _cave;
        Castle _castle;
        FarmToCave _farmToCave;
        CaveToCastle _caveToCastle;

        //Sprites
        Texture2D _titleScreenSprite;
        Texture2D _creditScreenSprite;
        Texture2D _caveBackGround;
        Texture2D _farmerSpriteSheet;
        Texture2D _hayBale;
        Texture2D _sign;
        Texture2D _textbox;

        //Tutorial and Farm Textures
        Texture2D _barn;
        Texture2D _tutorialFarmBackground;
        Texture2D _tutorialSecondLayer;
        Texture2D _tutorialThirdLayer;
        Texture2D _tutorialLastLayer;
        Texture2D _farClouds;
        Texture2D _fastClouds;

        //Cave Textures
        Texture2D _caveFloor;
        Texture2D _caveFirstLayer;
        Texture2D _caveSecondLayer;
        Texture2D _caveThirdLayer;
        Texture2D _caveFourthLayer;
        Texture2D _caveFifthLayer;
        Texture2D _caveSixthLayer;

        //Castle Textures
        Texture2D _castleFloor;
        Texture2D _castleFirstLayer;
        Texture2D _castleSecondLayer;
        Texture2D _castleThirdLayer;
        Texture2D _castleFourthLayer;
        Texture2D _castleFifthLayer;
        Texture2D _castleSixthLayer;
        Texture2D _castleSeventhLayer;
        Texture2D _castleEighthLayer;

        //Transition Textures
        Texture2D _ftc;
        Texture2D _ctcFront;
        Texture2D _ctcBack;

        Farmer _player;

         //6836f5d3a13ac8096d49dfd4fbe474f0f274e674
        Vector2 playerPosition;

        
        public SpriteFont _creditFont { get; private set; } //Added
        //SpriteFont _artFont; //Added, Not implemented
        //SpriteFont _musicFont; //Added, Not implemented
        //SpriteFont _programFont; //Added, Not implemented
        //SpriteFont _scottFont; //Added, Not implemented
        //SpriteFont _lukeFont; //Added, Not implemented


        MusicManager _musicManager;
        Song _titleTheme;
        Song _tutorialTheme;


        InputController _inputController;
        Display_Options _displayOptions;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Farmer _farmer;

        public WheatandWandsGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _game = this;
        }

        protected override void Initialize()
        {

            _graphics.PreferredBackBufferHeight = WINDOW_HEIGHT;
            _graphics.PreferredBackBufferWidth = WINDOW_WIDTH;
            _graphics.ApplyChanges();

            _gameState = new GameState();

            playerPosition = new Vector2(100 , (_graphics.PreferredBackBufferHeight / 2) + 15 ); //defaults player to center of the screen
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            //backgrounds
            _titleScreenSprite = Content.Load<Texture2D>("Backgrounds/Title screen");
            _creditScreenSprite = Content.Load<Texture2D>("Backgrounds/Credits Screen"); 
            _caveBackGround = Content.Load<Texture2D>("Backgrounds/Cave Background");

            //Farm Background Layers (and Tutorial too)
            _barn = Content.Load<Texture2D>("Backgrounds/FarmLayer/Barn");
            _tutorialFarmBackground = Content.Load<Texture2D>("Backgrounds/FarmLayer/FarmerBackground2D2");
            _tutorialSecondLayer = Content.Load<Texture2D>("Backgrounds/FarmLayer/FarmSecondLayer");
            _tutorialThirdLayer = Content.Load<Texture2D>("Backgrounds/FarmLayer/FarmThirdLayer");
            _tutorialLastLayer = Content.Load<Texture2D>("Backgrounds/FarmLayer/FarmLastLayer");
            _farClouds = Content.Load<Texture2D>("Backgrounds/FarmLayer/FarClouds");
            _fastClouds = Content.Load<Texture2D>("Backgrounds/FarmLayer/FastClouds");

            //Cave Background Layer
            _caveFloor = Content.Load<Texture2D>("Backgrounds/CaveLayer/Cave Floor");
            _caveFirstLayer = Content.Load<Texture2D>("Backgrounds/CaveLayer/CaveFirstLayer");
            _caveSecondLayer = Content.Load<Texture2D>("Backgrounds/CaveLayer/CaveSecondLayer");
            _caveThirdLayer = Content.Load<Texture2D>("Backgrounds/CaveLayer/CaveThirdLayer");
            _caveFourthLayer = Content.Load<Texture2D>("Backgrounds/CaveLayer/CaveFourthLayer");
            _caveFifthLayer = Content.Load<Texture2D>("Backgrounds/CaveLayer/CaveFifthLayer");
            _caveSixthLayer = Content.Load<Texture2D>("Backgrounds/CaveLayer/CaveSixthLayer");

            //Castle Background Layer
            _castleFloor = Content.Load<Texture2D>("Backgrounds/CastleLayer/CastleFloor");
            _castleFirstLayer = Content.Load<Texture2D>("Backgrounds/CastleLayer/CastleFirstLayer");
            _castleSecondLayer = Content.Load<Texture2D>("Backgrounds/CastleLayer/CastleSecondLayer");
            _castleThirdLayer= Content.Load<Texture2D>("Backgrounds/CastleLayer/CastleThirdLayer");
            _castleFourthLayer = Content.Load<Texture2D>("Backgrounds/CastleLayer/CastleFourthLayer");
            _castleFifthLayer = Content.Load<Texture2D>("Backgrounds/CastleLayer/CastleFifthLayer");
            _castleSixthLayer = Content.Load<Texture2D>("Backgrounds/CastleLayer/CastleSixthLayer");
            _castleSeventhLayer = Content.Load<Texture2D>("Backgrounds/CastleLayer/CastleSeventhLayer");
            _castleEighthLayer = Content.Load<Texture2D>("Backgrounds/CastleLayer/CastleLastLayer");

            //Transition Layers
            _ftc = Content.Load<Texture2D>("Backgrounds/TransitionBackgrounds/FarmToCave");
            _ctcFront = Content.Load<Texture2D>("Backgrounds/TransitionBackgrounds/CavetoCastleFront");
            _ctcBack = Content.Load<Texture2D>("Backgrounds/TransitionBackgrounds/CavetoCastleBack");

            //entities
            _hayBale = Content.Load<Texture2D>("PNG Objects/HayBale-1");
            _sign = Content.Load<Texture2D>("PNG Objects/Sign");
            _textbox = Content.Load<Texture2D>("PNG Objects/TextBox");

            //farmer animations
            _farmerSpriteSheet = Content.Load<Texture2D>("Farmer walk cycle");

            //fonts
            _creditFont = Content.Load<SpriteFont>("Spritefonts/Credits"); 

            //music
            _tutorialTheme = Content.Load<Song>("music_orlamusic_Happy+006");
            _titleTheme = Content.Load<Song>("music_zapsplat_game_music_zen_calm_soft_arpeggios_013");

            _farmer = new Farmer(_farmerSpriteSheet, playerPosition);

            //system controls
            _displayOptions = new Display_Options(_graphics);
            _inputController = new InputController(_farmer, _displayOptions);
            _musicManager = new MusicManager(_gameState, _titleTheme, _tutorialTheme);

            //levels
            _titleScreen = new TitleScreen(_titleScreenSprite, _gameState);
            _creditScreen = new CreditScreen(_creditScreenSprite,_creditFont );
            _optionScreen = new OptionScreen(_gameState,_creditScreenSprite, _titleScreenSprite, _creditFont);
            _tutorial = new TutorialFarm(_farmer, _sign, _textbox, _hayBale ,_creditFont,_gameState, _barn, _tutorialFarmBackground,
                _tutorialSecondLayer, _tutorialThirdLayer, _tutorialLastLayer, _farClouds, _fastClouds);
            _cave = new Cave(_farmer, _gameState, _caveFloor, _caveFirstLayer, _caveSecondLayer, _caveThirdLayer, _caveFourthLayer,
                _caveFifthLayer, _caveSixthLayer);
            _castle = new Castle(_farmer, _gameState, _castleFloor, _castleFirstLayer, _castleSecondLayer, _castleThirdLayer,
                _castleFourthLayer, _castleFifthLayer, _castleSixthLayer, _castleSeventhLayer, _castleEighthLayer);
            _farmToCave = new FarmToCave(_farmer, _gameState, _ftc, _tutorialSecondLayer, _tutorialThirdLayer, _farClouds, 
                _fastClouds, _tutorialLastLayer);
            _caveToCastle = new CaveToCastle(_farmer, _gameState, _ctcFront, _ctcBack, _caveSecondLayer, _caveThirdLayer, _caveFourthLayer,
                _caveFifthLayer, _caveSixthLayer);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)) { 
            Exit();
            }
            

            if (_gameState.state == States.TitleScreen)
            {
                _level = _titleScreen;
            }
            if (_gameState.state == States.Tutorial)
            {
                _level = _tutorial;
            }
            if (_gameState.state == States.CreditScreen)
            {
                _level = _creditScreen;
            }
            if (_gameState.state == States.OptionsScreen)
            {
                _level = _optionScreen;
            }
            if (_gameState.state == States.FarmToCave)
            {
                _level = _farmToCave;
            }
            if (_gameState.state == States.Cave)
            {
                _level = _cave;
            }
            if (_gameState.state == States.CaveToCastle)
            {
                _level = _caveToCastle;
            }
            if (_gameState.state == States.Castle)
            {
                _level = _castle;
            }



            _inputController.ProcessControls(gameTime);
            _level.Update(gameTime);

            base.Update(gameTime);
            
            _musicManager.Play();
        }

        protected override void Draw(GameTime gameTime)
        {


            // TODO: Add your drawing code here
            _spriteBatch.Begin(SpriteSortMode.BackToFront);
            GraphicsDevice.Clear(Color.White);


            _level.Draw(_spriteBatch, gameTime);

            /*if (_level == _tutorial) *///Tutorial entities will spawn in the tutorial screen
                //foreach (var scrollBackground in _farmScrollBackgrounds)
                //    scrollBackground.Draw(gameTime, _spriteBatch);

            

            _spriteBatch.End();
            base.Draw(gameTime);
        }

    }
}
