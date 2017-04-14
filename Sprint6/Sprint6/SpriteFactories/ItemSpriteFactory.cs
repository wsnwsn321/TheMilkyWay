using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint6.Sprites.UFOSprite;

namespace Sprint6.SpriteFactories
{
    class ItemSpriteFactory
    {

        private Texture2D mushroomSpritesheet;
        private Texture2D coinSpritesheet;
        private Texture2D flowerSpritesheet;
        private Texture2D starSpritesheet;
        private Texture2D fireballSpritesheet;
        private Texture2D blockPieceSpritesheet;
        private Texture2D fireballExplosionSpritesheet;

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
            fireballSpritesheet = content.Load<Texture2D>("MainCharacter/Fmario/FmarioFireball");
            blockPieceSpritesheet = content.Load<Texture2D>("Item/BlockPiece");
            fireballExplosionSpritesheet= content.Load<Texture2D>("MainCharacter/Fmario/FireBallHitTheWall");
            this.sb = sb;
        }

        //create item sprites
       


    }
}
