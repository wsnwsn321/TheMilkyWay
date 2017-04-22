using Microsoft.Xna.Framework;
using TheMilkyWay.SpriteFactories;

namespace TheMilkyWay.Commands
{
    class QuitCommand : ICommand
    {
        private Game1 myGame;

        public QuitCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.level.mainCharacter.state.Sprite = CharacterSpriteFactory.Instance.CreateFlyingUFOSprite();
            myGame.level.currentLevel = GameConstants.Menu;
            myGame.level.Load(GameConstants.Menu, new Vector2(GameConstants.MainCharStartingX, GameConstants.MainCharStartingY));
        }
    }
}
