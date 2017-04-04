using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SuperMarioGame.Sprites;

namespace SuperMarioGame.ElementClasses.ElementInterfaces
{
    public interface IEnemyState
    {
         
         void EnemyIdle();

         void BeFilpped();

         void BeStomped();

         void ChangeDirection();
       // void MovingShell(int side);

         void Draw(Vector2 position, ISprite enemySprite);

         void Update(ISprite enemySprite);

    }
}
