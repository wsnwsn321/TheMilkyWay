﻿using System;
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
    class GoombaStompedState : IEnemyState
    {
        public const int GOOMBA_IDLE = 1, GOOMBA_DEAD = 2;
        private Goomba goomba;
        public GoombaStompedState(Goomba goomba)
        {
            this.goomba = goomba;
        }

     
        public void BeStomped()
        {
            goomba.goombaAction = GOOMBA_DEAD;
        }

  
        public void Draw(Vector2 position,ISprite enemySprite)
        {
            enemySprite.Draw(position);
        }

        public void BeFilpped()
        {
            //do Nothing
        }

        public void ChangeDirection()
        {
            //do Nothing
        }

        public void EnemyIdle()
        {
            //do Nothing
        }

        public void Update(ISprite enemySprite)
        {
            enemySprite.Update();
        }
    }
}
