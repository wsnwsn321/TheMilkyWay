using Microsoft.Xna.Framework;
using SuperMarioGame.ElementClasses.ElementInterfaces;
using SuperMarioGame.ElementClasses.EnemyState.KoopaState;
using SuperMarioGame.Sprites;
using System;

namespace SuperMarioGame.ElementClasses.CharacterClass.Enemies
{
    public class Koopa : ElementInterfaces.IEnemy

    {
        public ISprite enemySprite { get; set; }
        public Vector2 position { get; set; }
        public bool isVisible { get; set; }

        public IEnemyState koopaState;

        public const int KOOPA_IDLE = 1, KOOPA_FLIPPED = 2, KOOPA_SHELL = 3;

        public const bool GOOMBA_LEFT = true;

        public bool koopaDirection;

        public int koopaAction;

        public Koopa(Vector2 pos)
        {
            position    = pos;
            enemySprite = SpriteFactories.EnemySpriteFactory.Instance.CreateKoopaSprite();
            koopaState  = new KoopaIdleState(this);
            koopaAction = KOOPA_IDLE; 
            isVisible   = true;
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
            koopaState.Update(enemySprite);
        }

        public void ChangeDirection()
        {
            koopaState.ChangeDirection();
        }

        public void BeStomped()
        {
            enemySprite = SpriteFactories.EnemySpriteFactory.Instance.CreateKoopaStompedSprite();
            koopaState.BeStomped();
        }

        public void BeFlipped()
        {
            //enemySprite = SpriteFactories.EnemySpriteFactory.Instance.CreateKoopaFlippedSprite();
            //koopaState.BeFlipped()
        }

        public void EnemyIdle()
        {
            enemySprite = SpriteFactories.EnemySpriteFactory.Instance.CreateKoopaSprite();
            koopaState.EnemyIdle();
        }
    }
}
