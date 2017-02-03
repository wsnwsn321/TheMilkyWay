using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.SpriteFactories
{
    class EnvironmentSpriteFactory
    {
        private Texture2D brickBlockSpritesheet;
        private Texture2D questionBlockSpritesheet;
        private Texture2D usedBlockSpritesheet;
        private Texture2D groundBlockSpritesheet;
        private Texture2D pipeSpritesheet;
        // More private Texture2Ds follow
        // ...

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

        public void LoadAllTextures(ContentManager content)
        {
            //load sprite sheets here**************************************
            //one example is below

            pipeSpritesheet = content.Load<Texture2D>("Item/Pipe");
            usedBlockSpritesheet = content.Load<Texture2D>("Item/UsedBlock");
            brickBlockSpritesheet = content.Load<Texture2D>("Item/BrickBlock");
            questionBlockSpritesheet = content.Load<Texture2D>("Item/QuestionBlock");
            groundBlockSpritesheet = content.Load<Texture2D>("Item/GroundBlock");


        }

        //methods for creating sprites below*************************************************
        //one example is below

        public Sprites.ISprite CreatePipeSprite()
        {
            return new Sprites.PipeSprite(pipeSpritesheet);
        }

        public Sprites.ISprite CreateUsedBlockSprite()
        {
            return new Sprites.UsedBlockSprite(usedBlockSpritesheet);
        }

        public Sprites.ISprite CreateBrickBlockSprite()
        {
            return new Sprites.BrickBlockSprite(brickBlockSpritesheet);
        }

        public Sprites.ISprite CreateQuestionBlockSprite()
        {
            return new Sprites.QuestionBlockSprite(questionBlockSpritesheet);
        }

        public Sprites.ISprite CreateGroundBlockSprite()
        {
            return new Sprites.GroundBlockSprite(groundBlockSpritesheet);
        }

        public Sprites.ISprite CreateHiddenBlockSprite()
        {
            return new Sprites.HiddenBlockSprite(pipeSpritesheet);
        }
    }
}
