using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint6.Sprites;
using Sprint6.Sprites.UFOSprite;

namespace Sprint6.SpriteFactories
{
    class BackgroundSpriteFactory
    {
        private Texture2D starryNightSpritesheet;


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
            //load sprite sheets here**************************************
            //one example is below

            starryNightSpritesheet = content.Load<Texture2D>("UFOGameObjects/StarryNight");

            this.sb = sb;

        }

        //create environment sprites
        public ISprite CreateStarryNightSprite()
        {
            return new StarryNightSprite(starryNightSpritesheet, sb);
        }

        //create environment sprites
        public ISprite CreateDarkerNightSprite()
        {
            return new DarkerNightSprite(starryNightSpritesheet, sb);
        }

        public ISprite CreateDarkestNightSprite()
        {
            return new DarkestNightSprite(starryNightSpritesheet, sb);
        }
    }
}
