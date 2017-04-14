using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint6.SpriteFactories
{
    class EnvironmentSpriteFactory
    {
        private Texture2D brickBlockSpritesheet;
        private Texture2D questionBlockSpritesheet;
        private Texture2D usedBlockSpritesheet;
        private Texture2D groundBlockSpritesheet;
        private Texture2D pipeSpritesheet;
        private Texture2D underPipeSpritesheet;
        private Texture2D stageBlockSpritesheet;
        private Texture2D blueGroundBlockSpritesheet;
        private Texture2D blueBrickBlockSpritesheet;

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

            underPipeSpritesheet = content.Load<Texture2D>("Item/undergroundPipe");
            pipeSpritesheet = content.Load<Texture2D>("Item/Pipe");
            usedBlockSpritesheet = content.Load<Texture2D>("Item/QuestionBlock");
            brickBlockSpritesheet = content.Load<Texture2D>("Item/BrickBlock");
            questionBlockSpritesheet = content.Load<Texture2D>("Item/QuestionBlock");
            groundBlockSpritesheet = content.Load<Texture2D>("Item/GroundBlock");
            stageBlockSpritesheet = content.Load<Texture2D>("Item/UsedBlock");
            blueGroundBlockSpritesheet = content.Load<Texture2D>("Item/BlueGroundBlock");
            blueBrickBlockSpritesheet= content.Load<Texture2D>("Item/BlueBrickBlock");

            this.sb = sb;

        }

        //create environment sprites
    
    }
}
