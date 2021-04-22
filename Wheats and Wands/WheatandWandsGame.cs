using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
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

        //level systems
        GameState _gameState;
        GameState _playerProgress;
        Level _level;
        Level _prevLevel;
        TitleScreen _titleScreen;
        CreditScreen _creditScreen;
        StageSelectMenu _stageSelectMenu;
        OptionScreen _optionScreen;
        TutorialFarm _tutorial;
        Cave _cave;
        Castle _castle;
        FarmToCave _farmToCave;
        CaveToCastle _caveToCastle;
        DragonLevel _dragonLevel;
        Castle2 _castle2;
        Space _spaceLevel;

        //A button that tops up if the player dies 3 times on 1 level
        Button _skipLevelButton;

        //Sprites
        Texture2D _titleScreenSprite;
        Texture2D _creditScreenSprite;
        //Texture2D _caveBackGround;
        Texture2D _farmerSpriteSheet;
        Texture2D _fancyFarmerSheet;
        Texture2D _wizardFarmerSheet;
        Texture2D _hayBale;
        Texture2D _sign;
        Texture2D _textbox;
        Texture2D _spikes;
        Texture2D _cavePits;
        Texture2D _dragon;
        Texture2D _fireBreath;
        Texture2D _heartSheet;
        Texture2D _lava;
        Texture2D _fireball;
        Texture2D _totemHead;
        Texture2D _orb;
        Texture2D _cow;
        Texture2D _asteroid;

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
        //Texture2D _cavePitFloor;
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

        //Space Texture
        Texture2D _spaceBackground;

        //Transition Textures
        Texture2D _ftc;
        Texture2D _ctcFront;
        Texture2D _ctcBack;

        Texture2D _miniFarm;
        Texture2D _miniCave;
        Texture2D _miniCastle;
        Texture2D _miniSpace;

        //Farmer _player;
        Vector2 playerPosition;


        public SpriteFont _font { get; private set; } 

        //Music/Sound System
        MusicManager _musicManager;
        Song _titleTheme;
        Song _tutorialTheme;
        Song _caveTheme;
        Song _castleTheme;
        Song _dragonTheme;
        Song _cowTheme;

        SoundEffect _jumpSound;

        //User imput handeling
        InputController _inputController;
        Display_Options _displayOptions;

        
        //graphics managment
        public GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //player character
        private Farmer _farmer;

        public WheatandWandsGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";          
            IsMouseVisible = true;
            _game = this;
        }

        // Initialize fundemental system elements
        protected override void Initialize()
        {

            _graphics.PreferredBackBufferHeight = WINDOW_HEIGHT;
            _graphics.PreferredBackBufferWidth = WINDOW_WIDTH;
            _graphics.ApplyChanges();

            _gameState = new GameState();
            _playerProgress = new GameState();
            _spriteBatch = new SpriteBatch(GraphicsDevice); //initalizes spriteBatch

            //IMPORTANT!!! REMOVE AFTER CASTLE TESTING
            //_gameState.state = States.Castle2;
            //IMPORTANT!!! REMOVE AFTER CASTLE TESTING

            playerPosition = new Vector2(100, (_graphics.PreferredBackBufferHeight / 2) + 15); //defaults player to 100,495
            base.Initialize();
        }

        protected override void LoadContent() //this loads in content and classes that can't be initalized without content
        {
            

            //backgrounds
            _titleScreenSprite = Content.Load<Texture2D>("Backgrounds/Title screen");
            _creditScreenSprite = Content.Load<Texture2D>("Backgrounds/Credits Screen");
            //_caveBackGround = Content.Load<Texture2D>("Backgrounds/Cave Background");

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
            //_cavePitFloor = Content.Load<Texture2D>("Backgrounds/CastleLayer/CaveFloorPits");
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
            _castleThirdLayer = Content.Load<Texture2D>("Backgrounds/CastleLayer/CastleThirdLayer");
            _castleFourthLayer = Content.Load<Texture2D>("Backgrounds/CastleLayer/CastleFourthLayer");
            _castleFifthLayer = Content.Load<Texture2D>("Backgrounds/CastleLayer/CastleFifthLayer");
            _castleSixthLayer = Content.Load<Texture2D>("Backgrounds/CastleLayer/CastleSixthLayer");
            _castleSeventhLayer = Content.Load<Texture2D>("Backgrounds/CastleLayer/CastleSeventhLayer");
            _castleEighthLayer = Content.Load<Texture2D>("Backgrounds/CastleLayer/CastleLastLayer");

            //Space Background Layer
            _spaceBackground = Content.Load<Texture2D>("Backgrounds/SpaceBackground");

            //Transition Layers
            _ftc = Content.Load<Texture2D>("Backgrounds/TransitionBackgrounds/FarmToCave");
            _ctcFront = Content.Load<Texture2D>("Backgrounds/TransitionBackgrounds/CavetoCastleFront");
            _ctcBack = Content.Load<Texture2D>("Backgrounds/TransitionBackgrounds/CavetoCastleBack");

            //mini level sprites
            _miniFarm = Content.Load<Texture2D>("Backgrounds/PreviewFolder/FarmerBackground2DPreview");
            _miniCave = Content.Load<Texture2D>("Backgrounds/PreviewFolder/CaveBackgroundPreview");
            _miniCastle = Content.Load<Texture2D>("Backgrounds/PreviewFolder/CastleBackgroundPreview");
            _miniSpace = Content.Load<Texture2D>("Backgrounds/PreviewFolder/SpaceBackgroundPreview");


            //entities
            _hayBale = Content.Load<Texture2D>("PNG Objects/HayBale-1");
            _sign = Content.Load<Texture2D>("PNG Objects/Sign");
            _textbox = Content.Load<Texture2D>("PNG Objects/TextBox");
            _spikes = Content.Load<Texture2D>("PNG Objects/CaveSpike2");
            _cavePits = Content.Load<Texture2D>("PNG Objects/CavePits");
            _dragon = Content.Load<Texture2D>("PNG Objects/Dragon");
            _fireBreath = Content.Load<Texture2D>("PNG Objects/FireBreath");
            _heartSheet = Content.Load<Texture2D>("PNG Objects/Heart");
            _lava = Content.Load<Texture2D>("PNG Objects/Lava texture 1.0");
            _fireball = Content.Load<Texture2D>("PNG Objects/Fireball");
            _totemHead = Content.Load<Texture2D>("PNG Objects/Island Head");
            _orb = Content.Load<Texture2D>("ORB");
            _cow = Content.Load<Texture2D>("PNG Objects/Cow");
            _asteroid = Content.Load<Texture2D>("PNG Objects/Asteroid");

            //farmer animations
            _farmerSpriteSheet = Content.Load<Texture2D>("Farmer walk cycle");
            _fancyFarmerSheet = Content.Load<Texture2D>("Fancy walk cycle");
            _wizardFarmerSheet = Content.Load<Texture2D>("AltSkin walk cycle");

            //fonts
            _font = Content.Load<SpriteFont>("Spritefonts/Credits");

            //music
            _tutorialTheme = Content.Load<Song>("music_orlamusic_Happy+006");
            _titleTheme = Content.Load<Song>("music_zapsplat_game_music_zen_calm_soft_arpeggios_013");
            _caveTheme = Content.Load<Song>("music_zapsplat_deep_investigation_126");
            _castleTheme = Content.Load<Song>("music_zapsplat_last_chance_103");
            _dragonTheme = Content.Load<Song>("audio_hero_911_SIPML_J-0501");
            _cowTheme = Content.Load<Song>("audio_hero_Your-Choice_SIPML_B-0420");

            _jumpSound = Content.Load<SoundEffect>("zapsplat_multimedia_game-sound_classic_retro_jump_006_65126");

            //Player character
            _farmer = new Farmer(_farmerSpriteSheet, playerPosition, _heartSheet, _fancyFarmerSheet, _wizardFarmerSheet);

            //system controls
            _displayOptions = new Display_Options(_graphics);
            _inputController = new InputController(_farmer, _displayOptions, _jumpSound);
            _musicManager = new MusicManager(_gameState, _titleTheme, _tutorialTheme, _caveTheme, _castleTheme, _dragonTheme, _cowTheme);
            _skipLevelButton = new Button(new Sprite(_titleScreenSprite, 357, 644, 250, 70, new Vector2(25, 25 + 540)));
            _skipLevelButton.Click += _skipLevelButton_Click;

            //levels
            _titleScreen = new TitleScreen(_titleScreenSprite, _gameState);
            _creditScreen = new CreditScreen(_creditScreenSprite, _font, _titleScreenSprite, _gameState);
            _stageSelectMenu = new StageSelectMenu(_playerProgress, _gameState, _creditScreenSprite, _miniFarm, _miniCave, _miniCastle, _miniSpace);
            _optionScreen = new OptionScreen(_gameState, _creditScreenSprite, _titleScreenSprite, _font);
            _tutorial = new TutorialFarm(_farmer, _sign, _textbox, _hayBale, _font, _gameState, _barn, _tutorialFarmBackground,
                _tutorialSecondLayer, _tutorialThirdLayer, _tutorialLastLayer, _farClouds, _fastClouds);
            _cave = new Cave(_farmer, _gameState, _caveFloor, _caveFirstLayer, _caveSecondLayer, _caveThirdLayer, _caveFourthLayer,
                _caveFifthLayer, _caveSixthLayer, _spikes, _cavePits, _orb);
            _castle = new Castle(_farmer, _gameState, _castleFloor, _castleFirstLayer, _castleSecondLayer, _castleThirdLayer,
                _castleFourthLayer, _castleFifthLayer, _castleSixthLayer, _castleSeventhLayer, _castleEighthLayer, _lava, _fireball, _orb);
            _farmToCave = new FarmToCave(_farmer, _gameState, _ftc, _tutorialSecondLayer, _tutorialThirdLayer, _farClouds,
                _fastClouds, _tutorialLastLayer, _hayBale);
            _caveToCastle = new CaveToCastle(_farmer, _gameState, _ctcFront, _ctcBack, _caveSecondLayer, _caveThirdLayer, _caveFourthLayer,
                _caveFifthLayer, _caveSixthLayer, _spikes, _totemHead, _textbox, _font);
            _dragonLevel = new DragonLevel(_farmer, _gameState, _castleFloor, _castleFirstLayer, _castleSecondLayer, _castleThirdLayer,
                _castleFourthLayer, _castleFifthLayer, _castleSixthLayer, _castleSeventhLayer, _castleEighthLayer, _dragon, _fireBreath);
            _castle2 = new Castle2(_farmer, _gameState, _castleFloor, _castleFirstLayer, _castleSecondLayer, _castleThirdLayer,
                _castleFourthLayer, _castleFifthLayer, _castleSixthLayer, _castleSeventhLayer, _castleEighthLayer, _cow, _font);
            _spaceLevel = new Space(_spaceBackground, _farmer, _gameState, _asteroid, _font);

        }

        //contains universal update logic
        //uses the game state system to determin which level is marked as "_level" and only updates the level currently being viewed
        protected override void Update(GameTime gameTime)
        {
            //takes the user to the main menu
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                _gameState.state = States.TitleScreen;
            }
            //_prevLevel is used detect if any level chanes have occured in the middle of update
            _prevLevel = _level;
            

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
            if (_gameState.state == States.StageSelectMenu)
            {
                _level = _stageSelectMenu;
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
                //1 way update to unlock the 2nd load state
                if (_playerProgress.state < States.Cave)
                {
                    _playerProgress.state = States.Cave; 
                }
                _level = _cave;
            }
            if (_gameState.state == States.CaveToCastle)
            {
                _level = _caveToCastle;
            }
            if (_gameState.state == States.Castle)
            {
                //1 way update to unlock the 3rd load state
                if (_playerProgress.state < States.Castle)
                {
                    _playerProgress.state = States.Castle;
                }
                _level = _castle;
            }
            if (_gameState.state == States.DragonLevel)
            {
                _level = _dragonLevel;
            }
            if (_gameState.state == States.Castle2)
            {
                //1 way update to unlock the hidden 4th load state
                if (_playerProgress.state < States.Castle2)
                {
                    _playerProgress.state = States.Castle2;
                }
                _level = _castle2;
            }
            if (_gameState.state == States.Space)
            {
                _level = _spaceLevel;
            }

            //resets the players health to full once the enter a new level
            if (_prevLevel != _level)
            {
                _farmer.lives = 3;
            }

            //updates the skip button if the player dies 3 times in a level and are in a valid level to skip
            if (_gameState.state > States.OptionsScreen && _farmer.lives <= 0 && _gameState.state < States.Castle2)
                _skipLevelButton.Update(gameTime);

            _inputController.ProcessControls(gameTime);
            _level.Update(gameTime);

            base.Update(gameTime);

            _musicManager.Play();
        }

        protected override void Draw(GameTime gameTime)
        {

            //layers all sprites ontop and draw them in a batch
            _spriteBatch.Begin(SpriteSortMode.BackToFront);
            GraphicsDevice.Clear(Color.Black);

            //draws the current level
            _level.Draw(_spriteBatch, gameTime);

            //draws the skip button if the player dies 3 times in a level and are in a valid level to skip
            if (_gameState.state > States.OptionsScreen && _farmer.lives <= 0 && _gameState.state < States.Castle2)
            {
                _skipLevelButton.Draw(gameTime, _spriteBatch);
                _spriteBatch.DrawString(_font, "SKIP", new Vector2(130, 50), Color.White);
            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }

        public void _skipLevelButton_Click(object sender, EventArgs e)
        {
            //incriments the game state to the next level
            _gameState.state++;
            _farmer.Position = new Vector2(50, 290);
        }

    }
}
