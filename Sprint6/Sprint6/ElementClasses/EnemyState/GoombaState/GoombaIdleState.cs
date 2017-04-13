using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Sprint6.ElementClasses.ElementInterfaces;
using Sprint6.ElementClasses.CharacterClass.Enemies;
using Sprint6.SpriteFactories;
using Sprint6.Sprites;

namespace Sprint6.ElementClasses.EnemyState
{
    class GoombaIdleState : IEnemyState
    {
        public const int GOOMBA_IDLE = 1, GOOMBA_DEAD = 2;
        private Goomba goomba;
        public GoombaIdleState(Goomba goomba)
        {
            this.goomba = goomba;
        }
     
  
        public void EnemyIdle()
        {
            goomba.goombaAction = GOOMBA_IDLE;
        }
    
        public void BeStomped()
        {
            goomba.goombaState  = new GoombaStompedState(goomba);
            goomba.goombaAction = GOOMBA_DEAD;
            goomba.BeStomped();
        }

        public void ChangeDirection()
        {
            goomba.goombaDirection = !goomba.goombaDirection;
        }

        public void Draw(Vector2 position, ISprite enemySprite)
        {
            enemySprite.Draw(position);
        }

        public void Update(ISprite enemySprite)
        {
            enemySprite.Update();
        }

        public void BeFilpped()
        {
            //Nothing
        }
    }
}
