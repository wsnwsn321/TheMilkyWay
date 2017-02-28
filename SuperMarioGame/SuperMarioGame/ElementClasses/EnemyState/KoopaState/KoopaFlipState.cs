using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SuperMarioGame.ElementClasses.ElementInterfaces;
using SuperMarioGame.Sprites;
using SuperMarioGame.ElementClasses.CharacterClass.Enemies;

namespace SuperMarioGame.ElementClasses.EnemyState.KoopaState
{
    public class KoopaFlipState: IEnemyState
    {

        private Koopa koopa;

        public KoopaFlipState(Koopa koop)
        {
            koopa = koop;
        }
        public void EnemyIdle(Koopa koop)
        {
            koopa = koop;
        }

        public void BeFilpped()
        {
            koopa.koopaAction = Koopa.KOOPA_FLIPPED;
        }

        public void BeStomped()
        {
            koopa.koopaAction = Koopa.KOOPA_SHELL;
            koopa.koopaState = new KoopaShellState(koopa);
        }

        public void ChangeDirection()
        {
            koopa.koopaDirection = !koopa.koopaDirection;
        }

        public void EnemyIdle()
        {
            koopa.koopaAction = Koopa.KOOPA_IDLE;
            koopa.koopaState = new KoopaIdleState(koopa);
        }

        public void Draw(Vector2 position, ISprite enemySprite)
        {
            enemySprite.Draw(position);
        }

        public void Update(ISprite enemySprite)
        {
            enemySprite.Update();
        }

        
    }
}
