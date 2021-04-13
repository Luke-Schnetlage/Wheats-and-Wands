using System;
using System.Collections.Generic;
using System.Text;

namespace Wheats_and_Wands.System
{
    public class GameState
    {
        public States state { get; set; }
        public GameState()
        {
            state = States.TitleScreen;
        }
    }
    public enum States
    {
        TitleScreen,
        CreditScreen,
        Tutorial,
        OptionsScreen,
        Cave
    }
}
