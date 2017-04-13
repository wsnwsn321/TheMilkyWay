using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint6.SpriteFactories
{
    class MarioSpriteFactory
    {
        private Texture2D idleSmallMarioSpritesheet;
        private Texture2D runningSmallMarioSpritesheet;
        private Texture2D jumpingSmallMarioSpritesheet;
        private Texture2D deadSmallMarioSpritesheet;
        private Texture2D flagSmallMarioSpritesheet;

        private Texture2D idleBigMarioSpritesheet;
        private Texture2D runningBigMarioSpritesheet;
        private Texture2D jumpingBigMarioSpritesheet;
        private Texture2D crouchingBigMarioSpritesheet;
        private Texture2D flagBigMarioSpritesheet;


        private Texture2D idleFireMarioSpritesheet;
        private Texture2D runningFireMarioSpritesheet;
        private Texture2D jumpingFireMarioSpritesheet;
        private Texture2D crouchingFireMarioSpritesheet;
        private Texture2D attackingFireMarioSpritesheet;
        private Texture2D flagFireMarioSpritesheet;

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
            this.sb = sb;
            idleSmallMarioSpritesheet = content.Load<Texture2D>("Mario/Smario/SmarioStand");
            runningSmallMarioSpritesheet = content.Load<Texture2D>("Mario/Smario/SmarioRun");
            jumpingSmallMarioSpritesheet = content.Load<Texture2D>("Mario/Smario/SmarioJump");
            deadSmallMarioSpritesheet = content.Load<Texture2D>("Mario/Smario/SmarioDead");
            flagSmallMarioSpritesheet = content.Load<Texture2D>("Mario/Smario/SmarioFlag");

            idleBigMarioSpritesheet = content.Load<Texture2D>("Mario/Bmario/BmarioStand");
            runningBigMarioSpritesheet = content.Load<Texture2D>("Mario/Bmario/BmarioRun");
            jumpingBigMarioSpritesheet = content.Load<Texture2D>("Mario/Bmario/BmarioJump");
            crouchingBigMarioSpritesheet = content.Load<Texture2D>("Mario/Bmario/BmarioStand");
            flagBigMarioSpritesheet = content.Load<Texture2D>("Mario/Bmario/BmarioFlag");

            idleFireMarioSpritesheet = content.Load<Texture2D>("Mario/Fmario/FmarioStand");
            runningFireMarioSpritesheet = content.Load<Texture2D>("Mario/Fmario/FmarioRun");
            jumpingFireMarioSpritesheet = content.Load<Texture2D>("Mario/Fmario/FmarioJump");
            crouchingFireMarioSpritesheet = content.Load<Texture2D>("Mario/Fmario/FmarioStand");
            attackingFireMarioSpritesheet = content.Load<Texture2D>("Mario/Fmario/FireAttack");
            flagFireMarioSpritesheet = content.Load<Texture2D>("Mario/Fmario/FmarioFlag");
        }


        //create mario sprites
        public Sprites.IMarioSprite CreateLeftIdleSmallMarioSprite()
        {
            return new Sprites.MarioSprite.SmallMarioSprite.LeftIdleSmallMarioSprite(idleSmallMarioSpritesheet, sb);
        }

        public Sprites.IMarioSprite CreateRightIdleSmallMarioSprite()
        {
            return new Sprites.MarioSprite.SmallMarioSprite.RightIdleSmallMarioSprite(idleSmallMarioSpritesheet, sb);
        }
        public Sprites.IMarioSprite CreateLeftRunningSmallMarioSprite()
        {
            return new Sprites.MarioSprite.SmallMarioSprite.LeftRunningSmallMarioSprite(runningSmallMarioSpritesheet, sb);
        }

        public Sprites.IMarioSprite CreateRightRunningSmallMarioSprite()
        {
            return new Sprites.MarioSprite.SmallMarioSprite.RightRunningSmallMarioSprite(runningSmallMarioSpritesheet, sb);
        }

        public Sprites.IMarioSprite CreateLeftJumpingSmallMarioSprite()
        {
            return new Sprites.MarioSprite.SmallMarioSprite.LeftJumpingSmallMarioSprite(jumpingSmallMarioSpritesheet, sb);
        }
        public Sprites.IMarioSprite CreateRightJumpingSmallMarioSprite()
        {
            return new Sprites.MarioSprite.SmallMarioSprite.RightJumpingSmallMarioSprite(jumpingSmallMarioSpritesheet, sb);
        }
        public Sprites.IMarioSprite CreateDeadSmallMarioSprite()
        {
            return new Sprites.MarioSprite.SmallMarioSprite.DeadSmallMarioSprite(deadSmallMarioSpritesheet, sb);
        }

        public Sprites.IMarioSprite CreateLeftFlagSmallMarioSprite()
        {
            return new Sprites.MarioSprite.SmallMarioSprite.LeftFlagSmallMarioSprite(flagSmallMarioSpritesheet, sb);
        }
        public Sprites.IMarioSprite CreateRightFlagSmallMarioSprite()
        {
            return new Sprites.MarioSprite.SmallMarioSprite.RightFlagSmallMarioSprite(flagSmallMarioSpritesheet, sb);
        }
        public Sprites.IMarioSprite CreateLeftIdleBigMarioSprite()
        {
            return new Sprites.MarioSprite.BigMarioSprite.LeftIdleBigMarioSprite(idleBigMarioSpritesheet, sb);
        }

        public Sprites.IMarioSprite CreateRightIdleBigMarioSprite()
        {
            return new Sprites.MarioSprite.BigMarioSprite.RightIdleBigMarioSprite(idleBigMarioSpritesheet, sb);
        }
        public Sprites.IMarioSprite CreateLeftRunningBigMarioSprite()
        {
            return new Sprites.MarioSprite.BigMarioSprite.LeftRunningBigMarioSprite(runningBigMarioSpritesheet, sb);
        }

        public Sprites.IMarioSprite CreateRightRunningBigMarioSprite()
        {
            return new Sprites.MarioSprite.BigMarioSprite.RightRunningBigMarioSprite(runningBigMarioSpritesheet, sb);
        }

        public Sprites.IMarioSprite CreateLeftJumpingBigMarioSprite()
        {
            return new Sprites.MarioSprite.BigMarioSprite.LeftJumpingBigMarioSprite(jumpingBigMarioSpritesheet, sb);
        }
        public Sprites.IMarioSprite CreateRightJumpingBigMarioSprite()
        {
            return new Sprites.MarioSprite.BigMarioSprite.RightJumpingBigMarioSprite(jumpingBigMarioSpritesheet, sb);
        }

        public Sprites.IMarioSprite CreateLeftCrouchingBigMarioSprite()
        {
            return new Sprites.MarioSprite.BigMarioSprite.LeftCrouchingBigMarioSprite(crouchingBigMarioSpritesheet, sb);
        }
        public Sprites.IMarioSprite CreateRightCrouchingBigMarioSprite()
        {
            return new Sprites.MarioSprite.BigMarioSprite.RightCrouchingBigMarioSprite(crouchingBigMarioSpritesheet, sb);
        }
        public Sprites.IMarioSprite CreateLeftFlagBigMarioSprite()
        {
            return new Sprites.MarioSprite.BigMarioSprite.LeftFlagBigMarioSprite(flagBigMarioSpritesheet, sb);
        }
        public Sprites.IMarioSprite CreateRightFlagBigMarioSprite()
        {
            return new Sprites.MarioSprite.BigMarioSprite.RightFlagBigMarioSprite(flagBigMarioSpritesheet, sb);
        }

        public Sprites.IMarioSprite CreateLeftIdleFireMarioSprite()
        {
            return new Sprites.MarioSprite.FireMarioSprite.LeftIdleFireMarioSprite(idleFireMarioSpritesheet, sb);
        }

        public Sprites.IMarioSprite CreateRightIdleFireMarioSprite()
        {
            return new Sprites.MarioSprite.FireMarioSprite.RightIdleFireMarioSprite(idleFireMarioSpritesheet, sb);
        }
        public Sprites.IMarioSprite CreateLeftRunningFireMarioSprite()
        {
            return new Sprites.MarioSprite.FireMarioSprite.LeftRunningFireMarioSprite(runningFireMarioSpritesheet, sb);
        }

        public Sprites.IMarioSprite CreateRightRunningFireMarioSprite()
        {
            return new Sprites.MarioSprite.FireMarioSprite.RightRunningFireMarioSprite(runningFireMarioSpritesheet, sb);
        }

        public Sprites.IMarioSprite CreateLeftJumpingFireMarioSprite()
        {
            return new Sprites.MarioSprite.FireMarioSprite.LeftJumpingFireMarioSprite(jumpingFireMarioSpritesheet, sb);
        }
        public Sprites.IMarioSprite CreateRightJumpingFireMarioSprite()
        {
            return new Sprites.MarioSprite.FireMarioSprite.RightJumpingFireMarioSprite(jumpingFireMarioSpritesheet, sb);
        }

        public Sprites.IMarioSprite CreateLeftCrouchingFireMarioSprite()
        {
            return new Sprites.MarioSprite.FireMarioSprite.LeftCrouchingFireMarioSprite(crouchingFireMarioSpritesheet, sb);
        }
        public Sprites.IMarioSprite CreateRightCrouchingFireMarioSprite()
        {
            return new Sprites.MarioSprite.FireMarioSprite.RightCrouchingFireMarioSprite(crouchingFireMarioSpritesheet, sb);
        }

        public Sprites.IMarioSprite CreateRightAttackingFireMarioSprite()
        {
            return new Sprites.MarioSprite.FireMarioSprite.RightAttackingMarioSprite(attackingFireMarioSpritesheet, sb);
        }
        public Sprites.IMarioSprite CreateLeftAttackingFireMarioSprite()
        {
            return new Sprites.MarioSprite.FireMarioSprite.LeftAttackingMarioSprite(attackingFireMarioSpritesheet, sb);
        }
        public Sprites.IMarioSprite CreateLeftFlagFireMarioSprite()
        {
            return new Sprites.MarioSprite.FireMarioSprite.LeftFlagFireMarioSprite(flagFireMarioSpritesheet, sb);
        }
        public Sprites.IMarioSprite CreateRightFlagFireMarioSprite()
        {
            return new Sprites.MarioSprite.FireMarioSprite.RightFlagFireMarioSprite(flagFireMarioSpritesheet, sb);
        }
    }
}
