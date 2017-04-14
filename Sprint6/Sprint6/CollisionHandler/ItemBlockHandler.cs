using Sprint6.ElementClasses.ElementInterfaces;
using Sprint6.ElementClasses;
using Sprint6.Sprites.UFOSprite;
using Microsoft.Xna.Framework;

namespace Sprint6.CollisionHandler
{
    public static class ItemBlockHandler
    {
        public static void BlockHandler(Game1 myGame,IItem item, IBlock block, int CollisionSide)
        {
            Vector2 newPosition;
            int SIX = 6;

            if (block.isVisible)
            {
                switch (CollisionSide)
                {
                    case 1:
                        newPosition.X = item.itemSprite.desRectangle.X;
                        newPosition.Y = block.blockSprite.desRectangle.Y - item.itemSprite.desRectangle.Height- SIX;
                        item.position = newPosition;
                        break;
                    case 2:
                        newPosition.X = block.blockSprite.desRectangle.X + block.blockSprite.desRectangle.Width;
                        newPosition.Y = item.itemSprite.desRectangle.Y;
                        item.position = newPosition;
                        break;
                    case 3:
                        newPosition.X = item.itemSprite.desRectangle.X;
                        newPosition.Y = block.blockSprite.desRectangle.Y + item.itemSprite.desRectangle.Height;
                        item.position = newPosition;
                        break;
                    case 4:
                        newPosition.X = block.blockSprite.desRectangle.X - item.itemSprite.desRectangle.Width;
                        newPosition.Y = item.itemSprite.desRectangle.Y;
                        item.position = newPosition;
                        break;
                }
               
            }         
        }
    }
}
