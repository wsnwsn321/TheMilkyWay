﻿using Microsoft.Xna.Framework;
using SuperMarioGame.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.ElementClasses.EnvironmentClass
{
    public class QuestionBlock : ElementInterfaces.IBlock

    {
        public ISprite blockSprite { get; set; }
        public Vector2 position { get; set; }

        public QuestionBlock(Vector2 pos)
        {
            position = pos;
            blockSprite = SpriteFactories.EnvironmentSpriteFactory.Instance.CreateQuestionBlockSprite();
        }

        public void Draw()
        {
            blockSprite.Draw(position);
        }

        public void Update()
        {
            blockSprite.Update();
        }
    }
}
