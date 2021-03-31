using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wheats_and_Wands.System
{
	public class MusicManager
	{
		Song _song;
		Song _titleTheme;
		Song _farmTheme;
		GameState _gameState;

		public MusicManager(GameState gameState,Song titleTheme, Song farmtheme)
		{
			_gameState = gameState;
			_titleTheme = titleTheme;
			_farmTheme = farmtheme;
		}

		public void Play()
        {
			Song temp = _song;
			if (_gameState.state == States.TitleScreen || _gameState.state == States.CreditScreen)
            {
				_song = _titleTheme;
            }
			else if (_gameState.state == States.Tutorial)
            {
				_song = _farmTheme;
            }
			if (temp != _song)
            {
				MediaPlayer.Stop();
            }
			if (MediaPlayer.State != MediaState.Playing){
				MediaPlayer.Play(_song);
			}
			
        }
	}
}