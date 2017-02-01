using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.SpriteFactories
{
    class MarioSpriteFactory
    {
        private Texture2D smallMarioRunningSpritesheet;
        private Texture2D smallMarioStandingSpritesheet;
        private Texture2D largeMarioRunningSpritesheet;
        private Texture2D largeMarioStandingSpritesheet;
        //there will be tons of other mario sprite sheets i assume...

        private static MarioSpriteFactory instance = new MarioSpriteFactory();

        public static MarioSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private MarioSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            //load sprite sheets here**************************************
            //one example is below

            //smallMarioRunningSpriteSheet = content.Load<Texture2D>("smallMarioRunning");
        }

        //methods for creating sprites below*************************************************
        //one example is below

        //public ISprite CreateSmallMarioRunningSprite()
        //{
        //    return new SmallMarioRunningSprite(smallMarioRunningSpritesheet, Game1.Instance.level.isAboveGround);
        //}
    }
}
