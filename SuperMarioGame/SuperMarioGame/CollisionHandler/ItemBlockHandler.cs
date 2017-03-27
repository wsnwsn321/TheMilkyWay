﻿using SuperMarioGame.ElementClasses.ElementInterfaces;
using SuperMarioGame.ElementClasses;
using SuperMarioGame.Sprites;
using Microsoft.Xna.Framework;
using SuperMarioGame.ElementClasses.EnvironmentClass;

namespace SuperMarioGame.CollisionHandler
{
    public static class ItemBlockHandler
    {
        public static void BlockHandler(IItem item, IBlock block, int CollisionSide)
        {
            Vector2 newPosition;
            bool top = false;

            if (!(block.blockSprite is HiddenBlockSprite)&& !(item is BlockPiece) && block.isVisible)
            {
                switch (CollisionSide)
                {
                    case 1:
                        newPosition.X = item.itemSprite.desRectangle.X;
                        newPosition.Y = block.blockSprite.desRectangle.Y - item.itemSprite.desRectangle.Height-3;
                        item.position = newPosition;
                        if(item.itemSprite is FireballSprite)
                        {
                            item.ItemChangeDirection();
                        }
                        top = true;
                        break;
                    case 2:
                        newPosition.X = block.blockSprite.desRectangle.X + block.blockSprite.desRectangle.Width;
                        newPosition.Y = item.itemSprite.desRectangle.Y;
                        item.position = newPosition;
                        if(item.itemSprite is FireballSprite)
                        {
                            item.isVisible = !item.isVisible;
                        }else
                        {
                            item.ItemChangeDirection();
                        }
                      

                        break;
                    case 3:
                        newPosition.X = item.itemSprite.desRectangle.X;
                        newPosition.Y = block.blockSprite.desRectangle.Y + item.itemSprite.desRectangle.Height;
                        item.position = newPosition;
                        top = true;
                        if (item.itemSprite is FireballSprite)
                        {
                            item.ItemChangeDirection();
                        }
                        break;
                    case 4:
                        newPosition.X = block.blockSprite.desRectangle.X - item.itemSprite.desRectangle.Width;
                        newPosition.Y = item.itemSprite.desRectangle.Y;
                        item.position = newPosition;
                        if (item.itemSprite is FireballSprite)
                        {
                            item.isVisible = !item.isVisible;
                        }
                        else
                        {
                            item.ItemChangeDirection();
                        }
                        break;
                }
                //if (top)
                //{
                  //  item.onTop = true;
                //}
                //else
                //{
                    //if (item.itemSprite is FireballSprite)
                    //{
                      //  item.isVisible = false;
                    //}
                  //  item.onTop = false;
                //}
            }         
        }
    }
}
