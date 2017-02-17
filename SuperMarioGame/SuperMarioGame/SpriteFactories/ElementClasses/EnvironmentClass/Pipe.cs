using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.ElementClasses.EnvironmentClass
{
    public class Pipe : ElementInterfaces.IBlock

    {
        Sprites.ISprite pipe;
        public Vector2 position { get; set; }

        public Pipe(Vector2 pos)
        {
            position = pos;
            pipe = SpriteFactories.EnvironmentSpriteFactory.Instance.CreatePipeSprite();
        }

        public void Draw()
        {
            pipe.Draw(position);
        }

        public void Update()
        {
            pipe.Update();
        }
    }
}
