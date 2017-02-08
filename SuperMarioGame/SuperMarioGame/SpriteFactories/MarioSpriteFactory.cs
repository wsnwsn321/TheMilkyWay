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
        //maybe we don't need separate left/right since we have the spritesheets which put these two together
        private Texture2D idleSmallMarioSpritesheet;
        private Texture2D runningSmallMarioSpritesheet;
        private Texture2D jumpingSmallMarioSpritesheet;
        private Texture2D deadSmallMarioSpritesheet;

        private Texture2D idleBigMarioSpritesheet;
        private Texture2D runningBigMarioSpritesheet;
        private Texture2D jumpingBigMarioSpritesheet;
        private Texture2D crouchingBigMarioSpritesheet;

        private Texture2D idleFireMarioSpritesheet;
        private Texture2D runningFireMarioSpritesheet;
        private Texture2D jumpingFireMarioSpritesheet;
        private Texture2D crouchingFireMarioSpritesheet;





        //there will be tons of other mario sprite sheets i assume...

        public SpriteBatch sb { set; get; }
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
            idleSmallMarioSpritesheet = content.Load<Texture2D>("Mario/Smario/SmarioStand");
            runningSmallMarioSpritesheet = content.Load<Texture2D>("Mario/Smario/SmarioRun");
            jumpingSmallMarioSpritesheet = content.Load<Texture2D>("Mario/Smario/SmarioJump");
            deadSmallMarioSpritesheet = content.Load<Texture2D>("Mario/Smario/SmarioDead");



        }

        //methods for creating sprites below*************************************************
        //one example is below
        //public Sprites.ISprite CreateSmallMarioRunningSprite()
        //{
        //return new SmallMarioRunningSprite(smallMarioRunningSpritesheet, Game1.Instance.level.isAboveGround);
        //}

        public Sprites.ISprite CreateLeftIdleSmallMarioSprite()
        {
            return new Sprites.MarioSprite.SmallMarioSprite.LeftIdleSmallMarioSprite(idleSmallMarioSpritesheet, sb);
        }

        public Sprites.ISprite CreateRightIdleSmallMarioSprite()
        {
            return new Sprites.MarioSprite.SmallMarioSprite.RightIdleSmallMarioSprite(idleSmallMarioSpritesheet, sb);
        }
        public Sprites.ISprite CreateLeftRunningSmallMarioSprite()
        {
            return new Sprites.MarioSprite.SmallMarioSprite.LeftRunningSmallMarioSprite(runningSmallMarioSpritesheet, sb);
        }

        public Sprites.ISprite CreateRightRunningSmallMarioSprite()
        {
            return new Sprites.MarioSprite.SmallMarioSprite.RightRunningSmallMarioSprite(runningSmallMarioSpritesheet, sb);
        }

        public Sprites.ISprite CreateLeftJumpingSmallMarioSprite()
        {
            return new Sprites.MarioSprite.SmallMarioSprite.LeftJumpingSmallMarioSprite(jumpingSmallMarioSpritesheet, sb);
        }
        public Sprites.ISprite CreateRightJumpingSmallMarioSprite()
        {
            return new Sprites.MarioSprite.SmallMarioSprite.RightJumpingSmallMarioSprite(jumpingSmallMarioSpritesheet, sb);
        }

        public Sprites.ISprite CreateDeadSmallMarioSprite()
        {
            return new Sprites.MarioSprite.SmallMarioSprite (deadSmallMarioSpritesheet, sb);
        }
    }
}
