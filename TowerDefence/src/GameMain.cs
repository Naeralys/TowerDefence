using System;
using SwinGameSDK;

namespace MyGame
{
	/// <summary>
    /// This is the Main class with the main function.
    /// </summary>
    public class GameMain
    {
        public static void Main()
        {
            Game game = new Game ("Tower Defence", 800, 600);         

            //Run the game loop
			while(game.IsRunning)
            {
				game.Update ();
				game.Render ();
            }
        }
    }
}