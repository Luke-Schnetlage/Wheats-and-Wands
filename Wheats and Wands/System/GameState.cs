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
        StageSelectMenu,
        OptionsScreen, //this is the boundry between skip button and none, no unskipable leves past this point
        Tutorial,
        FarmToCave,
        Cave,
        CaveToCastle,
        Castle,
        DragonLevel,
        Castle2,
        Space
    }
}
