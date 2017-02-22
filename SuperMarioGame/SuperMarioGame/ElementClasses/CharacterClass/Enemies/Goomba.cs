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
        public IEnemyState goombaState;
        public ISprite enemySprite { get; set; }
        public  const int GOOMBA_IDLE = 1, GOOMBA_DEAD = 2;

        public const bool GOOMBA_LEFT = true;

        public bool goombaDirection;
        public int goombaAction;

        public Goomba(Vector2 pos)
        {
            position        = pos;
            goombaDirection = true;
            goombaState = new GoombaIdleState(this);
            enemySprite = SpriteFactories.EnemySpriteFactory.Instance.CreateGoombaSprite();
            goombaAction    = GOOMBA_IDLE;
            EnemyIdle();
        }

        public void  EnemyIdle()
        {
            goombaState.EnemyIdle();
            enemySprite = SpriteFactories.EnemySpriteFactory.Instance.CreateGoombaSprite();
        }
        public void Draw()
        {
            goombaState.Draw(position,enemySprite);
        }

        public void Update()
        {
            goombaState.Update(enemySprite);
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

        public void BeFilpped()
        {
            //nothing
        }
        
    }
}
