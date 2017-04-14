using Microsoft.Xna.Framework;
using Sprint6.ElementClasses;
using Sprint6.ElementClasses.ElementInterfaces;
using Sprint6.Sound.MarioSound;
using Sprint6.SpriteFactories;
using Sprint6.Sprites.UFOSprite;

namespace Sprint6.CollisionHandler
{
    public static class MainCharBlockHandler
    {
        public static void BlockHandler(Game1 game, MainCharacter mainCharacter, IBlock block, int CollisionSide)
        {
            int SIXTEEN = 16;
            int SIX = 6;
            int THREE = 3;
            int THIRTYONE = 31;
            int EIGHT = 8;
            int TWELVE = 12;
            Vector2 newPosition;
            Game1 myGame = game;

            if (block.isVisible)
            {
                switch (CollisionSide)
                {
                    case 1: //top collision
                        newPosition.X = mainCharacter.state.Sprite.desRectangle.X;
                        newPosition.Y = block.blockSprite.desRectangle.Y - mainCharacter.state.Sprite.desRectangle.Height-SIX;
                        mainCharacter.position = newPosition;
                        break;
                    case 2: //right side collision
                        newPosition.X = block.blockSprite.desRectangle.X + block.blockSprite.desRectangle.Width;
                        newPosition.Y = mainCharacter.state.Sprite.desRectangle.Y;
                        mainCharacter.position = newPosition;
                        break;
                    case 3: //bottom collision
                        newPosition.X = mainCharacter.state.Sprite.desRectangle.X;
                        newPosition.Y = block.blockSprite.desRectangle.Y + block.blockSprite.desRectangle.Height+THREE;
                        mainCharacter.position = newPosition;
                        break;
                    case 4: //left side collision
                        newPosition.X = block.blockSprite.desRectangle.X - mainCharacter.state.Sprite.desRectangle.Width;
                        newPosition.Y = mainCharacter.state.Sprite.desRectangle.Y;
                        mainCharacter.position = newPosition;
                        break;
                }
            }
        }
    }
}
