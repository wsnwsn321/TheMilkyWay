using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioGame.SpriteFactories
{
    class BackgroundSpriteFactory
    {
        private Texture2D backgroundSpritesheet;
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

    }
}
