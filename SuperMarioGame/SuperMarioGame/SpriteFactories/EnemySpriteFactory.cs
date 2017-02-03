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

        public void LoadAllTextures(ContentManager content)
        {
            //load sprite sheets here**************************************
            //one example below

            goombaSpritesheet = content.Load<Texture2D>("Goomba/Goomba");
            koopaSpritesheet = content.Load<Texture2D>("Koopa/Koopa");

        }

        //methods for creating sprites below*************************************************
        //examples below

        public Sprites.ISprite CreateGoombaSprite()
        {
            return new Sprites.GoombaSprite(goombaSpritesheet);
        }

        public Sprites.ISprite CreateKoopaSprite()
        {
            return new Sprites.KoopaSprite(koopaSpritesheet);
        }
    }
}
