using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint6.Sprites.UFOSprite;

namespace Sprint6.SpriteFactories
{
    class EnvironmentSpriteFactory
    {
        private Texture2D farmPackSpritesheet;


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

            this.sb = sb;

        }

        //create environment sprites
        public ISprite CreateSiloSprite()
        {
            return new SiloSprite(farmPackSpritesheet, sb, 0);
        }
    }
}
