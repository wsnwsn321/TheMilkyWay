using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint6.SpriteFactories
{
    class BackgroundSpriteFactory
    {
        private Texture2D backgroundSpritesheet;
        private Texture2D flagpole;
        private Texture2D flag;

        public SpriteBatch sb { get; set; }
        private static BackgroundSpriteFactory instance = new BackgroundSpriteFactory();

        public static BackgroundSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private BackgroundSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content, SpriteBatch sb)
        {
            backgroundSpritesheet = content.Load < Texture2D >("Background/BackgroundEnvironment");
            flagpole = content.Load<Texture2D>("Background/Flagpole");
            flag = content.Load<Texture2D>("Background/Flag");

            this.sb = sb;
        }

        //create environment sprites
        public Sprites.ISprite CreateSmallBrushSprite()
        {
            return new Sprites.SmallBrushSprite(backgroundSpritesheet, sb);
        }

        public Sprites.ISprite CreateBigBrushSprite()
        {
            return new Sprites.BigBrushSprite(backgroundSpritesheet, sb);
        }

        public Sprites.ISprite CreateSmallMountainSprite()
        {
            return new Sprites.SmallMountainSprite(backgroundSpritesheet, sb);
        }

        public Sprites.ISprite CreateBigMountainSprite()
        {
            return new Sprites.BigMountainSprite(backgroundSpritesheet, sb);
        }

        public Sprites.ISprite CreateSmallCloudSprite()
        {
            return new Sprites.SmallCloudSprite(backgroundSpritesheet, sb);
        }
        public Sprites.ISprite CreateBigCloudSprite()
        {
            return new Sprites.BigCloudSprite(backgroundSpritesheet, sb);
        }

        public Sprites.ISprite CreateCastleSprite()
        {
            return new Sprites.CastleSprite(backgroundSpritesheet, sb);
        }
        public Sprites.ISprite CreateFlagpoleSprite()
        {
            return new Sprites.FlagpoleSprite(flagpole, sb);
        }

        public Sprites.ISprite CreateFlagSprite()
        {
            return new Sprites.FlagSprite(flag, sb);
        }
    }
}
