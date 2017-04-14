using System.Diagnostics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint6.Sprites.UFOSprite;

namespace Sprint6.SpriteFactories
{
    class UFOSpriteFactory
    {
        private Texture2D flyingUFOSpritesheet;
        private static UFOFlyingSprite ufo;
        private static UFOJumpingSprite  ufo2;
        private static bool first = true;

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
            flyingUFOSpritesheet = content.Load<Texture2D>("MainCharacter/UFO/ufo");
            this.sb = sb;
        }


        //create mainCharacter sprites
        public ISprite CreateFlyingUFOSprite()
        {
            if (first)
            {

                ufo = new UFOFlyingSprite(flyingUFOSpritesheet, sb, 0);
            }
            else
            {
                ufo = new UFOFlyingSprite(flyingUFOSpritesheet, sb, ufo2.currentFrame++);
            }
            return ufo;
        }
        public ISprite CreateJumpingUFOSprite()
        {
            ufo2 = new UFOJumpingSprite(flyingUFOSpritesheet, sb, ufo.currentFrame++);
            first = false;
            return ufo2;
        }
        public ISprite CreateDeadUFOSprite()
        {
            return new Sprites.UFOSprite.UFOFlyingSprite(flyingUFOSpritesheet, sb, 0);
        }
    }
}
