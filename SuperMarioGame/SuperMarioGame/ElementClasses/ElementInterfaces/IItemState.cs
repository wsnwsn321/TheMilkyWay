using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SuperMarioGame.Sprites;

namespace SuperMarioGame.ElementClasses.ElementInterfaces
{
    public interface IItemState
    {

        void ItemMoving();
        void ItemChangeDirection();
        void Draw(Vector2 position, ISprite enemySprite);
        void Update(ISprite itemSprite);
    }
}
