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
    class KoopaIdleState: IEnemyState
    {
      
        private Koopa koopa;

        public KoopaIdleState(Koopa koopa)
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
            koopa.koopaState = new KoopaShellState(koopa);
        }

        public void ChangeDirection()
        {
            koopa.koopaDirection = !koopa.koopaDirection;
        }

        public void Draw(Vector2 position, ISprite koopaSprite)
        {
            koopaSprite.Draw(position);
        }

        public void Update(ISprite koopaSprtie)
        {
            koopaSprtie.Update();
        }

        public void EnemyIdle()
        {
            koopa.koopaAction = Koopa.KOOPA_IDLE;
        }
    }
}
