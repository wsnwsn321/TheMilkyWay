using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{

    public interface ISprite
    {
        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 location);

        int SpriteID();
    }

    public class StandingInPlaceTidusSprite : ISprite
    {
        public Texture2D spriteTexture { get; set; }
        public StandingInPlaceTidusSprite(Texture2D texture)
        {
            spriteTexture = texture;
        }

        public int SpriteID()
        {
            return 0;
        }
        public void Update()
        {

        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle();
            Rectangle destinationRectangle = new Rectangle();
            int width, height;
            width = 47;
            height = 73;
            sourceRectangle = new Rectangle(22, 11, width, height);
            destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 40, 70);

            spriteBatch.Begin();
            spriteBatch.Draw(spriteTexture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }

    public class FixedAnimatedTidusSprite : ISprite
    {
        private int currentFrame;
        private int totalFrame;

        private int counter;

        public Texture2D spriteTexture { get; set; }
        public FixedAnimatedTidusSprite(Texture2D texture)
        {
            currentFrame = 0;
            totalFrame = 4;
            spriteTexture = texture;
        }

        public int SpriteID()
        {
            return 1;
        }

        public void Update()
        {
            if (counter % 10 == 0)
            {
                currentFrame++;
            }
            counter++;

            if (counter > 99)
            {
                counter = 0;
            }
            if (currentFrame >= totalFrame)
            {
                currentFrame = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle();
            Rectangle destinationRectangle = new Rectangle();
            int width, height;

            if (currentFrame == 0)
            {
                width = 47;
                height = 73;
                sourceRectangle = new Rectangle(22, 11, width, height);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 40, 70);
            }
            else if (currentFrame == 1)
            {
                width = 47;
                height = 69;
                sourceRectangle = new Rectangle(119, 15, width, height);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 40, 70);
            }
            else if (currentFrame == 2)
            {
                width = 47;
                height = 73;
                sourceRectangle = new Rectangle(22, 11, width, height);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 40, 70);
            }
            else if (currentFrame == 3)
            {
                width = 44;
                height = 69;
                sourceRectangle = new Rectangle(27, 205, width, height);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 40, 70);
            }


            spriteBatch.Begin();
            spriteBatch.Draw(spriteTexture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }

    public class MovingAnimatedTidusSprite : ISprite
    {
        private int currentFrame;
        private int totalFrame;

        int counter = 0;

        public Texture2D spriteTexture { get; set; }
        public MovingAnimatedTidusSprite(Texture2D texture)
        {
            currentFrame = 0;
            totalFrame = 4;
            spriteTexture = texture;
        }

        public int SpriteID()
        {
            return 2;
        }

        public void Update()
        {
            if (counter % 10 == 0)
            {
                currentFrame++;
            }
            counter++;

            if ( counter > 99)
            {
                counter = 0;
            }
            if (currentFrame >= totalFrame)
            {
                currentFrame = 0;
            }

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle();
            Rectangle destinationRectangle = new Rectangle();
            int width, height;

            if (currentFrame == 0)
            {
                width = 47;
                height = 73;
                sourceRectangle = new Rectangle(22, 11, width, height);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 40, 70);
            }
            else if (currentFrame == 1)
            {
                width = 47;
                height = 69;
                sourceRectangle = new Rectangle(119, 15, width, height);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 40, 70);
            }
            else if (currentFrame == 2)
            {
                width = 47;
                height = 73;
                sourceRectangle = new Rectangle(22, 11, width, height);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 40, 70);
            } else if (currentFrame == 3) 
            {
                width = 44;
                height = 69;
                sourceRectangle = new Rectangle(27, 205, width, height);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 40, 70);
            }

            
            spriteBatch.Begin();
            spriteBatch.Draw(spriteTexture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }

    public class DeadTidusSprite : ISprite
    {
        public Texture2D spriteTexture { get; set; }
        public DeadTidusSprite(Texture2D texture)
        {
            spriteTexture = texture;
        }

        public int SpriteID()
        {
            return 3;
        }

        public void Update()
        {

        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle();
            Rectangle destinationRectangle = new Rectangle();
            int width, height;
            width = 49;
            height = 71;
            sourceRectangle = new Rectangle(407, 12, width, height);
            destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 40, 70);

            spriteBatch.Begin();
            spriteBatch.Draw(spriteTexture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }

}

