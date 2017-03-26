using Microsoft.Xna.Framework;
using SuperMarioGame.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarioGame.ElementClasses.ElementInterfaces;
using SuperMarioGame.ElementClasses.EnemyState;

namespace SuperMarioGame.ElementClasses.CharacterClass.Enemies
{
    public class Goomba : IEnemy

    {     
        public Vector2 position { get; set; }
        internal IEnemyState goombaState;
        public ISprite enemySprite { get; set; }
        public bool isVisible { get; set; }

        public float gravity { get; set; }

        public bool onTop { get; set; }

        public bool flip { get; set; }
        public bool shellDirection { get; set; }
        public int shellMoving { get; set; }

        public const int GOOMBA_IDLE = 1, GOOMBA_DEAD = 2;

        public const bool GOOMBA_LEFT = true;

        internal bool goombaDirection;

        internal int goombaAction;

        private int deadCounter = 0;

        public Goomba(Vector2 pos)
        {
            position = pos;
            goombaDirection = true;
            goombaState = new GoombaIdleState(this);
            enemySprite = SpriteFactories.EnemySpriteFactory.Instance.CreateGoombaSprite();
            goombaAction = GOOMBA_IDLE;
            EnemyIdle();
            isVisible = true;
            gravity = 3;
            onTop = false;
            
        }

        public void  EnemyIdle()
        {
            goombaState.EnemyIdle();
            enemySprite = SpriteFactories.EnemySpriteFactory.Instance.CreateGoombaSprite();
        }
        public void Draw()
        {
            if (isVisible)
            {
                goombaState.Draw(position, enemySprite);
            }
        }

        public void Update()
        {
            if (flip)
            {
                gravity = 3;
            }
            if (goombaAction != Goomba.GOOMBA_DEAD)
            {
                if (goombaDirection)
                {
                    position = new Vector2(position.X - 1, position.Y);
                }
                else
                {
                    position = new Vector2(position.X + 1, position.Y);
                }
            }           
              
            goombaState.Update(enemySprite);
            if (goombaAction.Equals(GOOMBA_DEAD))
            {
                deadCounter++;
                if(deadCounter == 50)
                {
                    isVisible = false;
                }
            }
            
        }

        public void ChangeDirection()
        {
            goombaState.ChangeDirection();
     
        }

        public void BeStomped()
        {
            goombaState.BeStomped();
            enemySprite = SpriteFactories.EnemySpriteFactory.Instance.CreateGoombaStompedSprite();
        }

        public void BeFlipped()
        {
            goombaState.BeStomped();
            enemySprite = SpriteFactories.EnemySpriteFactory.Instance.CreateGoombaFlippedSprite();
            flip = true;
        }

    }
}
