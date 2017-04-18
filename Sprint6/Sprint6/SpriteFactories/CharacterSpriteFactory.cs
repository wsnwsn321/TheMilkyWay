using System.Diagnostics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint6.Sprites.UFOSprite;
using Sprint6.Sprites;

namespace Sprint6.SpriteFactories
{
    class CharacterSpriteFactory
    {
        private Texture2D flyingUFOSpritesheet, cowSpritesheet,beamSpritesheeet, bombSpritesheet;
        private static UFOFlyingSprite ufo;
        private static UFOJumpingSprite  ufo2;
        private static bool first = true;

        private SpriteBatch sb { set; get; }
        private static CharacterSpriteFactory instance = new CharacterSpriteFactory();

        public static CharacterSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private CharacterSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content,SpriteBatch sb)
        {
            flyingUFOSpritesheet = content.Load<Texture2D>("MainCharacter/UFO/ufo");
            cowSpritesheet = content.Load<Texture2D>("UFOGameObjects/Cowsheet");
            beamSpritesheeet = content.Load<Texture2D>("UFOGameObjects/UFOBeam");
            bombSpritesheet = content.Load<Texture2D>("UFOGameObjects/bomb");

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
            return new UFOFlyingSprite(flyingUFOSpritesheet, sb, 0);
        }

        public ISprite CreateLivingCowSprite()
        {
            return new CowSprite(cowSpritesheet, sb, 0);
        }

        public ISprite CreateCowHeadSprite()
        {
            return new CowHeadSprite(cowSpritesheet, sb, 0);
        }
        public ISprite CreateBeamSprite()
        {
            return new BeamSprite(beamSpritesheeet, sb, 0);
        }
        public ISprite CreateBombSprite()
        {
            return new BombSprite(bombSpritesheet, sb, 0);
        }

    }
}
