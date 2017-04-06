using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioGame.SpriteFactories
{
    class EnvironmentSpriteFactory
    {
        private Texture2D brickBlockSpritesheet;
        private Texture2D backgroundSpritesheet;
        private Texture2D questionBlockSpritesheet;
        private Texture2D usedBlockSpritesheet;
        private Texture2D groundBlockSpritesheet;
        private Texture2D pipeSpritesheet;
        private Texture2D stageBlockSpritesheet;
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

            pipeSpritesheet = content.Load<Texture2D>("Item/Pipe");
            backgroundSpritesheet = content.Load<Texture2D>("Background/BackgroundEnvironment");
            usedBlockSpritesheet = content.Load<Texture2D>("Item/QuestionBlock");
            brickBlockSpritesheet = content.Load<Texture2D>("Item/BrickBlock");
            questionBlockSpritesheet = content.Load<Texture2D>("Item/QuestionBlock");
            groundBlockSpritesheet = content.Load<Texture2D>("Item/GroundBlock");
            stageBlockSpritesheet = content.Load<Texture2D>("Item/UsedBlock");
         
            this.sb = sb;

        }

        //create environment sprites
        public Sprites.ISprite CreatePipeSprite(int size)
        {
            if (size == GameConstants.UnderPipe)
            {
                return new Sprites.PipeSprite(backgroundSpritesheet, sb);
            }
            else
            {
                return new Sprites.PipeSprite(pipeSpritesheet, sb, size);
            }
        }

        public Sprites.ISprite CreateUsedBlockSprite()
        {
            return new Sprites.UsedBlockSprite(usedBlockSpritesheet,sb);
        }

        public Sprites.ISprite CreateBrickBlockSprite()
        {
            return new Sprites.BrickBlockSprite(brickBlockSpritesheet,sb);
        }

        public Sprites.ISprite CreateBlueBrickBlockSprite()
        {
            return new Sprites.BlueBrickBlockSprite(brickBlockSpritesheet, sb);
        }

        public Sprites.ISprite CreateQuestionBlockSprite()
        {
            return new Sprites.QuestionBlockSprite(questionBlockSpritesheet,sb);
        }

        public Sprites.ISprite CreateGroundBlockSprite()
        {
            return new Sprites.GroundBlockSprite(groundBlockSpritesheet,sb);
        }

        public Sprites.ISprite CreateBlueGroundBlockSprite()
        {
            return new Sprites.BlueGroundBlockSprite(groundBlockSpritesheet, sb);
        }

        public Sprites.ISprite CreateHiddenBlockSprite()
        {
            return new Sprites.HiddenBlockSprite(pipeSpritesheet,sb);
        }
        public Sprites.ISprite CreateStageBlockSprite()
        {
            return new Sprites.StageBlockSprite(stageBlockSpritesheet, sb);
        }


      

    }
}
