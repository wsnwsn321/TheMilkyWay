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
    class KoopaShellState: IEnemyState
    {

        private Koopa koopa;
        public KoopaShellState(Koopa koopa)
        {
            this.koopa = koopa;
        }
        public void BeFilpped()
        {
            koopa.koopaAction = Koopa.KOOPA_FLIPPED;
            koopa.koopaState = new KoopaFlipState(koopa);

        }

        public void BeStomped()
        {
            koopa.koopaAction = Koopa.KOOPA_SHELL;
        }

        public void ChangeDirection()
        {
            koopa.koopaDirection = !koopa.koopaDirection;
        }


        public void Draw(Vector2 position, ISprite enemySprite)
        {
            enemySprite.Draw(position);
        }

        public void EnemyIdle()
        {
            koopa.koopaAction = Koopa.KOOPA_IDLE;
            koopa.koopaState = new KoopaIdleState(koopa);
        }


        public void Update(ISprite enemySprite)
        {
            enemySprite.Update();
        }
    }
}
