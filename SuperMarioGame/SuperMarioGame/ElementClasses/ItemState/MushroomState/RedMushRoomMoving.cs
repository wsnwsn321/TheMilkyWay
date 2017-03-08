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
using SuperMarioGame.ElementClasses.ItemClass;

namespace SuperMarioGame.ElementClasses.ItemState.MushroomState
{
    class RedMushRoomMoving: IItemState
    {
        private RedMushroom redmushroom;
        public RedMushRoomMoving(RedMushroom redmushroom)
        {
            this.redmushroom = redmushroom;
        }
        public void ItemMoving()
        {

        }

        public void ItemChangeDirection()
        {
            redmushroom.changeDirection = !redmushroom.changeDirection;
        }
        public void Draw(Vector2 position, ISprite redmushroom)
        {
            redmushroom.Draw(position);
        }
        public void Update(ISprite itemSprite)
        {
            redmushroom.Update();
        }

    }
}
