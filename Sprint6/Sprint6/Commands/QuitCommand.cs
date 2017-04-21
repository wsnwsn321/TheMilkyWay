using Microsoft.Xna.Framework;
using Sprint6.SpriteFactories;

namespace Sprint6.Commands
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
            myGame.freeze = false;
            myGame.level.mainCharacter.state.Sprite = CharacterSpriteFactory.Instance.CreateFlyingUFOSprite();
            myGame.level.currentLevel = GameConstants.Menu;
            myGame.level.Load(GameConstants.Menu, new Vector2(GameConstants.MainCharStartingX, GameConstants.MainCharStartingY));
        }
    }
}
