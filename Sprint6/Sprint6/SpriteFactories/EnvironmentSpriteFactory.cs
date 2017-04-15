using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint6.Sprites;
using Sprint6.Sprites.EnvironmentSprite;
using Sprint6.Sprites.UFOSprite;

namespace Sprint6.SpriteFactories
{
    class EnvironmentSpriteFactory
    {
        private Texture2D farmPackSpritesheet;
        private Texture2D grassSpritesheet;



        public SpriteBatch sb { get; set; }
        private static EnvironmentSpriteFactory instance = new EnvironmentSpriteFactory();

        public static EnvironmentSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private EnvironmentSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content, SpriteBatch sb)
        {
            //load sprite sheets here**************************************
            //one example is below

            farmPackSpritesheet = content.Load<Texture2D>("UFOGameObjects/FarmPack");
            grassSpritesheet = content.Load<Texture2D>("UFOGameObjects/ground");

            this.sb = sb;

        }

        //create environment sprites
        public ISprite CreateSiloSprite()
        {
            return new SiloSprite(farmPackSpritesheet, sb, 0);
        }
        public ISprite CreateBarnSprite()
        {
            return new BarnSprite(farmPackSpritesheet, sb, 0);
        }
        
        public ISprite CreateGrassSprite()
        {
            return new GrassSprite(grassSpritesheet, sb, 0);
        }
    }
}
