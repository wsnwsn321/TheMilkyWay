﻿using System.Collections.Generic;
using Sprint6.ElementClasses.ElementInterfaces;
using Sprint6.ElementClasses;
using Microsoft.Xna.Framework;
using Sprint6.Sprites.UFOSprite;
using Sprint6.SpriteFactories;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using Sprint6.Sound.MarioSound;
using Microsoft.Xna.Framework.Media;
using MyGame;

namespace Sprint6.CollisionHandler
{
    class CollisionDetection
    {
        private Rectangle collideRectangle;
        private Rectangle firstRectangle;
        private Rectangle secondRectangle;
        public int SIDE;
        Game1 myGame;
        private bool animation = false;

        private static CollisionDetection instance = new CollisionDetection();

        public static CollisionDetection Instance
        {
            get { return instance; }
        }

        private CollisionDetection()
        {
        }

        public void MainCharBlockCollision(Game1 game, MainCharacter mainCharacter, List<IBlock> envElements)
        {
            myGame = game;
            mainCharacter.gravity = 0;
            bool intersect = false;
            foreach (IBlock block in envElements)
            {

                foreach (Circle c in mainCharacter.state.Sprite.circles)
                {
                    if (c.Intersects(block.blockSprite.desRectangle))
                    {
                        intersect = true;
                    }
                }
                if (intersect)
                {
                    mainCharacter.canMove = false;
                    firstRectangle = mainCharacter.state.Sprite.desRectangle;
                    secondRectangle = block.blockSprite.desRectangle;
                    collideRectangle = Rectangle.Intersect(firstRectangle, secondRectangle);
                    if (collideRectangle.Width > collideRectangle.Height)
                    {
                        if (firstRectangle.Top > secondRectangle.Top)
                        {
                            SIDE = GameConstants.Bottom;
                        }
                        else
                        {
                            SIDE = GameConstants.Top;
                        }
                    }
                    else if (collideRectangle.Width <= collideRectangle.Height)
                    {
                        if (firstRectangle.Left > secondRectangle.Left)
                        {
                            SIDE = GameConstants.Right;
                        }
                        else
                        {
                            SIDE = GameConstants.Left;
                        }
                    }
                    if (collideRectangle.Width * collideRectangle.Height > GameConstants.Eleven + GameConstants.Two)
                    {
                        MainCharBlockHandler.BlockHandler(myGame, mainCharacter, block, SIDE);
                    }
                }

            }
        }

        public void EnemyBlockCollision(MainCharacter mainCharacter, IEnemy enemy, List<IBlock> envElements)
        {
            foreach (IBlock block in envElements)
            {
                if (enemy.enemySprite.desRectangle.Intersects(block.blockSprite.desRectangle))
                {
                    firstRectangle = enemy.enemySprite.desRectangle;
                    secondRectangle = block.blockSprite.desRectangle;
                    collideRectangle = Rectangle.Intersect(firstRectangle, secondRectangle);
                    if (collideRectangle.Width > collideRectangle.Height)
                    {
                        if (firstRectangle.Top > secondRectangle.Top)
                        {
                            SIDE = GameConstants.Bottom;
                        }
                        else
                        {
                            SIDE = GameConstants.Top;
                        }
                    }
                    else if (collideRectangle.Width <= collideRectangle.Height)
                    {
                        if (firstRectangle.Left > secondRectangle.Left)
                        {
                            SIDE = GameConstants.Right;
                        }
                        else
                        {
                            SIDE = GameConstants.Left;
                        }
                    }
                    if (collideRectangle.Width * collideRectangle.Height > GameConstants.Eleven + GameConstants.Two)
                    {
                        EnemyBlockHandler.BlockHandler(enemy, block, SIDE);
                    }
                }
            }
        }

        public void ItemBlockCollision(IItem item, List<IBlock> envElements)
        {
            foreach (IBlock block in envElements)
            {
                if (item.itemSprite.desRectangle.Intersects(block.blockSprite.desRectangle))
                {
                    firstRectangle = item.itemSprite.desRectangle;
                    secondRectangle = block.blockSprite.desRectangle;
                    collideRectangle = Rectangle.Intersect(firstRectangle, secondRectangle);
                    if (collideRectangle.Width > collideRectangle.Height)
                    {
                        if (firstRectangle.Top > secondRectangle.Top)
                        {
                            SIDE = GameConstants.Bottom;
                        }
                        else
                        {
                            SIDE = GameConstants.Top;
                        }
                    }
                    else if (collideRectangle.Width <= collideRectangle.Height)
                    {
                        if (firstRectangle.Left > secondRectangle.Left)
                        {
                            SIDE = GameConstants.Right;
                        }
                        else
                        {
                            SIDE = GameConstants.Left;
                        }
                    }
                    if (collideRectangle.Width * collideRectangle.Height > GameConstants.Eleven + GameConstants.Two)
                    {
                        ItemBlockHandler.BlockHandler(myGame, item, block, SIDE);
                        if (SIDE == 1)
                        {
                            item.gravity = 0;
                        }
                        else
                        {
                            item.gravity = 3;
                        }
                    }
                }
            }
        }
        public void ItemEnemyCollision(IItem item, List<IEnemy> enemyElements, MainCharacter mainCharacter)
        {
            SIDE = GameConstants.Top;
            
            foreach (IEnemy enemy in enemyElements)
            {
                if (item.itemSprite.desRectangle.Intersects(enemy.enemySprite.desRectangle))
                {
                    ItemEnemyHandler.EnemyHandler(item, enemy, GameConstants.Top);
                }
            }  
        }

        public void MarioItemCollision(MainCharacter mainCharacter, List<IItem> itemElements)
        {
         //   SIDE = GameConstants.Top;
           // foreach (IItem item in itemElements)
            //{     
             //   if (mainCharacter.state.Sprite.desRectangle.Intersects(item.itemSprite.desRectangle))
              //  {
               //     MainCharItemHandler.ItemHandler( myGame,mainCharacter, item);
             //   }
         //   }
        }       

        public void MarioEnemyCollision(MainCharacter mainCharacter, List<IEnemy> enemyElements)
        {

            foreach (IEnemy enemy in enemyElements)
            {
                bool intersect = false;

                foreach (Circle c in enemy.enemySprite.circles)
                {
                    if (c.Intersects(mainCharacter.state.Sprite.desRectangle))
                    {
                        intersect = true;
                    }
                }
                if (intersect)
                {
                    mainCharacter.canMove = false;
                    firstRectangle = mainCharacter.state.Sprite.desRectangle;
                    secondRectangle = enemy.enemySprite.desRectangle;
                    collideRectangle = Rectangle.Intersect(mainCharacter.state.Sprite.desRectangle, enemy.enemySprite.desRectangle);
                    if (collideRectangle.Width > collideRectangle.Height)
                    {
                        if (firstRectangle.Top > secondRectangle.Top)
                        {
                            SIDE = GameConstants.Bottom;
                        }
                        else
                        {
                            SIDE = GameConstants.Top;
                        }
                    }
                    else if (collideRectangle.Width < collideRectangle.Height)
                    {
                        if (firstRectangle.Left > secondRectangle.Left)
                        {
                            SIDE = GameConstants.Right;
                        }
                        else
                        {
                            SIDE = GameConstants.Left;
                        }
                    }
                    MainCharEnemyHandler.EnemyHandler(mainCharacter, enemy, SIDE);
                }
            }
        }       
    }
}