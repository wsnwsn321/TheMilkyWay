using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.ElementClasses.CharacterClass.Enemies
{
    public class Koopa : ElementInterfaces.IEnemy

    {
        Sprites.ISprite koopa;
        public Vector2 position { get; set; }

        public Koopa(Vector2 pos)
        {
            position = pos;
            koopa = SpriteFactories.EnemySpriteFactory.Instance.CreateKoopaSprite();
        }

        public void Draw()
        {
            koopa.Draw(position);
        }

        public void Update()
        {
            koopa.Update();
        }
    }
}
