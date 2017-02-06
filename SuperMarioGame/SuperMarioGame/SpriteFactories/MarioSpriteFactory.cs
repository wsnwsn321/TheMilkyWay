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
        private Texture2D idleSmallMarioSpritesheet;
        private Texture2D runningSmallMarioSpritesheet;
        private Texture2D jumpingSmallMarioSpritesheet;
        private Texture2D crouchingSmallMarioSpritesheet;

        private Texture2D idleBigMarioSpritesheet;
        private Texture2D runningBigMarioSpritesheet;
        private Texture2D jumpingBigMarioSpritesheet;
        private Texture2D crouchingBigMarioSpritesheet;

        private Texture2D idleFireMarioSpritesheet;
        private Texture2D runningFireMarioSpritesheet;
        private Texture2D jumpingFireMarioSpritesheet;
        private Texture2D crouchingFireMarioSpritesheet;

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



        }

        //methods for creating sprites below*************************************************
        //one example is below

        //public Sprites.ISprite CreateSmallMarioRunningSprite()
        //{
        //return new SmallMarioRunningSprite(smallMarioRunningSpritesheet, Game1.Instance.level.isAboveGround);
        //}

        public Sprites.ISprite CreateLeftIdleSmallMarioSprite()
        {
            return new Sprites.MarioSpite.SmallMarioSprite.LeftIdleSmallMarioSprit(idleSmallMarioSpritesheet);
        }

        public Sprites.ISprite CreateRightIdleSmallMarioSprite()
        {
            return new Sprites.MarioSpite.SmallMarioSprite.RightIdleSmallMarioSprit(idleSmallMarioSpritesheet);
        }
        public Sprites.ISprite CreateLeftRunningSmallMarioSprite()
        {
            return new Sprites.MarioSpite.SmallMarioSprite.LeftRunningSmallMarioSprite (runningSmallMarioSpritesheet);
        }

        public Sprites.ISprite CreateRightRunningSmallMarioSprite()
        {
            return new Sprites.MarioSpite.SmallMarioSprite.RightRunningSmallMarioSprite(runningSmallMarioSpritesheet);
        }
    }
}
