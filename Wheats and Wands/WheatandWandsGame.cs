
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

        //level systems
        GameState _gameState;
        Level _level;
        TitleScreen _titleScreen;
        CreditScreen _creditScreen;
        OptionScreen _optionScreen;
        TutorialFarm _tutorial;
        Cave _cave;


        Texture2D _titleScreenSprite;
        Texture2D _tutorialFarmBackground;
        Texture2D _creditScreenSprite;
        Texture2D _caveBackGround;
        Texture2D _farmerSpriteSheet;
        Texture2D _hayBale;
        Texture2D _sign;
        Texture2D _textbox;

        List<ScrollBackground> _farmScrollBackgrounds;
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
            _tutorialFarmBackground = Content.Load<Texture2D>("Backgrounds/FarmLayer/FarmerBackground2D2");
            _caveBackGround = Content.Load<Texture2D>("Backgrounds/Cave Background");
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


            var farmerSpriteSheet = Content.Load<Texture2D>("Farmer walk cycle"); //Why is this a thing? _farmerSpriteSheet already exists

            _farmer = new Farmer(farmerSpriteSheet, new Vector2(50, (WINDOW_HEIGHT - farmerSpriteSheet.Height) - 20));
            _farmScrollBackgrounds = new List<ScrollBackground>()
            {
                new ScrollBackground(Content.Load<Texture2D>("Backgrounds/FarmLayer/Barn"), _farmer, 0f)
                {
                    Layer = 0.1f // Front Layer
                },
                new ScrollBackground(Content.Load<Texture2D>("Backgrounds/FarmLayer/FarmerBackground2D2"), _farmer, 0f)
                {
                    Layer = 0.1f
                },
                new ScrollBackground(Content.Load<Texture2D>("Backgrounds/FarmLayer/FarmSecondLayer"), _farmer, 0f)
                {
                    Layer = 0.11f
                },
                new ScrollBackground(Content.Load<Texture2D>("Backgrounds/FarmLayer/FarmThirdLayer"), _farmer, 0f)
                {
                    Layer = 0.12f
                },
                new ScrollBackground(Content.Load<Texture2D>("Backgrounds/FarmLayer/FastClouds"), _farmer, 3f, true)
                {
                    Layer = 0.4f
                },
                new ScrollBackground(Content.Load<Texture2D>("Backgrounds/FarmLayer/FarClouds"), _farmer, .5f, true)
                {
                    Layer = 0.4f
                },
                new ScrollBackground(Content.Load<Texture2D>("Backgrounds/FarmLayer/FarmLastLayer"), _farmer, 0f)
                {
                    Layer = 1f //Back Layer
                }
            };

            _farmer = new Farmer(_farmerSpriteSheet, playerPosition);

            //system controls
            _displayOptions = new Display_Options(_graphics);
            _inputController = new InputController(_farmer, _displayOptions);
            _musicManager = new MusicManager(_gameState, _titleTheme, _tutorialTheme);

            //levels
            _titleScreen = new TitleScreen(_titleScreenSprite, _gameState);
            _creditScreen = new CreditScreen(_creditScreenSprite,_creditFont );
            _optionScreen = new OptionScreen(_gameState,_creditScreenSprite, _titleScreenSprite, _creditFont);
            _tutorial = new TutorialFarm( _farmer, _sign, _textbox, _hayBale ,_creditFont,_gameState);
            _cave = new Cave(_farmer, _gameState, _caveBackGround);
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
                foreach (var scrollBackground in _farmScrollBackgrounds)
                    scrollBackground.Update(gameTime);
            }
            if (_gameState.state == States.CreditScreen)
            {
                _level = _creditScreen;
            }
            if (_gameState.state == States.OptionsScreen)
            {
                _level = _optionScreen;
            }
            if (_gameState.state == States.Cave)
            {
                _level = _cave;
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

            if (_level == _tutorial) //Tutorial entities will spawn in the tutorial screen
                foreach (var scrollBackground in _farmScrollBackgrounds)
                    scrollBackground.Draw(gameTime, _spriteBatch);

            

            _spriteBatch.End();
            base.Draw(gameTime);
        }

    }
}
