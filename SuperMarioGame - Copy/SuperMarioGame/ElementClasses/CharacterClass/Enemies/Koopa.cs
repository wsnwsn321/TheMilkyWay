using Microsoft.Xna.Framework;
using Sprint6.ElementClasses.ElementInterfaces;
using Sprint6.ElementClasses.EnemyState.KoopaState;
using Sprint6.Sprites;
using System;
using System.Collections.Generic;

namespace Sprint6.ElementClasses.CharacterClass.Enemies
{
    public class Koopa : ElementInterfaces.IEnemy

    {
        public ISprite enemySprite { get; set; }
        public Vector2 position { get; set; }
        public bool isVisible { get; set; }
        public float gravity { get; set; }
        public bool flip { get; set; }

        public bool shellDirection { get; set; }
        public int shellMoving { get; set; }

        internal IEnemyState koopaState;

        public const int KOOPA_IDLE = 1, KOOPA_FLIPPED = 2, KOOPA_SHELL = 3;

        public const bool KOOPA_LEFT = true;

        internal bool koopaDirection;

        internal int koopaAction;

        
        public Koopa(Vector2 pos)
        {
            position    = pos;
            enemySprite = SpriteFactories.EnemySpriteFactory.Instance.CreateKoopaMoveLeftSprite();
            koopaState  = new KoopaIdleState(this);
            koopaAction = KOOPA_IDLE;
            koopaDirection = KOOPA_LEFT;
            isVisible   = true;
            shellDirection = false;
            gravity = 3;
            shellMoving = 0;
        }

        public void Draw()
        {
            if (isVisible)
            { 
                koopaState.Draw(position,enemySprite);
            }
        }

        public void Update()
        {
            if(koopaAction != Koopa.KOOPA_SHELL)
            {
                if (koopaDirection)
                {
                    position = new Vector2(position.X - 1, position.Y);
                }
                else
                {
                    position = new Vector2(position.X + 1, position.Y);
                }
            }
            else
            {
                if(shellDirection)
                {
                    
                    if (shellMoving==2)
                    {
                        position = new Vector2(position.X - 4, position.Y);
                    }
                    else if(shellMoving==4)
                    {
                        position = new Vector2(position.X + 4, position.Y);
                    }
                } 
            }
            
            koopaState.Update(enemySprite);
        }
        

        public void ChangeDirection()
        {
            koopaState.ChangeDirection();
            if(koopaAction != KOOPA_SHELL)
            {
                if (koopaDirection)
                {
                    enemySprite = SpriteFactories.EnemySpriteFactory.Instance.CreateKoopaMoveLeftSprite();
                }
                else
                {
                    enemySprite = SpriteFactories.EnemySpriteFactory.Instance.CreateKoopaMoveRightSprite();
                }
            }
            else
            {

            }
                    
        
            
        }

        public void BeStomped()
        {
            enemySprite = SpriteFactories.EnemySpriteFactory.Instance.CreateKoopaStompedSprite();
            koopaState.BeStomped();
        }

        public void BeFlipped()
        {
            if(enemySprite is KoopaStompedSprite)
            {

            }
            koopaState.BeStomped();
            enemySprite = SpriteFactories.EnemySpriteFactory.Instance.CreateKoopaFlippedSprite();
            flip = true;
        }

        public void EnemyIdle()
        {
            enemySprite = SpriteFactories.EnemySpriteFactory.Instance.CreateKoopaMoveLeftSprite();
            koopaState.EnemyIdle();
        }
    }
}
