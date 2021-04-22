using Microsoft.Xna.Framework.Media;

namespace Wheats_and_Wands.System
{
    public class MusicManager
    {
        Song _song;
        Song _titleTheme;
        Song _farmTheme;
        Song _caveTheme;
        Song _castleTheme;
        Song _dragonTheme;
        GameState _gameState;

        public MusicManager(GameState gameState, Song titleTheme, Song farmtheme, Song caveTheme, Song castleTheme, Song dragonTheme)
        {
            _gameState = gameState;
            _titleTheme = titleTheme;
            _farmTheme = farmtheme;
            _caveTheme = caveTheme;
            _castleTheme = castleTheme;
            _dragonTheme = dragonTheme;
        }

        public void Play()
        {
            MediaPlayer.Volume = 0.3f;
            Song temp = _song;
            if (_gameState.state == States.TitleScreen || _gameState.state == States.CreditScreen)
            {
                _song = _titleTheme;
            }
            else if (_gameState.state == States.Tutorial)
            {
                _song = _farmTheme;
            }
            else if (_gameState.state == States.Cave)
            {
                _song = _caveTheme;
            }
            else if (_gameState.state == States.Castle)
            {
                _song = _castleTheme;
            }
            else if (_gameState.state == States.DragonLevel)
            {
                _song = _dragonTheme;
            }
            if (temp != _song)
            {
                MediaPlayer.Stop();
            }
            if (MediaPlayer.State != MediaState.Playing)
            {
                MediaPlayer.Play(_song);
            }

        }
    }
}