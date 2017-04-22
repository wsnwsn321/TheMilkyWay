using TheMilkyWay.ElementClasses.ElementInterfaces;
using TheMilkyWay.ElementClasses;
using TheMilkyWay.Sprites.UFOSprite;
using Microsoft.Xna.Framework;

namespace TheMilkyWay.CollisionHandler
{
    public static class ItemBlockHandler
    {
        public static void BlockHandler(IItem item, IBlock block)
        {
            Vector2 newPosition;

            if (block.isVisible)
            {         
                        newPosition.X = item.itemSprite.desRectangle.X;
                        newPosition.Y = block.blockSprite.desRectangle.Y - item.itemSprite.desRectangle.Height;
                        item.position = newPosition;
                }
               
            }         
        }
    }

