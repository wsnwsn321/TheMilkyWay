using System.Collections.Generic;
using TheMilkyWay.ElementClasses.ElementInterfaces;
using TheMilkyWay.ElementClasses;
using Microsoft.Xna.Framework;
using TheMilkyWay.Sprites.UFOSprite;
using TheMilkyWay.SpriteFactories;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using Microsoft.Xna.Framework.Media;
using MyGame;
using TheMilkyWay.Sound.BackgroundMusic;
using TheMilkyWay.Sound.UFOSound;

namespace TheMilkyWay.CollisionHandler
{
    class CollisionDetection
    {
        private Rectangle collideRectangle;
        private Rectangle firstRectangle;
        private Rectangle secondRectangle;
        public static    bool cowSoundPlay = true;
        private int bombCount = 0;
        Game1 myGame;

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
                if ((item is CowCharacter || item is BadCowCharacter) &&
                    item.itemSprite.desRectangle.Intersects(mainCharacter.state.BeamSprite.desRectangle) && mainCharacter.state.beam)
                {
                    item.position = new Vector2(item.position.X, item.position.Y - 3);
                    
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
                if (mainCharacter.bombItem.itemSprite.desRectangle.Intersects(item.itemSprite.desRectangle) && !(item.itemSprite is DiskSprite))
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
                        mainCharacter.bombItem.canMove = false;
                        if (item is BadCowCharacter)
                        {
                            mainCharacter.BadCowCount++;
                            mainCharacter.GoalCount++;
                            item.itemSprite = CharacterSpriteFactory.Instance.CreateBadCowDeadSprite();
                        }
                        else
                        {
                            item.itemSprite = CharacterSpriteFactory.Instance.CreateDeadCowSprite();
                        }

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
                if ((item is CowCharacter || item is BadCowCharacter) && mainCharacter.state.Sprite.desRectangle.Intersects(item.itemSprite.desRectangle) && mainCharacter.state.beam && item.isVisible)
                {
                    if (item is CowCharacter)
                    {
                        myGame.level.mainCharacter.GoodCowCount++;
                      
                            UFOSoundManager.instance.playSound(UFOSoundManager.COW);
                
                    }
                    else
                    {
                        mainCharacter.canMove = false;
                        mainCharacter.UFODie();
                    }
                    item.isVisible = false;
                } else if (item is Disk && mainCharacter.state.Sprite.desRectangle.Intersects(item.itemSprite.desRectangle) && item.isVisible)
                {
                    Sound.MenuMusic.SoundList.instance.addMusic();
                    item.isVisible = false;
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

                }

            }
        }

        public void ItemBlockCollision(IItem item, List<IBlock> envElements)
        {
            foreach (IBlock block in envElements)
            {
                firstRectangle = item.itemSprite.desRectangle;
                secondRectangle = block.blockSprite.desRectangle;
                collideRectangle = Rectangle.Intersect(firstRectangle, secondRectangle);
                if (item.itemSprite.desRectangle.Intersects(block.blockSprite.desRectangle))
                {

                    if (collideRectangle.Width * collideRectangle.Height > GameConstants.Eleven + GameConstants.Two)
                    {
                        ItemBlockHandler.BlockHandler(item, block);
                    }
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
                }
            }
        }       
    }
}
