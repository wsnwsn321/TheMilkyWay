using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioGame.SpriteFactories
{
    class ItemSpriteFactory
    {

        private Texture2D mushroomSpritesheet;
        private Texture2D coinSpritesheet;
        private Texture2D flowerSpritesheet;
        private Texture2D starSpritesheet;
        private Texture2D fireballSpritesheet;

        public SpriteBatch sb { set; get; }
        private static ItemSpriteFactory instance = new ItemSpriteFactory();
        public static ItemSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private ItemSpriteFactory()
        {

        }

        public void LoadAllTextures(ContentManager content,SpriteBatch sb)
        {
            //load sprite sheets here**************************************
            //one example is below

            mushroomSpritesheet = content.Load<Texture2D>("Item/Mushroom");
            flowerSpritesheet = content.Load<Texture2D>("Item/Flower");
            starSpritesheet = content.Load<Texture2D>("Item/Star");
            coinSpritesheet = content.Load<Texture2D>("Item/Coin");
            fireballSpritesheet = content.Load<Texture2D>("Mario/Fmario/FmarioFireball");
            this.sb = sb;
        }

        //create item sprites
        public Sprites.ISprite CreateFlowerSprite()
        {
            return new Sprites.FlowerSprite(flowerSpritesheet, sb);
        }

        public Sprites.ISprite CreateStarSprite()
        {
            return new Sprites.StarSprite(starSpritesheet, sb);
        }

        public Sprites.ISprite CreateGreenMushroomSprite()
        {
            return new Sprites.GreenMushroomSprite(mushroomSpritesheet, sb);
        }

        public Sprites.ISprite CreateRedMushroomSprite()
        {
            return new Sprites.RedMushroomSprite(mushroomSpritesheet, sb);
        }

        public Sprites.ISprite CreateCoinSprite()
        {
            return new Sprites.CoinSprite(coinSpritesheet, sb);
        }

        public Sprites.ISprite CreateFireballSprite()
        {
            return new Sprites.FireballSprite(fireballSpritesheet, sb);
        }

    }
}
