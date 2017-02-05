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
        private Texture2D leftRunningSmallMarioSpritesheet;
        private Texture2D rightRunningSmallMarioSpritesheet;
        private Texture2D leftIdleSmallMarioSpritesheet;
        private Texture2D rightIdleSmallMarioSpritesheet;
        private Texture2D rightCrouchingSmallMarioSpritesheet;
        private Texture2D rightJumpingSmallMarioSpritesheet;
        private Texture2D leftCrouchingSmallMarioSpritesheet;
        private Texture2D leftJumpingSmallMarioSpritesheet;

        private Texture2D leftRunningBigMarioSpritesheet;
        private Texture2D rightRunningBigMarioSpritesheet;
        private Texture2D leftIdleBigMarioSpritesheet;
        private Texture2D rightIdleBigMarioSpritesheet;
        private Texture2D rightCrouchingBigMarioSpritesheet;
        private Texture2D rightJumpingBigMarioSpritesheet;
        private Texture2D leftCrouchingBigMarioSpritesheet;
        private Texture2D leftJumpingBigMarioSpritesheet;

        private Texture2D leftRunningFireMarioSpritesheet;
        private Texture2D rightRunningFireMarioSpritesheet;
        private Texture2D leftIdleFireMarioSpritesheet;
        private Texture2D rightIdleFireMarioSpritesheet;
        private Texture2D rightCrouchingFireMarioSpritesheet;
        private Texture2D rightJumpingFireMarioSpritesheet;
        private Texture2D leftCrouchingFireMarioSpritesheet;
        private Texture2D leftJumpingFireMarioSpritesheet;



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

        //public Sprites.ISprite CreateSmallMarioRunningSprite()
        //{
            //return new SmallMarioRunningSprite(smallMarioRunningSpritesheet, Game1.Instance.level.isAboveGround);
        //}
    }
}
