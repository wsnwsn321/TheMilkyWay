using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public interface ICommand
    {
        void Execute();
    }

    public class StandingInPlaceTidusCommand : ICommand {

        private Game1 myGame;

        public StandingInPlaceTidusCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.TidusSprite = new StandingInPlaceTidusSprite(myGame.Texture);
        }
    }

    public class FixedAnimatedTidusCommand : ICommand
    {

        private Game1 myGame;

        public FixedAnimatedTidusCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            if (myGame.TidusSprite.Equals(new FixedAnimatedTidusSprite(myGame.Texture)))
            {

            }
            else
            {
                myGame.TidusSprite = new FixedAnimatedTidusSprite(myGame.Texture);
            }
        }
    }

    // Input of Y or key (t)
    public class MovingAnimatedTidusCommand : ICommand
    {

        private Game1 myGame;

        public MovingAnimatedTidusCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.TidusSprite = new MovingAnimatedTidusSprite(myGame.Texture);
        }
    }

    // Input of (B) or key (r)
    public class KillTidusCommand : ICommand
    {

        private Game1 myGame;

        public KillTidusCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.TidusSprite = new DeadTidusSprite(myGame.Texture);
        }
    }

    public class EndGameCommand : ICommand
    {
        private Game1 myGame;

        public EndGameCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.Exit();
        }
    }
}
