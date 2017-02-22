using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SuperMarioGame.ElementClasses.ElementInterfaces;
using SuperMarioGame.ElementClasses.CharacterClass.Enemies;
using SuperMarioGame.SpriteFactories;
using SuperMarioGame.Sprites;

namespace SuperMarioGame.ElementClasses.EnemyState
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
