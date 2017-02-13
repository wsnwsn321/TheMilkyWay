using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.SpriteFactories
{
    public class EnemySpriteFactory
    {

        private Texture2D goombaSpritesheet;
        private Texture2D koopaSpritesheet;
        // More private Texture2Ds follow
        // ...
        public SpriteBatch sb { get; set; }
        private static EnemySpriteFactory instance = new EnemySpriteFactory();

 
        public static EnemySpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private EnemySpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content, SpriteBatch sb)
        {
            goombaSpritesheet = content.Load<Texture2D>("Goomba/Goomba");
            koopaSpritesheet = content.Load<Texture2D>("Koopa/Koopa");
            this.sb = sb;
        }

        //create enemy sprites
        public Sprites.ISprite CreateGoombaSprite()
        {
            return new Sprites.GoombaSprite(goombaSpritesheet,sb);
        }

        public Sprites.ISprite CreateKoopaSprite()
        {
            return new Sprites.KoopaSprite(koopaSpritesheet,sb);
        }
    }
}
