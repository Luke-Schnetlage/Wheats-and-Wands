﻿using System;

namespace Wheats_and_Wands
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new WheatandWandsGame())
                game.Run();

        }
    }
}
