﻿using SuperMarioGame.ElementClasses.ElementInterfaces;
using SuperMarioGame.ElementClasses;
using SuperMarioGame.Sprites;
using Microsoft.Xna.Framework;

namespace SuperMarioGame.CollisionHandler
{

    public static class EnemyBlockHandler
    {
        
        public static void BlockHandler(IEnemy enemy, IBlock block, int CollisionSide)
        {
            Vector2 newPosition;
            int SIX= 6;
            if (!enemy.flip&&block.isBroken==false&&block.isVisible)
            {
                switch (CollisionSide)
                {
                    case 1:
                        newPosition.X = enemy.enemySprite.desRectangle.X;
                        newPosition.Y = block.blockSprite.desRectangle.Y - enemy.enemySprite.desRectangle.Height - SIX;
                        enemy.position = newPosition;
                        break;
                    case 2:
                        newPosition.X = block.blockSprite.desRectangle.X + block.blockSprite.desRectangle.Width;
                        newPosition.Y = enemy.enemySprite.desRectangle.Y;
                        enemy.position = newPosition;
                        enemy.ChangeDirection();
                        if (enemy.shellMoving == GameConstants.Right)
                        {
                            enemy.shellMoving = GameConstants.Left;
                        }
                       else if (enemy.shellMoving == GameConstants.Left)
                        {
                            enemy.shellMoving = GameConstants.Right;
                        }
                        break;
                    case 3:
                        newPosition.X = enemy.enemySprite.desRectangle.X;
                        newPosition.Y = block.blockSprite.desRectangle.Y + enemy.enemySprite.desRectangle.Height;
                        enemy.position = newPosition;
                        break;
                    case 4:
                        newPosition.X = block.blockSprite.desRectangle.X - enemy.enemySprite.desRectangle.Width;
                        newPosition.Y = enemy.enemySprite.desRectangle.Y;
                        enemy.position = newPosition;
                        enemy.ChangeDirection();
                        if (enemy.shellMoving == GameConstants.Right)
                        {
                            enemy.shellMoving = GameConstants.Left;
                        }
                        else if (enemy.shellMoving == GameConstants.Left)
                        {
                            enemy.shellMoving = GameConstants.Right;
                        }
                        break;
                }
            }            
        }
    }
}
