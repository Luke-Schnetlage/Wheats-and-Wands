using System;
using System.Collections.Generic;
using System.Text;

namespace Wheats_and_Wands.System
{
    public class GameState
    {
        public GameStates gameStates { get; set; }
        public GameState()
        {
            gameStates = GameStates.TitleScreen;
        }
    }
    public enum GameStates
    {
        TitleScreen,
        Tutorial,
        Credits,
    }
}
