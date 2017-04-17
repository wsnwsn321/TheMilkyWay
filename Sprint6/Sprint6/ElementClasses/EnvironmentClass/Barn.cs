﻿using Microsoft.Xna.Framework;
using Sprint6.ElementClasses.ElementInterfaces;
using Sprint6.Sprites.UFOSprite;
using Sprint6.Sprites;

namespace Sprint6.ElementClasses

{
    public class Barn : ElementInterfaces.IBlock

    {
        public ISprite blockSprite { get; set; }
        public Vector2 position { get; set; }
        public bool isVisible { get; set; }
        public Barn(Vector2 pos)
        {
            position = pos;
            blockSprite = SpriteFactories.EnvironmentSpriteFactory.Instance.CreateBarnSprite();
            isVisible = true;
        }

        public void Draw()
        {
            if (isVisible)
            {

                blockSprite.Draw(position);
            }

        }

        public void Update()
        {
            if (isVisible)
            {

            }

            blockSprite.Update();
        }
    }
}