using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMarioGame.Sprites
{
    class KoopaSprite: ISprite

    {
            public Texture2D Texture { get; set; }
            Vector2 p;

            public KoopaSprite(Texture2D texture)
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
                Rectangle sourceRectangle = new Rectangle(75, 0, 17, 22);
                Rectangle desRectangle = new Rectangle((int)position.X, (int)position.Y, 34, 44);
                spriteBatch.Draw(Texture, desRectangle,sourceRectangle, Color.White);
                p = position;
                spriteBatch.End();
            }
        }
    }


