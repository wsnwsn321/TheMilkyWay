﻿using Microsoft.Xna.Framework;
using SuperMarioGame.ElementClasses.ElementInterfaces;
using SuperMarioGame.ElementClasses.EnemyState.KoopaState;
using SuperMarioGame.Sprites;
using System;
using System.Collections.Generic;

namespace SuperMarioGame.ElementClasses.CharacterClass.Enemies
{
    public class Koopa : ElementInterfaces.IEnemy

    {
        public ISprite enemySprite { get; set; }
        public Vector2 position { get; set; }
        public bool isVisible { get; set; }
        public float gravity { get; set; }
        public bool onTop { get; set; }

        public bool flip { get; set; }

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
            gravity = 3;
            onTop = false;
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
        
            
        }

        public void BeStomped()
        {
            enemySprite = SpriteFactories.EnemySpriteFactory.Instance.CreateKoopaStompedSprite();
            koopaState.BeStomped();
        }

        public void BeFlipped()
        {
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
