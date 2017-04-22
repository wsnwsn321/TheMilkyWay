using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using TheMilkyWay.Sprites.UFOSprite;
using TheMilkyWay.Sprites;

namespace TheMilkyWay.SpriteFactories
{
    class BackgroundSpriteFactory
    {
        private Texture2D starryNightSpritesheet;
        private Texture2D milkyWaySpritesheet;

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
            milkyWaySpritesheet = content.Load<Texture2D>("UFOGameObjects/TheMilkyWay");
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
        public ISprite CreateMilkyWaySprite()
        {
            return new MilkyWaySprite(milkyWaySpritesheet, sb);
        }
    }
}
