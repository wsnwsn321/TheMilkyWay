using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMarioGame.Sprites
{
    class FlowerSprite: SpriteFactories.ISprite

    {
            public Texture2D Texture { get; set; }
            Vector2 p;

            public FlowerSprite(Texture2D texture)
            {
                Texture = texture;
               // SpriteFactories.ISprite newS = SpriteFactories.ItemSpriteFactory.Instance.CreateFlowerSprite();
            }
            public void Update()
            {

            }

            public Vector2 returnPosition()
            {
                return p;
            }

            public void Draw(SpriteBatch spriteBatch, Vector2 position)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(Texture, new Rectangle((int)position.X, (int)position.Y, 16, 16), Color.White);
                p = position;
                spriteBatch.End();
            }
        }
    }


