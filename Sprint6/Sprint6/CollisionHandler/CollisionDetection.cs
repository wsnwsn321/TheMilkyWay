using System.Collections.Generic;
using Sprint6.ElementClasses.ElementInterfaces;
using Sprint6.ElementClasses;
using Microsoft.Xna.Framework;
using Sprint6.ElementClasses.ItemClass;
using Sprint6.Sprites;
using Sprint6.SpriteFactories;
using Microsoft.Xna.Framework.Input;
using Sprint6.ElementClasses.BackgroundClass;
using Sprint6.ElementClasses.EnvironmentClass;
using System.Diagnostics;
using Sprint6.Sound.MarioSound;
using Microsoft.Xna.Framework.Media;

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
            get
            {
                return instance;
            }
        }

        private CollisionDetection()
        {
        }

        public void MarioBlockCollision(Game1 game, MainCharacter mainCharacter, List<IBlock> envElements)
        {
            Pipe tempPipe;
            mainCharacter.gravity = 4;
            foreach (IBlock block in envElements)
            {
                myGame = game;
                if (block.isVisible)
                {                   
                    if (mainCharacter.state.marioSprite.desRectangle.Bottom > block.position.Y - 5 && mainCharacter.state.marioSprite.desRectangle.Bottom <= block.position.Y)
                    {
                        if (mainCharacter.state.marioSprite.desRectangle.Right > block.position.X + 3 && mainCharacter.state.marioSprite.desRectangle.Left < block.blockSprite.desRectangle.Right - 3)
                        {
                            if(block is Pipe && mainCharacter.state is CrouchMarioState)
                            {
                                tempPipe = block as Pipe;                      
                                if (tempPipe.special)
                                {
                                    if(mainCharacter.marioState==MainCharacter.MARIO_SMALL)
                                        mainCharacter.position = new Vector2(block.position.X+17, block.position.Y-mainCharacter.state.marioSprite.desRectangle.Height);
                                    else
                                        mainCharacter.position = new Vector2(block.position.X + 12, block.position.Y - mainCharacter.state.marioSprite.desRectangle.Height);
                                    mainCharacter.animated = true;
                                    mainCharacter.animation = GameConstants.PipeAnimation;
                                }
                                else
                                {
                                    mainCharacter.gravity = 0;
                                    mainCharacter.jump = true;
                                }
                            }
                            else
                            {
                                mainCharacter.gravity = 0;
                                mainCharacter.jump = true;
                            }
                        }
                    }
                }
                if (mainCharacter.state.marioSprite.desRectangle.Intersects(block.blockSprite.desRectangle))
                {
                    firstRectangle = mainCharacter.state.marioSprite.desRectangle;
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
            enemy.gravity = 3;
            foreach (IBlock block in envElements)
            {
                if (block.isVisible)
                {
                    if (enemy.enemySprite.desRectangle.Bottom > block.position.Y - 5 && enemy.enemySprite.desRectangle.Bottom <= block.position.Y)
                    {
                        if (enemy.enemySprite.desRectangle.Right > block.position.X + 3 && enemy.enemySprite.desRectangle.Left < block.blockSprite.desRectangle.Right - 3)
                        {
                            if (!enemy.flip)
                            {
                                if (mainCharacter.state.marioSprite.desRectangle.Intersects(block.blockSprite.desRectangle)&&mainCharacter.marioState!=MainCharacter.MARIO_SMALL&&block.blockSprite is BrickBlockSprite)
                                {
                                    enemy.BeFlipped();
                                    //score part
                                    mainCharacter.isScored = true;
                                    mainCharacter.score = GameConstants.Score1;
                                    mainCharacter.totalScore += mainCharacter.score;
                                    Vector2 newP;
                                    newP.X = block.blockSprite.desRectangle.X + GameConstants.Twelve;
                                    newP.Y = block.blockSprite.desRectangle.Y - GameConstants.Three;
                                    mainCharacter.textPosition = newP;
                                }
                                enemy.gravity = 0;
                            }
                        }
                    }
                }
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
                    if (collideRectangle.Width * collideRectangle.Height > GameConstants.Eleven+ GameConstants.Two)
                    {
                        EnemyBlockHandler.BlockHandler(enemy, block, SIDE);
                    }
                }
            }
        }

        public void ItemBlockCollision(IItem item, List<IBlock> envElements)
        {
            if(!(item.itemSprite is FireballSprite))
            {
                item.gravity = GameConstants.Two* GameConstants.Two;
            }
        
            foreach (IBlock block in envElements)
            {
                if (block.isVisible)
                {
                    if (item.itemSprite.desRectangle.Bottom > block.position.Y - 5 && item.itemSprite.desRectangle.Bottom <= block.position.Y)
                    {
                        
                        if (item.itemSprite.desRectangle.Right > block.position.X + 3 && item.itemSprite.desRectangle.Left < block.blockSprite.desRectangle.Right - 3)
                        {
                            if(item.itemSprite is FireballSprite)
                            {
                                item.ItemChangeDirection();
                            }
                            item.gravity = 0;
                        }
                    }
                }
                if (!(item is Flower) && item.itemSprite.desRectangle.Intersects(block.blockSprite.desRectangle))
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
                        ItemBlockHandler.BlockHandler(myGame,item, block, SIDE);
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
                    if(item is Fireball)
                    {
                        //score part
                        mainCharacter.isScored = true;
                        mainCharacter.score = GameConstants.Score2;
                        mainCharacter.totalScore += mainCharacter.score;
                        Vector2 newP;
                        newP.X = enemy.position.X;
                        newP.Y = enemy.position.Y - GameConstants.Three;
                        mainCharacter.textPosition = newP;
                    }
                }
            }  
        }

        public void MarioItemCollision(MainCharacter mainCharacter, List<IItem> itemElements)
        {
            SIDE = GameConstants.Top;
            foreach (IItem item in itemElements)
            {     
                if (mainCharacter.state.marioSprite.desRectangle.Intersects(item.itemSprite.desRectangle))
                {
                    MainCharItemHandler.ItemHandler( myGame,mainCharacter, item);
                }
            }
        }

        public void MarioFlagCollision(MainCharacter mainCharacter, List<IBackground> backgroundElements)
        {
            if (!mainCharacter.animated)
            {
                animation = false;
            }
            if (!animation)
            {
                foreach (IBackground bg in backgroundElements)
                {
                    if (bg is Flag)
                    {
                        Flag tempFlag = bg as Flag;
                        if (!tempFlag.isDown)
                        {
                            if (mainCharacter.state.marioSprite.desRectangle.Right > bg.backgroundSprite.desRectangle.Right)
                            {
                                //score part
                                mainCharacter.isScored = true;
                                if (mainCharacter.position.Y < bg.backgroundSprite.desRectangle.Y + GameConstants.Fifty)
                                {
                                    mainCharacter.score = GameConstants.Score1500;
                                }
                                else if(mainCharacter.position.Y >= bg.backgroundSprite.desRectangle.Y + GameConstants.Fifty&&mainCharacter.position.Y < bg.backgroundSprite.desRectangle.Y + GameConstants.Fifty* GameConstants.Three)
                                {
                                    mainCharacter.score = GameConstants.Score1000;
                                }
                                else{
                                    mainCharacter.score = GameConstants.Score500;
                                }
                                mainCharacter.totalScore += mainCharacter.score;
                                Vector2 newP;
                                newP.X = mainCharacter.position.X;
                                newP.Y = mainCharacter.position.Y - GameConstants.Three;
                                mainCharacter.textPosition = newP;
                                MediaPlayer.Stop();
                                MarioSoundManager.instance.playSound(MarioSoundManager.FLAGPOLE);
                                MarioSoundManager.instance.playSound(MarioSoundManager.STAGECLEAR);
                                myGame.keyboardController.keysEnabled = false;
                                bg.moveDown = true;
                                mainCharacter.animated = true;
                                mainCharacter.animation = GameConstants.FlagAnimation;
                                animation = true;
                            }
                        }
                    }
                }
            }
        }

        public void MarioEnemyCollision(MainCharacter mainCharacter, List<IEnemy> enemyElements)
        {

            foreach (IEnemy enemy in enemyElements)
            {
                if (mainCharacter.state.marioSprite.desRectangle.Intersects(enemy.enemySprite.desRectangle))
                {
                    firstRectangle = mainCharacter.state.marioSprite.desRectangle;
                    secondRectangle = enemy.enemySprite.desRectangle;
                    collideRectangle = Rectangle.Intersect(mainCharacter.state.marioSprite.desRectangle, enemy.enemySprite.desRectangle);
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

        public void EnemyEnemyCollision(IEnemy enemy1, List<IEnemy> enemyElements)
        {
            foreach (IEnemy enemy2 in enemyElements)
            {
                if (!enemy1.Equals(enemy2) && enemy1.enemySprite.desRectangle.Intersects(enemy2.enemySprite.desRectangle))
                {
                    firstRectangle = enemy1.enemySprite.desRectangle;
                    secondRectangle = enemy2.enemySprite.desRectangle;
                    collideRectangle = Rectangle.Intersect(enemy1.enemySprite.desRectangle, enemy2.enemySprite.desRectangle);
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
                    EnemyEnemyHandler.EnemyHandler(enemy1, enemy2, SIDE);
                }
            }
        }
    }
}
