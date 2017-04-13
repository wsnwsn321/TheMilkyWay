using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint6.SpriteFactories
{
    class UFOSpriteFactory
    {
        private Texture2D flyingUFOSpritesheet;

        private SpriteBatch sb { set; get; }
        private static UFOSpriteFactory instance = new UFOSpriteFactory();

        public static UFOSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private UFOSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content,SpriteBatch sb)
        {
            flyingUFOSpritesheet = content.Load<Texture2D>("MainCharacter/UFO");
            this.sb = sb;
        }


        //create mainCharacter sprites
        public Sprites.ISprite CreateFlyingUFOSprite()
        {
            return new Sprites.UFOSprite.UFOFlyingSprite(flyingUFOSpritesheet, sb);
        }
        public Sprites.ISprite CreateDeadUFOSprite()
        {
            return new Sprites.UFOSprite.UFOFlyingSprite(flyingUFOSpritesheet, sb);
        }
    }
}
