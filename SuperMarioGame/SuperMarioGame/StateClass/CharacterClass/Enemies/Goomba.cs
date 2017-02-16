using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.StateClass.CharacterClass.Enemies
{
    public class Goomba : StateInterface.IEnemy

    {
        Sprites.ISprite goomba;
        public Vector2 position { get; set; }

        public Goomba(Vector2 pos)
        {
            position = pos;
            goomba = SpriteFactories.EnemySpriteFactory.Instance.CreateGoombaSprite();
        }

        public void Draw()
        {
            goomba.Draw(position);
        }

        public void Update()
        {
            goomba.Update();
        }
    }
}
