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

        private SpriteBatch sb { set; get; }
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

        public void LoadAllTextures(ContentManager content,SpriteBatch sb)
        {
            //load sprite sheets here**************************************
            //one example is below
            this.sb = sb;
            //smallMarioRunningSpriteSheet = content.Load<Texture2D>("smallMarioRunning");
            idleSmallMarioSpritesheet = content.Load<Texture2D>("Mario/Smario/SmarioStand");
            runningSmallMarioSpritesheet = content.Load<Texture2D>("Mario/Smario/SmarioRun");
            jumpingSmallMarioSpritesheet = content.Load<Texture2D>("Mario/Smario/SmarioJump");
            deadSmallMarioSpritesheet = content.Load<Texture2D>("Mario/Smario/SmarioDead");

            idleBigMarioSpritesheet = content.Load<Texture2D>("Mario/Bmario/BmarioStand");
            runningBigMarioSpritesheet = content.Load<Texture2D>("Mario/Bmario/BmarioRun");
            jumpingBigMarioSpritesheet = content.Load<Texture2D>("Mario/Bmario/BmarioJump");
            crouchingBigMarioSpritesheet = content.Load<Texture2D>("Mario/Bmario/BmarioStand");

            idleFireMarioSpritesheet = content.Load<Texture2D>("Mario/Fmario/FmarioStand");
            runningFireMarioSpritesheet = content.Load<Texture2D>("Mario/Fmario/FmarioRun");
            jumpingFireMarioSpritesheet = content.Load<Texture2D>("Mario/Fmario/FmarioJump");
            crouchingFireMarioSpritesheet = content.Load<Texture2D>("Mario/Fmario/FmarioStand");
        }

        //methods for creating sprites below*************************************************

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
            return new Sprites.MarioSprite.SmallMarioSprite.DeadSmallMarioSprite(deadSmallMarioSpritesheet, sb);
        }
        public Sprites.ISprite CreateLeftIdleBigMarioSprite()
        {
            return new Sprites.MarioSprite.BigMarioSprite.LeftIdleBigMarioSprite(idleBigMarioSpritesheet, sb);
        }

        public Sprites.ISprite CreateRightIdleBigMarioSprite()
        {
            return new Sprites.MarioSprite.BigMarioSprite.RightIdleBigMarioSprite(idleBigMarioSpritesheet, sb);
        }
        public Sprites.ISprite CreateLeftRunningBigMarioSprite()
        {
            return new Sprites.MarioSprite.BigMarioSprite.LeftRunningBigMarioSprite(runningBigMarioSpritesheet, sb);
        }

        public Sprites.ISprite CreateRightRunningBigMarioSprite()
        {
            return new Sprites.MarioSprite.BigMarioSprite.RightRunningBigMarioSprite(runningBigMarioSpritesheet, sb);
        }

        public Sprites.ISprite CreateLeftJumpingBigMarioSprite()
        {
            return new Sprites.MarioSprite.BigMarioSprite.LeftJumpingBigMarioSprite(jumpingBigMarioSpritesheet, sb);
        }
        public Sprites.ISprite CreateRightJumpingBigMarioSprite()
        {
            return new Sprites.MarioSprite.BigMarioSprite.RightJumpingBigMarioSprite(jumpingBigMarioSpritesheet, sb);
        }

        public Sprites.ISprite CreateLeftCrouchingBigMarioSprite()
        {
            return new Sprites.MarioSprite.BigMarioSprite.LeftCrouchingBigMarioSprite(crouchingBigMarioSpritesheet, sb);
        }
        public Sprites.ISprite CreateRightCrouchingBigMarioSprite()
        {
            return new Sprites.MarioSprite.BigMarioSprite.RightCrouchingBigMarioSprite(crouchingBigMarioSpritesheet, sb);
        }

        public Sprites.ISprite CreateLeftIdleFireMarioSprite()
        {
            return new Sprites.MarioSprite.FireMarioSprite.LeftIdleFireMarioSprite(idleFireMarioSpritesheet, sb);
        }

        public Sprites.ISprite CreateRightIdleFireMarioSprite()
        {
            return new Sprites.MarioSprite.FireMarioSprite.RightIdleFireMarioSprite(idleFireMarioSpritesheet, sb);
        }
        public Sprites.ISprite CreateLeftRunningFireMarioSprite()
        {
            return new Sprites.MarioSprite.FireMarioSprite.LeftRunningFireMarioSprite(runningFireMarioSpritesheet, sb);
        }

        public Sprites.ISprite CreateRightRunningFireMarioSprite()
        {
            return new Sprites.MarioSprite.FireMarioSprite.RightRunningFireMarioSprite(runningFireMarioSpritesheet, sb);
        }

        public Sprites.ISprite CreateLeftJumpingFireMarioSprite()
        {
            return new Sprites.MarioSprite.FireMarioSprite.LeftJumpingFireMarioSprite(jumpingFireMarioSpritesheet, sb);
        }
        public Sprites.ISprite CreateRightJumpingFireMarioSprite()
        {
            return new Sprites.MarioSprite.FireMarioSprite.RightJumpingFireMarioSprite(jumpingFireMarioSpritesheet, sb);
        }

        public Sprites.ISprite CreateLeftCrouchingFireMarioSprite()
        {
            return new Sprites.MarioSprite.FireMarioSprite.LeftCrouchingFireMarioSprite(crouchingFireMarioSpritesheet, sb);
        }
        public Sprites.ISprite CreateRightCrouchingFireMarioSprite()
        {
            return new Sprites.MarioSprite.FireMarioSprite.RightCrouchingFireMarioSprite(crouchingFireMarioSpritesheet, sb);
        }

    }
}
