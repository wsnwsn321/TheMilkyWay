using SuperMarioGame.ElementClasses.ElementInterfaces;
using SuperMarioGame.ElementClasses;
using SuperMarioGame.Sprites;
using Microsoft.Xna.Framework;

namespace SuperMarioGame.CollisionHandler
{
    public static class ItemBlockHandler
    {
        public static void BlockHandler(IItem item, IBlock block, int CollisionSide)
        {
            Vector2 newPosition;

            switch (CollisionSide)
            {
                case 1:
                    newPosition.X = item.itemSprite.desRectangle.X;
                    newPosition.Y = block.blockSprite.desRectangle.Y - item.itemSprite.desRectangle.Height;
                    item.position = newPosition;
                    break;
                case 2:
                    item.ItemChangeDirection();
                    break;
                case 3:
                    newPosition.X = item.itemSprite.desRectangle.X;
                    newPosition.Y = block.blockSprite.desRectangle.Y + item.itemSprite.desRectangle.Height;
                    item.position = newPosition;
                    break;
                case 4:
                    item.ItemChangeDirection();
                    break;
            }            
        }
    }
}
