using System.Collections.Generic;
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
using Sprint6.Sound.BackgroundMusic;

namespace Sprint6.CollisionHandler
{
    class CollisionDetection
    {
        private Rectangle collideRectangle;
        private Rectangle firstRectangle;
        private Rectangle secondRectangle;
        public int SIDE;
        private int bombCount = 0;
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

        public void BeamCowCollision(Game1 game, MainCharacter mainCharacter, List<IItem> itemElements)
        {
            myGame = game;
            foreach (IItem item in itemElements)
            {
                if ((item is CowCharacter||item is BadCowCharacter) &&
                    item.itemSprite.desRectangle.Intersects(mainCharacter.state.BeamSprite.desRectangle)&&mainCharacter.state.beam)
                {
                    item.position = new Vector2(item.position.X,item.position.Y - 3);
                }
            }
        }
        public void BombBlockCollision(Game1 game, MainCharacter mainCharacter, List<IBlock> envElements)
        {
            myGame = game;
            foreach (IBlock block in envElements)
            {
                if (mainCharacter.bombItem.itemSprite.desRectangle.Intersects(block.blockSprite.desRectangle))
                {
                    if (bombCount == 30)
                    {
                        mainCharacter.bombItem.isVisible = false;
                        bombCount = 0;
                        mainCharacter.bombUpdate = false;
                    }
                    else
                    {
                        mainCharacter.bombItem.canMove = false;
                        mainCharacter.bombItem.itemSprite = CharacterSpriteFactory.Instance.CreateDeadUFOSprite();
                    }
                    bombCount++;
                }
            }
        }

        public void BombItemCollision(Game1 game, MainCharacter mainCharacter, List<IItem> itemElements)
        {
            myGame = game;
            foreach (IItem item in itemElements)
            {
                if (mainCharacter.bombItem.itemSprite.desRectangle.Intersects(item.itemSprite.desRectangle))
                {
                    if (bombCount == 30)
                    {
                        mainCharacter.bombItem.isVisible = false;
                        bombCount = 0;
                        mainCharacter.bombUpdate = false;
                    }
                    else
                    {
                        item.gravity = 0;
                        item.itemSprite = CharacterSpriteFactory.Instance.CreateDeadCowSprite();
                        mainCharacter.bombItem.canMove = false;
                        mainCharacter.bombItem.itemSprite = CharacterSpriteFactory.Instance.CreateDeadUFOSprite();
                    }
                    bombCount++;
                }
            }
        }


        public void MainCharItemCollision(MainCharacter mainCharacter, List<IItem> itemElements)
        {
            foreach (IItem item in itemElements)
            {
                if ((item is CowCharacter ||item is BadCowCharacter)&& mainCharacter.state.Sprite.desRectangle.Intersects(item.itemSprite.desRectangle) && mainCharacter.state.beam && item.isVisible)
                {
                    if(item is CowCharacter)
                    {
                        myGame.level.mainCharacter.GoodCowCount++;

                    }
                    else
                    {
                        mainCharacter.canMove = false;
                        mainCharacter.UFODie();
                    }
                    item.isVisible = false;
                }else if(item is Disk && mainCharacter.state.Sprite.desRectangle.Intersects(item.itemSprite.desRectangle) && item.isVisible)
                {
                    item.isVisible = false;
                    BackgroundMusic.instanse.mashPlay();
                }
                
            }
        }

        public void MainCharBlockCollision(Game1 game, MainCharacter mainCharacter, List<IBlock> envElements)
        {
            myGame = game;
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
                    mainCharacter.UFODie();
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

        public void MainCharEnemyCollision(MainCharacter mainCharacter, List<IEnemy> enemyElements)
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
                    mainCharacter.UFODie();
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
